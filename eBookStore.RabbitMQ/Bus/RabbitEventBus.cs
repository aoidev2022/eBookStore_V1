using eBookStore.RabbitMQ.Commands;
using eBookStore.RabbitMQ.Events;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.RabbitMQ.Bus
{
    public class RabbitEventBus : IRabbitEventBus
    {
        readonly IMediator _mediator;
        readonly Dictionary<string, List<Type>> _handlers;
        readonly List<Type> _eventTypes;
        readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitEventBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task SendComand<T>(T comand) where T : Command
        {
            return _mediator.Send(comand);
        }

        public void PublishEvent<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory { HostName = "ebookstore.rabbitmq" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var eventName = @event.GetType().Name;

            channel.QueueDeclare(eventName, false, false, false, null);

            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", eventName, null, body);
        }

        public void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if (_handlers[eventName].Any(q => q.GetType() == handlerType))
            {
                throw new ArgumentException($"The handler {handlerType.Name} is already registered by {eventName}");
            }

            _handlers[eventName].Add(handlerType);

            var factory = new ConnectionFactory { HostName = "ebookstore.rabbitmq", DispatchConsumersAsync = true };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(eventName, false, false, false, null);
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += ConsumerDelegate;

            channel.BasicConsume(eventName, true, consumer);
        }

        private async Task ConsumerDelegate(object sender, BasicDeliverEventArgs @event)
        {
            var eventName = @event.RoutingKey;
            var message = Encoding.UTF8.GetString(@event.Body.ToArray());

            try
            {
                if (_handlers.ContainsKey(eventName))
                {
                    using var scope = _serviceScopeFactory.CreateScope();
                    var subscriptions = _handlers[eventName];
                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetService(subscription);
                        if (handler == null) continue;

                        var evenType = _eventTypes.SingleOrDefault(q => q.Name == eventName);
                        if (evenType == null) continue;

                        var messageObj = JsonConvert.DeserializeObject(message, evenType);
                        var concretType = typeof(IEventHandler<>).MakeGenericType(evenType);

                        await (Task)concretType.GetMethod("Handle").Invoke(handler, new[] { messageObj });
                    }
                }
            }
            catch (Exception)
            {
                // todo log error
                throw;
            }
        }
    }
}

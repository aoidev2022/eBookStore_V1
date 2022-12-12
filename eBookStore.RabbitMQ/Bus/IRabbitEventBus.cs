using eBookStore.RabbitMQ.Commands;
using eBookStore.RabbitMQ.Events;

using System.Threading.Tasks;

namespace eBookStore.RabbitMQ.Bus
{
    public interface IRabbitEventBus
    {
        Task SendComand<T>(T comand) where T : Command;
        void PublishEvent<T>(T @event) where T : Event;
        void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>;
    }

    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}

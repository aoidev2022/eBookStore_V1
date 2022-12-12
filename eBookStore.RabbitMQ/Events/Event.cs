using MediatR;

using System;

namespace eBookStore.RabbitMQ.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; set; }
        protected Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }

    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}

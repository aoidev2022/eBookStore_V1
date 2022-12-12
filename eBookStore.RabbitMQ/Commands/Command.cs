using eBookStore.RabbitMQ.Events;

using System;

namespace eBookStore.RabbitMQ.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; set; }
        protected Command()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}

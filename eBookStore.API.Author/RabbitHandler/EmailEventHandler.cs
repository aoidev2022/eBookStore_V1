using eBookStore.RabbitMQ.Bus;
using eBookStore.RabbitMQ.Events.Queue;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System.Threading.Tasks;

namespace eBookStore.API.Author.RabbitHandler
{
    public class EmailEventHandler : IEventHandler<EmailEvent>
    {
        readonly ILogger<EmailEventHandler> _logger;

        public EmailEventHandler(ILogger<EmailEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(EmailEvent @event)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(@event));
            return Task.CompletedTask;
        }
    }
}

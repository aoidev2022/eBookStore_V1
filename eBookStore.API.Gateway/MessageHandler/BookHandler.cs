using eBookStore.API.Gateway.RemoteInterface.Author;
using eBookStore.API.Gateway.RemoteInterface.Book;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Gateway.MessageHandler
{
    public class BookHandler : DelegatingHandler
    {
        readonly ILogger<BookHandler> _logger;
        readonly IAuthorRemote _authorRemote;

        public BookHandler(ILogger<BookHandler> logger, IAuthorRemote authorRemote)
        {
            _logger = logger;
            _authorRemote = authorRemote;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var timer = Stopwatch.StartNew();

            _logger.LogInformation("starting request process.");

            var response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var bookDto = JsonConvert.DeserializeObject<BookDto>(content);

                var getAuthorResponse = await _authorRemote.GetAuthorAsync(bookDto.AuthorId, cancellationToken);

                if (getAuthorResponse.Item1)
                {
                    bookDto.Author = getAuthorResponse.Item2;

                    response.Content = new StringContent(JsonConvert.SerializeObject(bookDto), System.Text.Encoding.UTF8, "application/json");
                }
            }

            _logger.LogInformation($"Request processed in {timer.Elapsed.Milliseconds} ms.");

            return response;
        }
    }
}

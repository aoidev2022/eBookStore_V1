using Microsoft.Extensions.Logging;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace eBookStore.API.Basket.Clients.Book
{
    public interface IBookService
    {
        Task<(Book, bool)> GetBookAsync(int id);
    }

    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BookService> _logger;

        public BookService(IHttpClientFactory httpClient, ILogger<BookService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(Book, bool)> GetBookAsync(int id)
        {
            try
            {
                var client = _httpClient.CreateClient("book");
                var httpResponse = await client.GetAsync($"api/book/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var obj = JsonSerializer.Deserialize<Book>(content, options);

                    return (obj, true);
                }

                return (null, false);
            }
            catch (System.Exception er)
            {
                _logger.LogError(er.Message);

                return (null, false);
            }
        }
    }
}

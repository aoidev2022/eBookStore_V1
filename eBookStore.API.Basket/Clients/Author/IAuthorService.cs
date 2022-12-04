using Microsoft.Extensions.Logging;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace eBookStore.API.Basket.Clients.Author
{
    public interface IAuthorService
    {
        Task<(Author, bool)> GetAuthorAsync(int id);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IHttpClientFactory httpClient, ILogger<AuthorService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(Author, bool)> GetAuthorAsync(int id)
        {
            try
            {
                var client = _httpClient.CreateClient("book");
                var httpResponse = await client.GetAsync($"api/book/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var obj = JsonSerializer.Deserialize<Author>(content, options);

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

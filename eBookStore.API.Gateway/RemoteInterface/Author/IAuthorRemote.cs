using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Gateway.RemoteInterface.Author
{
    public interface IAuthorRemote
    {
        Task<(bool, AuthorDto, string)> GetAuthorAsync(int id, CancellationToken cancellationToken);
    }

    public class AuthorRemote : IAuthorRemote
    {
        readonly IHttpClientFactory _httpClientFactory;
        readonly ILogger<AuthorRemote> _logger;

        public AuthorRemote(ILogger<AuthorRemote> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<(bool, AuthorDto, string)> GetAuthorAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("author-service");
                var resp = await client.GetAsync($"/author/{id}", cancellationToken);

                if (resp.IsSuccessStatusCode)
                {
                    var content = await resp.Content.ReadAsStringAsync();
                    _logger.LogDebug(content);
                    var result = JsonConvert.DeserializeObject<AuthorDto>(content);

                    return (true, result, null);
                }

                return (false, null, resp.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving Author remote", ex);
                return (false, null, ex.Message);
            }
        }
    }

    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
    }
}

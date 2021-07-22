using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Togglr.Utilities
{
    public abstract class HttpUtilities
    {}

    public class FetchUtility : HttpUtilities
    {
        public async Task<string> Fetch(string url)
        {
            HttpResponseMessage response = await CreateClient.NewClient().GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
    
    public class CreateClient
    {
        private readonly IHttpClientFactory _clientFactory;
        public CreateClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public static HttpClient NewClient()
        {
            return _clientFactory.CreateClient();
        }
    }
}
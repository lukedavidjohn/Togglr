using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Togglr.Utilities
{
    public class FetchUtility : IFetchUtility
    {
        private readonly IHttpClientFactory _clientFactory;
        
        public FetchUtility(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> FetchAsync(Uri url)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YmZmYjI1NmVhNGE1MmU2ZTM3OGJkYmZkOWU4NDdkYmM6YXBpX3Rva2Vu");
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
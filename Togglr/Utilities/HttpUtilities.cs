using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Togglr.Utilities
{

    public static class FetchUtility
    {
        static readonly HttpClient client = new();
        public static async Task<string> Fetch(string url)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YmZmYjI1NmVhNGE1MmU2ZTM3OGJkYmZkOWU4NDdkYmM6YXBpX3Rva2Vu");
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
    
    // public class CreateClient
    // {
    //     private readonly IHttpClientFactory _clientFactory;
    //     public CreateClient(IHttpClientFactory clientFactory)
    //     {
    //         _clientFactory = clientFactory;
    //     }
    //     public static HttpClient NewClient()
    //     {
    //         return _clientFactory.CreateClient();
    //     }
    // }
}
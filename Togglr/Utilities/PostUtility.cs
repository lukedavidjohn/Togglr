using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Togglr.Utilities
{
    public class PostUtility<T> : IPostUtility<T>
    {
        private readonly IHttpClientFactory _clientFactory;
        public PostUtility(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<string> PostAsync(string authScheme, string authParameter, Uri path, T body)
        {
            try
            {
                var client = _clientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authScheme, authParameter);
                string bodyAsString = JsonConvert.SerializeObject(body);
                HttpResponseMessage response = await client.PostAsync(path, new StringContent(bodyAsString, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }
    }
}
using System;
using System.Threading.Tasks;

namespace Togglr.Utilities
{
    public interface IFetchUtility
    {
        public Task<string> FetchAsync(Uri url, string authScheme, string authToken);
    }
}
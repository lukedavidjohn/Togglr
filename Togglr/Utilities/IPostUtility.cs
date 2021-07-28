using System;
using System.Threading.Tasks;

namespace Togglr.Utilities
{
    public interface IPostUtility<T>
    {
        public Task<string> PostAsync(string authScheme, string authParameter, Uri path, T body);
    }
}
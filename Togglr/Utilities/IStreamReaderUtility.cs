using System.IO;
using System.Threading.Tasks;

namespace Togglr.Utilities
{
    public interface IStreamReaderUtility
    {
        public string ReadStreamToEnd(string path);

        public Task<string> ReadStreamToEnd(Stream stream);
    }
}
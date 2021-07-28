using System.IO;
using System.Threading.Tasks;

namespace Togglr.Utilities
{
    public class StreamReaderUtility : IStreamReaderUtility
    {
        public string ReadStreamToEnd(string path)
        {
            return new StreamReader(path).ReadToEnd();
        }
        
        public Task<string> ReadStreamToEnd(Stream stream)
        {
            return new StreamReader(stream).ReadToEndAsync();
        }
    }
}
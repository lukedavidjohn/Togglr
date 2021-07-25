using System.IO;

namespace Togglr.Utilities
{
    public class StreamReaderUtility : IStreamReaderUtility
    {
        public string ReadStreamToEnd(string path)
        {
            return new StreamReader(path).ReadToEnd();
        }
    }
}
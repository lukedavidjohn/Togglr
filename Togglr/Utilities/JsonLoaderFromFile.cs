using System.Collections.Generic;
using System.IO;

namespace Togglr.Utilities
{
    public class JsonLoaderFromFile<T> : IJsonLoaderFromFile<T>
    {
        readonly IStreamReaderUtility _streamReaderUtility;
        readonly IDeserializer _deserializer;
        public JsonLoaderFromFile(IStreamReaderUtility streamReaderUtility, IDeserializer deserializer)
        {
            _streamReaderUtility = streamReaderUtility;
            _deserializer = deserializer;
        }
        public List<T> LoadJsonFromFile(string path)
        {
            var jsonAsString = _streamReaderUtility.ReadStreamToEnd(path);
            return _deserializer.DeserializeList<T>(jsonAsString);
        }
    }
}
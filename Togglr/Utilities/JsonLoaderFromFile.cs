using System.Collections.Generic;
using System.IO;

namespace Togglr.Utilities
{
    public class JsonLoaderFromFile<T> : IJsonLoaderFromFile<T>
    {
        readonly IDeserializer _deserializer;
        public JsonLoaderFromFile(IDeserializer deserializer)
        {
            _deserializer = deserializer;
        }
        public List<T> LoadJsonFromFile(string path)
        {
            var jsonAsString = new StreamReader(path).ReadToEnd();
            return _deserializer.Deserialize<T>(jsonAsString);
        }
    }
}
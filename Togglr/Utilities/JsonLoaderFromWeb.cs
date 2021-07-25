using System;
using System.Collections.Generic;

namespace Togglr.Utilities
{
    public class JsonLoaderFromWeb<T> : IJsonLoaderFromWeb<T>
    {
        readonly IDeserializer _deserializer;
        public JsonLoaderFromWeb(IDeserializer deserializer)
        {
            _deserializer = deserializer;
        }
        public List<T> LoadJsonFromWeb(Uri path)
        {
            var jsonAsString = FetchUtility.Fetch(path).Result;
            return _deserializer.Deserialize<T>(jsonAsString);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Togglr.Utilities
{
    public class JsonLoaderFromWeb<T> : IJsonLoaderFromWeb<T>
    {
        readonly IFetchUtility _fetchUtility;

        readonly IDeserializer _deserializer;
        public JsonLoaderFromWeb(IFetchUtility fetchUtility, IDeserializer deserializer)
        {
            _fetchUtility = fetchUtility;
            _deserializer = deserializer;
        }
        public List<T> LoadJsonFromWeb(Uri path)
        {
            var jsonAsString = _fetchUtility.FetchAsync(path).Result;
            return _deserializer.Deserialize<T>(jsonAsString);
        }
    }
}

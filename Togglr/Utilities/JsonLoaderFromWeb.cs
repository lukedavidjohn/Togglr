using System;
using System.Collections.Generic;

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
        public List<T> LoadJsonFromWeb(Uri path, string authScheme, string authToken)
        {
            var jsonAsString = _fetchUtility.FetchAsync(path, authScheme, authToken).Result;
            return _deserializer.DeserializeList<T>(jsonAsString);
        }
    }
}

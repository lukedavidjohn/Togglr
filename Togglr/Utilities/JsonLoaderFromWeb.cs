using System.Collections.Generic;
using Newtonsoft.Json;

namespace Togglr.Utilities
{
    public class JsonLoaderFromWeb<T>
    {
        public List<T> LoadJson(string path)
        {
            var jsonAsString = FetchUtility.Fetch(path).Result;
            return JsonConvert.DeserializeObject<List<T>>(jsonAsString);
        }
    }
}

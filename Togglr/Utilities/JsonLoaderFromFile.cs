using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace Togglr.Utilities
{
    public class JsonLoaderFromFile<T>
    {
        public List<T> LoadJson(string path)
        {
            var jsonAsString = new StreamReader(path).ReadToEnd();
            return JsonConvert.DeserializeObject<List<T>>(jsonAsString);
        }
    }
}
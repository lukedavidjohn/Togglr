using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Togglr.Utilities
{
    public abstract class JsonLoader<T>
    {
        public abstract List<T> LoadJson(string path);

        public List<T> Deserialize(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(path);
        }
    }
}

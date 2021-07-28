using System.Collections.Generic;
using Newtonsoft.Json;

namespace Togglr.Utilities
{
    public class Deserializer : IDeserializer
    {
        public T Deserialize<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(path);
        }

        public List<T> DeserializeList<T>(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(path);
        }
    }
}

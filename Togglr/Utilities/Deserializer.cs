using System.Collections.Generic;
using Newtonsoft.Json;

namespace Togglr.Utilities
{
    public class Deserializer : IDeserializer
    {
        public List<T> DeserializeList<T>(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(path);
        }
    }
}

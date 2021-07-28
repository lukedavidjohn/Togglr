using System.Collections.Generic;

namespace Togglr.Utilities
{
    public interface IDeserializer
    {
        public T Deserialize<T>(string path);

        public List<T> DeserializeList<T>(string path);
    }
}

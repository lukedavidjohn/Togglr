using System.Collections.Generic;

namespace Togglr.Utilities
{
    public interface IDeserializer
    {
        public List<T> Deserialize<T>(string path);
    }
}

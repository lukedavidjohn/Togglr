using System.Collections.Generic;

namespace Togglr.Utilities
{
    public interface IJsonLoaderFromFile<T>
    {
        public List<T> LoadJsonFromFile(string path);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Togglr.Utilities
{
    public interface IJsonLoaderFromWeb<T>
    {
        public List<T> LoadJsonFromWeb(Uri path);
    }
}
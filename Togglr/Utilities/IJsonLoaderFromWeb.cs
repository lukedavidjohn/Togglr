using System;
using System.Collections.Generic;

namespace Togglr.Utilities
{
    public interface IJsonLoaderFromWeb<T>
    {
        public List<T> LoadJsonFromWeb(Uri path, string authScheme, string authToken);
    }
}
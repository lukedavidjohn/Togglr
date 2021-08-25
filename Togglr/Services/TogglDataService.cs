using System.Collections.Generic;
using Togglr.Models;
using Togglr.Utilities;

namespace Togglr.Services
{
    public abstract class TogglDataService<T> where T : TogglData
    {
        public readonly List<T> Items;
        readonly IJsonLoaderFromFile<T> _jsonLoaderFromFile;
        public TogglDataService(IJsonLoaderFromFile<T> jsonLoaderFromFile, string path)
        {
            _jsonLoaderFromFile = jsonLoaderFromFile;
            Items = _jsonLoaderFromFile.LoadJsonFromFile(path);
        }
        public List<T> GetAll()
        {
            return Items;
        }
    }
}
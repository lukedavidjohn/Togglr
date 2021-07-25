using System.Collections.Generic;
using System.Linq;
using Togglr.Models;
using Togglr.Utilities;

namespace Togglr.Services
{
    public abstract class TogglDataService<T> where T : TogglData
    {
        public static List<T> Items { get; set; }

        readonly IJsonLoaderFromFile<T> _jsonLoaderFromFile;

        public TogglDataService(IJsonLoaderFromFile<T> jsonLoaderFromFile, string path)
        {
            _jsonLoaderFromFile = jsonLoaderFromFile;
            Items = _jsonLoaderFromFile.LoadJsonFromFile(path);
        }

        public List<T> GetAll() => Items;
        public T Get(int id) => Items.FirstOrDefault(item => item.Id == id);
        public T Get(string name) => Items.FirstOrDefault(item => item.Name == name);

        // public T GetByName(string name) => Items.FirstOrDefault(item => item.Name == name);

        public int GetCount() => Items.Count;

        public List<T> Post(T item)
        {
            Items.Add(item);
            return Items;
        }

        public bool Put(int id, T body)
        {
            try
            {
                var item = Get(id);
                var itemIndex = Items.IndexOf(item);
                Items[itemIndex] = body;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var item = Get(id);
            return Items.Remove(item);
        }
    }
}
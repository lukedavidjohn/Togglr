using System.Collections.Generic;

namespace Togglr.Services
{
    public interface ITogglDataService<T>
    {
        public static List<T> Items { get; set; }

        public List<T> GetAll();

        public T Get(int id);
        
        public T Get(string name);

        public int GetCount();

        public List<T> Post(T item);
    }
}
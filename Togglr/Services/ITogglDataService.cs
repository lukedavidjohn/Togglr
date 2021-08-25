using System.Collections.Generic;

namespace Togglr.Services
{
    public interface ITogglDataService<T>
    {
        public static List<T> Items { get; set; }
        public List<T> GetAll();
    }
}
using Togglr.Models;

namespace Togglr.Services
{
    public class TagService : TogglDataService<Tag>
    {
        public TagService(string path) : base(path)
        {
        }
    }
}
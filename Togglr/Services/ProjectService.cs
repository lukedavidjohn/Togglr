using Togglr.Models;

namespace Togglr.Services
{
    public class ProjectService : TogglDataService<Project>
    {
        public ProjectService(string path) : base(path)
        {
        }
    }
}
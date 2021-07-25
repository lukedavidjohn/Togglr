using Togglr.Models;
using Togglr.Utilities;

namespace Togglr.Services
{
    public class ProjectService : TogglDataService<Project>, ITogglDataService<Project>
    {
        public ProjectService(IJsonLoaderFromFile<Project> jsonLoaderFromFile) : base(jsonLoaderFromFile, "./TogglData/Projects.json")
        {}
    }
}
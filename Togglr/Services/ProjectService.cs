using System.Collections.Generic;
using Togglr.Models;
using Togglr.Utilities;

namespace Togglr.Services
{
    public class ProjectService : TogglDataService<Project>, ITogglDataService<Project>
    {
        public static List<Project> Projects { get; set; }
        public ProjectService(IJsonLoaderFromFile<Project> jsonLoaderFromFile) : base(jsonLoaderFromFile, "./TogglData/Projects.json")
        {}
    }
}
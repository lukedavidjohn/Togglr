using System.Collections.Generic;
using Togglr.Models;

namespace Togglr.Services
{
    public class ProjectService : TogglDataService<Project>, ITogglDataService<Project>
    {
        public static List<Project> Projects { get; set; }
        public ProjectService() : base("./TogglData/Projects.json")
        {}
    }
}
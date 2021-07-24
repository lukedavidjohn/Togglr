using System.Collections.Generic;
using Togglr.Models;

namespace Togglr.Services
{
    public class ProjectService : TogglDataService<Project>, IProjectService
    {
        public static List<Project> Projects { get; set; }
        public ProjectService() : base("./TogglData/Projects.json")
        {}
    }
}
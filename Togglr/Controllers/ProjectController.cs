using Microsoft.AspNetCore.Mvc;
using Togglr.Models;
using Togglr.Services;

namespace Togglr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : TogglDataController<Project>, ITogglDataController<Project>
    {   
        public ProjectController(ITogglDataService<Project> projectService) : base(projectService)
        {
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Togglr.Models;
using Togglr.Services;

namespace Togglr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase, ITogglDataController<Project>
    {
        readonly string projectFilePath = "./TogglData/Projects.json";
        readonly ProjectService projectService;
        public ProjectController()
        {
            projectService = new ProjectService(projectFilePath);
        }

        [HttpGet]
        public ActionResult<List<Project>> GetAll()
        {
            // string authHeader = Request.Headers["Authorization"];
            // var user = UserService.GetByAuthToken(authHeader);
            // if (user == null)
            // {
            //     return NotFound();
            // }
            // if (user.IsAdminUser == false)
            // {
            //     return Unauthorized();
            // }
            return projectService.GetAll();
        }
        [HttpGet("{argument}")]
        public ActionResult<Project> Get(string argument)
        {
            Project project;
            bool argumentIsInteger = int.TryParse(argument, out int argumentAsInteger);
            switch (argumentIsInteger)
            {
                case false:
                    project = projectService.Get(argument);
                    break;
                case true:
                    project = projectService.Get(argumentAsInteger);
                    break;
            }
            if(project == null)
            {
                return NotFound();
            }
            return project;
        }
    }
}
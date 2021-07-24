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
        readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("~/[controller]/[action]")]
        public ActionResult<List<Project>> GetAll() => _projectService.GetAll();
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

        [HttpGet("{argument}")]
        public ActionResult<Project> Get(string argument)
        {
            Project project;
            bool argumentIsInteger = int.TryParse(argument, out int argumentAsInteger);
            switch (argumentIsInteger)
            {
                case false:
                    project = _projectService.Get(argument);
                    break;
                case true:
                    project = _projectService.Get(argumentAsInteger);
                    break;
            }
            if(project == null)
            {
                return NotFound();
            }
            return project;
        }

        [HttpGet("~/[controller]/[action]")]
        public ActionResult<int> GetCount() => _projectService.GetCount();

        [HttpPost]
        public ActionResult<List<Project>> Post(Project body)
        {
            var projects = _projectService.Post(body);
            return Created("", projects);
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Togglr.Models;
using Togglr.Services;

namespace Togglr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase, ITogglDataController<Task>
    {
        public ITogglDataService<Task> _taskService;
        public TaskController(ITogglDataService<Task> taskService)
        {
            _taskService = taskService;
        }
        [HttpGet("~/[controller]/[action]")]
        public ActionResult<List<Task>> GetAll() => _taskService.GetAll();

        [HttpGet("{argument}")]
        public ActionResult<Task> Get(string argument)
        {
            Task task;
            bool argumentIsInteger = int.TryParse(argument, out int argumentAsInteger);
            switch (argumentIsInteger)
            {
                case false:
                    task = _taskService.Get(argument);
                    break;
                case true:
                    task = _taskService.Get(argumentAsInteger);
                    break;
            }
            if(task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpGet("~/[controller]/[action]")]
        public ActionResult<int> GetCount() => _taskService.GetCount();
        [HttpPost]
        public ActionResult<List<Task>> Post(Task body)
        {
            var tasks = _taskService.Post(body);
            return Created("", tasks);
        }
    }
}
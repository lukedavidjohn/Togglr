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
        readonly string taskFilePath = "./TogglData/Tasks.json";
        readonly TaskService taskService;
        public TaskController()
        {
            taskService = new TaskService(taskFilePath);
        }
        [HttpGet]
        public ActionResult<List<Task>> GetAll() => taskService.GetAll();

        [HttpGet("{argument}")]
        public ActionResult<Task> Get(string argument)
        {
            Task task;
            bool argumentIsInteger = int.TryParse(argument, out int argumentAsInteger);
            switch (argumentIsInteger)
            {
                case false:
                    task = taskService.Get(argument);
                    break;
                case true:
                    task = taskService.Get(argumentAsInteger);
                    break;
            }
            if(task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpGet]
        public ActionResult<int> GetCount() => taskService.GetCount();

        public ActionResult<List<Task>> Post(Task body)
        {
            var tasks = taskService.Post(body);
            return Created("", tasks);
        }
    }
}
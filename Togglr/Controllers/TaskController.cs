using Microsoft.AspNetCore.Mvc;
using Togglr.Models;
using Togglr.Services;

namespace Togglr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : TogglDataController<Task>, ITogglDataController<Task>
    {
        public TaskController(ITogglDataService<Task> taskService) : base(taskService)
        {
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Togglr.Models;
using Togglr.Services;

namespace Togglr.Controllers
{
    public class HomeController : Controller
    {
        readonly ITimeEntryService _timeEntryService;
        readonly ITogglDataService<Project> _projectService;
        readonly ITogglDataService<Tag> _tagService;
        readonly ITogglDataService<Task>_taskService;
        public HomeController(ITimeEntryService timeEntryService, ITogglDataService<Project> projectService, ITogglDataService<Tag> tagService, ITogglDataService<Task> taskService)
        {
            _timeEntryService = timeEntryService;
            _projectService = projectService;
            _tagService = tagService;
            _taskService = taskService;
        }
        [HttpGet("~/[controller]/[action]")]
        public ActionResult Index()
        {
            var viewModelsData = new ViewModelsData
            {
                TimeEntries = _timeEntryService.GetAll(),
                Projects = _projectService.GetAll(),
                Tags = _tagService.GetAll(),
                Tasks = _taskService.GetAll(),
                UserInput = new UserInput()
            };

            return View(viewModelsData);
        }
        [HttpPost("~/[controller]/[action]")]
        public async System.Threading.Tasks.Task<ActionResult> Index(UserInput userInput)
        {
            var newTimeEntry = _timeEntryService.CreateNewTimeEntry(userInput, _projectService);
            await _timeEntryService.Post(newTimeEntry, "Basic", "YmZmYjI1NmVhNGE1MmU2ZTM3OGJkYmZkOWU4NDdkYmM6YXBpX3Rva2Vu");

            ViewData["Description"] = newTimeEntry.Description;
            ViewData["Pid"] = newTimeEntry.Pid;
            ViewData["Tid"] = newTimeEntry.Tid;
            ViewData["Tags"] = newTimeEntry.Tags[0];
            ViewData["Start"] = newTimeEntry.Start;
            ViewData["Stop"] = newTimeEntry.Stop;
            return View("FormLanding");
        }
    }
}
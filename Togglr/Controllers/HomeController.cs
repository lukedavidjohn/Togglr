using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Togglr.Models;
using Togglr.Services;
using Newtonsoft.Json;

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
        public 
        ActionResult Index()
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
        public ActionResult Index(UserInput userInput)
        {
            Console.WriteLine(userInput.Pid);
            return View("Information");
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Togglr.Models;
using Togglr.Services;
using Togglr.Utilities;

namespace Togglr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeEntryController : ControllerBase
    {
        readonly string timeEntryPath = "https://track.toggl.com/api/v9/me/time_entries?since=";

        public TimeEntryService timeEntryService;

        public TimeEntryController(IJsonLoaderFromWeb<TimeEntry> jsonLoaderFromWeb)
        {
            timeEntryService = new TimeEntryService(jsonLoaderFromWeb, timeEntryPath);
        }

        [HttpGet]
        public ActionResult<List<TimeEntry>> GetAll()
        {
            return timeEntryService.GetAll();
        }
        
        [HttpGet("{id}")]
        public ActionResult<TimeEntry> Get(int id)
        {
            var timeEntry = timeEntryService.Get(id);
            if(timeEntry == null)
            {
                return NotFound();
            }
            return timeEntry;
        }
    }
}

// namespace Togglr.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class TimeEntryController : ControllerBase
//     {
//         // public HttpClient _httpClient;
//         readonly string timeEntryPath = "https://track.toggl.com/api/v9/time_entries";
//         public TimeEntryService timeEntryService;
//         public TimeEntryController(HttpClient httpClient)
//         {
//             _httpClient = httpClient;
//             timeEntryService = new TimeEntryService(timeEntryPath);
//         }
//         // [HttpPost]
//         // public async System.Threading.Tasks.Task<IActionResult> Post()
//         // {
//         //     HttpResponseMessage response = await _httpClient.GetAsync("https://www.google.co.uk");
//         //     Console.WriteLine(response);
//         //     return Ok();
//         // }
//         [HttpGet]
//         public ActionResult<List<TimeEntry>> GetAll() => timeEntryService.GetAll();
//         [HttpGet("{id}")]
//         public ActionResult<TimeEntry> Get(int id)
//         {
//             var timeEntry = timeEntryService.Get(id);
//             if(timeEntry == null)
//             {
//                 return NotFound();
//             }
//             return timeEntry;
//         }
//     }
// }
using System;
using System.Collections.Generic;
using System.Globalization;
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
        readonly string timeEntryPath = "https://track.toggl.com/api/v9/me/time_entries";

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

        [HttpGet("~/[controller]/[action]")]
        public ActionResult<int> GetCount() => timeEntryService.GetCount();

        [HttpGet("{dateString}")]
        public ActionResult<List<TimeEntry>> GetAllSinceDate(string dateString)
        {
            var sinceDate = DateTime.ParseExact(dateString, "dd-MM-yyyy", new CultureInfo("en-GB"));;
            return timeEntryService.GetAllSinceDate(sinceDate);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Togglr.Models;
using Togglr.Services;
using Togglr.Utilities;

namespace Togglr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeEntryController : Controller
    {
        readonly string timeEntryPath = "https://track.toggl.com/api/v9/me/time_entries";

        public TimeEntryService timeEntryService;

        readonly IStreamReaderUtility _streamReaderUtility;

        public TimeEntryController(IPostUtility<TimeEntry> postUtility, IJsonLoaderFromWeb<TimeEntry> jsonLoaderFromWeb, IDeserializer deserializer, IStreamReaderUtility streamReaderUtility)
        {
            timeEntryService = new TimeEntryService(postUtility, jsonLoaderFromWeb, deserializer);
            _streamReaderUtility = streamReaderUtility;
        }

        [HttpGet]
        public ActionResult<List<TimeEntry>> GetAll()
        {
            return timeEntryService.GetAll();
        }

        [HttpGet("{dateString}")]
        public ActionResult<List<TimeEntry>> GetAllSinceDate(string dateString)
        {
            var sinceDate = DateTime.ParseExact(dateString, "dd-MM-yyyy", new CultureInfo("en-GB"));;
            return timeEntryService.GetAllSinceDate(sinceDate);
        }

        [HttpGet("~/[controller]/[action]")]
        public ActionResult<int> GetCount() => timeEntryService.GetCount();

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var body = await _streamReaderUtility.ReadStreamToEnd(Request.Body);
            var response = await timeEntryService.Post(body);
            return Created(Request.Path, response);
        }
    }
}
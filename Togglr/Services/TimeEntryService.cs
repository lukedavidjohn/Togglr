using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Togglr.Models;
using Togglr.Utilities;

namespace Togglr.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        static List<TimeEntry> TimeEntries { get; set; }
        readonly IJsonLoaderFromWeb<TimeEntry> _jsonLoaderFromWeb;
        static string _path;
        static Uri _jsonUrl;
        readonly IPostUtility<TimeEntry> _postUtility;
        readonly string authScheme = "Basic";
        readonly string authToken = "YmZmYjI1NmVhNGE1MmU2ZTM3OGJkYmZkOWU4NDdkYmM6YXBpX3Rva2Vu";
        public TimeEntryService(IPostUtility<TimeEntry> postUtility, IJsonLoaderFromWeb<TimeEntry> jsonLoaderFromWeb)
        {
            _postUtility = postUtility;
            _jsonLoaderFromWeb = jsonLoaderFromWeb;
            _path = "https://track.toggl.com/api/v9/me/time_entries";
            _jsonUrl = new Uri(_path);
            TimeEntries = _jsonLoaderFromWeb.LoadJsonFromWeb(_jsonUrl, authScheme, authToken);
        }
        public List<TimeEntry> GetAll()
        {
            return TimeEntries;
        }
        public TimeEntry CreateNewTimeEntry(UserInput userInput, ITogglDataService<Project> projectService)
        {
            var projects = projectService.GetAll();
            var project = projects.Find(project => project.Id == userInput.Pid);
            var userInputDateParts = userInput.Date.Split("-");
            var userInputStartTimeParts = userInput.Start.Split(":");
            var userInputStopTimeParts = userInput.Stop.Split(":");
            var startDate = new DateTime(int.Parse(userInputDateParts[0]), int.Parse(userInputDateParts[1]), int.Parse(userInputDateParts[2]), int.Parse(userInputStartTimeParts[0]), int.Parse(userInputStartTimeParts[1]), 0, DateTimeKind.Local);
            var stopDate = new DateTime(int.Parse(userInputDateParts[0]), int.Parse(userInputDateParts[1]), int.Parse(userInputDateParts[2]), int.Parse(userInputStopTimeParts[0]), int.Parse(userInputStopTimeParts[1]), 0, DateTimeKind.Local);
            var newTimeEntry = new TimeEntry
            {
                Created_With = "Snowball",
                Pid = userInput.Pid,
                Tid = userInput.Tid,
                Billable = project.Billable,
                Start = startDate,
                Stop = stopDate,
                Duration = (int)(stopDate - startDate).TotalSeconds,
                Description = userInput.Description,
                Tags = new List<string>() { userInput.Tag },
                Uid = 5400208,
                Wid = 2500287
            };
            return newTimeEntry;
        }
        public async Task<string> Post(TimeEntry timeEntry, string authScheme, string authToken)
        {
            var response = await _postUtility.PostAsync(authScheme, authToken, new Uri("https://track.toggl.com/api/v9/time_entries"), timeEntry);
            return response; 
        }
    }
}
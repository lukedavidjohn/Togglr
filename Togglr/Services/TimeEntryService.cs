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

        readonly IDeserializer _deserializer;

        static Uri _jsonUrl;
        readonly IPostUtility<TimeEntry> _postUtility;

        readonly string authScheme = "Basic";
        readonly string authToken = "";
        
        public TimeEntryService(IPostUtility<TimeEntry> postUtility, IJsonLoaderFromWeb<TimeEntry> jsonLoaderFromWeb, IDeserializer deserializer)
        {
            _postUtility = postUtility;
            _jsonLoaderFromWeb = jsonLoaderFromWeb;
            _path = "https://track.toggl.com/api/v9/me/time_entries";
            _deserializer = deserializer;
            _jsonUrl = new Uri(_path);
            TimeEntries = _jsonLoaderFromWeb.LoadJsonFromWeb(_jsonUrl, authScheme, authToken);
        }

        public List<TimeEntry> GetAll()
        {
            return TimeEntries;
        }

        public List<TimeEntry> GetAllSinceDate(DateTime sinceDate)
        {
            return TimeEntries.FindAll(timeEntry => timeEntry.Start > sinceDate);
        }

        public int GetCount() => TimeEntries.Count;

        private TimeEntry CreateNewTimeEntry(string body)
        {
            var bodyParts = _deserializer.Deserialize<TimeEntry>(body);
            bodyParts.SetTimes();
            return bodyParts;
        }

        public async Task<string> Post(string body, string authScheme, string authToken)
        {
            // "{"Created_With": "Snowball", "pid": 157025838, "tid": 27896544, "billable": true, "start": "2021/07/06T16:00:00", "stop": "2021/07/06T17:00:00", "description": "Slack user reporting", "tags": ["ALPINE"], "uid": 5400208, "wid": 2500287}"
            var timeEntry = CreateNewTimeEntry(body);
            var response = await _postUtility.PostAsync(authScheme, authToken, new Uri("https://track.toggl.com/api/v9/time_entries"), timeEntry);
            return response; 
        }

        // public void Delete(int id)
        // {
        //     var timeEntry = Get(id);
        //     if(timeEntry is null)
        //     {
        //         return;
        //     }
        //     TimeEntries.Remove(timeEntry);
        // }
    }
}
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Togglr.Models;
using Togglr.Utilities;

namespace Togglr.Services
{
    public class TimeEntryService
    {
        static List<TimeEntry> TimeEntries { get; set; }

        readonly IJsonLoaderFromWeb<TimeEntry> _jsonLoaderFromWeb;

        static string _path;

        readonly IDeserializer _deserializer;

        static Uri _jsonUrl;
        readonly IPostUtility<TimeEntry> _postUtility;
        
        public TimeEntryService(IPostUtility<TimeEntry> postUtility, IJsonLoaderFromWeb<TimeEntry> jsonLoaderFromWeb, string path, IDeserializer deserializer)
        {
            _postUtility = postUtility;
            _jsonLoaderFromWeb = jsonLoaderFromWeb;
            _path = path;
            _deserializer = deserializer;
            _jsonUrl = new Uri(_path);
            TimeEntries = _jsonLoaderFromWeb.LoadJsonFromWeb(_jsonUrl);
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

        public async System.Threading.Tasks.Task<string> Post(string body)
        {
            // "{"Created_With": "Snowball", "pid": 157025838, "tid": 27896544, "billable": true, "start": "2021/07/06T16:00:00", "stop": "2021/07/06T17:00:00", "description": "Slack user reporting", "tags": ["ALPINE"], "uid": 5400208, "wid": 2500287}"
            var bodyParts = _deserializer.Deserialize<TimeEntry>(body);
            bodyParts.SetTimes();
            var response = await _postUtility.PostAsync("Basic", "YmZmYjI1NmVhNGE1MmU2ZTM3OGJkYmZkOWU4NDdkYmM6YXBpX3Rva2Vu", new Uri("https://track.toggl.com/api/v9/time_entries"), bodyParts);
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
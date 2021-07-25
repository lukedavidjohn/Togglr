using System;
using System.Collections.Generic;
using System.Linq;
using Togglr.Models;
using Togglr.Utilities;

namespace Togglr.Services
{
    public class TimeEntryService
    {
        static List<TimeEntry> TimeEntries { get; set; }

        readonly IJsonLoaderFromWeb<TimeEntry> _jsonLoaderFromWeb;
        static string _path;
        static Uri _jsonUrl;
        public TimeEntryService(IJsonLoaderFromWeb<TimeEntry> jsonLoaderFromWeb, string path)
        {
            _jsonLoaderFromWeb = jsonLoaderFromWeb;
            _path = path;
            _jsonUrl = new Uri(_path);
            TimeEntries = _jsonLoaderFromWeb.LoadJsonFromWeb(_jsonUrl);
        }

        public List<TimeEntry> GetAll()
        {
            return TimeEntries;
        }

        public TimeEntry Get(int id) => TimeEntries.FirstOrDefault(timeEntry => timeEntry.Id == id);

        public int GetCount() => TimeEntries.Count;

        public void Post(UserInput userInput)
        {
            // var enrichedUserInput = stuff
            var timeEntry = new TimeEntry(userInput, _path);
            TimeEntries.Add(timeEntry);
        }

        public void Delete(int id)
        {
            var timeEntry = Get(id);
            if(timeEntry is null)
                return;

            TimeEntries.Remove(timeEntry);
        }
    }
}
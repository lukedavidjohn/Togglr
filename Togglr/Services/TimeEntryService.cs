using System.Collections.Generic;
using System.Linq;
using Togglr.Models;
using Togglr.Utilities;

namespace Togglr.Services
{
    public class TimeEntryService
    {
        static List<TimeEntry> TimeEntries { get; set; }
        static string Path;
        public TimeEntryService(string path)
        {
            Path = path;
            TimeEntries = new JsonLoaderFromWeb<TimeEntry>().LoadJson(path);
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
            var timeEntry = new TimeEntry(userInput, Path);
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
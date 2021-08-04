using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Togglr.Models;

namespace Togglr.Services
{
    public interface ITimeEntryService
    {
        public List<TimeEntry> GetAll();

        public List<TimeEntry> GetAllSinceDate(DateTime sinceDate);

        public int GetCount();

        public Task<string> Post(string body);
    }
}
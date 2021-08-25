using System.Collections.Generic;
using System.Threading.Tasks;
using Togglr.Models;

namespace Togglr.Services
{
    public interface ITimeEntryService
    {
        public List<TimeEntry> GetAll();
        public TimeEntry CreateNewTimeEntry(UserInput userInput, ITogglDataService<Project> projectService);
        public Task<string> Post(TimeEntry timeEntry, string authScheme, string authToken);
    }
}
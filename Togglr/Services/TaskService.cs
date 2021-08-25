using Togglr.Models;
using Togglr.Utilities;

namespace Togglr.Services
{
    public class TaskService : TogglDataService<Task>, ITogglDataService<Task>
    {
        public TaskService(IJsonLoaderFromFile<Task> jsonLoaderFromFile) : base(jsonLoaderFromFile, "./TogglData/Tasks.json")
        {
        }
    }
}
using System.Collections.Generic;
using Togglr.Models;

namespace Togglr.Services
{
    public class TaskService : TogglDataService<Task>, ITaskService
    {
        public static List<Task> Tasks { get; set; }
        public TaskService() : base("./TogglData/Tasks.json")
        {}

        // public List<Task> GetByProject(int pid)
        // {
        //     return Items.FindAll(item => item.Pid == pid);
        // }
    }
}
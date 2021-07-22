using System;
using System.Collections.Generic;
using Togglr.Models;

namespace Togglr.Services
{
    public class TaskService : TogglDataService<Task>
    {
        public TaskService(string path) : base(path)
        {
        }
        public List<Task> GetByProject(int pid)
        {
            return Items.FindAll(item => item.Pid == pid);
        }
    }
}
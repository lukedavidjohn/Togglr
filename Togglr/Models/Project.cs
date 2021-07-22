using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Togglr.Services;

namespace Togglr.Models
{
    public class Project : TogglData
    {
        public bool Billable { get;  }
		public bool IsPrivate { get; }
		public bool Active { get; private set; }
		public bool Template { get; }
        public DateTime CreatedAt { get; }
		public int Color { get; }
		public string AutoEstimates { get; }
		public string ActualHours { get; }
		public string Hex_color { get; }
		[JsonIgnore]
		public IReadOnlyList<Task> Tasks { get; private set; }
		[OnDeserialized]
		internal void GetTasks(StreamingContext context)
		{
			TaskService taskService = new("./TogglData/Tasks.json");
			Tasks = taskService.GetByProject(Id);
		}
		internal void ActivateProject()
		{
			if (Active == true)
			{
				throw new Exception("Project already active");
			}
			Active = true;
		}
		internal void InactivateProject()
		{
			if (Active == false)
			{
				throw new Exception("Project already inactive");
			}
			Active = false;
		}
    }    
}

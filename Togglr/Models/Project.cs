using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Togglr.Services;

namespace Togglr.Models
{
    public sealed class Project : TogglData
    {
        public bool Billable { get;  }

		public bool IsPrivate { get; }

		public bool Active { get; }

		public bool Template { get; }

        public DateTime CreatedAt { get; }

		public int Color { get; }

		public string AutoEstimates { get; }

		public string ActualHours { get; }

		public string Hex_color { get; }

		// [JsonIgnore]
		// public IReadOnlyList<Task> Tasks { get; private set; }

		// [JsonIgnore]
		// private ITogglDataService<Task> _taskService;

        // [OnDeserialized]
		// internal void GetTasks(StreamingContext context, ITogglDataService<Task> taskService)
		// {
		// 	_taskService = taskService;
		// 	Tasks = _taskService.GetAll();
		// 	// TaskService taskService = new("./TogglData/Tasks.json");
		// 	// Tasks = taskService.GetByProject(Id);
		// }
		// internal void ActivateProject()
		// {
		// 	if (Active == true)
		// 	{
		// 		throw new Exception("Project already active");
		// 	}
		// 	Active = true;
		// }
		// internal void InactivateProject()
		// {
		// 	if (Active == false)
		// 	{
		// 		throw new Exception("Project already inactive");
		// 	}
		// 	Active = false;
		// }
    }    
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Togglr.Services;

namespace Togglr.Models
{
    sealed class Project : TogglData
    {
        public static bool Billable { get;  }

		public static bool IsPrivate { get; }

		public static bool Active { get; }

		public static bool Template { get; }

        public static DateTime CreatedAt { get; }

		public static int Color { get; }

		public static string AutoEstimates { get; }

		public static string ActualHours { get; }

		public static string Hex_color { get; }

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

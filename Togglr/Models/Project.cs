using System;

namespace Togglr.Models
{
    public sealed class Project : TogglData
    {
        public bool Billable { get; set; }

		public bool IsPrivate { get; set; }

		public bool Active { get; set; }

		public bool Template { get; set; }

        public DateTime CreatedAt { get; set; }

		public int Color { get; set; }

		public string AutoEstimates { get; set; }

		public string ActualHours { get; set; }

		public string Hex_color { get; set; }

		// [JsonIgnore]
		// public IReadOnlyList<Task> Tasks { get; private set; }

		// [JsonIgnore]
		// private ITogglDataService<Task> _taskService;

        // [OnDeserialized]
		// internal void GetTasks(StreamingContext context, ITogglDataService<Task> taskService)
		// {
			// _taskService = taskService;
			// Tasks = _taskService.GetByProject();
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

using System.Collections.Generic;

namespace Togglr.Models
{
    public class ViewModelsData
    {
        public List<TimeEntry> TimeEntries { get; set; }
        public List<Project> Projects { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Task> Tasks { get; set; }
        public UserInput UserInput { get; set; }
    }
}
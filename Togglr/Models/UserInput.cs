using System;

namespace Togglr.Models
{
    public class UserInput
    {
		public string Description { get; set; }
        public string Project { get; set; }
        public string Task { get; set; }
        public string Tags  { get; set; }
        public DateTime Date { get; set; }
        public string StartHour { get; set; }
        public string StartMinute { get; set; }
        public string StopHour { get; set; }
        public string StopMinute { get; set; }
    }
}
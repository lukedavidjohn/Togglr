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
    }    
}

using System;

namespace Togglr.Models
{
    public class Task : TogglData
    {
        public int Pid { get; set; }
        public bool Active { get; set; }
        public string EstimatedSeconds { get; set; }
        internal void ActivateTask()
		{
			if (Active == true)
			{
				throw new Exception("Task already active");
			}
			Active = true;
		}
		internal void InactivateTask()
		{
			if (Active == false)
			{
				throw new Exception("Task already inactive");
			}
			Active = false;
		}
    }
}
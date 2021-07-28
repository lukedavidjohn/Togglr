using System;
using System.Collections.Generic;

namespace Togglr.Models
{
    public class TimeEntry
    {   
        // public TimeEntry(UserInput userInput, string path)
        // {
            // At = //DateTime.Now;
            // Billable = //new ProjectService(path).Get(userInput.Project).Billable;
            // Billable = false;
            // Description = userInput.Description;
            // Duronly = false;
            // Id = 
            // Pid = new ProjectService(path).Get(userInput.Project).Id;
            // Start = userInput.Date.AddHours(int.Parse(userInput.StartHour)).AddMinutes(int.Parse(userInput.StartMinute));
            // Stop = userInput.Date.AddHours(int.Parse(userInput.StopHour)).AddMinutes(int.Parse(userInput.StopMinute));
            // Tags = new List<string>{userInput.Tags};
            // Tid = // TaskService.Get(this.Pid, userInput.Task).Id;
            // Uid = 5400208;
            // UserId = 5400208;
            // Wid = 2500287;
            // Duration = (this.Stop - this.Start).TotalSeconds;
        // }
        public DateTime At { get; set; }

        public bool Billable { get; set; }

        public string Description { get; set; }

        public double Duration { get; set; }

        public bool Duronly { get; set; }

        public int Id { get; set; }

        public int Pid { get; set; }

        public int ProjectId { get; set; }

        public string ServerDeletedAt { get; set; }

        public DateTime Start { get; set; }

        public DateTime Stop { get; set; }

        public List<int> TagIds { get; set; }

        public List<string> Tags { get; set; }

        public int TaskId { get; set; }

        public int Tid { get; set; }

        public int Uid { get; set; }

        public int UserId { get; set; }

        public int Wid { get; set; }

        public int WorkspaceId { get; set; }
    }
}
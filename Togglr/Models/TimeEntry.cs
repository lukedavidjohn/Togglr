using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Togglr.Services;

namespace Togglr.Models
{
    public class TimeEntry
    {   
        public TimeEntry(UserInput userInput, string path)
        {
            At = DateTime.Now;
            Billable = new ProjectService(path).Get(userInput.Project).Billable;
            Description = userInput.Description;
            Duronly = false;
            // Id = 
            Pid = new ProjectService(path).Get(userInput.Project).Id;
            Start = userInput.Date.AddHours(int.Parse(userInput.StartHour)).AddMinutes(int.Parse(userInput.StartMinute));
            Stop = userInput.Date.AddHours(int.Parse(userInput.StopHour)).AddMinutes(int.Parse(userInput.StopMinute));
            Tags = new List<string>{userInput.Tags};
            // Tid = TaskService.Get(this.Pid, userInput.Task).Id;
            Uid = 5400208;
            UserId = 5400208;
            Wid = 2500287;
            Duration = (this.Stop - this.Start).TotalSeconds;
        }
        public TimeEntry()
        {
        }
        [Required]
        public DateTime At { get; set; }
        [Required]
        public bool Billable { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        public bool Duronly { get; set; }
        public int Id { get; set; }
        [Required]
        public int Pid { get; set; }
        public int ProjectId { get; set; }
        public string ServerDeletedAt { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime Stop { get; set; }
        public List<int> TagIds { get; set; }
        [Required]
        public List<string> Tags { get; set; }
        public int TaskId { get; set; }
        [Required]
        public int Tid { get; set; }
        [Required]
        public int Uid { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Wid { get; set; }
        public int WorkspaceId { get; set; }
    }
}
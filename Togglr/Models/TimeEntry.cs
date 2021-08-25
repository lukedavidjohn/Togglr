using System;
using System.Collections.Generic;

namespace Togglr.Models
{
    public class TimeEntry
    {   
        public TimeEntry(string createdWith, int pid, int tid, bool billable, DateTime start, DateTime stop, string description, List<string> tags, int uid, int wid)
        {
            Created_With = createdWith;
            Pid = pid;
            Tid = tid;
            Billable = billable;
            Start = start;
            Stop = stop;
            Duration = 0;
            Description = description;
            Tags = tags;
            Uid = uid;
            Wid = wid;
        }
        public TimeEntry()
        {}

        public bool Billable { get; set; }

        public string Created_With { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public int Pid { get; set; }

        public DateTime Start { get; set; }

        public DateTime Stop { get; set; }

        public List<string> Tags { get; set; }

        public int Tid { get; set; }

        public int Uid { get; set; }

        public int Wid { get; set; }

        public void SetTimes()
        {
            Start = TimeZoneInfo.ConvertTimeToUtc(Start);
            Stop = TimeZoneInfo.ConvertTimeToUtc(Stop);
            Duration = (int)(Stop - Start).TotalSeconds;
        }
    }
}
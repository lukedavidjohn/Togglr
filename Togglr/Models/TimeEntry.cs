using System;
using System.Collections.Generic;

namespace Togglr.Models
{
    public class TimeEntry
    {   
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
    }
}
using System;
using System.Collections.Generic;

namespace Togglr.Models
{
    public class UserInput
    {
        public string Created_With { get; set; }
        public int Pid { get; set; }
        public int Tid { get; set; }
        public bool Billable { get; set; }
        public string Date { get; set; }
        public string Start { get; set; }
        public string Stop { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public int Uid { get; set; }
        public int Wid { get; set; }
    }
}
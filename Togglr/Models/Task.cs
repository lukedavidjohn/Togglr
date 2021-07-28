namespace Togglr.Models
{
    public sealed class Task : TogglData
    {
        public int Pid { get; set; }
        public bool Active { get; set; }
        public string EstimatedSeconds { get; set; }
    }
}
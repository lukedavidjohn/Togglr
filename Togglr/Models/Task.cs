namespace Togglr.Models
{
    public sealed class Task : TogglData
    {
        public int Pid { get; }
        public bool Active { get; }
        public string EstimatedSeconds { get; }
    }
}
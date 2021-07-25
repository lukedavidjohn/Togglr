namespace Togglr.Models
{
    sealed class Task : TogglData
    {
        public static int Pid { get; }
        public static bool Active { get; }
        public static string EstimatedSeconds { get; }
    }
}
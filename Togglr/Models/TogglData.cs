using System;

namespace Togglr.Models
{
    public abstract class TogglData
    {
        public int Id { get; }
        public int Wid { get; }
        public string Name{ get; }
		public DateTime At{ get; }
    }   
}

using System;

namespace Togglr.Models
{
    public abstract class TogglData
    {
        public int Id { get; set; }
        public int Wid { get; set; }
        public string Name{ get; set; }
		public DateTime At{ get; set; }
    }   
}

using System.Collections.Generic;
using Togglr.Models;

namespace Togglr.Services
{
    public class TagService : TogglDataService<Tag>, ITogglDataService<Tag>
    {
        public static List<Tag> Tags { get; set; }
        public TagService() : base("./TogglData/Tags.json")
        {}
    }
}
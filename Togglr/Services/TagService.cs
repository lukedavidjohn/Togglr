using Togglr.Models;
using Togglr.Utilities;

namespace Togglr.Services
{
    public class TagService : TogglDataService<Tag>, ITogglDataService<Tag>
    {
        public TagService(IJsonLoaderFromFile<Tag> jsonLoaderFromFile) : base(jsonLoaderFromFile, "./TogglData/Tags.json")
        {
        }
    }
}
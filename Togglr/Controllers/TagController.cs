using Microsoft.AspNetCore.Mvc;
using Togglr.Models;
using Togglr.Services;

namespace Togglr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : TogglDataController<Tag>, ITogglDataController<Tag>
    {
        public TagController(ITogglDataService<Tag> tagService) : base(tagService)
        {
        }
    }
}
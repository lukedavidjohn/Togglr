using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Togglr.Models;
using Togglr.Services;

namespace Togglr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase, ITogglDataController<Tag>
    {
        readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpGet("~/[controller]/[action]")]
        public ActionResult<List<Tag>> GetAll() => _tagService.GetAll();

        [HttpGet("{argument}")]
        public ActionResult<Tag> Get(string argument)
        {
            Tag tag;
            bool argumentIsInteger = int.TryParse(argument, out int argumentAsInteger);
            switch (argumentIsInteger)
            {
                case false:
                    tag = _tagService.Get(argument);
                    break;
                case true:
                    tag = _tagService.Get(argumentAsInteger);
                    break;
            }
            if(tag == null)
            {
                return NotFound();
            }
            return tag;
        }

        [HttpGet("~/[controller]/[action]")]
        public ActionResult<int> GetCount() => _tagService.GetCount();
        [HttpPost]
        public ActionResult<List<Tag>> Post(Tag body)
        {
            var tags = _tagService.Post(body);
            return Created("", tags);
        }
    }
}
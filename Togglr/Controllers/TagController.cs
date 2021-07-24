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
        public ITogglDataService<Tag> _tagService;
        public TagController(ITogglDataService<Tag> tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("{argument}")]
        public ActionResult<Tag> Get(string argument)
        {
            throw new System.NotImplementedException();
        }
        [HttpGet("~/[controller]/[action]")]
        public ActionResult<List<Tag>> GetAll() => _tagService.GetAll();

        [HttpGet("~/[controller]/[action]")]
        public ActionResult<int> GetCount()
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public ActionResult<List<Tag>> Post(Tag body)
        {
            throw new System.NotImplementedException();
        }
    }
}
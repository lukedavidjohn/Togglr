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
        readonly string tagFilePath = "./TogglData/Tags.json";
        readonly TagService tagService;
        public TagController()
        {
            tagService = new TagService(tagFilePath);
        }
        [HttpGet]
        public ActionResult<List<Tag>> GetAll() => tagService.GetAll();

        [HttpGet("{argument}")]
        public ActionResult<Tag> Get(string argument)
        {
            Tag tag;
            bool argumentIsInteger = int.TryParse(argument, out int argumentAsInteger);
            switch (argumentIsInteger)
            {
                case false:
                    tag = tagService.Get(argument);
                    break;
                case true:
                    tag = tagService.Get(argumentAsInteger);
                    break;
            }
            if(tag == null)
            {
                return NotFound();
            }
            return tag;
        }
    }
}
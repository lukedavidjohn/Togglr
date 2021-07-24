using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Togglr.Services;

namespace Togglr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class TogglDataController<T> : ControllerBase
    {
        public ITogglDataService<T> _togglDataService;

        public TogglDataController(ITogglDataService<T> togglDataService)
        {
            _togglDataService = togglDataService;
        }

        [HttpGet("~/[controller]/[action]")]
        public ActionResult<List<T>> GetAll() => _togglDataService.GetAll();
            // string authHeader = Request.Headers["Authorization"];
            // var user = UserService.GetByAuthToken(authHeader);
            // if (user == null)
            // {
            //     return NotFound();
            // }
            // if (user.IsAdminUser == false)
            // {
            //     return Unauthorized();
            // }

        [HttpGet("{argument}")]
        public ActionResult<T> Get(string argument)
        {
            T item;
            bool argumentIsInteger = int.TryParse(argument, out int argumentAsInteger);
            switch (argumentIsInteger)
            {
                case false:
                    item = _togglDataService.Get(argument);
                    break;
                case true:
                    item = _togglDataService.Get(argumentAsInteger);
                    break;
            }
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("~/[controller]/[action]")]
        public ActionResult<int> GetCount() => _togglDataService.GetCount();

        [HttpPost]
        public ActionResult<List<T>> Post(T body)
        {
            var projects = _togglDataService.Post(body);
            return Created("", projects);
        }
    }
}
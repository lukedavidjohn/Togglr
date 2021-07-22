using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Togglr.Models;

namespace Togglr.Controllers
{
    interface ITogglDataController<T> where T : TogglData
    {
        ActionResult<List<T>> GetAll();
        ActionResult<T> Get(string argument);
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Togglr.Models;

namespace Togglr.Controllers
{
    public interface ITogglDataController<T> where T : TogglData
    {
        ActionResult<T> Get(string argument);
        ActionResult<List<T>> GetAll();
        ActionResult<int> GetCount();
        ActionResult<List<T>> Post(T body);
    }
}
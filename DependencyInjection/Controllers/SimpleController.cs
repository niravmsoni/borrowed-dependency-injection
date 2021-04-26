using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DependencyInjection.Controllers
{
    public class SimpleController : ControllerBase
    {
        // simple/getall
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // simple/getitem/1
        [HttpGet]
        public string GetItem(int id)
        {
            return "value";
        }
    }
}

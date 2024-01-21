using DependencyInjection.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    [Produces("text/plain")]
    [ApiController]
    [Route("api/[controller]")]
    public class TestFilterController
    {
        //[ServiceFilter(typeof(MyServiceFilterAttribute))]
        [HttpGet]
        public string Index()
        {
            return "Hello from GetTest";
        }
    }
}

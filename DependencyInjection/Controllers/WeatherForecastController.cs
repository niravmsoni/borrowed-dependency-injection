using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly GuidService _guidService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, GuidService guidService)
        {
            _logger = logger;
            _guidService = guidService;
        }

        [HttpGet]
        public ActionResult Get([FromServices] IService service, [FromServices] GuidService guidService1,
            [FromServices] Gender gender)
        {
            //var service = new AmazingService();

            _logger.LogDebug(_guidService.Value);
            _logger.LogDebug(guidService1.Value);

            return Ok(service.GetData());
        }
    }
}

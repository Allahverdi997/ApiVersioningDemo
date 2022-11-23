using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıVersıonıngIntegratıon.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class WeatherForecastController : ControllerBase
    {
        List<int> says = new List<int>();
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            this.says.Add(1);
            this.says.Add(2);
            this.says.Add(3);
            this.says.Add(4);
            this.says.Add(5);
            this.says.Add(6);
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("index")]
        public List<int> Index()
        {
            return says;
        }
    }
}

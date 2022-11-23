using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApıVersıonıngIntegratıon.Controllers.v2
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("2.0")]
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

        
        [HttpGet("index")]
        public int Index()
        {
            return says.First();
        }
    }
}

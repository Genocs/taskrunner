using Genocs.TaskRunner.ExternalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Genocs.TaskRunner.ExternalWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizedController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AuthorizedController> _logger;

        public AuthorizedController(ILogger<AuthorizedController> logger)
        {
            _logger = logger;
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

        [HttpPost("{id}")]
        public IEnumerable<WeatherForecast> Post(string id, [FromBody] ChangeStatusSchedule message)
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

    }

    public class ChangeStatusSchedule
    {
        public string MessageId { get; set; }
        public string StatusId { get; set; }
        public string DateEvent { get; set; }
    }
}

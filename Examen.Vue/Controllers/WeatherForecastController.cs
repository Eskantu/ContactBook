﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
namespace Examen.Vue.Controllers
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
        private readonly IContactoManager _contactoManager;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IContactoManager contactoManager)
        {
            _logger = logger;
            _contactoManager = contactoManager;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var contactos = _contactoManager.ObtenerTodos(new SpParametros("SpAgendaWinForm", new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("@Opcion", 1), }));
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
}

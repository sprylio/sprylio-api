// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sprylio.Api.Controllers
{
    /// <summary>
    ///     Demo controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        private static readonly string[] ScopeRequiredByApi = { "access_as_user", };

        private readonly ILogger<WeatherForecastController> logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeatherForecastController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>The set of weather forecasts.</returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)],
                })
                .ToArray();
        }
    }
}
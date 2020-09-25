// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Sprylio.Api
{
    /// <summary>
    ///     The weather forecast data object.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Gets or sets the temperature c.
        /// </summary>
        /// <value>
        ///     The temperature c.
        /// </value>
        public int? TemperatureC { get; set; }

        /// <summary>
        ///     Gets the temperature f.
        /// </summary>
        /// <value>
        ///     The temperature f.
        /// </value>
        public int? TemperatureF => 32 + (int?)(this.TemperatureC / 0.5556);

        /// <summary>
        ///     Gets or sets the summary.
        /// </summary>
        /// <value>
        ///     The summary.
        /// </value>
        public string? Summary { get; set; }
    }
}
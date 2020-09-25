// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Sprylio.Api.Tests
{
    /// <summary>
    /// See https://adamstorr.azurewebsites.net/blog/integration-testing-with-aspnetcore-3-1.
    /// </summary>
    public class UnitTest1
    {
        [Fact]
        public async Task get_weather_forecast_returns_set_of_forecasts()
        {
            // Arrange
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();

                    // Specify the environment
                    webHost.UseEnvironment("Test");

                    webHost.Configure(app => app.Run(async ctx => await ctx.Response.WriteAsync("Hello World!")));
                });

            // Create and start up the host
            var host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            var client = host.GetTestClient();

            // Act
            var response = await client.GetAsync("/WeatherForecast");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Be("Hello World!");
        }
    }
}

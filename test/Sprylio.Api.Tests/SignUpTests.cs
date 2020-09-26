// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Sprylio.Api.Common;
using Xunit;

namespace Sprylio.Api.Tests
{
    /// <summary>
    /// See https://adamstorr.azurewebsites.net/blog/integration-testing-with-aspnetcore-3-1 and
    /// https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.0#customize-webapplicationfactory.
    /// </summary>
    public class SignupTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public SignupTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task should_be_able_to_post_a_signup()
        {
            // Arrange
            var client = this.factory.CreateClient();
            var content = new StringContent(string.Empty);

            // Act
            var response = await client.PostAsync(Routes.Signups, content);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}

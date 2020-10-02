// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Sprylio.Api.Common;
using Sprylio.Api.Model;
using Xunit;

namespace Sprylio.Api.Tests
{
    /// <summary>
    /// See https://adamstorr.azurewebsites.net/blog/integration-testing-with-aspnetcore-3-1 and
    /// https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.0#customize-webapplicationfactory.
    /// </summary>
    public class SignupTests : IClassFixture<TestWebApplicationFactory>
    {
        private readonly TestWebApplicationFactory factory;

        public SignupTests(TestWebApplicationFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task should_be_able_to_post_a_signup()
        {
            // Arrange
            var client = this.factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync(Routes.Signups, new CreateSignupData("test@test.com"));

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            response.StatusCode.Should().Be(HttpStatusCode.Accepted);
        }

        [Fact]
        public async Task should_NOT_be_able_to_post_duplicate_email_addresses()
        {
            // Arrange
            var client = this.factory.CreateClient();
            await client.PostAsJsonAsync(Routes.Signups, new CreateSignupData("test@test.com"));

            // Act
            var response = await client.PostAsJsonAsync(Routes.Signups, new CreateSignupData("test@test.com"));

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task posting_an_invalid_email_should_return_bad_request()
        {
            // Arrange
            var client = this.factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync(Routes.Signups, new CreateSignupData("foo"));

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var errorMessage = await response.Content.ReadAsStringAsync();
            errorMessage.Should().Contain("The EmailAddress field is not a valid e-mail address.");
        }
    }
}

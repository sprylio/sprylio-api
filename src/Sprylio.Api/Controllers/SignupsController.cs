// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Sprylio.Api.Common;

namespace Sprylio.Api.Controllers
{
    /// <summary>
    /// Manages signups.
    /// For routing see https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#ar.
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    public class SignupsController : ControllerBase
    {
        private readonly ILogger<SignupsController> logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SignupsController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public SignupsController(ILogger<SignupsController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Post a signup.
        /// </summary>
        /// <returns>The completed task.</returns>
        [HttpPost(Routes.Signups)]
        public Task Post()
        {
            return Task.CompletedTask;
        }
    }
}
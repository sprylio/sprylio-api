// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sprylio.Api.Common;
using Sprylio.Api.Model;

namespace Sprylio.Api.Controllers
{
    /// <summary>
    /// Manages signups.
    /// For routing see https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#ar.
    /// For a full example, see https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api.
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
        /// <param name="signup">The signup data.</param>
        /// <returns>
        /// The completed task.
        /// </returns>
        [HttpPost(Routes.Signups)]
        public IActionResult Post(Signup signup)
        {
            return this.Accepted();
        }
    }
}
﻿// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RT.Comb;
using Sprylio.Api.Common;
using Sprylio.Api.Model;
using Sprylio.Api.Repository;

namespace Sprylio.Api.Controllers
{
    /// <summary>
    ///     Manages signups.
    ///     For routing see https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#ar.
    ///     For a full example, see https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api.
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    public class SignupsController : ControllerBase
    {
        /// <summary>
        ///     Post a signup.
        /// </summary>
        /// <param name="data">The signup data.</param>
        /// <returns>
        ///     The completed task.
        /// </returns>
        [HttpPost(Routes.Signups)]
        public async Task<IActionResult> Post(CreateSignupData data)
        {
            var signup = new Signup(Provider.Sql.Create(), data.EmailAddress, DateTime.UtcNow);

            await using (var repository = new SprylioRepository())
            {
                await repository.Database.EnsureDeletedAsync();

                await repository.Database.EnsureCreatedAsync();

                await repository.Signups.AddAsync(signup);

                await repository.SaveChangesAsync();
            }

            return this.Accepted();
        }
    }
}
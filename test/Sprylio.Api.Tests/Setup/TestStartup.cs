// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Hosting;
using Xunit;

namespace Sprylio.Api.Tests.Setup
{
    /// <summary>
    ///     Configuration for the web app.
    /// </summary>
    public class TestStartup : Startup
    {
        public TestStartup(IWebHostEnvironment env)
            : base(env)
        {
        }
    }
}
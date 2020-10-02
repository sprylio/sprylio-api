// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Configuration;

namespace Sprylio.Api.Tests
{
    /// <summary>
    ///     Configuration for the web app.
    /// </summary>
    public class TestStartup : Startup
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TestStartup" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sprylio.Api.Repository;

namespace Sprylio.Api.Tests.Setup
{
    /// <summary>
    ///     Based upon
    ///     https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/test/integration-tests/samples/3.x/IntegrationTestsSample.
    /// </summary>
    /// <seealso cref="WebApplicationFactory{TEntryPoint}" />
    public class TestWebApplicationFactory : WebApplicationFactory<TestStartup>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            // From https://github.com/dotnet/aspnetcore/issues/17707#issuecomment-609061917
            builder.UseContentRoot(Directory.GetCurrentDirectory());

            return base.CreateHost(builder);
        }

        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureTestServices(services => services.AddControllers().AddApplicationPart(typeof(Program).Assembly));
                webBuilder.UseStartup<TestStartup>();
            }).UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }
    }
}
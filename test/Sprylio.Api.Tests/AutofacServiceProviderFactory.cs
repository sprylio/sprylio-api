// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Sprylio.Api.Tests
{
    /// <summary>
    ///     See https://blog.johnnyreilly.com/2020/10/autofac-6-integration-tests-and-generic-hosting.html.
    ///     Based upon https://github.com/dotnet/aspnetcore/issues/14907#issuecomment-620750841 - only necessary because of an
    ///     issue in ASP.NET Core.
    /// </summary>
    public class AutofacServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
    {
        private readonly Autofac.Extensions.DependencyInjection.AutofacServiceProviderFactory wrapped;
        private IServiceCollection? services;

        public AutofacServiceProviderFactory()
        {
            this.wrapped = new Autofac.Extensions.DependencyInjection.AutofacServiceProviderFactory();
        }

        /// <inheritdoc />
        public ContainerBuilder CreateBuilder(IServiceCollection services)
        {
            // Store the services for later.
            this.services = services;

            return this.wrapped.CreateBuilder(services);
        }

        public IServiceProvider CreateServiceProvider(ContainerBuilder containerBuilder)
        {
            var serviceProvider = this.services.BuildServiceProvider();
#pragma warning disable CS0612 // Type or member is obsolete
            var filters = serviceProvider.GetRequiredService<IEnumerable<IStartupConfigureContainerFilter<ContainerBuilder>>>();
#pragma warning restore CS0612 // Type or member is obsolete

            foreach (var filter in filters)
            {
                filter.ConfigureContainer(b => { })(containerBuilder);
            }

            return this.wrapped.CreateServiceProvider(containerBuilder);
        }
    }
}
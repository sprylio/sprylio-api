// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Autofac;

namespace Sprylio.Api.Repository
{
    /// <inheritdoc />
    public class RepositoryModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SprylioRepository>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
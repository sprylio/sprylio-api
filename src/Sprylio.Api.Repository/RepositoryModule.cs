// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Autofac;
using ExRam.Gremlinq.Core;
using ExRam.Gremlinq.Providers.WebSocket;
using Gremlin.Net.Structure;
using Microsoft.Extensions.Logging;
using Sprylio.Api.Model;

// Put this into static scope to access the default GremlinQuerySource as "g".
using static ExRam.Gremlinq.Core.GremlinQuerySource;

namespace Sprylio.Api.Repository
{
    /// <inheritdoc />
    public class RepositoryModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => g.ConfigureEnvironment(env => env

                // Since the Entity and Edge classes contained in this sample implement IVertex resp. IEdge,
                // setting a model is actually not required as long as these classes are discoverable (i.e. they reside
                // in a currently loaded assembly). We explicitly set a model here anyway.
                .UseModel(GraphModel.FromBaseTypes<Vertex, Edge>(lookup => lookup.IncludeAssembliesOfBaseTypes())

                    // For CosmosDB, we exclude the 'PartitionKey' property from being included in updates.
                    .ConfigureProperties(model => model.ConfigureElement<Entity>(conf =>
                        conf.IgnoreOnUpdate(x => x.PartitionKey))))

                // Disable query logging for a noise free console output.
                // Enable logging by setting the verbosity to anything but None.
                .ConfigureOptions(options => options.SetValue(WebSocketGremlinqOptions.QueryLogLogLevel, LogLevel.None))
                .UseCosmosDb(cosmosDbConfigurationBuilder =>
                    cosmosDbConfigurationBuilder.At(new Uri("ws://localhost:8901/"), "sprylio", "SprylioRepository")
                        .AuthenticateBy("C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==")
                        .ConfigureWebSocket(_ => _.ConfigureGremlinClient(client => client.ObserveResultStatusAttributes((requestMessage, statusAttributes) =>
                {
                    // Uncomment to log request charges for CosmosDB.
                    // if (statusAttributes.TryGetValue("x-ms-total-request-charge", out var requestCharge))
                    //    env.Logger.LogInformation($"Query {requestMessage.RequestId} had a RU charge of {requestCharge}.");
                }))))))
                .As<IGremlinQuerySource>()
                .SingleInstance();

            builder.RegisterType<SprylioRepository>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Xunit;

namespace Sprylio.Api.Tests.Setup
{
    public sealed class SetupFixture : IAsyncLifetime
    {
        private Process? cosmosDbEmulator;

        public async Task InitializeAsync()
        {
            this.cosmosDbEmulator = StartCosmosDb();
            var database = await this.CreateDatabaseIfNotExistsAsync();
            await this.DeleteContainerAsync(database);
            await this.CreateContainerAsync(database);
        }

        public Task DisposeAsync()
        {
            this.cosmosDbEmulator?.Dispose();

            return Task.CompletedTask;
        }

        private static Process? StartCosmosDb()
        {
            var cosmosDbProcesses = Process.GetProcessesByName("Microsoft.Azure.Cosmos.Emulator");

            return cosmosDbProcesses.Length == 0 ? Process.Start("C:\\Program Files\\Azure Cosmos DB Emulator\\Microsoft.Azure.Cosmos.Emulator.exe") : cosmosDbProcesses[0];
        }

        private async Task CreateContainerAsync(Database database)
        {
            await database.CreateContainerAsync("SprylioRepository", "/PartitionKey", 400);
        }

        private async Task<Database> CreateDatabaseIfNotExistsAsync()
        {
            var client = new CosmosClient("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            return await client.CreateDatabaseIfNotExistsAsync("sprylio");
        }

        private async Task DeleteContainerAsync(Database database)
        {
            try
            {
                await database.GetContainer("SprylioRepository").DeleteContainerAsync();
            }
            catch
            {
                // Doesn't exist
            }
        }
    }
}
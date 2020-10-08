// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;

namespace Sprylio.Api.Tests.Setup
{
    public sealed class SetupFixture : IDisposable
    {
        private readonly Process? cosmosDbEmulator;

        public SetupFixture()
        {
            this.cosmosDbEmulator = StartCosmosDb();
        }

        public void Dispose()
        {
            this.cosmosDbEmulator?.Dispose();
        }

        private static Process? StartCosmosDb()
        {
            var cosmosDbProcesses = Process.GetProcessesByName("CosmosDB.Emulator");

            return cosmosDbProcesses.Length == 0
                ? Process.Start("C:\\Program Files\\Azure Cosmos DB Emulator\\CosmosDB.Emulator.exe")
                : cosmosDbProcesses[0];
        }
    }
}
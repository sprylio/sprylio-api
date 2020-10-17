// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using ExRam.Gremlinq.Core;
using Sprylio.Api.Model;

namespace Sprylio.Api.Repository
{
    /// <summary>
    ///     The repository for the sprylio db.
    /// See https://medium.com/@jayanta.mondal/cosmos-db-graph-gremlin-api-how-to-executing-multiple-writes-as-a-unit-via-a-single-gremlin-2ce82d8bf365
    /// and https://github.com/ExRam/ExRam.Gremlinq/issues/62
    /// for "transaction" support.
    /// </summary>
    public class SprylioRepository
    {
        private readonly IGremlinQuerySource database;

        /// <summary>
        /// Initializes a new instance of the <see cref="SprylioRepository"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public SprylioRepository(IGremlinQuerySource database)
        {
            this.database = database;
        }

        /// <summary>
        /// Store the signup.
        /// </summary>
        /// <param name="signup">The signup.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task AddSignupAsync(Signup signup)
        {
            await this.database.AddV<Signup>(signup);
        }
    }
}
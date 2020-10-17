﻿// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sprylio.Api.Model;

namespace Sprylio.Api.Repository
{
    /// <summary>
    ///     The repository for the sprylio db.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class SprylioRepository : DbContext
    {
        /// <summary>
        ///     Gets the signups.
        /// </summary>
        /// <value>
        ///     The signups.
        /// </value>
        public DbSet<Signup> Signups => this.Set<Signup>();

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos("AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "sprylio");
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // See https://azure.microsoft.com/en-us/blog/a-fintech-startup-pivots-to-azure-cosmos-db/
            // to choose appropriate partition keys
            modelBuilder.Entity<Signup>(entity =>
            {
                entity.HasKey(signup => signup.Id);
                entity.HasPartitionKey(signup => signup.Id);
                entity.HasAlternateKey(signup => signup.EmailAddress);
                entity.Property(signup => signup.Id).HasConversion(new GuidToStringConverter());
            });
        }
    }
}
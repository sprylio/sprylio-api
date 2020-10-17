// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ExRam.Gremlinq.Core.GraphElements;

namespace Sprylio.Api.Model
{
    /// <summary>
    /// The way in which two or more entities are connected.
    /// </summary>
    /// <seealso cref="IEdge" />
    public class Relationship : IEdge
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public object? Id { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string? Label { get; set; }

        /// <summary>
        /// Gets the partition key.
        /// </summary>
        /// <value>
        /// The partition key.
        /// </value>
        public string? PartitionKey => this.Id?.ToString();
    }
}
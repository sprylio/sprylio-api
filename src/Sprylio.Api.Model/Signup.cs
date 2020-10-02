// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;

namespace Sprylio.Api.Model
{
    /// <summary>
    ///     The Signup resource.
    ///     See https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types.
    ///     and https://github.com/layomia/NET5JsonDemos/blob/master/Program.cs.
    /// </summary>
    public class Signup
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Signup" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="createdDateTime">The created date time.</param>
        public Signup(Guid id, string emailAddress, DateTime createdDateTime)
        {
            this.Id = id;
            this.EmailAddress = emailAddress;
            this.CreatedDateTime = createdDateTime;
        }

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; private set; }

        /// <summary>
        ///     Gets the email address.
        /// </summary>
        /// <value>
        ///     The email address.
        /// </value>
        [EmailAddress]
        [MaxLength(254)]
        public string EmailAddress { get; private set; }

        /// <summary>
        ///     Gets the created date time.
        /// </summary>
        /// <value>
        ///     The created date time.
        /// </value>
        public DateTime CreatedDateTime { get; private set; }
    }
}
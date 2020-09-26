// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

namespace Sprylio.Api.Model
{
    /// <summary>
    /// The Signup resource.
    /// See https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types.
    /// and https://github.com/layomia/NET5JsonDemos/blob/master/Program.cs.
    /// </summary>
    public class Signup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Signup"/> class.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        public Signup(string emailAddress)
        {
            this.EmailAddress = emailAddress;
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}

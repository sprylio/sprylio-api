// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

namespace Sprylio.Api.Model
{
    /// <summary>
    ///     Data to create a signup.
    /// </summary>
    public class CreateSignupData
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateSignupData" /> class.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        public CreateSignupData(string emailAddress)
        {
            this.EmailAddress = emailAddress;
        }

        /// <summary>
        ///     Gets the email address.
        /// </summary>
        /// <value>
        ///     The email address.
        /// </value>
        [EmailAddress]
        [MaxLength(254)]
        public string EmailAddress { get; }
    }
}
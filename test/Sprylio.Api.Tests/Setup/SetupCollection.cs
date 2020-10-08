// Copyright (c) Sprylio Inc. and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Xunit;

namespace Sprylio.Api.Tests.Setup
{
    /// <summary>
    ///     See https://xunit.github.io/docs/shared-context.html#collection-fixture.
    /// </summary>
    /// <seealso cref="Xunit.ICollectionFixture{Sprylio.Api.Tests.Setup.SetupFixture}" />
    [CollectionDefinition("SetupCollection")]
    public class SetupCollection : ICollectionFixture<SetupFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Users.Api.IntegrationTests.Configuration
{
    [CollectionDefinition("Base Collection")]
    public abstract class BaseTestCollection : ICollectionFixture<BaseTestFixture>
    {

    }
}

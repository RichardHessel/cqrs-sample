using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Users.Api.IntegrationTests.Configuration
{
    [Collection("Base Collection")]
    public abstract class BaseIntegrationTest
    {
        protected readonly TestServer testServer;
        protected readonly HttpClient client;
        protected BaseTestFixture fixture;

        protected BaseIntegrationTest(BaseTestFixture fixture)
        {
            this.fixture = fixture;
            this.testServer = fixture._server;
            this.client = fixture._client;
        }


    }
}

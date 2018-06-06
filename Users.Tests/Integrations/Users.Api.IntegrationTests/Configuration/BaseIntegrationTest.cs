using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
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
        protected DbContext dbContext;

        protected BaseIntegrationTest(BaseTestFixture fixture)
        {
            this.fixture = fixture;
            this.testServer = fixture._server;
            this.client = fixture._client;
            this.dbContext = fixture._dbContext;
            //this.dbContext.Database.EnsureDeleted();
        }


    }
}

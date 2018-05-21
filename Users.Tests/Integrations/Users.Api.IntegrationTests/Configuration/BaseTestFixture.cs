using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Users.Api.IntegrationTests.Configuration
{
    public class BaseTestFixture : IDisposable
    {
        public readonly TestServer _server;

        public readonly HttpClient _client;

        public BaseTestFixture()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }
    }
}

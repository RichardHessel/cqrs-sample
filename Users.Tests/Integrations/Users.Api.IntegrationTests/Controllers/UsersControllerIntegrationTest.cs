using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Api.IntegrationTests.Configuration;
using Users.Domain.Entities;
using Xunit;
using Xunit.Abstractions;

namespace Users.Api.IntegrationTests.Controllers
{
    public class UsersControllerIntegrationTest : BaseIntegrationTest
    {
        private const string baseUrl = "/api/users";
        private readonly ITestOutputHelper testOutput;

        public UsersControllerIntegrationTest(BaseTestFixture fixture, ITestOutputHelper testOutput) : base(fixture)
        {
            this.testOutput = testOutput;
        }

        [Fact]
        public async Task ShouldBeReturnUser()
        {
            var response = await client.GetAsync(baseUrl + "?email=richardrodrigues_h@outlook.com");
            response.EnsureSuccessStatusCode();
            User user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(user);
        }
    }
}

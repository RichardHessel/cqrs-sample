using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Users.Api.IntegrationTests.Configuration;
using Users.Api.Models.RegisterUser;
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
            NewUserModel newUser = await CreateUserAsync();

            var response = await client.GetAsync(baseUrl + $"?email={newUser.Email}");
            response.EnsureSuccessStatusCode();

            User user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());

            Assert.Equal(newUser.Name, user.Name);
            Assert.Equal(newUser.Email, user.Email);
        }

        private async Task<NewUserModel> CreateUserAsync()
        {
            NewUserModel user = new NewUserModel();
            user.Name = "richard";
            user.Email = "richard.hessel@outlook.com";
            user.Password = "12354243513d";

            var response = await client
                .PostAsync(baseUrl, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            string content = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            return user;
        }
    }
}

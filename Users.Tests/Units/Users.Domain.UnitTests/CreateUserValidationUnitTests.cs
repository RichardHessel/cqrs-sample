using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Commands.User;
using Users.Domain.Validations.User;
using Xunit;

namespace Users.Domain.UnitTests
{
    public class CreateUserValidationUnitTests
    {
        public CreateUserValidationUnitTests()
        {

        }
        [Theory]
        [InlineData("joao@teste.com","Joaozinho","m")]
        [InlineData("joao@teste.com","jo","m12345678")]
        [InlineData("joao","joaozinho","12345678")]
        [InlineData("joao","jo","s1")]
        public void ShouldBeInValid(string email, string name, string password)
        {
            CreateUserCommand createUserCommand = new CreateUserCommand
            {
                Email = email,
                Name = name,
                Password = password
            };

            var userValidation = new CreateUserValidation().Validate(createUserCommand);

            Assert.False(userValidation.IsValid);
        }

        [Fact]
        public void ShouldBeValid()
        {
            CreateUserCommand createUserCommand = new CreateUserCommand
            {
                Email = "joao@teste.com",
                Name = "João",
                Password = "Teste@123"
            };

            var userValidation = new CreateUserValidation().Validate(createUserCommand);

            Assert.True(userValidation.IsValid);
        }
    }
}

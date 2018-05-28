
using Users.Domain.Validations.User;

namespace Users.Domain.Commands.User
{
    public class CreateUserCommand : UserCommand
    {
        public string Password { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
} 
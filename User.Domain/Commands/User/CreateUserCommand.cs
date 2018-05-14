
namespace User.Domain.Commands.User
{
    public class CreateUserCommand : UserCommand
    {
        public string Password { get; set; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
} 
using Users.Domain.Core.Commands;

namespace Users.Domain.Commands.User
{
    public abstract class UserCommand : Command
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
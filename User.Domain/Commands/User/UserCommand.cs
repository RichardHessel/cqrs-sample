using User.Domain.Core.Commands;

namespace User.Domain.Commands.User
{
    public abstract class UserCommand : Command
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
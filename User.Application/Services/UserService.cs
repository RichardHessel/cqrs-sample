using System.Threading.Tasks;
using User.Application.Models.RegisterUser;
using User.Application.Services.Interfaces;
using User.Domain.Commands.User;
using User.Domain.Core.Bus;
namespace User.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMediatorHandler Bus;
        public UserService(IMediatorHandler bus)
        {
            this.Bus = bus;
        }
        public async Task AddUserAsync(NewUserModel user)
        {
            CreateUserCommand command = null; //TODO: Mapper.Map(user)
            await Bus.SendCommand(command);
        }

    }
}
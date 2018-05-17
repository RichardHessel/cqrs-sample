using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Domain.Core.Bus;
using User.Domain.Core.Notifications;
using Users.Api.Models.RegisterUser;
using Users.Domain.Commands.User;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        private readonly IMediatorHandler Bus;

        protected UsersController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler bus
            ) : base(notifications)
        {
            this.Bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync(NewUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            CreateUserCommand command = null; //TODO: Mapper.Map(user)

            await Bus.SendCommand(command);

            return Response(model);
        }
    }
}
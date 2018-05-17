using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper mapper;

        public UsersController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler bus,
            IMapper mapper
            ) : base(notifications)
        {
            this.Bus = bus;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync([FromBody]NewUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            CreateUserCommand command = mapper.Map<CreateUserCommand>(model); //TODO: Mapper.Map(user)

            await Bus.SendCommand(command);

            return Response(model);
        }
    }
}
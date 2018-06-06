using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Domain.Core.Bus;
using Users.Domain.Core.Notifications;
using Users.Api.Models.RegisterUser;
using Users.Domain.Commands.User;
using Users.Domain.Interfaces.Repositories;
using Users.Domain.QuerySide.Queries.Users;
using Users.Domain.Entities;
using Users.Api.Models.GetUser;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        private readonly IMediatorHandler Bus;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UsersController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler bus,
            IMapper mapper,
            IUserRepository userRepository
            ) : base(notifications)
        {
            this.Bus = bus;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync([FromBody]NewUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            CreateUserCommand command = mapper.Map<CreateUserCommand>(model);

            await Bus.SendCommand(command);

            return Response(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAsync(string email)
        {
            User user = await Bus.Execute(new GetUserByMailQuery(email));
            var userResult = mapper.Map<UserDetailsModel>(user);
            if (userResult is null)
                return NotFound();

            return Ok(userResult);
        }
    }
}
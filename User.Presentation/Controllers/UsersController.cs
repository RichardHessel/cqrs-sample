using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Models.RegisterUser;
using User.Application.Services.Interfaces;
using User.Domain.Core.Notifications;

namespace User.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        protected UsersController(INotificationHandler<DomainNotification> notifications,
        IUserService userService) : base(notifications)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync(NewUserModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            await userService.AddUserAsync(model);
            
            return Response(model);
        }
    }
}
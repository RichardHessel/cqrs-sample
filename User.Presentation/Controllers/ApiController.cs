using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Domain.Core.Notifications;

namespace User.Presentation.Controllers
{
    public class ApiController : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        protected ApiController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }
        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
                return Ok(result);

            return BadRequest(_notifications.GetNotifications().Select(x => x.Value));
        }
        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _notifications.Handle(new DomainNotification(code, message), 
            new System.Threading.CancellationToken()).GetAwaiter().GetResult();
        }


    }
}
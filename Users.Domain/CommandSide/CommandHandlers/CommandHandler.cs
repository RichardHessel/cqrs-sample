using MediatR;
using Users.Domain.Core.Bus;
using Users.Domain.Core.Commands;
using Users.Domain.Core.Notifications;
using Users.Domain.Interfaces;

namespace Users.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        
        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command command)
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(command.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;
            _bus.RaiseEvent(new DomainNotification("Commit", "Error"));
            return false;
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using User.Domain.Commands.User;
using User.Domain.Core.Bus;
using User.Domain.Core.Notifications;
using User.Domain.Events;
using User.Domain.Interfaces;
using User.Domain.Interfaces.Repositories;

namespace User.Domain.CommandHandlers
{
    public class UserCommandHandler : CommandHandler,
    INotificationHandler<CreateUserCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IMediatorHandler Bus;

        public UserCommandHandler(IUnitOfWork uow, IMediatorHandler bus,
        INotificationHandler<DomainNotification> notifications,
        IUserRepository userRepository) : base(uow, bus, notifications)
        {
            this.userRepository = userRepository;
            this.Bus = bus;
        }

        public async Task Handle(CreateUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }
            Domain.Entities.User user = new Domain.Entities.User(message.Name, message.Email, message.Password);

            if (await userRepository.GetByMailAsync(user.Email) != null)
            {
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "EMAIL_HAS_TAKEN"));
                return;
            }

            await userRepository.AddAsync(user);

            if (Commit())
                await Bus.RaiseEvent(new UserRegisteredEvent(user.Id, user.Email, user.Name));
        }
    }
}
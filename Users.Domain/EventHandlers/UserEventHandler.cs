using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Domain.Events;

namespace Users.Domain.EventHandlers
{
    public class UserEventHandler :
        INotificationHandler<UserRegisteredEvent>
    {
        
        public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
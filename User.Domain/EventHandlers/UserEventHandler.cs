namespace User.Domain.EventHandlers
{
    public class UserEventHandler :
        INotificationHandler<UserRegisteredEvent>
    {
        public void Handle(UserRegisteredEvent message)
        {
        }
    }
using MediatR;

namespace Users.Domain.Core.Events
{
    public interface IHandler<in T> where T : Message, INotification
    {
        void Handle(T message);
    }
}
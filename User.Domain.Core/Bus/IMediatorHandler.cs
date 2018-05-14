
using System.Threading.Tasks;
using User.Domain.Core.Commands;
using User.Domain.Core.Events;

namespace User.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
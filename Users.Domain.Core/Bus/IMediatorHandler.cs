
using MediatR;
using System.Threading.Tasks;
using Users.Domain.Core.Commands;
using Users.Domain.Core.Events;
using Users.Domain.Core.Queries;

namespace Users.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
        Task<TResponse> Execute<TResponse>(IRequest<TResponse> query);
    }
}
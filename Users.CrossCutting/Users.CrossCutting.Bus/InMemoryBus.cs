using System;
using MediatR;
using System.Threading.Tasks;
using Users.Domain.Core.Bus;
using Users.Domain.Core.Commands;
using Users.Domain.Core.Events;

namespace Users.CrossCutting.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator mediator;

        public InMemoryBus(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public Task SendCommand<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return Publish(@event);
        }

        private Task Publish<T>(T message) where T : Event
        {
            return mediator.Publish(message);
        }
    }
}

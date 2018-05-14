using System;
using User.Domain.Core.Bus;
using User.Domain.Core.Commands;
using User.Domain.Core.Events;
using MediatR;

namespace User.CrossCutting.Bus
{
    private readonly IMediator mediator;

    public class InMemoryBus : IMediatorHandler
    {
        public InMemoryBus(IMediator mediator)
        {
            this.mediator = mediator;
        }
          public Task SendCommand<T>(T command) where T : Command
        {
            return Publish(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return Publish(@event);
        }

        private Task Publish<T>(T message) where T : Message
        {
            return _mediator.Publish(message);
        }
    }
}

using System;
using MediatR;

namespace Users.Domain.Core.Events
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
        protected Message()
        {
            MessageType = this.GetType().Name;
        }
    }
}
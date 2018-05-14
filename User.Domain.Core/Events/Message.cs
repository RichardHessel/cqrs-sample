using System;
using MediatR;

namespace User.Domain.Core.Events
{
    public abstract class Message : INotification
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
        protected Message()
        {
            MessageType = this.GetType().Name;
        }
    }
}
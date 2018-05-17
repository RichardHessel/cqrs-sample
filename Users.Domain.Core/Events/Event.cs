using MediatR;
using System;

namespace Users.Domain.Core.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; protected set; }
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
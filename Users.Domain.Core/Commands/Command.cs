using System;
using FluentValidation.Results;
using Users.Domain.Core.Events;

namespace Users.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        protected Command()
        {
            Timestamp = DateTime.Now;
        }
        public abstract bool IsValid();
    }
}
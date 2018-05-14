using System;
using User.Domain.Core.Events;

namespace User.Domain.Events
{
    public class UserRegisteredEvent : Event
    {
        public UserRegisteredEvent(Guid id, string name, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
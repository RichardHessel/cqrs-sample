using System;

namespace Users.Domain.Entities
{
    public class User
    {
        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.HashPassword = password; //TODO: Fazer hash da senha
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }

    }
}
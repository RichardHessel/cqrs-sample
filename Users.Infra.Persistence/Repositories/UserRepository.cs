using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Entities;
using Users.Domain.Interfaces.Repositories;

namespace Users.Infra.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByMailAsync(string email)
        {
            return new User("richard", "richardrodrigues_h@outlook.com", "Teste@123");
        }
    }
}

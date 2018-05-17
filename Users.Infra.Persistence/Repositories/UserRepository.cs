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
        public Task AddAsync(Domain.Entities.User user)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.User> GetByMailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}

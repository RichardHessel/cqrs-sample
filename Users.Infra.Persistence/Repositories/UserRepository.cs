using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.Entities;
using Users.Domain.Interfaces.Repositories;

namespace Users.Infra.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbSet<User> _db;
        public UserRepository(DbContext context)
        {
            _db = context.Set<User>();
        }
        public Task AddAsync(User user)
        {
            return _db.AddAsync(user);
        }

        public Task<User> GetByMailAsync(string email)
        {
            return _db.Where(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}

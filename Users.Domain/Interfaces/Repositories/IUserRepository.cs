using System.Threading.Tasks;

namespace Users.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Domain.Entities.User> GetByMailAsync(string email);
        Task AddAsync(Domain.Entities.User user);
    }
}
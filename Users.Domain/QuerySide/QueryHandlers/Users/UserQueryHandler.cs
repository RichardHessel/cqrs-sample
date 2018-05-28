using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Users.Domain.Entities;
using Users.Domain.Interfaces.Repositories;
using Users.Domain.QuerySide.Queries.Users;

namespace Users.Domain.QuerySide.QueryHandlers.Users
{
    public class UserQueryHandler : IRequestHandler<GetUserByMailQuery, User>
    {
        private readonly IUserRepository userRepository;

        public UserQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<User> Handle(GetUserByMailQuery request, CancellationToken cancellationToken)
        {
            return userRepository.GetByMailAsync(request.Email);
        }
    }
}

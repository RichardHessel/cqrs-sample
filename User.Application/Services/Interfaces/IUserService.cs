using System;
using System.Threading.Tasks;
using User.Application.Models.RegisterUser;

namespace User.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(NewUserModel user);
    }
}
using System;
using Users.Domain.Core.Commands;

namespace Users.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
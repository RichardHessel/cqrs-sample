using User.Domain.Commands;
using System;
using User.Domain.Core.Commands;

namespace User.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
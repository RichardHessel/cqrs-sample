using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Core.Commands;
using Users.Domain.Interfaces;

namespace Users.Infra.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public CommandResponse Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

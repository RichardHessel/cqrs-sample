using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Core.Commands;
using Users.Domain.Interfaces;

namespace Users.Infra.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        public CommandResponse Commit()
        {
            int result = context.SaveChanges();
            return new CommandResponse(result >= 1);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

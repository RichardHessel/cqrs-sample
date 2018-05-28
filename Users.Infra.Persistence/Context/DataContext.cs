using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Users.Infra.Persistence.Context.Configuration;

namespace Users.Infra.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}

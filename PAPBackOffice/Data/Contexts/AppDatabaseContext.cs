using Microsoft.EntityFrameworkCore;
using PAPBackOffice.Data.Entities;

namespace PAPBackOffice.Data
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Colaborador> Colaborador { get; set; }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

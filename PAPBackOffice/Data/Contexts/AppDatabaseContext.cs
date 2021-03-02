using Microsoft.EntityFrameworkCore;
using PAPBackOffice.Data.Entities;

namespace PAPBackOffice.Data
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Colaborador> Colaborador { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<PedidoPrioridade> PedidoPrioridade { get; set; }

        public DbSet<PedidoEstado> PedidoEstado { get; set; }

        public DbSet<PedidoComentario> PedidoComentario { get; set; }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}

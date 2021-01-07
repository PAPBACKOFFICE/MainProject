using Microsoft.EntityFrameworkCore;
using PAPBackOffice.Data;
using PAPBackOffice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public class PedidoServico : IPedidoServico
    {
        private readonly IDbContextFactory<AppDatabaseContext> ContextFactory;

        public PedidoServico(IDbContextFactory<AppDatabaseContext> contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public async Task<List<Pedido>> ListarTodas()
        {
            using var context = ContextFactory.CreateDbContext();
            return await context
                    .Pedido
                    .Where(m => m.Activo == true)
                    .Select(s => new Pedido()
                    {
                        Id = s.Id,
                        Assunto = s.Assunto
                    }).ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> CriarPedido(Pedido Pedido)
        {
            if (Pedido == null)
                throw new NullReferenceException("O Pedido não tem dados.");

            Pedido.Activo = true;

            using var context = ContextFactory.CreateDbContext();
            context.Pedido.Add(Pedido);

            await context.SaveChangesAsync();

            return Pedido.Id;
        }

        public async Task EditarPedido(Pedido Pedido)
        {
            if (Pedido == null)
                throw new NullReferenceException("O Pedido não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            var PedidoOrigin = await context.Pedido.Where(m => m.Id == Pedido.Id).FirstOrDefaultAsync();

            PedidoOrigin.Assunto = Pedido.Assunto;
            PedidoOrigin.Descricao = Pedido.Descricao;
            PedidoOrigin.Data = Pedido.Data;
            PedidoOrigin.EmpresaId = Pedido.EmpresaId;
            PedidoOrigin.ColaboradorId = Pedido.ColaboradorId;
            PedidoOrigin.PedidoPrioridadeId = Pedido.PedidoPrioridadeId;
            PedidoOrigin.PedidoEstadoId = Pedido.PedidoEstadoId;
            PedidoOrigin.AlteradoEm = DateTime.Now;

            context.Entry(PedidoOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task InativarPedido(int Id)
        {
            using var context = ContextFactory.CreateDbContext();
            var PedidoOrigin = await context.Pedido.Where(m => m.Id == Id).FirstOrDefaultAsync();

            if (PedidoOrigin == null)
                throw new NullReferenceException("O Pedido não tem dados.");

            PedidoOrigin.Activo = false;

            context.Entry(PedidoOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}

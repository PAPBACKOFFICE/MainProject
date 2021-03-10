using Microsoft.EntityFrameworkCore;
using PAPBackOffice.Data;
using PAPBackOffice.Data.Entities;
using PAPBackOffice.Models.Pedido;
using PAPBackOffice.Pages.Common.Base;
using PAPBackOffice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public class VendasServico : IVendasServico
    {
        private readonly IDbContextFactory<AppDatabaseContext> ContextFactory;

        public VendasServico(IDbContextFactory<AppDatabaseContext> contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public async Task<List<Vendas>> ListarTodas()
        {
            using var context = ContextFactory.CreateDbContext();
            return await context
                    .Vendas
                    .Where(m => m.efetuado == true)
                    .Select(s => new Vendas()
                    {
                        Id = s.Id,
                        produto = s.produto
                    })
                    .ToListAsync()
                    .ConfigureAwait(false);
        }
        public async Task<int> CriarVendas(Vendas Vendas)
        {
            if (Vendas == null)
                throw new NullReferenceException("A Venda não tem dados.");

            Vendas.produto = "";
            Vendas.CriadoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            Vendas.AlteradoEm = DateTime.Now;
            Vendas.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            Vendas.efetuado = true;

            using var context = ContextFactory.CreateDbContext();
            context.Vendas.Add(Vendas);

            await context.SaveChangesAsync();

            return Vendas.Id;
        }

        public async Task EditarVenda(Vendas Vendas)
        {
            if (Vendas == null)
                throw new NullReferenceException("A Vendas não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            var VendaOrigin = await context.Vendas.Where(m => m.Id == Vendas.Id).FirstOrDefaultAsync();
            if (VendaOrigin == null)
                throw new NullReferenceException("A Venda não foi encontrada ou não existe.");

            VendaOrigin.produto= Vendas.produto;
            VendaOrigin.preco = Vendas.preco;
            VendaOrigin.quantidade = Vendas.quantidade;
            VendaOrigin.CriadoPor = Vendas.CriadoPor;
            VendaOrigin.CriadoEm = Vendas.CriadoEm;
            VendaOrigin.AlteradoEm = DateTime.Now;
            VendaOrigin.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado

            context.Entry(VendaOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task CancelarVenda(int Id)
        {
            using var context = ContextFactory.CreateDbContext();

            var VendasOrigin = await context.Vendas.Where(m => m.Id == Id).FirstOrDefaultAsync();
            if (VendasOrigin == null)
                throw new NullReferenceException("A Venda não foi encontrada ou não existe.");

            VendasOrigin.AlteradoEm = DateTime.Now;
            VendasOrigin.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            VendasOrigin.efetuado = false;

            context.Entry(VendasOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}

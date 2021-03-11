using Microsoft.EntityFrameworkCore;
using PAPBackOffice.Data;
using PAPBackOffice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public class FaturaServico : IFaturaServico
    {
        private readonly IDbContextFactory<AppDatabaseContext> ContextFactory;

        public FaturaServico(IDbContextFactory<AppDatabaseContext> contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public async Task<List<Fatura>> ListarTodos()
        {
            using var context = ContextFactory.CreateDbContext();
            return await context
                    .Fatura
                    .ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<Fatura>> Listar(Expression<Func<Fatura, bool>> query)
        {
            using var context = ContextFactory.CreateDbContext();
            return await context
                    .Fatura
                    .Where(query)
                    .Include(m => m.Empresa)
                    .Include(m => m.FaturaEstado)
                    .Include(m => m.Colaborador)
                    .ToListAsync();
        }

        public async Task<int> CriarFatura(Fatura Fatura)
        {
            if (Fatura == null)
                throw new NullReferenceException("O Fatura não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            //Fatura.CriadoEm = DateTime.Now;
            //Fatura.CriadoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            //Fatura.AlteradoEm = DateTime.Now;
            //Fatura.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            //Fatura.Activo = true;

            context.Fatura.Add(Fatura);

            await context.SaveChangesAsync();

            return Fatura.Id;
        }

        public async Task CreditarFatura(Fatura Fatura)
        {
            if (Fatura == null)
                throw new NullReferenceException("O Fatura não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            var FaturaOrigin = await context.Fatura.FirstOrDefaultAsync(m => m.Id == Fatura.Id);
            if (FaturaOrigin == null)
                throw new NullReferenceException("O Fatura não foi encontrado ou não existe.");

            //FaturaOrigin.Nome = Fatura.Nome;
            //FaturaOrigin.Telefone = Fatura.Telefone;
            //FaturaOrigin.Email = Fatura.Email;
            //FaturaOrigin.Funcao = Fatura.Funcao;
            //FaturaOrigin.AlteradoEm = DateTime.Now;
            //FaturaOrigin.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado

            context.Entry(FaturaOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task<int> NumeroProximaFatura()
        {
            using var context = ContextFactory.CreateDbContext();
            return await context
                    .Fatura
                    .MaxAsync(m => m.Id);
        }
    }
}

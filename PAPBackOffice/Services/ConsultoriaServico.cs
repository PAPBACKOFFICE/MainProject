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
    public class ConsultoriaServico : IConsultoriaServico
    {
        private readonly IDbContextFactory<AppDatabaseContext> ContextFactory;

        public ConsultoriaServico(IDbContextFactory<AppDatabaseContext> contextFactory)
        {
            ContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public async Task<List<Consultoria>> ListarTodas()
        {
            using var context = ContextFactory.CreateDbContext();

            return await context
                    .Consultoria
                    .Where(m => m.Activo == true)
                    .Select(s => new Consultoria()
                    {
                        Id = s.Id,
                        Nome = s.Nome
                    }).ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<Consultoria>> Listar(Expression<Func<Consultoria, bool>> query)
        {
            using var context = ContextFactory.CreateDbContext();

            return await context
                    .Consultoria
                    .Where(query)
                    .ToListAsync();
        }

        public async Task<int> CriarConsultoria(Consultoria Consultoria, string userName)
        {
            if (Consultoria == null)
                throw new NullReferenceException("O Consultoria não tem dados.");

            Consultoria.Activo = true;

            using var context = ContextFactory.CreateDbContext();
            context.Consultoria.Add(Consultoria);

            await context.SaveChangesAsync();

            return Consultoria.Id;
        }

        public async Task EditarConsultoria(Consultoria Consultoria)
        {
            if (Consultoria == null)
                throw new NullReferenceException("O Consultoria não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            var ConsultoriaOrigin = await context.Consultoria.Where(m => m.Id == Consultoria.Id).FirstOrDefaultAsync();
            if (ConsultoriaOrigin == null)
                throw new NullReferenceException("O Consultoria não foi encontrado ou não existe.");

            ConsultoriaOrigin.Nome = Consultoria.Nome;
            ConsultoriaOrigin.Descricao = Consultoria.Descricao;
            ConsultoriaOrigin.PrecoBase = Consultoria.PrecoBase;

            context.Entry(ConsultoriaOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task InativarConsultoria(int Id)
        {
            using var context = ContextFactory.CreateDbContext();

            var ConsultoriaOrigin = await context.Consultoria.Where(m => m.Id == Id).FirstOrDefaultAsync();
            if (ConsultoriaOrigin == null)
                throw new NullReferenceException("O Consultoria não foi encontrado ou não existe.");

            ConsultoriaOrigin.Activo = false;

            context.Entry(ConsultoriaOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}

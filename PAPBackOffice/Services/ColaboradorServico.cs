using Microsoft.EntityFrameworkCore;
using PAPBackOffice.Data;
using PAPBackOffice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public class ColaboradorServico : IColaboradorServico
    {
        private readonly IDbContextFactory<AppDatabaseContext> ContextFactory;

        public ColaboradorServico(IDbContextFactory<AppDatabaseContext> contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public async Task<List<Colaborador>> ListarTodos()
        {
            using var context = ContextFactory.CreateDbContext();
            return await context
                    .Colaborador
                    .Where(m => m.Activo == true)
                    .Select(s => new Colaborador()
                    {
                        Id = s.Id,
                        Nome = s.Nome
                    }).ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> CriarColaborador(Colaborador colaborador)
        {
            if (colaborador == null)
                throw new NullReferenceException("A Colaborador não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            colaborador.Activo = true;

            context.Colaborador.Add(colaborador);

            await context.SaveChangesAsync();

            return colaborador.Id;
        }

        public async Task EditarColaborador(Colaborador colaborador)
        {
            if (colaborador == null)
                throw new NullReferenceException("A Colaborador não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            var colaboradorOrigin = await context.Colaborador.FirstOrDefaultAsync(m => m.Id == colaborador.Id);

            colaboradorOrigin.Nome = colaborador.Nome;
            colaboradorOrigin.Telefone = colaborador.Telefone;
            colaboradorOrigin.Email = colaborador.Email;
            colaboradorOrigin.Funcao = colaborador.Funcao;

            context.Entry(colaboradorOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task InativarColaborador(int Id)
        {
            using var context = ContextFactory.CreateDbContext();

            var colaboradorOrigin = await context.Colaborador.FirstOrDefaultAsync(m => m.Id == Id);

            if (colaboradorOrigin == null)
                throw new NullReferenceException("O Colaborador não tem dados.");

            colaboradorOrigin.Activo = false;

            context.Entry(colaboradorOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}

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

        public async Task<int> CriarColaborador(Colaborador Colaborador)
        {
            if (Colaborador == null)
                throw new NullReferenceException("O Colaborador não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            Colaborador.CriadoEm = DateTime.Now;
            Colaborador.CriadoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            Colaborador.AlteradoEm = DateTime.Now;
            Colaborador.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            Colaborador.Activo = true;

            context.Colaborador.Add(Colaborador);

            await context.SaveChangesAsync();

            return Colaborador.Id;
        }

        public async Task EditarColaborador(Colaborador Colaborador)
        {
            if (Colaborador == null)
                throw new NullReferenceException("O Colaborador não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            var ColaboradorOrigin = await context.Colaborador.FirstOrDefaultAsync(m => m.Id == Colaborador.Id);
            if (ColaboradorOrigin == null)
                throw new NullReferenceException("O Colaborador não foi encontrado ou não existe.");

            ColaboradorOrigin.Nome = Colaborador.Nome;
            ColaboradorOrigin.Telefone = Colaborador.Telefone;
            ColaboradorOrigin.Email = Colaborador.Email;
            ColaboradorOrigin.Funcao = Colaborador.Funcao;
            ColaboradorOrigin.AlteradoEm = DateTime.Now;
            ColaboradorOrigin.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado

            context.Entry(ColaboradorOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task InativarColaborador(int Id)
        {
            using var context = ContextFactory.CreateDbContext();

            var ColaboradorOrigin = await context.Colaborador.FirstOrDefaultAsync(m => m.Id == Id);
            if (ColaboradorOrigin == null)
                throw new NullReferenceException("O Colaborador não foi encontrado ou não existe.");

            ColaboradorOrigin.AlteradoEm = DateTime.Now;
            ColaboradorOrigin.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            ColaboradorOrigin.Activo = false;

            context.Entry(ColaboradorOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}

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
    public class EmpresaServico : IEmpresaServico
    {
        private readonly IDbContextFactory<AppDatabaseContext> ContextFactory;

        public EmpresaServico(IDbContextFactory<AppDatabaseContext> contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public async Task<List<Empresa>> ListarTodas()
        {
            using var context = ContextFactory.CreateDbContext();
            return await context
                    .Empresa
                    .Where(m => m.Activo == true)
                    .Select(s => new Empresa()
                    {
                        Id = s.Id,
                        Nome = s.Nome
                    })
                    .ToListAsync()
                    .ConfigureAwait(false);
        }

        public async Task<List<Empresa>> Listar(Expression<Func<Empresa, bool>> query)
        {
            using var context = ContextFactory.CreateDbContext();
            return await context
                    .Empresa
                    .Where(query)
                    .ToListAsync()
                    .ConfigureAwait(false);
        }

        public async Task<int> CriarEmpresa(Empresa Empresa)
        {
            if (Empresa == null)
                throw new NullReferenceException("A empresa não tem dados.");

            Empresa.CriadoEm = DateTime.Now;
            Empresa.CriadoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            Empresa.AlteradoEm = DateTime.Now;
            Empresa.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            Empresa.Activo = true;

            using var context = ContextFactory.CreateDbContext();
            context.Empresa.Add(Empresa);
            
            await context.SaveChangesAsync();

            return Empresa.Id;
        }

        public async Task EditarEmpresa(Empresa Empresa)
        {
            if (Empresa == null)
                throw new NullReferenceException("A empresa não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            var EmpresaOrigin = await context.Empresa.Where(m => m.Id == Empresa.Id).FirstOrDefaultAsync();
            if (EmpresaOrigin == null)
                throw new NullReferenceException("A Empresa não foi encontrado ou não existe.");

            EmpresaOrigin.NIF = Empresa.NIF;
            EmpresaOrigin.Nome = Empresa.Nome;
            EmpresaOrigin.Telefone = Empresa.Telefone;
            EmpresaOrigin.Email = Empresa.Email;
            EmpresaOrigin.Morada = Empresa.Morada;
            EmpresaOrigin.CodigoPostal = Empresa.CodigoPostal;
            EmpresaOrigin.Localidade = Empresa.Localidade;
            EmpresaOrigin.Website = Empresa.Website;
            EmpresaOrigin.AlteradoEm = DateTime.Now;
            EmpresaOrigin.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado

            context.Entry(EmpresaOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task InativarEmpresa(int Id)
        {
            using var context = ContextFactory.CreateDbContext();

            var EmpresaOrigin = await context.Empresa.Where(m => m.Id == Id).FirstOrDefaultAsync();
            if (EmpresaOrigin == null)
                throw new NullReferenceException("A Empresa não foi encontrado ou não existe.");

            EmpresaOrigin.AlteradoEm = DateTime.Now;
            EmpresaOrigin.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            EmpresaOrigin.Activo = false;

            context.Entry(EmpresaOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}

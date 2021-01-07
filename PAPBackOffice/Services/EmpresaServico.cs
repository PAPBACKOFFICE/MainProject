using Microsoft.EntityFrameworkCore;
using PAPBackOffice.Data;
using PAPBackOffice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    }).ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> CriarEmpresa(Empresa empresa)
        {
            if (empresa == null)
                throw new NullReferenceException("A empresa não tem dados.");

            empresa.Activo = true;

            using var context = ContextFactory.CreateDbContext();
            context.Empresa.Add(empresa);
            
            await context.SaveChangesAsync();

            return empresa.Id;
        }

        public async Task EditarEmpresa(Empresa empresa)
        {
            if (empresa == null)
                throw new NullReferenceException("A empresa não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            var empresaOrigin = await context.Empresa.Where(m => m.Id == empresa.Id).FirstOrDefaultAsync();

            empresaOrigin.NIF = empresa.NIF;
            empresaOrigin.Nome = empresa.Nome;
            empresaOrigin.Telefone = empresa.Telefone;
            empresaOrigin.Email = empresa.Email;
            empresaOrigin.Morada = empresa.Morada;
            empresaOrigin.CodigoPostal = empresa.CodigoPostal;
            empresaOrigin.Localidade = empresa.Localidade;
            empresaOrigin.Website = empresa.Website;

            context.Entry(empresaOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task InativarEmpresa(int Id)
        {
            using var context = ContextFactory.CreateDbContext();
            var empresaOrigin = await context.Empresa.Where(m => m.Id == Id).FirstOrDefaultAsync();

            if (empresaOrigin == null)
                throw new NullReferenceException("A empresa não tem dados.");

            empresaOrigin.Activo = false;

            context.Entry(empresaOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}

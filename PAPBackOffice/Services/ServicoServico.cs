using Microsoft.EntityFrameworkCore;
using PAPBackOffice.Data;
using PAPBackOffice.Data.Entities;
using PAPBackOffice.Models.Pedido;
using PAPBackOffice.Pages.Common.Base;
using PAPBackOffice.Services.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public class ServicoServico : IServicoServico
    {
        private readonly IDbContextFactory<AppDatabaseContext> ContextFactory;

        public ServicoServico(IDbContextFactory<AppDatabaseContext> contextFactory)
        {
            ContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public async Task<List<Servico>> ListarTodas()
        {
            using var context = ContextFactory.CreateDbContext();

            return await context
                    .Servico
                    .Where(m => m.Activo == true)
                    .Select(s => new Servico()
                    {
                        Id = s.Id,
                        Nome = s.Nome
                    }).ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<Servico>> Listar(Expression<Func<Servico, bool>> query)
        {
            using var context = ContextFactory.CreateDbContext();

            return await context
                    .Servico
                    .Where(query)
                    .ToListAsync();
        }

        public async Task<PagedResult<EmpresaServicoDTO>> ListarServicosPorEmpresa(int Page, int PageSize, int EmpresaId)
        {
            using var context = ContextFactory.CreateDbContext();

            var empresaServicos = new PagedResult<EmpresaServicoDTO>()
            {
                PagingData = new PagedResultBase()
                {
                    PageSize = PageSize,
                    CurrentPage = Page
                }
            };

            var query = context
                    .EmpresaServico
                    .Where(m => m.EmpresaId == EmpresaId)
                    .AsQueryable();

            //if (companyFilterInput != null)
            //{
            //    if (!string.IsNullOrEmpty(companyFilterInput.Search))
            //    {
            //        query = query.Where(
            //            m => m.Name.Contains(companyFilterInput.Search) ||
            //            m.FiscalNumber.Contains(companyFilterInput.Search) ||
            //            m.GS1_CompanyEmail.Any(e => e.GS1_Email.Email.Contains(companyFilterInput.Search)) ||
            //            m.GS1_CompanyPhoneNumber.Any(e => e.GS1_PhoneNumber.Number.Contains(companyFilterInput.Search))
            //        );
            //    }

            //    if (companyFilterInput.CompanyStatusId.HasValue && companyFilterInput.CompanyStatusId.Value != 0)
            //    {
            //        query = query.Where(m => m.GS1_CompanyStatusId == companyFilterInput.CompanyStatusId.Value);
            //    }
            //}

            empresaServicos.PagingData.FilteredCount = await query.CountAsync();
            empresaServicos.PagingData.PageCount = (int)Math.Ceiling((decimal)((empresaServicos.PagingData.FilteredCount * 1.0) / (empresaServicos.PagingData.PageSize * 1.0)));

            if (empresaServicos.PagingData.FilteredCount > 0)
            {
                if (empresaServicos.PagingData.CurrentPage > empresaServicos.PagingData.PageCount)
                    empresaServicos.PagingData.CurrentPage = empresaServicos.PagingData.FirstPage;

                empresaServicos.Results = await query
                    .OrderByDescending(m => m.Data)
                    .Skip((empresaServicos.PagingData.CurrentPage - 1) * empresaServicos.PagingData.PageSize)
                    .Take(empresaServicos.PagingData.PageSize)
                    .Select(m => new EmpresaServicoDTO()
                    {
                        Servico = m.Servico.Nome,
                        Valor = m.Servico.PrecoBase,
                        CriadoEm = m.Data,
                        Estado = m.EmpresaServicoEstado.Nome
                    })
                    .ToListAsync();
            }

            return empresaServicos;
        }

        public async Task<EmpresaServico> CriarNovoServicoEmpresa(EmpresaServico empresaServico, string userName)
        {
            if (empresaServico == null)
                throw new NullReferenceException("O serviço não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            var empresaServicoEstado = await context.EmpresaServicoEstado.FirstOrDefaultAsync(m => m.Codigo == EmpresaServicoEstadoDefinitions.EMPRESA_SERVICO_ATIVO.ToString());

            empresaServico.Data = DateTime.Now;
            empresaServico.EmpresaServicoEstadoId = empresaServicoEstado.Id;

            context.EmpresaServico.Add(empresaServico);

            await context.SaveChangesAsync();

            return empresaServico;
        }

        public async Task<int> CriarServico(Servico Servico, string userName)
        {
            if (Servico == null)
                throw new NullReferenceException("O Servico não tem dados.");

            Servico.Activo = true;

            using var context = ContextFactory.CreateDbContext();
            context.Servico.Add(Servico);

            await context.SaveChangesAsync();

            return Servico.Id;
        }

        public async Task EditarServico(Servico Servico)
        {
            if (Servico == null)
                throw new NullReferenceException("O Servico não tem dados.");

            using var context = ContextFactory.CreateDbContext();

            var ServicoOrigin = await context.Servico.Where(m => m.Id == Servico.Id).FirstOrDefaultAsync();
            if (ServicoOrigin == null)
                throw new NullReferenceException("O Servico não foi encontrado ou não existe.");

            ServicoOrigin.Nome = Servico.Nome;
            ServicoOrigin.Descricao = Servico.Descricao;
            ServicoOrigin.PrecoBase = Servico.PrecoBase;

            context.Entry(ServicoOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task InativarServico(int Id)
        {
            using var context = ContextFactory.CreateDbContext();

            var ServicoOrigin = await context.Servico.Where(m => m.Id == Id).FirstOrDefaultAsync();
            if (ServicoOrigin == null)
                throw new NullReferenceException("O Servico não foi encontrado ou não existe.");

            ServicoOrigin.Activo = false;

            context.Entry(ServicoOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}

using Microsoft.EntityFrameworkCore;
using PAPBackOffice.Data;
using PAPBackOffice.Data.Entities;
using PAPBackOffice.Models.Pedido;
using PAPBackOffice.Pages.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<Pedido>> Listar(Expression<Func<Pedido, bool>> query)
        {
            using var context = ContextFactory.CreateDbContext();
            return await context
                    .Pedido
                    .Where(query)
                    .Include(m => m.Colaborador)
                    .Include(m => m.Empresa)
                    .Include(m => m.PedidoEstado)
                    .Include(m => m.PedidoPrioridade)
                    .ToListAsync();
        }

        public async Task<PagedResult<PedidoComentarioDTO>> ListarComentariosPorPedido(int Page, int PageSize, int PedidoId)
        {
            using var context = ContextFactory.CreateDbContext();

            var pedidoComentarios = new PagedResult<PedidoComentarioDTO>()
            {
                PagingData = new PagedResultBase()
                {
                    PageSize = PageSize,
                    CurrentPage = Page
                }
            };

            var query = context
                    .PedidoComentario
                    .Where(m => m.PedidoId == PedidoId)
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

            pedidoComentarios.PagingData.FilteredCount = await query.CountAsync();
            pedidoComentarios.PagingData.PageCount = (int)Math.Ceiling((decimal)((pedidoComentarios.PagingData.FilteredCount * 1.0) / (pedidoComentarios.PagingData.PageSize * 1.0)));

            if (pedidoComentarios.PagingData.FilteredCount > 0)
            {
                if (pedidoComentarios.PagingData.CurrentPage > pedidoComentarios.PagingData.PageCount)
                    pedidoComentarios.PagingData.CurrentPage = pedidoComentarios.PagingData.FirstPage;

                pedidoComentarios.Results = await query
                    .OrderByDescending(m => m.CriadoEm)
                    .Skip((pedidoComentarios.PagingData.CurrentPage - 1) * pedidoComentarios.PagingData.PageSize)
                    .Take(pedidoComentarios.PagingData.PageSize)
                    .Select(m => new PedidoComentarioDTO()
                    {
                        Comentario = m.Comentario,
                        CriadoEm = m.CriadoEm,
                        CriadoPor = m.CriadoPor
                    })
                    .ToListAsync();
            }

            return pedidoComentarios;
        }

        public async Task<PedidoComentario> CriarNovoComentario(PedidoComentario pedidoComentario, string userName)
        {
            if (pedidoComentario == null)
                throw new NullReferenceException("O comentario não tem dados.");

            pedidoComentario.CriadoEm = DateTime.Now;
            pedidoComentario.CriadoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            pedidoComentario.AlteradoEm = DateTime.Now;
            pedidoComentario.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            pedidoComentario.Activo = true;

            using var context = ContextFactory.CreateDbContext();

            context.PedidoComentario.Add(pedidoComentario);

            await context.SaveChangesAsync();

            return pedidoComentario;
        }


        public async Task<int> CriarPedido(Pedido Pedido, string userName)
        {
            if (Pedido == null)
                throw new NullReferenceException("O Pedido não tem dados.");

            Pedido.CriadoEm = DateTime.Now;
            Pedido.CriadoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            Pedido.AlteradoEm = DateTime.Now;
            Pedido.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado
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
            if (PedidoOrigin == null)
                throw new NullReferenceException("O Pedido não foi encontrado ou não existe.");

            PedidoOrigin.Assunto = Pedido.Assunto;
            PedidoOrigin.Descricao = Pedido.Descricao;
            PedidoOrigin.Data = Pedido.Data;
            PedidoOrigin.EmpresaId = Pedido.EmpresaId;
            PedidoOrigin.ColaboradorId = Pedido.ColaboradorId;
            PedidoOrigin.PedidoPrioridadeId = Pedido.PedidoPrioridadeId;
            PedidoOrigin.PedidoEstadoId = Pedido.PedidoEstadoId;
            PedidoOrigin.AlteradoEm = DateTime.Now;
            PedidoOrigin.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado

            context.Entry(PedidoOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public async Task InativarPedido(int Id)
        {
            using var context = ContextFactory.CreateDbContext();

            var PedidoOrigin = await context.Pedido.Where(m => m.Id == Id).FirstOrDefaultAsync();
            if (PedidoOrigin == null)
                throw new NullReferenceException("O Pedido não foi encontrado ou não existe.");

            PedidoOrigin.AlteradoEm = DateTime.Now;
            PedidoOrigin.AlteradoPor = ""; // TODO: Substituir pelo nome do utilizador logado
            PedidoOrigin.Activo = false;

            context.Entry(PedidoOrigin).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}

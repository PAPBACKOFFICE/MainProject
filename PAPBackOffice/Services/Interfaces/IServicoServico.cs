using PAPBackOffice.Data.Entities;
using PAPBackOffice.Models.Pedido;
using PAPBackOffice.Pages.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IServicoServico
    {
        Task<EmpresaServico> CriarNovoServicoEmpresa(EmpresaServico empresaServico, string userName);
        Task<int> CriarServico(Servico Consultoria, string userName);
        Task EditarServico(Servico Consultoria);
        Task InativarServico(int Id);
        Task<List<Servico>> Listar(Expression<Func<Servico, bool>> query);
        Task<PagedResult<EmpresaServicoDTO>> ListarServicosPorEmpresa(int Page, int PageSize, int EmpresaId);
        Task<List<Servico>> ListarTodas();
    }
}
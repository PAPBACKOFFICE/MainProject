using PAPBackOffice.Data.Entities;
using PAPBackOffice.Models.Pedido;
using PAPBackOffice.Pages.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IPedidoServico
    {
        Task<PedidoComentario> CriarNovoComentario(PedidoComentario pedidoComentario, string userName);
        Task<int> CriarPedido(Pedido Pedido, string userName);
        Task EditarPedido(Pedido Pedido);
        Task<bool> FecharPedido(int Id);
        Task<bool> MeterPedidoEmEspera(int Id);
        Task<bool> DescartarPedido(int Id);
        Task<bool> CancelarPedido(int Id);
        Task InativarPedido(int Id);
        Task<List<Pedido>> Listar(Expression<Func<Pedido, bool>> query);
        Task<PagedResult<PedidoComentarioDTO>> ListarComentariosPorPedido(int Page, int PageSize, int PedidoId);
        Task<List<Pedido>> ListarTodas();
    }
}
using PAPBackOffice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IPedidoServico
    {
        Task<int> CriarPedido(Pedido Pedido);
        Task EditarPedido(Pedido Pedido);
        Task InativarPedido(int Id);
        Task<List<Pedido>> Listar(Expression<Func<Pedido, bool>> query);
        Task<List<Pedido>> ListarTodas();
    }
}
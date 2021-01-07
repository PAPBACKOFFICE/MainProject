using PAPBackOffice.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IPedidoServico
    {
        Task<int> CriarPedido(Pedido Pedido);
        Task EditarPedido(Pedido Pedido);
        Task InativarPedido(int Id);
        Task<List<Pedido>> ListarTodas();
    }
}
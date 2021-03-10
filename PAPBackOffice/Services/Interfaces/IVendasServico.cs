using PAPBackOffice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Services.Interfaces
{
    public interface IVendasServico
    {
        Task<int> CriarVendas(Vendas Vendas);
        Task EditarEmpresa(Empresa empresa);
        Task InativarEmpresa(int Id);
        Task<List<Empresa>> Listar(Expression<Func<Empresa, bool>> query);
        Task<List<Empresa>> ListarTodas();
    }
}

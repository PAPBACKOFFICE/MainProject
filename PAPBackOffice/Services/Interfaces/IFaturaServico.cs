using PAPBackOffice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IFaturaServico
    {
        Task CreditarFatura(Fatura Fatura);
        Task<int> CriarFatura(Fatura Fatura);
        Task<List<Fatura>> Listar(Expression<Func<Fatura, bool>> query);
        Task<List<Fatura>> ListarTodos();
        Task<int> NumeroProximaFatura();
    }
}
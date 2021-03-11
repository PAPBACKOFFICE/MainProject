using PAPBackOffice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IConsultoriaServico
    {
        Task<int> CriarConsultoria(Consultoria Consultoria, string userName);
        Task EditarConsultoria(Consultoria Consultoria);
        Task InativarConsultoria(int Id);
        Task<List<Consultoria>> Listar(Expression<Func<Consultoria, bool>> query);
        Task<List<Consultoria>> ListarTodas();
    }
}
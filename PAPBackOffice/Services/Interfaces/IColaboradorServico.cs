using PAPBackOffice.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IColaboradorServico
    {
        Task<int> CriarColaborador(Colaborador colaborador);
        Task EditarColaborador(Colaborador colaborador);
        Task InativarColaborador(int Id);
        Task<List<Colaborador>> ListarTodos();
    }
}
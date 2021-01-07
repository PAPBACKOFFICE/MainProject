using PAPBackOffice.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IEmpresaServico
    {
        Task<int> CriarEmpresa(Empresa empresa);
        Task EditarEmpresa(Empresa empresa);
        Task InativarEmpresa(int Id);
        Task<List<Empresa>> ListarTodas();
    }
}
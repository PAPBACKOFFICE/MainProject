using PAPBackOffice.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IEmpresaServico
    {
        int CriarEmpresa(Empresa empresa);
        void EditarEmpresa(Empresa empresa);
        void InativarEmpresa(int Id);
        List<Empresa> ListarTodas();
    }
}
using PAPBackOffice.Data.Entities;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IColaboradorServico
    {
        int CriarColaborador(Colaborador colaborador);
        void EditarColaborador(Colaborador colaborador);
        void InativarColaborador(int Id);
    }
}
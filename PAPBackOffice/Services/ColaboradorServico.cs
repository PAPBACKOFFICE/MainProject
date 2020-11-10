using PAPBackOffice.Data.Entities;
using PAPBackOffice.Data.Repository;
using System;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public class ColaboradorServico : IColaboradorServico
    {
        private readonly IRepository repository;

        public ColaboradorServico(IRepository repository)
        {
            this.repository = repository;
        }

        public int CriarColaborador(Colaborador colaborador)
        {
            if (colaborador == null)
                throw new NullReferenceException("A Colaborador não tem dados.");

            colaborador.Activo = true;

            repository.Create(colaborador);

            return colaborador.Id;
        }

        public void EditarColaborador(Colaborador colaborador)
        {
            if (colaborador == null)
                throw new NullReferenceException("A Colaborador não tem dados.");

            var colaboradorOriginal = repository.Find<Colaborador>(m => m.Id == colaborador.Id);

            colaboradorOriginal.Nome = colaborador.Nome;
            colaboradorOriginal.Telefone = colaborador.Telefone;
            colaboradorOriginal.Email = colaborador.Email;
            colaboradorOriginal.Funcao = colaborador.Funcao;

            repository.Update(colaboradorOriginal);
        }

        public void InativarColaborador(int Id)
        {
            var colaborador = repository.Find<Colaborador>(m => m.Id == Id);

            if (colaborador == null)
                throw new NullReferenceException("O Colaborador não tem dados.");

            colaborador.Activo = false;

            repository.Delete(colaborador);
        }

    }
}

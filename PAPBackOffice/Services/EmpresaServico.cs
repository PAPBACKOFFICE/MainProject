using PAPBackOffice.Data.Entities;
using PAPBackOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAPBackOffice.Services
{
    public class EmpresaServico : IEmpresaServico
    {
        private readonly IRepository repository;

        public EmpresaServico(IRepository repository)
        {
            this.repository = repository;
        }

        public List<Empresa> ListarTodas()
        {
            return repository
                    .Query<Empresa>()
                    .Where(m => m.Activo == true)
                    .Select(s => new Empresa()
                    {
                        Id = s.Id,
                        Nome = s.Nome
                    }).ToList();
        }

        public int CriarEmpresa(Empresa empresa)
        {
            if (empresa == null)
                throw new NullReferenceException("A empresa não tem dados.");

            empresa.Activo = true;

            repository.Create(empresa);

            return empresa.Id;
        }

        public void EditarEmpresa(Empresa empresa)
        {
            if (empresa == null)
                throw new NullReferenceException("A empresa não tem dados.");

            var empresaOriginal = repository.Find<Empresa>(m => m.Id == empresa.Id);

            empresaOriginal.NIF = empresa.NIF;
            empresaOriginal.Nome = empresa.Nome;
            empresaOriginal.Telefone = empresa.Telefone;
            empresaOriginal.Email = empresa.Email;
            empresaOriginal.Morada = empresa.Morada;
            empresaOriginal.CodigoPostal = empresa.CodigoPostal;
            empresaOriginal.Localidade = empresa.Localidade;
            empresaOriginal.Website = empresa.Website;

            repository.Update(empresaOriginal);
        }

        public void InativarEmpresa(int Id)
        {
            var empresa = repository.Find<Empresa>(m => m.Id == Id);

            if (empresa == null)
                throw new NullReferenceException("A empresa não tem dados.");

            empresa.Activo = false;

            repository.Delete(empresa);
        }

    }
}

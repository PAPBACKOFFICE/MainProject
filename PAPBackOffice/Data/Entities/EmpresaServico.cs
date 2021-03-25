using System;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class EmpresaServico
    {
        [Key]
        public int Id { get; set; }

        public int EmpresaId { get; set; }

        public int ServicoId { get; set; }

        public int EmpresaServicoEstadoId { get; set; }

        public DateTime Data { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual Servico Servico { get; set; }

        public virtual EmpresaServicoEstado EmpresaServicoEstado { get; set; }
    }
}

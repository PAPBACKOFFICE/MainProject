using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class EmpresaConsultoria
    {
        [Key]
        public int Id { get; set; }

        public int EmpresaId { get; set; }

        public int ConsultoriaId { get; set; }

        public int EmpresaConsultoriaEstadoId { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual Consultoria Consultoria { get; set; }

        public virtual EmpresaConsultoriaEstado EmpresaConsultoriaEstado { get; set; }
    }
}

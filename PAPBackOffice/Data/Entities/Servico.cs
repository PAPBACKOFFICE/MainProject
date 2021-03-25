using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public decimal PrecoBase { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<EmpresaServico> EmpresaServico { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAPBackOffice.Data.Entities
{
    public class Colaborador
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "É obrigatório indicar a empresa.")]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        public string Funcao { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        public int Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Email Inválido.")]
        public string Email { get; set; }

        public string CriadoPor { get; set; }

        public DateTime CriadoEm { get; set; }

        public string AlteradoPor { get; set; }

        public DateTime AlteradoEm { get; set; }

        public bool Activo { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}

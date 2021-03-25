using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O NIF é obrigatório.")]
        public string NIF { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email Inválido.")]
        public string Email { get; set; }

        public string Website { get; set; }

        public string Morada { get; set; }

        public string CodigoPostal { get; set; }

        public string Localidade { get; set; }

        public string CriadoPor { get; set; }

        public DateTime CriadoEm { get; set; }

        public string AlteradoPor { get; set; }

        public DateTime AlteradoEm { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<Colaborador> Colaborador { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }

        public virtual ICollection<EmpresaServico> EmpresaServico { get; set; }
    }
}

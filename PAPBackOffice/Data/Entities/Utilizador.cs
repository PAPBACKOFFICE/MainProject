using System;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class Utilizador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome Necessario ")]
        public string Nome { get; set; }

        public string NIF { get; set; }

        public int Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Email Invalido.")]
        public string Email { get; set; }

    }
}

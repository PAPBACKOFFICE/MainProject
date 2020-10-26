using System;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class Colaborador
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Funcao { get; set; }

        public int Telefone { get; set; }

        public string Email { get; set; }

        public string CriadoPor { get; set; }

        public DateTime CriadoEm { get; set; }

        public string AlteradoPor { get; set; }

        public DateTime AlteradoEm { get; set; }

        public bool Activo { get; set; }
    }
}

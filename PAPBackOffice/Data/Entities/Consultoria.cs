using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class Consultoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public double PrecoBase { get; set; }

        public bool Activo { get; set; }
    }
}

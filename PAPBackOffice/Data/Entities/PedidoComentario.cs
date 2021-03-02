using System;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class PedidoComentario
    {
        [Key]
        public int Id { get; set; }

        public int PedidoId { get; set; }

        [MaxLength(4000)]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Comentario { get; set; }

        public string CriadoPor { get; set; }

        public DateTime CriadoEm { get; set; }

        public string AlteradoPor { get; set; }

        public DateTime AlteradoEm { get; set; }

        public bool Activo { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}

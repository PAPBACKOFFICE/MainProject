using System;

namespace PAPBackOffice.Models.Pedido
{
    public class PedidoComentarioDTO
    {
        public string Comentario { get; set; }

        public string CriadoPor { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}

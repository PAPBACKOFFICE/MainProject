using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Assunto é obrigatório.")]
        public string Assunto { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Data é obrigatória.")]
        public DateTime? Data { get; set; }

        public string UserId { get; set; }

        public int? EmpresaId { get; set; }

        public int? ColaboradorId { get; set; }

        public int PedidoPrioridadeId { get; set; }

        public int PedidoEstadoId { get; set; }

        public int PedidoOrigemId { get; set; }

        public string CriadoPor { get; set; }

        public DateTime CriadoEm { get; set; }

        public string AlteradoPor { get; set; }

        public DateTime AlteradoEm { get; set; }

        public bool Activo { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual Colaborador Colaborador { get; set; }

        public virtual PedidoPrioridade PedidoPrioridade { get; set; }

        public virtual PedidoEstado PedidoEstado { get; set; }

        public virtual PedidoOrigem PedidoOrigem { get; set; }

        public virtual ICollection<PedidoComentario> PedidoComentario { get; set; }
    }
}

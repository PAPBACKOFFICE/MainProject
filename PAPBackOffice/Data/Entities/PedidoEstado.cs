﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class PedidoEstado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Codigo { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}

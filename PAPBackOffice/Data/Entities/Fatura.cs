using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class Fatura
    {
        [Key]
        public int Id { get; set; }

        public int Serie { get; set; }

        public int NumeroDocumento { get; set; }

        public string TipoDocumento { get; set; }

        public DateTime DataEmissao { get; set; }

        public float Desconto { get; set; }

        public float IVA { get; set; }

        public int FaturaEstadoId { get; set; }

        public int EmpresaId { get; set; }

        public int ColaboradorId { get; set; }

        public virtual FaturaEstado FaturaEstado { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual Colaborador Colaborador { get; set; }

        public virtual ICollection<FaturaLinha> FaturaLinha { get; set; }
    }
}

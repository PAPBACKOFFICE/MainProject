using System;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class FaturaLinha
    {
        [Key]
        public int Id { get; set; }

        public int FaturaId { get; set; }

        public int ConsultoriaId { get; set; }

        public int Quantidade { get; set; }

        public int Valor { get; set; }

        public virtual Fatura Fatura { get; set; }
    }
}

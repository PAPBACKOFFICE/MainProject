using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PAPBackOffice.Data.Entities
{
    public class Vendas
    {
        [Key]
        public int Id { get; set; }

        public int preco { get; set; }

        public string produto { get; set; }

        public int quantidade { get; set; }

        public bool efetuado { get; set; }

        public string CriadoPor { get; set; }

        public DateTime CriadoEm { get; set; }

        public string AlteradoPor { get; set; }

        public DateTime AlteradoEm { get; set; }

    }
}

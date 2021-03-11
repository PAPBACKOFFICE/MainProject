using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAPBackOffice.Data.Entities
{
    public class Configuracao
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Valor { get; set; }

        public bool Activo { get; set; }
    }
}

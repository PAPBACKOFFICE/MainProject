using System;

namespace PAPBackOffice.Models.Pedido
{
    public class EmpresaServicoDTO
    {
        public string Servico { get; set; }

        public decimal Valor { get; set; }

        public DateTime CriadoEm { get; set; }

        public string Estado { get; set; }
    }
}

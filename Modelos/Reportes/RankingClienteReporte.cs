using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trastuaro_V2.Modelos.Reportes
{
    public class RankingClienteReporte
    {
        public int Puesto { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public string Periodo { get; set; } = string.Empty;

        public int CantidadRemitos { get; set; }

        public decimal TotalFacturado { get; set; }
    }
}
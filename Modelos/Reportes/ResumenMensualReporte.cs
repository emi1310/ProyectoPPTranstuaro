using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trastuaro_V2.Modelos.Reportes
{
    public class ResumenMensualReporte
    {
        public string Periodo { get; set; } = string.Empty;

        public decimal TotalFacturado { get; set; }

        public decimal TotalCuentaCorriente { get; set; }

        public decimal TotalContado { get; set; }

        public int ClientesConActividad { get; set; }

        public int CantidadRemitos { get; set; }

        public int CantidadLiquidaciones { get; set; }
    }
}
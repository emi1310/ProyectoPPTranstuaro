using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trastuaro_V2.Modelos
{
    public class LiquidacionMensual

    {
        public string TipoLiquidacion { get; set; } = "Mensual";

        public int IdLiquidacion { get; set; }

        public int IdCliente { get; set; }

        public int Mes { get; set; }

        public int Anio { get; set; }

        public DateTime FechaEmision { get; set; } =
            DateTime.Today;

        public decimal Total { get; set; }

        public string Estado { get; set; } =
            "Pendiente";

        public override string ToString()
        {
            return $"Liquidación {Mes:D2}/{Anio} - ${Total:N2}";
        }
    }
}
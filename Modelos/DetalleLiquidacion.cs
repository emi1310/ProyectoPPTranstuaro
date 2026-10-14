using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trastuaro_V2.Modelos
{
    public class DetalleLiquidacion
    {
        public int IdDetalleLiquidacion { get; set; }

        public int IdLiquidacion { get; set; }

        public int IdRemito { get; set; }

        public decimal Importe { get; set; }

        public override string ToString()
        {
            return $"Remito {IdRemito} - ${Importe:N2}";
        }
    }
}
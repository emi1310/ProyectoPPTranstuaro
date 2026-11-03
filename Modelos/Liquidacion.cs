using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 namespace Trastuaro_V2.Modelos
    {
        public class Liquidacion
        {
            public int IdLiquidacion { get; set; }

            public int IdCliente { get; set; }

            public DateTime FechaEmision { get; set; } = DateTime.Today;

            public TipoFacturacion TipoFacturacion { get; set; }

            public int? Mes { get; set; }

            public int? Anio { get; set; }

            public EstadoLiquidacion Estado { get; set; }

            public decimal Total { get; set; }

            public override string ToString()
            {
                return TipoFacturacion == TipoFacturacion.CuentaCorriente
                    ? $"Liquidación {Mes:D2}/{Anio} - ${Total:N2}"
                    : $"Liquidación Contado - ${Total:N2}";
            }
        }
    }

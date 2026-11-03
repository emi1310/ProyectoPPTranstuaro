
using System.ComponentModel;
namespace Trastuaro_V2.Modelos
{
    
        public class Remito
        {
            public int IdRemito { get; set; }

            public string NumeroRemito { get; set; }
                = string.Empty;

            public DateTime Fecha { get; set; }
                = DateTime.Today;

            public int IdCliente { get; set; }

            public TipoFacturacion TipoFacturacion { get; set; }

            public EstadoRemito Estado { get; set; }
                = EstadoRemito.Pendiente;

            public decimal TotalFlete { get; set; }


            [Browsable(false)]
            public DateTime? FechaAnulacion { get; set; }

            [Browsable(false)]
            public string? MotivoAnulacion { get; set; }
      

            public override string ToString()
            {
                return $"Remito {NumeroRemito} - {Fecha:dd/MM/yyyy} - ${TotalFlete:N2}";
            }
        
        }
}
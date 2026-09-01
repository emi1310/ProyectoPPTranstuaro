using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRemitosTransporte.Modelos
{
    public class DetalleLiquidacion
    {
        public int IdDetalleLiquidacion { get; private set; }
        public Remito Remito { get; private set; }
        public decimal ImporteFacturado { get; private set; }

        public DetalleLiquidacion(
            int idDetalleLiquidacion,
            Remito remito)
        {
            if (remito == null)
                throw new ArgumentNullException(nameof(remito));

            if (remito.Estado == "Anulado")
                throw new InvalidOperationException("No se puede liquidar un remito anulado.");

            IdDetalleLiquidacion = idDetalleLiquidacion;
            Remito = remito;
            ImporteFacturado = remito.TotalFlete;
        }

        public decimal ObtenerImporteFacturado()
        {
            return ImporteFacturado;
        }
    }
}
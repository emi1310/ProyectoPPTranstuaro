using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRemitosTransporte.Modelos
{
    public class LiquidacionMensual
    {
        private readonly List<DetalleLiquidacion> _detalles;

        public int IdLiquidacion { get; private set; }
        public string NumeroLiquidacion { get; private set; }
        public DateTime FechaEmision { get; private set; }
        public int MesFacturado { get; private set; }
        public int AnioFacturado { get; private set; }
        public Cliente Cliente { get; private set; }
        public decimal Subtotal { get; private set; }
        public decimal Iva { get; private set; }
        public decimal Total { get; private set; }
        public string Estado { get; private set; }

        public IReadOnlyList<DetalleLiquidacion> Detalles => _detalles.AsReadOnly();

        public LiquidacionMensual(
            int idLiquidacion,
            string numeroLiquidacion,
            DateTime fechaEmision,
            int mesFacturado,
            int anioFacturado,
            Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (mesFacturado < 1 || mesFacturado > 12)
                throw new ArgumentException("El mes facturado debe estar entre 1 y 12.");

            IdLiquidacion = idLiquidacion;
            NumeroLiquidacion = numeroLiquidacion;
            FechaEmision = fechaEmision;
            MesFacturado = mesFacturado;
            AnioFacturado = anioFacturado;
            Cliente = cliente;
            Estado = "Generada";

            Subtotal = 0;
            Iva = 0;
            Total = 0;

            _detalles = new List<DetalleLiquidacion>();
        }

        public void AgregarRemito(Remito remito)
        {
            if (remito == null)
                throw new ArgumentNullException(nameof(remito));

            if (remito.Cliente != Cliente)
                throw new InvalidOperationException("El remito no corresponde al cliente de la liquidación.");

            if (remito.Estado == "Facturado")
                throw new InvalidOperationException("El remito ya fue facturado.");

            if (remito.Estado == "Anulado")
                throw new InvalidOperationException("No se puede liquidar un remito anulado.");

            DetalleLiquidacion detalle = new DetalleLiquidacion(
                _detalles.Count + 1,
                remito
            );

            _detalles.Add(detalle);

            CalcularTotales();
        }

        public void CalcularTotales()
        {
            Subtotal = 0;

            foreach (DetalleLiquidacion detalle in _detalles)
            {
                Subtotal += detalle.ImporteFacturado;
            }

            Iva = Subtotal * 0.21m;
            Total = Subtotal + Iva;
        }

        public void EmitirLiquidacion()
        {
            if (_detalles.Count == 0)
                throw new InvalidOperationException("No se puede emitir una liquidación sin remitos.");

            Estado = "Emitida";

            foreach (DetalleLiquidacion detalle in _detalles)
            {
                detalle.Remito.MarcarComoFacturado();
            }
        }

        public void AnularLiquidacion()
        {
            Estado = "Anulada";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionRemitosTransporte.Modelos
{
    public class Remito
    {
        private readonly List<DetalleRemito> _detalles;

        public int IdRemito { get; private set; }
        public string NumeroRemito { get; private set; }
        public DateTime Fecha { get; private set; }
        public Cliente Cliente { get; private set; }
        public string CondicionPago { get; private set; }
        public string Estado { get; private set; }
        public decimal TotalFlete { get; private set; }
        public string Observaciones { get; private set; }

        public IReadOnlyList<DetalleRemito> Detalles => _detalles.AsReadOnly();

        public Remito(
            int idRemito,
            string numeroRemito,
            DateTime fecha,
            Cliente cliente,
            string condicionPago,
            string observaciones)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (string.IsNullOrWhiteSpace(numeroRemito))
                throw new ArgumentException("El número de remito es obligatorio.");

            IdRemito = idRemito;
            NumeroRemito = numeroRemito;
            Fecha = fecha;
            Cliente = cliente;
            CondicionPago = condicionPago;
            Observaciones = observaciones;
            Estado = "Pendiente";
            TotalFlete = 0;

            _detalles = new List<DetalleRemito>();
        }

        public void AgregarDetalle(DetalleRemito detalle)
        {
            if (detalle == null)
                throw new ArgumentNullException(nameof(detalle));

            _detalles.Add(detalle);
            TotalFlete = CalcularTotalFlete();
        }

        public decimal CalcularTotalFlete()
        {
            decimal total = 0;

            foreach (DetalleRemito detalle in _detalles)
            {
                total += detalle.ImporteFlete;
            }

            return total;
        }

        public void MarcarComoEntregado()
        {
            if (Estado == "Anulado")
                throw new InvalidOperationException("No se puede entregar un remito anulado.");

            Estado = "Entregado";
        }

        public void MarcarComoFacturado()
        {
            if (Estado == "Anulado")
                throw new InvalidOperationException("No se puede facturar un remito anulado.");

            Estado = "Facturado";
        }

        public void AnularRemito(string motivo)
        {
            Estado = "Anulado";
            Observaciones = motivo;
        }
    }
}
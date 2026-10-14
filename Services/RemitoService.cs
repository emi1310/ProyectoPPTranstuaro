using Trastuaro_V2.Modelos;
using Trastuaro_V2.Repositories;

namespace Trastuaro_V2.Services
{
    public class RemitoService
    {
        private readonly RemitoRepository _remitoRepository;
        private readonly DetalleRemitoRepository _detalleRepository;

        public RemitoService(
            RemitoRepository remitoRepository,
            DetalleRemitoRepository detalleRepository)
        {
            _remitoRepository = remitoRepository;
            _detalleRepository = detalleRepository;
        }

        public int Registrar(
            Remito remito,
            DetalleRemito detalle)
        {
            ValidarRemito(remito);
            ValidarDetalle(detalle);

            remito.NumeroRemito =
                remito.NumeroRemito.Trim();

            remito.CondicionPago =
                remito.CondicionPago.Trim();

            remito.Estado =
                string.IsNullOrWhiteSpace(remito.Estado)
                    ? "Pendiente"
                    : remito.Estado.Trim();

            detalle.Descripcion =
                LimpiarTextoOpcional(detalle.Descripcion);

            detalle.ProveedorOrigen =
                LimpiarTextoOpcional(detalle.ProveedorOrigen);

            detalle.NumeroRemitoOrigen =
                LimpiarTextoOpcional(detalle.NumeroRemitoOrigen);

            // El total del remito coincide inicialmente
            // con el importe de su único detalle.
            remito.TotalFlete = detalle.ImporteFlete;

            int idRemito =
                _remitoRepository.Agregar(remito);

            detalle.IdRemito = idRemito;

            _detalleRepository.Agregar(detalle);

            return idRemito;
        }
        public List<Remito> ObtenerPendientesPorClienteYPeriodo(
            int idCliente,
            int mes,
            int anio)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException(
                    "Debe seleccionar un cliente.");
            }

            if (mes < 1 || mes > 12)
            {
                throw new ArgumentException(
                    "El mes debe estar comprendido entre 1 y 12.");
            }

            if (anio < 2000)
            {
                throw new ArgumentException(
                    "El año ingresado no es válido.");
            }

            return _remitoRepository
                .ObtenerPendientesPorClienteYPeriodo(
                    idCliente,
                    mes,
                    anio);
        }

        public void Finalizar(int idRemito)
        {
            if (idRemito <= 0)
            {
                throw new ArgumentException(
                    "El identificador del remito no es válido.");
            }

            _remitoRepository.ActualizarEstado(
                idRemito,
                "Finalizado");
        }
        private static void ValidarRemito(Remito remito)
        {
            ArgumentNullException.ThrowIfNull(remito);

            if (string.IsNullOrWhiteSpace(remito.NumeroRemito))
            {
                throw new ArgumentException(
                    "Debe ingresar el número de remito.");
            }

            if (remito.IdCliente <= 0)
            {
                throw new ArgumentException(
                    "Debe seleccionar un cliente.");
            }

            if (string.IsNullOrWhiteSpace(remito.CondicionPago))
            {
                throw new ArgumentException(
                    "Debe indicar la condición de pago.");
            }
        }

        private static void ValidarDetalle(DetalleRemito detalle)
        {
            ArgumentNullException.ThrowIfNull(detalle);

            if (detalle.CantidadBultos <= 0)
            {
                throw new ArgumentException(
                    "La cantidad de bultos debe ser mayor que cero.");
            }

            if (detalle.ValorDeclarado < 0)
            {
                throw new ArgumentException(
                    "El valor declarado no puede ser negativo.");
            }

            if (detalle.ImporteFlete < 0)
            {
                throw new ArgumentException(
                    "El importe del flete no puede ser negativo.");
            }
        }

        private static string? LimpiarTextoOpcional(string? texto)
        {
            return string.IsNullOrWhiteSpace(texto)
                ? null
                : texto.Trim();
        }
    }
}
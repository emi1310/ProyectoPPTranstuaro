using Trastuaro_V2.Modelos;
using Trastuaro_V2.Repositories;

namespace Trastuaro_V2.Services
{
    public class LiquidacionMensualService
    {
        private readonly LiquidacionMensualRepository
            _liquidacionRepository;

        private readonly DetalleLiquidacionRepository
            _detalleRepository;

        public LiquidacionMensualService(
            LiquidacionMensualRepository liquidacionRepository,
            DetalleLiquidacionRepository detalleRepository)
        {
            _liquidacionRepository = liquidacionRepository;
            _detalleRepository = detalleRepository;
        }

        public int Registrar(
            LiquidacionMensual liquidacion,
            List<DetalleLiquidacion> detalles)
        {
            ValidarLiquidacion(liquidacion);
            ValidarDetalles(detalles);

            liquidacion.Estado =
                string.IsNullOrWhiteSpace(liquidacion.Estado)
                    ? "Pendiente"
                    : liquidacion.Estado.Trim();

            liquidacion.Total =
                detalles.Sum(detalle => detalle.Importe);

            int idLiquidacion =
                _liquidacionRepository.Agregar(liquidacion);

            foreach (DetalleLiquidacion detalle in detalles)
            {
                detalle.IdLiquidacion = idLiquidacion;
                _detalleRepository.Agregar(detalle);
            }

            return idLiquidacion;
        }

        private static void ValidarLiquidacion(
            LiquidacionMensual liquidacion)
        {
            ArgumentNullException.ThrowIfNull(liquidacion);

            if (liquidacion.IdCliente <= 0)
            {
                throw new ArgumentException(
                    "Debe seleccionar un cliente.");
            }

            if (liquidacion.Mes < 1 || liquidacion.Mes > 12)
            {
                throw new ArgumentException(
                    "El mes debe estar comprendido entre 1 y 12.");
            }

            if (liquidacion.Anio < 2000)
            {
                throw new ArgumentException(
                    "El año ingresado no es válido.");
            }
        }

        private static void ValidarDetalles(
            List<DetalleLiquidacion> detalles)
        {
            ArgumentNullException.ThrowIfNull(detalles);

            if (detalles.Count == 0)
            {
                throw new ArgumentException(
                    "La liquidación debe contener al menos un remito.");
            }

            foreach (DetalleLiquidacion detalle in detalles)
            {
                if (detalle.IdRemito <= 0)
                {
                    throw new ArgumentException(
                        "Todos los detalles deben tener un remito válido.");
                }

                if (detalle.Importe < 0)
                {
                    throw new ArgumentException(
                        "El importe no puede ser negativo.");
                }
            }
        }
    }
}
using Trastuaro_V2.Modelos;
using Trastuaro_V2.Repositories;
using Microsoft.Data.Sqlite;
using Trastuaro_V2.Datos;


namespace Trastuaro_V2.Services
{
    public class LiquidacionMensualService
    {
        private readonly LiquidacionMensualRepository
            _liquidacionRepository;

        private readonly DetalleLiquidacionRepository
            _detalleRepository;
        private readonly RemitoRepository
            _remitoRepository;
        private readonly ClienteRepository
    _clienteRepository;

        public LiquidacionMensualService(
    LiquidacionMensualRepository liquidacionRepository,
    DetalleLiquidacionRepository detalleRepository,
    RemitoRepository remitoRepository,
    ClienteRepository clienteRepository)
        {
            _liquidacionRepository = liquidacionRepository;
            _detalleRepository = detalleRepository;
            _remitoRepository = remitoRepository;
            _clienteRepository = clienteRepository;
        }

        public int Registrar(LiquidacionMensual liquidacion, List<DetalleLiquidacion> detalles)
        {
            ValidarLiquidacion(liquidacion);
            ValidarDetalles(detalles);

            Cliente? cliente = _clienteRepository.ObtenerPorId(liquidacion.IdCliente);

            if (cliente == null)
            {
                throw new InvalidOperationException(
                    "No se encontró el cliente seleccionado.");
            }

            if (cliente.TieneCuentaCorriente)
            {
                liquidacion.TipoLiquidacion = "Mensual";
                liquidacion.Estado = "Abierta";
            }
            else
            {
                liquidacion.TipoLiquidacion = "Directa";
                liquidacion.Estado = "Cerrada";
            }

            liquidacion.Estado = string.IsNullOrWhiteSpace(liquidacion.Estado)
                    ? "Abierta"
                    : liquidacion.Estado.Trim();

            liquidacion.Total = detalles.Sum(detalle => detalle.Importe);

            LiquidacionMensual? liquidacionExistente = null;

            if (cliente.TieneCuentaCorriente)
            {
                liquidacionExistente =
                    _liquidacionRepository.ObtenerPorClienteYPeriodo(
                        liquidacion.IdCliente,
                        liquidacion.Mes,
                        liquidacion.Anio);
            }

            if (liquidacionExistente != null && liquidacionExistente.Estado == "Cerrada")
            {
                throw new InvalidOperationException(
                    "La liquidación del período seleccionado está cerrada y no admite nuevos remitos.");
            }

            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteTransaction transaccion =
                conexion.BeginTransaction();

            try
            {
                int idLiquidacion;

                if (liquidacionExistente == null)
                {
                    idLiquidacion =
                        _liquidacionRepository.Agregar(
                            liquidacion,
                            conexion,
                            transaccion);
                }
                else
                {
                    idLiquidacion =
                        liquidacionExistente.IdLiquidacion;

                    decimal nuevoTotal =
                        liquidacionExistente.Total +
                        liquidacion.Total;

                    _liquidacionRepository.ActualizarTotal(
                        idLiquidacion,
                        nuevoTotal,
                        conexion,
                        transaccion);
                }

                string nuevoEstadoRemito;

                if (cliente.TieneCuentaCorriente)
                {
                    nuevoEstadoRemito = "En proceso";
                }
                else
                {
                    nuevoEstadoRemito = "Facturado";
                }

                foreach (DetalleLiquidacion detalle in detalles)
                {
                    detalle.IdLiquidacion = idLiquidacion;

                    _detalleRepository.Agregar(
                        detalle,
                        conexion,
                        transaccion);

                    _remitoRepository.ActualizarEstado(
                        detalle.IdRemito,
                        nuevoEstadoRemito,
                        conexion,
                        transaccion);

                }

                transaccion.Commit();

                return idLiquidacion;
            }
            catch
            {
                transaccion.Rollback();
                throw;
            }
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
        public LiquidacionMensual? ObtenerPorClienteYPeriodo(int idCliente,int mes,int anio)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException(
                    "El cliente seleccionado no es válido.");
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

            return _liquidacionRepository
                .ObtenerPorClienteYPeriodo(
                    idCliente,
                    mes,
                    anio);
        }

        public List<LiquidacionMensual> ObtenerPorCliente(
    int idCliente)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException(
                    "El cliente seleccionado no es válido.");
            }

            return _liquidacionRepository.ObtenerPorCliente(
                idCliente);
        }

        public void CerrarLiquidacion(int idLiquidacion)
        {
            if (idLiquidacion <= 0)
            {
                throw new ArgumentException(
                    "La liquidación seleccionada no es válida.");
            }

            LiquidacionMensual? liquidacion =
                _liquidacionRepository.ObtenerPorId(idLiquidacion);

            if (liquidacion == null)
            {
                throw new InvalidOperationException(
                    "No se encontró la liquidación seleccionada.");
            }

            if (liquidacion.Estado == "Cerrada")
            {
                throw new InvalidOperationException(
                    "La liquidación ya se encuentra cerrada.");
            }

            List<Remito> remitosPendientes =
                _remitoRepository.ObtenerPorClientePeriodoYEstado(
                    liquidacion.IdCliente,
                    liquidacion.Mes,
                    liquidacion.Anio,
                    "Pendiente");

            if (remitosPendientes.Count > 0)
            {
                throw new InvalidOperationException(
                    $"No se puede cerrar la liquidación porque existen " +
                    $"{remitosPendientes.Count} remito(s) pendiente(s) de incorporar " +
                    $"para el período {liquidacion.Mes:D2}/{liquidacion.Anio}.");
            }

            _liquidacionRepository.ActualizarEstado(
                idLiquidacion,
                "Cerrada");
            _remitoRepository.FacturarRemitosEnProcesoPorPeriodo(
                liquidacion.IdCliente,
                liquidacion.Mes,
                liquidacion.Anio);
        }
        public List<Remito> ObtenerRemitosPorLiquidacion(
    int idLiquidacion)
        {
            if (idLiquidacion <= 0)
            {
                throw new ArgumentException(
                    "La liquidación seleccionada no es válida.");
            }

            return _detalleRepository.ObtenerRemitosPorLiquidacion(
                idLiquidacion);
        }
    }
}
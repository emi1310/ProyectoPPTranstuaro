using Trastuaro_V2.Modelos;
using Trastuaro_V2.Repositories;

namespace Trastuaro_V2.Services
{
    public class RemitoService
    {
        private readonly RemitoRepository _remitoRepository;
        private readonly DetalleRemitoRepository _detalleRepository;
        private readonly LiquidacionRepository _liquidacionRepository;
        private readonly PdfRemitoService _pdfRemitoService;


        public RemitoService(
            RemitoRepository remitoRepository,
            DetalleRemitoRepository detalleRepository,
            PdfRemitoService pdfRemitoService)
        {
            _remitoRepository = remitoRepository;
            _detalleRepository = detalleRepository;
            _liquidacionRepository = new LiquidacionRepository();
            _pdfRemitoService = pdfRemitoService;
        }


        //  actual / base para Transtuaro V3
        public ResultadoRegistroRemito Registrar( Remito remito, Cliente cliente, List<DetalleRemito> detalles)
        {


            if (detalles == null || detalles.Count == 0)
            {
                throw new ArgumentException(
                    "El remito debe contener al menos un detalle.");
            }

            decimal totalFlete = detalles.Sum(d => d.ImporteFlete);

            remito.TotalFlete = totalFlete;

            ValidarRemito(remito);

            if (remito.TipoFacturacion == TipoFacturacion.CuentaCorriente)
            {
                int mes = remito.Fecha.Month;
                int anio = remito.Fecha.Year;

                bool periodoCerrado =
                    _liquidacionRepository
                        .ExisteCuentaCorrientePorPeriodo(
                            remito.IdCliente,
                            mes,
                            anio);

                if (periodoCerrado)
                {
                    throw new InvalidOperationException(
                        "El período seleccionado ya fue cerrado para Cuenta Corriente. " +
                        "El remito deberá emitirse bajo modalidad Contado.");
                }
            }


            foreach (DetalleRemito detalle in detalles)
            {
                ValidarDetalle(detalle);

                detalle.Descripcion =
                    LimpiarTextoOpcional(detalle.Descripcion);

                detalle.ProveedorOrigen =
                    LimpiarTextoOpcional(detalle.ProveedorOrigen);

                detalle.NumeroRemitoOrigen =
                    LimpiarTextoOpcional(detalle.NumeroRemitoOrigen);
            }

           

            remito.NumeroRemito =
                remito.NumeroRemito.Trim();


            remito.Estado = EstadoRemito.Pendiente;

            remito.TotalFlete = detalles.Sum(detalle => detalle.ImporteFlete);

            int idRemito = _remitoRepository.Agregar(remito);

            foreach (DetalleRemito detalle in detalles)
            {
                detalle.IdRemito = idRemito;

                _detalleRepository.Agregar(detalle);
            }

            ResultadoRegistroRemito resultado = new()
            {
                IdRemito = idRemito
            };

            try
            {
                string rutaPdf =
                    _pdfRemitoService.GenerarPdf(
                        remito,
                        cliente,
                        detalles);

                resultado.PdfGenerado = true;
                resultado.RutaPdf = rutaPdf;
            }
            catch (Exception ex)
            {
                resultado.PdfGenerado = false;
                resultado.ErrorPdf = ex.Message;
            }

            return resultado;
        }


        public List<Remito> ObtenerPorFiltros( int idCliente, TipoFacturacion? tipoFacturacion, string estado, int? mes, int? anio)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException("El cliente seleccionado no es válido.");
            }

            return _remitoRepository.ObtenerPorFiltros( idCliente, tipoFacturacion, estado, mes, anio);
        }
        public List<Remito> ObtenerPorClienteYEstado( int idCliente, string estado)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException(
                    "El cliente seleccionado no es válido.");
            }

            if (estado != "Pendiente" &&
                estado != "EnProceso" &&
                estado != "Facturado" &&
                estado != "Todos")
            {
                throw new ArgumentException( "El estado seleccionado no es válido.");
            }

            return _remitoRepository.ObtenerPorClienteYEstado( idCliente, estado);
        }
        public List<Remito> ObtenerPendientesPorClienteYPeriodo( int idCliente, int mes, int anio)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException( "Debe seleccionar un cliente.");
            }

            if (mes < 1 || mes > 12)
            {
                throw new ArgumentException( "El mes debe estar comprendido entre 1 y 12.");
            }

            if (anio < 2000)
            {
                throw new ArgumentException( "El año ingresado no es válido.");
            }

            return _remitoRepository
                .ObtenerPendientesPorClienteYPeriodo( idCliente, mes, anio);
        }

        public List<Remito> ObtenerPorClientePeriodoYEstado(int idCliente, int mes, int anio, string estado)
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

            if (estado != "Pendiente" &&
                estado != "EnProceso" &&
                estado != "Facturado" &&
                estado != "Todos")
            {
                throw new ArgumentException(
                    "El estado seleccionado no es válido.");
            }

            return _remitoRepository
                .ObtenerPorClientePeriodoYEstado(
                    idCliente,
                    mes,
                    anio,
                    estado);
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

         

            if (remito.TotalFlete <= 0)
            {
                throw new ArgumentException(
                    "El importe total del remito debe ser mayor que cero.");
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
                    "El importe del flete debe no puede ser negativo.");
            }
        }

        private static string? LimpiarTextoOpcional(string? texto)
        {
            return string.IsNullOrWhiteSpace(texto)
                ? null
                : texto.Trim();
        }
        public string ObtenerProximoNumero()
        {
            return _remitoRepository.ObtenerProximoNumero();
        }

        public void AnularRemito( Remito remito, string motivo)
        {
            if (remito == null)
            {
                throw new ArgumentNullException(nameof(remito));
            }

            if (remito.Estado != EstadoRemito.Pendiente)
            {
                throw new InvalidOperationException(
                    "Solo se pueden anular remitos en estado Pendiente.");
            }

            if (string.IsNullOrWhiteSpace(motivo))
            {
                throw new ArgumentException(
                    "Debe indicar el motivo de la anulación.");
            }

            remito.Estado = EstadoRemito.Anulado;
            remito.FechaAnulacion = DateTime.Today;
            remito.MotivoAnulacion = motivo.Trim();

            _remitoRepository.AnularRemito( remito.IdRemito, remito.FechaAnulacion.Value, remito.MotivoAnulacion);

            // Todavía falta persistirlo en Repository.
        }
    }
}
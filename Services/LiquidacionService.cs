using Microsoft.Data.Sqlite;
using Trastuaro_V2.Datos;
using Trastuaro_V2.Modelos;

using Trastuaro_V2.Repositories;

namespace Trastuaro_V2.Services
{
    public class LiquidacionService
    {
        private readonly LiquidacionRepository _liquidacionRepository;
        private readonly DetalleLiquidacionRepository _detalleLiquidacionRepository;
        private readonly RemitoRepository _remitoRepository;

        private readonly PdfLiquidacionService _pdfLiquidacionService;

        public LiquidacionService( PdfLiquidacionService pdfLiquidacionService)
        {
            _liquidacionRepository =  new LiquidacionRepository();

            _detalleLiquidacionRepository = new DetalleLiquidacionRepository();

            _remitoRepository = new RemitoRepository();

            _pdfLiquidacionService = pdfLiquidacionService;
        }
        public List<Liquidacion> ObtenerPorCliente(int idCliente)
        {
            return _liquidacionRepository.ObtenerPorCliente(idCliente);
        }
        public List<Remito> ObtenerRemitosPorLiquidacion( int idLiquidacion)
        {
            return _detalleLiquidacionRepository.ObtenerRemitosPorLiquidacion(idLiquidacion);
        }

        public ResultadoLiquidacion GenerarLiquidacionContado( int idCliente, Cliente cliente, List<Remito> remitos)
        {
            if (remitos == null || remitos.Count == 0)
            {
                throw new InvalidOperationException(
                    "No existen remitos para liquidar.");
            }

            foreach (Remito remito in remitos)
            {
                if (remito.IdCliente != idCliente)
                {
                    throw new InvalidOperationException(
                        "Todos los remitos deben pertenecer al mismo cliente.");
                }

                if (remito.TipoFacturacion !=
                    TipoFacturacion.Contado)
                {
                    throw new InvalidOperationException(
                        "Todos los remitos deben ser de modalidad Contado.");
                }

                if (remito.Estado != EstadoRemito.Pendiente)
                {
                    throw new InvalidOperationException(
                        "Solo se pueden liquidar remitos en estado Pendiente.");
                }
            }

            decimal total =
                remitos.Sum(r => r.TotalFlete);

            Liquidacion liquidacion = new()
            {
                IdCliente = idCliente,
                FechaEmision = DateTime.Today,
                TipoFacturacion =
                    TipoFacturacion.Contado,

                Mes = null,
                Anio = null,

                Estado =
                    EstadoLiquidacion.Cerrada,

                Total = total
            };

            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteTransaction transaccion =
                conexion.BeginTransaction();

            try
            {
                int idLiquidacion =
                    _liquidacionRepository.Agregar(
                        liquidacion,
                        conexion,
                        transaccion);


                foreach (Remito remito in remitos)
                {
                    DetalleLiquidacion detalle = new()
                    {
                        IdLiquidacion = idLiquidacion,
                        IdRemito = remito.IdRemito,
                        Importe = remito.TotalFlete
                    };

                    _detalleLiquidacionRepository.Agregar(
                        detalle,
                        conexion,
                        transaccion);

                    _remitoRepository.ActualizarEstado(
                        remito.IdRemito,
                        EstadoRemito.Facturado,
                        conexion,
                        transaccion);
                }

                transaccion.Commit();

                liquidacion.IdLiquidacion = idLiquidacion;

                ResultadoLiquidacion resultado = new()
                {
                    IdLiquidacion = idLiquidacion
                };

                try
                {
                    string rutaPdf =
                        _pdfLiquidacionService.GenerarPdf(
                            liquidacion,
                            cliente,
                            remitos);

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
            catch
            {
                transaccion.Rollback();
                throw;
            }
        }
        public ResultadoLiquidacion GenerarLiquidacionCuentaCorriente( int idCliente, Cliente cliente, int mes, int anio, List<Remito> remitos)
        {

            if (mes < 1 || mes > 12)
            {
                throw new ArgumentException(
                    "Para generar una liquidación de Cuenta Corriente debe seleccionarse un mes válido.");
            }

            if (anio < 2000)
            {
                throw new ArgumentException(
                    "El año seleccionado no es válido.");
            }
            if (remitos == null || remitos.Count == 0)
            {
                throw new InvalidOperationException(
                    "No existen remitos para liquidar.");
            }
            if (_liquidacionRepository.ExisteCuentaCorrientePorPeriodo(idCliente,mes,anio))
            {
                throw new InvalidOperationException(
                    "Ya existe una liquidación de Cuenta Corriente para este cliente y período.");
            }
            foreach (Remito remito in remitos)
            {
                if (remito.IdCliente != idCliente)
                {
                    throw new InvalidOperationException(
                        "Todos los remitos deben pertenecer al mismo cliente.");
                }

                if (remito.TipoFacturacion !=
                    TipoFacturacion.CuentaCorriente)
                {
                    throw new InvalidOperationException(
                        "Todos los remitos deben ser de modalidad Cuenta Corriente.");
                }

                if (remito.Estado != EstadoRemito.Pendiente)
                {
                    throw new InvalidOperationException(
                        "Solo se pueden liquidar remitos en estado Pendiente.");
                }
            }

            decimal total =
                remitos.Sum(r => r.TotalFlete);

            Liquidacion liquidacion = new()
            {
                IdCliente = idCliente,
                FechaEmision = DateTime.Today,
                TipoFacturacion = TipoFacturacion.CuentaCorriente,
                Mes = mes,
                Anio = anio,
                Estado = EstadoLiquidacion.Cerrada,
                Total = total
            };

            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteTransaction transaccion =
                conexion.BeginTransaction();

            try
            {
                int idLiquidacion =
                    _liquidacionRepository.Agregar(
                        liquidacion,
                        conexion,
                        transaccion);

                foreach (Remito remito in remitos)
                {
                    DetalleLiquidacion detalle = new()
                    {
                        IdLiquidacion = idLiquidacion,
                        IdRemito = remito.IdRemito,
                        Importe = remito.TotalFlete
                    };

                    _detalleLiquidacionRepository.Agregar(
                        detalle,
                        conexion,
                        transaccion);

                    _remitoRepository.ActualizarEstado(
                        remito.IdRemito,
                        EstadoRemito.Facturado,
                        conexion,
                        transaccion);
                }

                transaccion.Commit();

                liquidacion.IdLiquidacion = idLiquidacion;

                ResultadoLiquidacion resultado = new()
                {
                    IdLiquidacion = idLiquidacion
                };

                try
                {
                    string rutaPdf =
                        _pdfLiquidacionService.GenerarPdf(
                            liquidacion,
                            cliente,
                            remitos);

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
            catch
            {
                transaccion.Rollback();
                throw;
            }
        }
        public string RegenerarPdf( Liquidacion liquidacion, Cliente cliente, List<Remito> remitos)
        {
            return _pdfLiquidacionService.GenerarPdf(liquidacion, cliente, remitos);
        }
    }
}
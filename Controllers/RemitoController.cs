using Trastuaro_V2.Modelos;
using Trastuaro_V2.Services;

namespace Trastuaro_V2.Controllers
{
    public class RemitoController
    {
        private readonly RemitoService _remitoService;

        public RemitoController(RemitoService remitoService)
        {
            _remitoService = remitoService;
        }

        public int RegistrarRemito(
            Remito remito,
            DetalleRemito detalle)
        {
            return _remitoService.Registrar(remito, detalle);
        }

        public List<Remito> ObtenerPendientesPorClienteYPeriodo(
            int idCliente,
            int mes,
            int anio)
        {
            return _remitoService
                .ObtenerPendientesPorClienteYPeriodo(
                    idCliente,
                    mes,
                    anio);
        }

        public List<Remito> ObtenerPorClientePeriodoYEstado(
            int idCliente,
            int mes,
            int anio,
            string estado)
        {
            return _remitoService.ObtenerPorClientePeriodoYEstado(
                idCliente,
                mes,
                anio,
                estado);
        }

        public List<Remito> ObtenerPendientesParaLiquidacion(
    Cliente cliente,
    int mes,
    int anio)
        {
            return _remitoService.ObtenerPendientesParaLiquidacion(
                cliente,
                mes,
                anio);
        }
        public void FinalizarRemito(int idRemito)
        {
            _remitoService.Finalizar(idRemito);
        }
        public string ObtenerProximoNumero()
        {
            return _remitoService.ObtenerProximoNumero();
        }

        public List<Remito> ObtenerPorClienteYEstado(
    int idCliente,
    string estado)
        {
            return _remitoService.ObtenerPorClienteYEstado(
                idCliente,
                estado);
        }
    }
}
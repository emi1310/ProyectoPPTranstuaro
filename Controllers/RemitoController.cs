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


        //NUEVO
        public ResultadoRegistroRemito RegistrarRemito( Remito remito, Cliente cliente, List<DetalleRemito> detalles)
        {
            return _remitoService.Registrar( remito, cliente, detalles);
        }

        public List<Remito> ObtenerPorFiltros( int idCliente, TipoFacturacion? tipoFacturacion, string estado, int? mes, int? anio)
        {
            return _remitoService.ObtenerPorFiltros( idCliente, tipoFacturacion, estado, mes, anio);
        }

        public List<Remito> ObtenerPendientesPorClienteYPeriodo( int idCliente, int mes, int anio)
        {
            return _remitoService.ObtenerPendientesPorClienteYPeriodo( idCliente, mes, anio);
        }

        public List<Remito> ObtenerPorClientePeriodoYEstado( int idCliente, int mes, int anio, string estado)
        {
            return _remitoService.ObtenerPorClientePeriodoYEstado( idCliente, mes, anio, estado);
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

        public void AnularRemito( Remito remito, string motivo)
        {
            _remitoService.AnularRemito( remito, motivo);
        }
    }
}
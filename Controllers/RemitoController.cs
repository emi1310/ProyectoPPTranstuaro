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
        public void FinalizarRemito(int idRemito)
        {
            _remitoService.Finalizar(idRemito);
        }
    }
}
using Trastuaro_V2.Modelos;
using Trastuaro_V2.Services;

namespace Trastuaro_V2.Controllers
{
    public class LiquidacionMensualController
    {
        private readonly LiquidacionMensualService
            _liquidacionService;

        public LiquidacionMensualController(
            LiquidacionMensualService liquidacionService)
        {
            _liquidacionService = liquidacionService;
        }

        public int RegistrarLiquidacion(
            LiquidacionMensual liquidacion,
            List<DetalleLiquidacion> detalles)
        {
            return _liquidacionService.Registrar(
                liquidacion,
                detalles);
        }
        public void CerrarLiquidacion( int idLiquidacion)
        {
            _liquidacionService.CerrarLiquidacion(idLiquidacion);
        }
        public LiquidacionMensual? ObtenerPorClienteYPeriodo(int idCliente,int mes,int anio)
        {
            return _liquidacionService
                .ObtenerPorClienteYPeriodo( idCliente, mes, anio);
        }

        public List<LiquidacionMensual> ObtenerPorCliente(
    int idCliente)
        {
            return _liquidacionService.ObtenerPorCliente(
                idCliente);
        }
        public List<Remito> ObtenerRemitosPorLiquidacion(
    int idLiquidacion)
        {
            return _liquidacionService.ObtenerRemitosPorLiquidacion(
                idLiquidacion);
        }
    }
}
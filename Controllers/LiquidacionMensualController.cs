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
    }
}
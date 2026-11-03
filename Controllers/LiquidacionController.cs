
using System.Collections.Generic;
using Trastuaro_V2.Modelos;

using Trastuaro_V2.Services;

namespace Trastuaro_V2.Controllers
{
    public class LiquidacionController
    {
        private readonly LiquidacionService _liquidacionService;

        public LiquidacionController(
            LiquidacionService liquidacionService)
        {
            _liquidacionService = liquidacionService;
        }

        public List<Liquidacion> ObtenerPorCliente(
            int idCliente)
        {
            return _liquidacionService.ObtenerPorCliente(
                idCliente);
        }

        public List<Remito> ObtenerRemitosPorLiquidacion(
    int idLiquidacion)
        {
            return _liquidacionService
                .ObtenerRemitosPorLiquidacion(idLiquidacion);
        }

        public ResultadoLiquidacion GenerarLiquidacionContado(
        int idCliente,
        Cliente cliente,
        List<Remito> remitos)
        {
            return _liquidacionService
                .GenerarLiquidacionContado(
                    idCliente,
                    cliente,
                    remitos);
        }

        public ResultadoLiquidacion GenerarLiquidacionCuentaCorriente( int idCliente, Cliente cliente, int mes, int anio, List<Remito> remitos)
        {
            return _liquidacionService.GenerarLiquidacionCuentaCorriente( idCliente, cliente, mes, anio, remitos);
        }
        public string RegenerarPdf( Liquidacion liquidacion, Cliente cliente,  List<Remito> remitos)
        {
            return _liquidacionService.RegenerarPdf( liquidacion, cliente, remitos);
        }
    }
}
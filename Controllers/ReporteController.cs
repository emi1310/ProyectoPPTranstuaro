using Trastuaro_V2.Modelos.Reportes;
using Trastuaro_V2.Services;

namespace Trastuaro_V2.Controllers
{
    public class ReporteController
    {
        private readonly ReporteService _reporteService;
        private readonly PdfReporteMensualService _pdfReporteMensualService;

        public ReporteController()
        {
            _reporteService = new ReporteService();
            _pdfReporteMensualService = new PdfReporteMensualService();
        }

        public List<RankingClienteReporte> ObtenerRankingClientes( int mes, int anio)
        {
            return _reporteService.ObtenerRankingClientes( mes, anio);
        }
        public ResumenMensualReporte ObtenerResumenMensual(int mes, int anio)
        {
            return _reporteService.ObtenerResumenMensual( mes, anio);
        }

        public ReporteMensual ObtenerReporteMensual( int mes, int anio)
        {
            return _reporteService .ObtenerReporteMensual( mes, anio);
        }

        public string GenerarPdf( ReporteMensual reporte)
        {
            return _pdfReporteMensualService.GenerarPdf( reporte.Resumen, reporte.Ranking);
        }
    }
}
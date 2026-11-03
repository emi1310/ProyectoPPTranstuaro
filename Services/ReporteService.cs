using Trastuaro_V2.Modelos.Reportes;
using Trastuaro_V2.Repositories;

namespace Trastuaro_V2.Services
{
    public class ReporteService
    {
        private readonly ReporteRepository _reporteRepository;

        public ReporteService()
        {
            _reporteRepository =
                new ReporteRepository();
        }

        public List<RankingClienteReporte> ObtenerRankingClientes(
            int mes,
            int anio)
        {
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

            return _reporteRepository
                .ObtenerRankingClientes(
                    mes,
                    anio);
        }

        public ResumenMensualReporte ObtenerResumenMensual(
    int mes,
    int anio)
        {
            if (mes < 1 || mes > 12)
            {
                throw new ArgumentException(
                    "El mes debe estar comprendido entre 1 y 12.");
            }

            if (anio < 2024)
            {
                throw new ArgumentException(
                    "El año ingresado no es válido.");
            }

            return _reporteRepository
                .ObtenerResumenMensual(
                    mes,
                    anio);
        }

        public ReporteMensual ObtenerReporteMensual(
    int mes,
    int anio)
        {
            ResumenMensualReporte resumen =
                ObtenerResumenMensual(
                    mes,
                    anio);

            List<RankingClienteReporte> ranking =
                ObtenerRankingClientes(
                    mes,
                    anio);

            return new ReporteMensual(
                resumen,
                ranking);
        }
    }
}
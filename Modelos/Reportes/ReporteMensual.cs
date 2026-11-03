using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trastuaro_V2.Modelos.Reportes
{
    public class ReporteMensual
    {
        public ResumenMensualReporte Resumen { get; }

        public List<RankingClienteReporte> Ranking { get; }

        public ReporteMensual(
            ResumenMensualReporte resumen,
            List<RankingClienteReporte> ranking)
        {
            Resumen = resumen;
            Ranking = ranking;
        }
    }
}
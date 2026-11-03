using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trastuaro_V2.Modelos
{
    public class ResultadoLiquidacion
    {
        public int IdLiquidacion { get; set; }

        public bool PdfGenerado { get; set; }

        public string? RutaPdf { get; set; }

        public string? ErrorPdf { get; set; }
    }
}
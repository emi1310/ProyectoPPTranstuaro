using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trastuaro_V2.Modelos
{
    public class ResultadoRegistroRemito
    {
        public int IdRemito { get; set; }

        public bool PdfGenerado { get; set; }

        public string? RutaPdf { get; set; }

        public string? ErrorPdf { get; set; }
    }
}
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Trastuaro_V2.Modelos;

namespace Trastuaro_V2.Services
{
    public class PdfLiquidacionService
    {
        public string GenerarPdf(
            Liquidacion liquidacion,
            Cliente cliente,
            List<Remito> remitos)
        {
            PdfDocument documento = new();

            PdfPage pagina = documento.AddPage();

            XGraphics gfx =
                XGraphics.FromPdfPage(pagina);

            XFont fuenteTitulo =
                new XFont(
                    "Arial",
                    18,
                    XFontStyleEx.Bold);

            XFont fuenteSubtitulo =
                new XFont(
                    "Arial",
                    11,
                    XFontStyleEx.Bold);

            XFont fuenteNormal =
                new XFont(
                    "Arial",
                    9,
                    XFontStyleEx.Regular);

            XFont fuenteNegrita =
                new XFont(
                    "Arial",
                    9,
                    XFontStyleEx.Bold);

            XFont fuenteTotal =
                new XFont(
                    "Arial",
                    11,
                    XFontStyleEx.Bold);

            XPen lapiz =
                new XPen(
                    XColors.Black,
                    0.8);

            double margenIzquierdo = 35;
            double margenDerecho = 35;

            double anchoPagina =
                pagina.Width.Point;

            double anchoUtil =
                anchoPagina
                - margenIzquierdo
                - margenDerecho;

            double y = 35;

            // ==========================================
            // ENCABEZADO
            // ==========================================

            gfx.DrawRectangle(
                lapiz,
                margenIzquierdo,
                y,
                anchoUtil,
                70);

            gfx.DrawString(
                "TRANSTUARO",
                fuenteTitulo,
                XBrushes.Black,
                new XRect(
                    margenIzquierdo,
                    y + 10,
                    anchoUtil,
                    25),
                XStringFormats.TopCenter);

            gfx.DrawString(
                $"LIQUIDACIÓN N° {liquidacion.IdLiquidacion}",
                fuenteSubtitulo,
                XBrushes.Black,
                margenIzquierdo + 10,
                y + 52);

            gfx.DrawString(
                $"Emisión: {liquidacion.FechaEmision:dd/MM/yyyy}",
                fuenteSubtitulo,
                XBrushes.Black,
                anchoPagina - margenDerecho - 145,
                y + 52);

            y += 85;

            // ==========================================
            // DATOS GENERALES
            // ==========================================

            gfx.DrawRectangle(
                lapiz,
                margenIzquierdo,
                y,
                anchoUtil,
                70);

            gfx.DrawString(
                "DATOS DE LA LIQUIDACIÓN",
                fuenteNegrita,
                XBrushes.Black,
                margenIzquierdo + 8,
                y + 15);

            gfx.DrawString(
                $"Cliente: {cliente.NombreRazonSocial}",
                fuenteNormal,
                XBrushes.Black,
                margenIzquierdo + 8,
                y + 35);

            string modalidad =
                liquidacion.TipoFacturacion ==
                TipoFacturacion.CuentaCorriente
                    ? "Cuenta corriente"
                    : "Contado";

            gfx.DrawString(
                $"Modalidad: {modalidad}",
                fuenteNormal,
                XBrushes.Black,
                anchoPagina - margenDerecho - 180,
                y + 35);

            if (liquidacion.TipoFacturacion ==
                TipoFacturacion.CuentaCorriente)
            {
                string periodo =
                    $"{liquidacion.Mes:D2}/{liquidacion.Anio}";

                gfx.DrawString(
                    $"Período: {periodo}",
                    fuenteNormal,
                    XBrushes.Black,
                    margenIzquierdo + 8,
                    y + 54);
            }

            y += 90;

            // ==========================================
            // REMITOS INCLUIDOS
            // ==========================================

            gfx.DrawString(
                "REMITOS INCLUIDOS",
                fuenteSubtitulo,
                XBrushes.Black,
                margenIzquierdo,
                y);

            y += 15;

            double altoFila = 28;

            double x1 = margenIzquierdo;

            double wNumero = 120;
            double wFecha = 100;
            double wModalidad = 130;

            double wImporte =
                anchoUtil
                - wNumero
                - wFecha
                - wModalidad;

            DibujarCelda(
                gfx,
                lapiz,
                fuenteNegrita,
                "Remito",
                x1,
                y,
                wNumero,
                altoFila,
                true);

            DibujarCelda(
                gfx,
                lapiz,
                fuenteNegrita,
                "Fecha",
                x1 + wNumero,
                y,
                wFecha,
                altoFila,
                true);

            DibujarCelda(
                gfx,
                lapiz,
                fuenteNegrita,
                "Modalidad",
                x1 + wNumero + wFecha,
                y,
                wModalidad,
                altoFila,
                true);

            DibujarCelda(
                gfx,
                lapiz,
                fuenteNegrita,
                "Importe",
                x1 + wNumero + wFecha + wModalidad,
                y,
                wImporte,
                altoFila,
                true);

            y += altoFila;

            foreach (Remito remito in remitos)
            {
                DibujarCelda(
                    gfx,
                    lapiz,
                    fuenteNormal,
                    remito.NumeroRemito,
                    x1,
                    y,
                    wNumero,
                    altoFila,
                    true);

                DibujarCelda(
                    gfx,
                    lapiz,
                    fuenteNormal,
                    remito.Fecha.ToString("dd/MM/yyyy"),
                    x1 + wNumero,
                    y,
                    wFecha,
                    altoFila,
                    true);

                string modalidadRemito =
                    remito.TipoFacturacion ==
                    TipoFacturacion.CuentaCorriente
                        ? "Cuenta corriente"
                        : "Contado";

                DibujarCelda(
                    gfx,
                    lapiz,
                    fuenteNormal,
                    modalidadRemito,
                    x1 + wNumero + wFecha,
                    y,
                    wModalidad,
                    altoFila,
                    true);

                DibujarCelda(
                    gfx,
                    lapiz,
                    fuenteNormal,
                    remito.TotalFlete.ToString("C2"),
                    x1 + wNumero + wFecha + wModalidad,
                    y,
                    wImporte,
                    altoFila,
                    false,
                    true);

                y += altoFila;
            }

            // ==========================================
            // TOTAL
            // ==========================================

            y += 20;

            gfx.DrawRectangle(
                lapiz,
                anchoPagina - margenDerecho - 220,
                y,
                220,
                40);

            gfx.DrawString(
                $"TOTAL: {liquidacion.Total:C2}",
                fuenteTotal,
                XBrushes.Black,
                new XRect(
                    anchoPagina - margenDerecho - 210,
                    y + 11,
                    200,
                    20),
                XStringFormats.TopRight);

            // ==========================================
            // PIE
            // ==========================================

            double yPie =
                pagina.Height.Point - 60;

            gfx.DrawLine(
                lapiz,
                margenIzquierdo,
                yPie,
                anchoPagina - margenDerecho,
                yPie);

            gfx.DrawString(
                $"Liquidación N° {liquidacion.IdLiquidacion}",
                fuenteNormal,
                XBrushes.Black,
                new XRect(
                    margenIzquierdo,
                    yPie + 10,
                    anchoUtil,
                    20),
                XStringFormats.TopCenter);

            // ==========================================
            // GUARDADO
            // ==========================================

            string carpeta =
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments),
                    "Transtuaro",
                    "Liquidaciones");

            Directory.CreateDirectory(carpeta);

            string nombreArchivo =
                $"Liquidacion_{liquidacion.IdLiquidacion:D6}.pdf";

            string ruta =
                Path.Combine(
                    carpeta,
                    nombreArchivo);

            documento.Save(ruta);

            return ruta;
        }


        private static void DibujarCelda(
            XGraphics gfx,
            XPen lapiz,
            XFont fuente,
            string texto,
            double x,
            double y,
            double ancho,
            double alto,
            bool centrar = false,
            bool alinearDerecha = false)
        {
            gfx.DrawRectangle(
                lapiz,
                x,
                y,
                ancho,
                alto);

            XStringFormat formato;

            if (alinearDerecha)
            {
                formato =
                    new XStringFormat
                    {
                        Alignment =
                            XStringAlignment.Far,

                        LineAlignment =
                            XLineAlignment.Center
                    };
            }
            else if (centrar)
            {
                formato =
                    XStringFormats.Center;
            }
            else
            {
                formato =
                    new XStringFormat
                    {
                        Alignment =
                            XStringAlignment.Near,

                        LineAlignment =
                            XLineAlignment.Center
                    };
            }

            gfx.DrawString(
                texto,
                fuente,
                XBrushes.Black,
                new XRect(
                    x + 4,
                    y,
                    ancho - 8,
                    alto),
                formato);
        }
    }
}
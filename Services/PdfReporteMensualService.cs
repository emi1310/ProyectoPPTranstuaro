using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Trastuaro_V2.Modelos.Reportes;

namespace Trastuaro_V2.Services
{
    public class PdfReporteMensualService
    {
        public string GenerarPdf(
            ResumenMensualReporte resumen,
            List<RankingClienteReporte> ranking)
        {
            string carpetaDocumentos =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

            string carpetaReportes =
                Path.Combine(
                    carpetaDocumentos,
                    "Transtuaro",
                    "Reportes");

            Directory.CreateDirectory(carpetaReportes);

            string nombreArchivo =
                $"Reporte_Mensual_{resumen.Periodo.Replace("/", "_").Replace(" ", "_")}.pdf";

            string rutaPdf =
                Path.Combine(
                    carpetaReportes,
                    nombreArchivo);

            PdfDocument documento = new PdfDocument();

            documento.Info.Title =
                $"Reporte Mensual - {resumen.Periodo}";

            PdfPage pagina = documento.AddPage();

            pagina.Size = PdfSharp.PageSize.A4;

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
                    12,
                    XFontStyleEx.Bold);

            XFont fuenteNormal =
                new XFont(
                    "Arial",
                    10,
                    XFontStyleEx.Regular);

            XFont fuenteNegrita =
                new XFont(
                    "Arial",
                    10,
                    XFontStyleEx.Bold);

            double margenIzquierdo = 50;
            double margenDerecho = 545;
            double y = 50;

            // ==========================================================
            // ENCABEZADO
            // ==========================================================

            gfx.DrawString(
                "TRANSTUARO",
                fuenteTitulo,
                XBrushes.Black,
                new XRect(
                    0,
                    y,
                    pagina.Width.Point,
                    30),
                XStringFormats.TopCenter);

            y += 35;

            gfx.DrawString(
                "REPORTE MENSUAL",
                fuenteSubtitulo,
                XBrushes.Black,
                new XRect(
                    0,
                    y,
                    pagina.Width.Point,
                    25),
                XStringFormats.TopCenter);

            y += 35;

            gfx.DrawString(
                $"Período: {resumen.Periodo}",
                fuenteNegrita,
                XBrushes.Black,
                margenIzquierdo,
                y);

            y += 30;

            gfx.DrawLine(
                XPens.Black,
                margenIzquierdo,
                y,
                margenDerecho,
                y);

            y += 25;

            // ==========================================================
            // RESUMEN GENERAL
            // ==========================================================

            gfx.DrawString(
                "RESULTADO GENERAL DEL PERÍODO",
                fuenteSubtitulo,
                XBrushes.Black,
                margenIzquierdo,
                y);

            y += 30;

            DibujarFilaResumen(
                gfx,
                "Total Facturado:",
                resumen.TotalFacturado.ToString("C2"),
                margenIzquierdo,
                ref y,
                fuenteNormal,
                fuenteNegrita);

            DibujarFilaResumen(
                gfx,
                "Cuenta Corriente:",
                resumen.TotalCuentaCorriente.ToString("C2"),
                margenIzquierdo,
                ref y,
                fuenteNormal,
                fuenteNegrita);

            DibujarFilaResumen(
                gfx,
                "Contado:",
                resumen.TotalContado.ToString("C2"),
                margenIzquierdo,
                ref y,
                fuenteNormal,
                fuenteNegrita);

            DibujarFilaResumen(
                gfx,
                "Clientes con Actividad:",
                resumen.ClientesConActividad.ToString(),
                margenIzquierdo,
                ref y,
                fuenteNormal,
                fuenteNegrita);

            DibujarFilaResumen(
                gfx,
                "Cantidad de Remitos:",
                resumen.CantidadRemitos.ToString(),
                margenIzquierdo,
                ref y,
                fuenteNormal,
                fuenteNegrita);

            DibujarFilaResumen(
                gfx,
                "Cantidad de Liquidaciones:",
                resumen.CantidadLiquidaciones.ToString(),
                margenIzquierdo,
                ref y,
                fuenteNormal,
                fuenteNegrita);

            y += 15;

            gfx.DrawLine(
                XPens.Black,
                margenIzquierdo,
                y,
                margenDerecho,
                y);

            y += 25;

            // ==========================================================
            // RANKING
            // ==========================================================

            gfx.DrawString(
                "RANKING DE CLIENTES POR FACTURACIÓN",
                fuenteSubtitulo,
                XBrushes.Black,
                margenIzquierdo,
                y);

            y += 30;

            DibujarEncabezadoRanking(
                gfx,
                margenIzquierdo,
                y,
                fuenteNegrita);

            y += 25;

            foreach (RankingClienteReporte item in ranking)
            {
                if (y > 780)
                {
                    pagina = documento.AddPage();
                    pagina.Size = PdfSharp.PageSize.A4;

                    gfx.Dispose();

                    gfx =
                        XGraphics.FromPdfPage(pagina);

                    y = 50;

                    DibujarEncabezadoRanking(
                        gfx,
                        margenIzquierdo,
                        y,
                        fuenteNegrita);

                    y += 25;
                }

                DibujarFilaRanking(
                    gfx,
                    item,
                    margenIzquierdo,
                    y,
                    fuenteNormal);

                y += 23;
            }

            // ==========================================================
            // PIE
            // ==========================================================

            gfx.DrawString(
                $"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}",
                fuenteNormal,
                XBrushes.Gray,
                new XRect(
                    margenIzquierdo,
                    pagina.Height.Point - 45,
                    495,
                    20),
                XStringFormats.Center);

            gfx.Dispose();

            documento.Save(rutaPdf);
            documento.Close();

            return rutaPdf;
        }

        private void DibujarFilaResumen(
            XGraphics gfx,
            string etiqueta,
            string valor,
            double x,
            ref double y,
            XFont fuenteNormal,
            XFont fuenteNegrita)
        {
            gfx.DrawString(
                etiqueta,
                fuenteNormal,
                XBrushes.Black,
                x,
                y);

            gfx.DrawString( valor, fuenteNegrita, XBrushes.Black, new XRect( x + 220, y - 12, 180,  20), XStringFormats.CenterRight);

            y += 23;
        }

        private void DibujarEncabezadoRanking(
            XGraphics gfx,
            double x,
            double y,
            XFont fuente)
        {
            gfx.DrawString(
                "Puesto",
                fuente,
                XBrushes.Black,
                x,
                y);

            gfx.DrawString(
                "Cliente",
                fuente,
                XBrushes.Black,
                x + 60,
                y);

            gfx.DrawString(
                "Remitos",
                fuente,
                XBrushes.Black,
                x + 300,
                y);

            gfx.DrawString(
                "Total Facturado",
                fuente,
                XBrushes.Black,
                x + 390,
                y);

            gfx.DrawLine(
                XPens.Black,
                x,
                y + 7,
                x + 495,
                y + 7);
        }

        private void DibujarFilaRanking(
            XGraphics gfx,
            RankingClienteReporte item,
            double x,
            double y,
            XFont fuente)
        {
            gfx.DrawString(
                item.Puesto.ToString(),
                fuente,
                XBrushes.Black,
                x,
                y);

            gfx.DrawString(
                item.Cliente,
                fuente,
                XBrushes.Black,
                x + 60,
                y);

            gfx.DrawString(
                item.CantidadRemitos.ToString(),
                fuente,
                XBrushes.Black,
                x + 310,
                y);

            gfx.DrawString( item.TotalFacturado.ToString("C2"),
                fuente, XBrushes.Black, new XRect( x + 340, y - 12, 125, 20), XStringFormats.CenterRight);
        }
    }
}
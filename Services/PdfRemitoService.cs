using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Trastuaro_V2.Modelos;

namespace Trastuaro_V2.Services
{
    public class PdfRemitoService
    {
        public string GenerarPdf(
            Remito remito,
            Cliente cliente,
            List<DetalleRemito> detalles)
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
                65);

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
                $"REMITO N° {remito.NumeroRemito}",
                fuenteSubtitulo,
                XBrushes.Black,
                margenIzquierdo + 10,
                y + 50);

            gfx.DrawString(
                $"Fecha: {remito.Fecha:dd/MM/yyyy}",
                fuenteSubtitulo,
                XBrushes.Black,
                anchoPagina - margenDerecho - 120,
                y + 50);

            y += 80;

            // ==========================================
            // DATOS DEL CLIENTE
            // ==========================================

            gfx.DrawRectangle(
                lapiz,
                margenIzquierdo,
                y,
                anchoUtil,
                55);

            gfx.DrawString(
                "DATOS DEL CLIENTE",
                fuenteNegrita,
                XBrushes.Black,
                margenIzquierdo + 8,
                y + 15);

            gfx.DrawString(
                $"Cliente: {cliente.NombreRazonSocial}",
                fuenteNormal,
                XBrushes.Black,
                margenIzquierdo + 8,
                y + 34);

            string modalidad =
                remito.TipoFacturacion ==
                TipoFacturacion.CuentaCorriente
                    ? "Cuenta corriente"
                    : "Contado";

            gfx.DrawString(
                $"Modalidad: {modalidad}",
                fuenteNormal,
                XBrushes.Black,
                anchoPagina - margenDerecho - 170,
                y + 34);

            y += 75;

            // ==========================================
            // TABLA DE DETALLES
            // ==========================================

            gfx.DrawString(
                "DETALLE DEL REMITO",
                fuenteSubtitulo,
                XBrushes.Black,
                margenIzquierdo,
                y);

            y += 15;

            double altoFila = 28;

            double x1 = margenIzquierdo;
            double wCantidad = 45;
            double wDescripcion = 120;
            double wProveedor = 95;
            double wRemitoOrigen = 75;
            double wValorDeclarado = 85;

            double wImporte =
                anchoUtil
                - wCantidad
                - wDescripcion
                - wProveedor
                - wRemitoOrigen
                - wValorDeclarado;

            // Encabezados
            DibujarCelda(
                gfx,
                lapiz,
                fuenteNegrita,
                "Bultos",
                x1,
                y,
                wCantidad,
                altoFila,
                true);

            DibujarCelda(
                gfx,
                lapiz,
                fuenteNegrita,
                "Descripción",
                x1 + wCantidad,
                y,
                wDescripcion,
                altoFila,
                true);

            DibujarCelda(
                gfx,
                lapiz,
                fuenteNegrita,
                "Proveedor",
                x1 + wCantidad + wDescripcion,
                y,
                wProveedor,
                altoFila,
                true);

            DibujarCelda(
                gfx,
                lapiz,
                fuenteNegrita,
                "Remito origen",
                x1 + wCantidad + wDescripcion + wProveedor,
                y,
                wRemitoOrigen,
                altoFila,
                true);

            DibujarCelda(
                gfx,
                lapiz,
                fuenteNegrita,
                "Valor declarado",
                x1
                    + wCantidad
                    + wDescripcion
                    + wProveedor
                    + wRemitoOrigen,
                y,
                wValorDeclarado,
                altoFila,
                true);

            DibujarCelda(
                gfx,
                lapiz,
                fuenteNegrita,
                "Flete",
                x1
                    + wCantidad
                    + wDescripcion
                    + wProveedor
                    + wRemitoOrigen
                    + wValorDeclarado,
                y,
                wImporte,
                altoFila,
                true);

            y += altoFila;

            foreach (DetalleRemito detalle in detalles)
            {
                DibujarCelda(
                    gfx,
                    lapiz,
                    fuenteNormal,
                    detalle.CantidadBultos.ToString(),
                    x1,
                    y,
                    wCantidad,
                    altoFila,
                    true);

                DibujarCelda(
                    gfx,
                    lapiz,
                    fuenteNormal,
                    detalle.Descripcion ?? "-",
                    x1 + wCantidad,
                    y,
                    wDescripcion,
                    altoFila);

                DibujarCelda(
                    gfx,
                    lapiz,
                    fuenteNormal,
                    detalle.ProveedorOrigen ?? "-",
                    x1 + wCantidad + wDescripcion,
                    y,
                    wProveedor,
                    altoFila);

                DibujarCelda(
                    gfx,
                    lapiz,
                    fuenteNormal,
                    detalle.NumeroRemitoOrigen ?? "-",
                    x1
                        + wCantidad
                        + wDescripcion
                        + wProveedor,
                    y,
                    wRemitoOrigen,
                    altoFila,
                    true);

                DibujarCelda(
                    gfx,
                    lapiz,
                    fuenteNormal,
                    detalle.ValorDeclarado.ToString("C2"),
                    x1
                        + wCantidad
                        + wDescripcion
                        + wProveedor
                        + wRemitoOrigen,
                    y,
                    wValorDeclarado,
                    altoFila,
                    false,
                    true);

                DibujarCelda(
                    gfx,
                    lapiz,
                    fuenteNormal,
                    detalle.ImporteFlete.ToString("C2"),
                    x1
                        + wCantidad
                        + wDescripcion
                        + wProveedor
                        + wRemitoOrigen
                        + wValorDeclarado,
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
                anchoPagina - margenDerecho - 210,
                y,
                210,
                38);

            gfx.DrawString(
                $"TOTAL FLETE: {remito.TotalFlete:C2}",
                fuenteTotal,
                XBrushes.Black,
                new XRect(
                    anchoPagina - margenDerecho - 200,
                    y + 10,
                    190,
                    20),
                XStringFormats.TopRight);

            // ==========================================
            // LEYENDA INFERIOR
            // ==========================================

            double yLeyenda =
                pagina.Height.Point - 70;

            gfx.DrawLine(
                lapiz,
                margenIzquierdo,
                yLeyenda,
                anchoPagina - margenDerecho,
                yLeyenda);

            gfx.DrawString(
                "NO APTO COMO DOCUMENTO LEGAL O FACTURA",
                fuenteSubtitulo,
                XBrushes.Black,
                new XRect(
                    margenIzquierdo,
                    yLeyenda + 12,
                    anchoUtil,
                    25),
                XStringFormats.TopCenter);

            // ==========================================
            // GUARDADO
            // ==========================================

            string carpeta =
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments),
                    "Transtuaro",
                    "Remitos");

            Directory.CreateDirectory(carpeta);

            string nombreArchivo =
                $"Remito_{remito.NumeroRemito.Replace("/", "-")}.pdf";

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
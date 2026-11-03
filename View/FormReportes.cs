using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trastuaro_V2.Controllers;
using Trastuaro_V2.Modelos;
using Trastuaro_V2.Modelos.Reportes;
using Trastuaro_V2.Services;


namespace Trastuaro_V2.View
{
    public partial class FormReportes : Form
    {
        private readonly ReporteController _reporteController;
        public FormReportes()
        {
            InitializeComponent();
            _reporteController = new ReporteController();

            cboMes.DataSource = Enum.GetValues(typeof(Mes));



            cboMes.SelectedIndex =
                DateTime.Today.Month - 1;

            nudAnio.Value =
                DateTime.Today.Year;
            cboMes.SelectedIndexChanged += CambioPeriodo;

            nudAnio.ValueChanged += CambioPeriodo;

            btnConsultar.Click += BtnConsultar_Click;
            btnGenerarPdf.Click += BtnGenerarPdf_Click;
        }

        private int ObtenerMesSeleccionado()
        {
            if (cboMes.SelectedItem == null)
            {
                throw new InvalidOperationException(
                    "Debe seleccionar un mes.");
            }

            Mes mesSeleccionado =
                (Mes)cboMes.SelectedItem;

            return (int)mesSeleccionado;
        }
        private int ObtenerAnioSeleccionado()
        {
            return Convert.ToInt32(nudAnio.Value);
        }
        private void CambioPeriodo(object? sender, EventArgs e)
        {
            LimpiarReporte();
        }

        private void BtnConsultar_Click( object? sender, EventArgs e)
        {
            try
            {
                int mes = ObtenerMesSeleccionado();
                int anio = ObtenerAnioSeleccionado();

                ReporteMensual reporte = _reporteController.ObtenerReporteMensual(mes, anio);


                MostrarReporte(reporte);
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Error al generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGenerarPdf_Click( object? sender, EventArgs e)
        {
            try
            {
                int mes = ObtenerMesSeleccionado();
                int anio = ObtenerAnioSeleccionado();

                ReporteMensual reporte = _reporteController.ObtenerReporteMensual( mes, anio);

                GenerarPdfReporte(reporte);
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Error al generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarReporte(ReporteMensual reporte)
        {
            List<RankingClienteReporte> ranking =
                reporte.Ranking;

            dgvRanking.DataSource = null;
            dgvRanking.DataSource = ranking;

            ConfigurarGrillaRanking();

            ResumenMensualReporte resumen =
                reporte.Resumen;

            lblValorPeriodo.Text =
                resumen.Periodo;

            lblValorTotalFacturado.Text =
                resumen.TotalFacturado.ToString("C2");

            lblValorCuentaCorriente.Text =
                resumen.TotalCuentaCorriente.ToString("C2");

            lblValorContado.Text =
                resumen.TotalContado.ToString("C2");

            lblValorClientesActividad.Text =
                resumen.ClientesConActividad.ToString();

            lblValorCantidadRemitos.Text =
                resumen.CantidadRemitos.ToString();

            lblValorCantidadLiquidaciones.Text =
                resumen.CantidadLiquidaciones.ToString();
        }

        private void ConfigurarGrillaRanking()
        {
            dgvRanking.ReadOnly = true;
            dgvRanking.AllowUserToAddRows = false;
            dgvRanking.AllowUserToDeleteRows = false;

            dgvRanking.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvRanking.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvRanking.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            if (dgvRanking.Columns["Puesto"] != null)
            {
                dgvRanking.Columns["Puesto"].HeaderText = "Puesto";
                dgvRanking.Columns["Puesto"].FillWeight = 12;
            }

            if (dgvRanking.Columns["Cliente"] != null)
            {
                dgvRanking.Columns["Cliente"].HeaderText = "Cliente";
                dgvRanking.Columns["Cliente"].FillWeight = 35;
            }

            if (dgvRanking.Columns["Periodo"] != null)
            {
                dgvRanking.Columns["Periodo"].HeaderText = "Período";
                dgvRanking.Columns["Periodo"].FillWeight = 18;
            }

            if (dgvRanking.Columns["CantidadRemitos"] != null)
            {
                dgvRanking.Columns["CantidadRemitos"].HeaderText =
                    "Cantidad de Remitos";

                dgvRanking.Columns["CantidadRemitos"].FillWeight = 20;
            }

            if (dgvRanking.Columns["TotalFacturado"] != null)
            {
                dgvRanking.Columns["TotalFacturado"].HeaderText =
                    "Total Facturado";

                dgvRanking.Columns["TotalFacturado"].FillWeight = 25;

                dgvRanking.Columns["TotalFacturado"]
                    .DefaultCellStyle.Format = "C2";

                dgvRanking.Columns["TotalFacturado"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void GenerarPdfReporte( ReporteMensual reporte)
        {
            string rutaPdf =  _reporteController.GenerarPdf(reporte);

            MessageBox.Show(
                $"PDF generado correctamente.\n\nArchivo:\n{rutaPdf}",
                "Reporte mensual",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void LimpiarReporte()
        {
            dgvRanking.DataSource = null;

            lblValorPeriodo.Text = "-";
            lblValorTotalFacturado.Text = "-";
            lblValorCuentaCorriente.Text = "-";
            lblValorContado.Text = "-";
            lblValorClientesActividad.Text = "-";
            lblValorCantidadRemitos.Text = "-";
            lblValorCantidadLiquidaciones.Text = "-";
        }
        
    }
}

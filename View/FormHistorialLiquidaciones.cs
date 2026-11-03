using System.Windows.Forms;
using Trastuaro_V2.Controllers;
using Trastuaro_V2.Modelos;
using Trastuaro_V2.Repositories;
using Trastuaro_V2.Services;


namespace Trastuaro_V2
{
    public partial class FormHistorialLiquidaciones : Form
    {
        private readonly ClienteController _clienteController;
        private readonly LiquidacionController _liquidacionController;
        public FormHistorialLiquidaciones()
        {
            InitializeComponent();

            dgvLiquidaciones.SelectionChanged += DgvLiquidaciones_SelectionChanged;

            btnGenerarPdf.Click += BtnGenerarPdf_Click;
            ClienteRepository clienteRepository = new();
            ClienteService clienteService = new(clienteRepository);

            _clienteController =
                new ClienteController(clienteService);

            PdfLiquidacionService pdfLiquidacionService = new();

            LiquidacionService liquidacionService =
                new LiquidacionService(
                    pdfLiquidacionService);

            _liquidacionController =
                new LiquidacionController(
                    liquidacionService);

            CargarClientes();
        }

        private void DgvLiquidaciones_SelectionChanged(
    object? sender,
    EventArgs e)
        {
            if (dgvLiquidaciones.CurrentRow?.DataBoundItem
                is not Liquidacion liquidacion)
            {
                dgvDetalleLiquidacion.DataSource = null;
                return;
            }

            List<Remito> remitos =
                _liquidacionController.ObtenerRemitosPorLiquidacion(
                    liquidacion.IdLiquidacion);

            dgvDetalleLiquidacion.DataSource = null;
            dgvDetalleLiquidacion.DataSource = remitos;
            dgvDetalleLiquidacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleLiquidacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetalleLiquidacion.Columns["TotalFlete"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleLiquidacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvDetalleLiquidacion.Columns["IdRemito"] != null)
                dgvDetalleLiquidacion.Columns["IdRemito"].Visible = false;

            if (dgvDetalleLiquidacion.Columns["IdCliente"] != null)
                dgvDetalleLiquidacion.Columns["IdCliente"].Visible = false;

            if (dgvDetalleLiquidacion.Columns["NumeroRemito"] != null)
                dgvDetalleLiquidacion.Columns["NumeroRemito"].HeaderText =
                    "N° Remito";

            if (dgvDetalleLiquidacion.Columns["TipoFacturacion"] != null)
                dgvDetalleLiquidacion.Columns["TipoFacturacion"].HeaderText =
                    "Modalidad";
            if (dgvDetalleLiquidacion.Columns["Estado"] != null)
            {
                dgvDetalleLiquidacion.Columns["Estado"].HeaderText =
                    "Estado Remito";
            }

            if (dgvDetalleLiquidacion.Columns["TotalFlete"] != null)
            {
                dgvDetalleLiquidacion.Columns["TotalFlete"].HeaderText =
                    "Importe";

                dgvDetalleLiquidacion.Columns["TotalFlete"]
                    .DefaultCellStyle.Format = "C2";

                dgvDetalleLiquidacion.Columns["TotalFlete"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
            
        }

        private void cboCliente_SelectedValueChanged( object sender, EventArgs e)
        {
            try
            {
                if (cboCliente.SelectedItem
                    is not Cliente cliente)
                {
                    return;
                }

                List<Liquidacion> liquidaciones =
                    _liquidacionController.ObtenerPorCliente(
                        cliente.IdCliente);

                dgvLiquidaciones.DataSource = null;
                dgvLiquidaciones.DataSource = liquidaciones;

                bool mostrarPeriodo = liquidaciones.Any( l => l.TipoFacturacion == TipoFacturacion.CuentaCorriente);

                if (dgvLiquidaciones.Columns["Mes"] != null)
                    dgvLiquidaciones.Columns["Mes"].Visible =  mostrarPeriodo;

                if (dgvLiquidaciones.Columns["Anio"] != null)
                    dgvLiquidaciones.Columns["Anio"].Visible = mostrarPeriodo;
                if (dgvLiquidaciones.Columns["Estado"] != null)
                {
                    dgvLiquidaciones.Columns["Estado"].HeaderText = "Estado Liquidación";
                }

                dgvLiquidaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLiquidaciones.DefaultCellStyle.Alignment =  DataGridViewContentAlignment.MiddleCenter;


                dgvLiquidaciones.AutoSizeColumnsMode =  DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvLiquidaciones.Columns["IdCliente"] != null)
                    dgvLiquidaciones.Columns["IdCliente"].Visible = false;

                if (dgvLiquidaciones.Columns["TipoFacturacion"] != null)
                    dgvLiquidaciones.Columns["TipoFacturacion"].HeaderText = "Modalidad";

                if (dgvLiquidaciones.Columns["FechaEmision"] != null)
                    dgvLiquidaciones.Columns["FechaEmision"].HeaderText = "Fecha";

                if (dgvLiquidaciones.Columns["Anio"] != null)
                    dgvLiquidaciones.Columns["Anio"].HeaderText = "Año";

                if (dgvLiquidaciones.Columns["Total"] != null)
                {
                    dgvLiquidaciones.Columns["Total"].HeaderText = "Total";

                    dgvLiquidaciones.Columns["Total"].DefaultCellStyle.Alignment =  DataGridViewContentAlignment.MiddleRight;

                    dgvLiquidaciones.Columns["Total"].DefaultCellStyle.Format = "C2";
                    dgvLiquidaciones.Columns["Total"].HeaderCell.Style.Alignment =  DataGridViewContentAlignment.MiddleCenter;

                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al consultar liquidaciones",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvLiquidaciones_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void CargarClientes()
        {
            List<Cliente> clientes =
                _clienteController.ListarClientesActivos();

            cboCliente.DataSource = clientes;

            if (clientes.Count > 0)
            {
                cboCliente.SelectedIndex = 0;
            }
        }

        private void BtnGenerarPdf_Click( object? sender, EventArgs e)
        {
            try
            {
                if (cboCliente.SelectedItem is not Cliente cliente)
                {
                    throw new InvalidOperationException(
                        "Debe seleccionar un cliente.");
                }

                if (dgvLiquidaciones.CurrentRow?.DataBoundItem
                    is not Liquidacion liquidacion)
                {
                    throw new InvalidOperationException(
                        "Debe seleccionar una liquidación.");
                }

                List<Remito> remitos =
                    _liquidacionController
                        .ObtenerRemitosPorLiquidacion(
                            liquidacion.IdLiquidacion);

                string rutaPdf =
                    _liquidacionController.RegenerarPdf(
                        liquidacion,
                        cliente,
                        remitos);

                MessageBox.Show(
                    $"PDF de la Liquidación N° {liquidacion.IdLiquidacion} regenerado correctamente.\n\n" +
                    $"Archivo:\n{rutaPdf}",
                    "PDF regenerado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show(
                    "El PDF de esta liquidación está abierto en otro programa.\n\n" +
                    "Cerralo antes de intentar regenerarlo.",
                    "PDF en uso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al regenerar PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }

}
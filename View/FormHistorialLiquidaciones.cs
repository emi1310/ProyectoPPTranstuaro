using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private readonly LiquidacionMensualController _liquidacionController;
        public FormHistorialLiquidaciones()
        {
            InitializeComponent();
            dgvLiquidaciones.SelectionChanged +=
    DgvLiquidaciones_SelectionChanged;
            ClienteRepository clienteRepository = new();

            LiquidacionMensualRepository liquidacionRepository = new();

            DetalleLiquidacionRepository detalleLiquidacionRepository = new();

            RemitoRepository remitoRepository = new();

            LiquidacionMensualService liquidacionService =
                new(
                    liquidacionRepository,
                    detalleLiquidacionRepository,
                    remitoRepository,
                    clienteRepository);

            _liquidacionController =
                new LiquidacionMensualController(
                    liquidacionService);

            ClienteService clienteService =
                new(clienteRepository);

            _clienteController =
                new ClienteController(clienteService);
            CargarClientes();
            btnBuscarLiquidaciones.Click += BtnBuscarLiquidaciones_Click;
        }

        private void DgvLiquidaciones_SelectionChanged(
    object? sender,
    EventArgs e)
        {
            if (dgvLiquidaciones.CurrentRow?.DataBoundItem
                is not LiquidacionMensual liquidacion)
            {
                return;
            }

            List<Remito> remitos =
                _liquidacionController.ObtenerRemitosPorLiquidacion(
                    liquidacion.IdLiquidacion);

            dgvDetalleLiquidacion.DataSource = null;
            dgvDetalleLiquidacion.DataSource = remitos;

            if (dgvDetalleLiquidacion.Columns["IdRemito"] != null)
                dgvDetalleLiquidacion.Columns["IdRemito"].Visible = false;

            if (dgvDetalleLiquidacion.Columns["IdCliente"] != null)
                dgvDetalleLiquidacion.Columns["IdCliente"].Visible = false;

            if (dgvDetalleLiquidacion.Columns["NumeroRemito"] != null)
                dgvDetalleLiquidacion.Columns["NumeroRemito"].HeaderText = "N° Remito";

            if (dgvDetalleLiquidacion.Columns["Fecha"] != null)
                dgvDetalleLiquidacion.Columns["Fecha"].HeaderText = "Fecha";

            if (dgvDetalleLiquidacion.Columns["CondicionPago"] != null)
                dgvDetalleLiquidacion.Columns["CondicionPago"].HeaderText = "Condición";

            if (dgvDetalleLiquidacion.Columns["Estado"] != null)
                dgvDetalleLiquidacion.Columns["Estado"].HeaderText = "Estado";

            if (dgvDetalleLiquidacion.Columns["TotalFlete"] != null)
            {
                dgvDetalleLiquidacion.Columns["TotalFlete"].HeaderText = "Importe";
                dgvDetalleLiquidacion.Columns["TotalFlete"].DefaultCellStyle.Format = "C2";
                dgvDetalleLiquidacion.Columns["TotalFlete"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                dgvDetalleLiquidacion.Columns["TotalFlete"].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
                       
        }
        private void BtnBuscarLiquidaciones_Click(
    object? sender,
    EventArgs e)
        {
            try
            {
                if (cboCliente.SelectedItem is not Cliente cliente)
                {
                    throw new ArgumentException(
                        "Debe seleccionar un cliente.");
                }

                List<LiquidacionMensual> liquidaciones =
                    _liquidacionController.ObtenerPorCliente(
                        cliente.IdCliente);

                dgvLiquidaciones.DataSource = null;
                dgvLiquidaciones.DataSource = liquidaciones;

                if (dgvLiquidaciones.Columns["IdCliente"] != null)
                    dgvLiquidaciones.Columns["IdCliente"].Visible = false;

                if (dgvLiquidaciones.Columns["IdLiquidacion"] != null)
                    dgvLiquidaciones.Columns["IdLiquidacion"].HeaderText = "ID";

                if (dgvLiquidaciones.Columns["FechaEmision"] != null)
                    dgvLiquidaciones.Columns["FechaEmision"].HeaderText = "Fecha";

                if (dgvLiquidaciones.Columns["TipoLiquidacion"] != null)
                    dgvLiquidaciones.Columns["TipoLiquidacion"].HeaderText = "Tipo";

                if (dgvLiquidaciones.Columns["Mes"] != null)
                    dgvLiquidaciones.Columns["Mes"].HeaderText = "Mes";

                if (dgvLiquidaciones.Columns["Anio"] != null)
                    dgvLiquidaciones.Columns["Anio"].HeaderText = "Año";

                if (dgvLiquidaciones.Columns["Estado"] != null)
                    dgvLiquidaciones.Columns["Estado"].HeaderText = "Estado";

                if (dgvLiquidaciones.Columns["Total"] != null)
                {
                    dgvLiquidaciones.Columns["Total"].HeaderText = "Total";
                    dgvLiquidaciones.Columns["Total"].DefaultCellStyle.Format = "C2";
                    dgvLiquidaciones.Columns["Total"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                    dgvLiquidaciones.Columns["Total"].HeaderCell.Style.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }

        
                if (liquidaciones.Count == 0)
                {
                    MessageBox.Show(
                        "El cliente seleccionado no posee liquidaciones registradas.",
                        "Sin liquidaciones",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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
    }
}

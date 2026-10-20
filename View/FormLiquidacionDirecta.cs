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
    public partial class FormLiquidacionDirecta : Form
    {
        private readonly Cliente _cliente;
        private readonly RemitoController _remitoController;

        private readonly LiquidacionMensualController _liquidacionController;

        private List<Remito> _remitos = new();

        public FormLiquidacionDirecta(Cliente cliente)
        {
            InitializeComponent();
            RemitoRepository remitoRepository = new();

            DetalleRemitoRepository detalleRepository = new();

            RemitoService remitoService =
                new(
                    remitoRepository,
                    detalleRepository);

            _remitoController =
                new RemitoController(remitoService);
            LiquidacionMensualRepository liquidacionRepository =
    new();

            DetalleLiquidacionRepository detalleLiquidacionRepository =
                new();

            ClienteRepository clienteRepository =
                new();

            LiquidacionMensualService liquidacionService =
                new(
                    liquidacionRepository,
                    detalleLiquidacionRepository,
                    remitoRepository,
                    clienteRepository);

            _liquidacionController =
                new LiquidacionMensualController(
                    liquidacionService);

            _cliente = cliente;
            lblCliente.Text =
    $"{_cliente.NombreRazonSocial} - {_cliente.CuitDni}";

            cboEstado.Items.Clear();

            cboEstado.Items.AddRange(
            [
                "Pendiente",
                "Facturado",
                "Todos"
            ]);

            cboEstado.SelectedIndex = 0;
            btnBuscarRemitos.Click +=
    BtnBuscarRemitos_Click;
            button1.Click +=
    BtnGenerarDirecta_Click;
            button1.Enabled = false;
            cboEstado.SelectedIndexChanged +=  CboEstado_SelectedIndexChanged;
        }

        private void CboEstado_SelectedIndexChanged(
    object? sender,
    EventArgs e)
        {
            button1.Enabled = false;
        }
        private void BtnGenerarDirecta_Click(
     object? sender,
     EventArgs e)
        {
            if (_remitos.Count == 0)
            {
                MessageBox.Show(
                    "No existen remitos pendientes para liquidar.",
                    "Sin remitos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult respuesta =
                MessageBox.Show(
                    "¿Confirma la generación de la liquidación directa?",
                    "Confirmar liquidación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }
            LiquidacionMensual liquidacion =
    new LiquidacionMensual
    {
        IdCliente = _cliente.IdCliente,
        Mes = DateTime.Today.Month,
        Anio = DateTime.Today.Year,
        FechaEmision = DateTime.Today,
        Estado = "Cerrada",
        TipoLiquidacion = "Directa"
    };

            List<DetalleLiquidacion> detalles =
                _remitos
                    .Select(remito =>
                        new DetalleLiquidacion
                        {
                            IdRemito = remito.IdRemito,
                            Importe = remito.TotalFlete
                        })
                    .ToList();

            _liquidacionController.RegistrarLiquidacion(
                liquidacion,
                detalles);

            MessageBox.Show(
    "La liquidación directa fue generada correctamente.",
    "Liquidación generada",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information);

            _remitos.Clear();

            dgvRemitosNuevo.DataSource = null;

            lblTotal.Text = "$ 0,00";

            button1.Enabled = false;
        }
        private void BtnBuscarRemitos_Click(object? sender,EventArgs e)
        {
            string estado = cboEstado.SelectedItem?.ToString() ?? "Pendiente";

            _remitos =
     _remitoController.ObtenerPorClienteYEstado(
         _cliente.IdCliente,
         estado);

            dgvRemitosNuevo.DataSource = null;
            dgvRemitosNuevo.DataSource = _remitos;

            if (dgvRemitosNuevo.Columns["IdRemito"] != null)
            {
                dgvRemitosNuevo.Columns["IdRemito"].Visible = false;
            }

            if (dgvRemitosNuevo.Columns["IdCliente"] != null)
            {
                dgvRemitosNuevo.Columns["IdCliente"].Visible = false;
            }

            if (dgvRemitosNuevo.Columns["NumeroRemito"] != null)
            {
                dgvRemitosNuevo.Columns["NumeroRemito"].HeaderText = "N° Remito";
            }

            if (dgvRemitosNuevo.Columns["Fecha"] != null)
            {
                dgvRemitosNuevo.Columns["Fecha"].HeaderText = "Fecha";
            }

            if (dgvRemitosNuevo.Columns["CondicionPago"] != null)
            {
                dgvRemitosNuevo.Columns["CondicionPago"].HeaderText = "Condición de pago";
            }

            if (dgvRemitosNuevo.Columns["Estado"] != null)
            {
                dgvRemitosNuevo.Columns["Estado"].HeaderText = "Estado";
            }

            if (dgvRemitosNuevo.Columns["TotalFlete"] != null)
            {
                dgvRemitosNuevo.Columns["TotalFlete"].HeaderText = "Importe";

                dgvRemitosNuevo.Columns["TotalFlete"].DefaultCellStyle.Format = "C2";

                dgvRemitosNuevo.Columns["TotalFlete"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgvRemitosNuevo.Columns["TotalFlete"].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
            decimal total = _remitos.Sum(remito => remito.TotalFlete);

            lblTotal.Text = total.ToString("C2");
            if (_remitos.Count == 0)
            {
                MessageBox.Show(
                    $"No se encontraron remitos en estado {estado}.",
                    "Sin remitos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            button1.Enabled = estado == "Pendiente" && _remitos.Count > 0;
        }
        
    }
}

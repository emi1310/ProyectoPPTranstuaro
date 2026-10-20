using Trastuaro_V2.Controllers;
using Trastuaro_V2.Modelos;
using Trastuaro_V2.Repositories;
using Trastuaro_V2.Services;

namespace Trastuaro_V2
{
    public partial class FormRemitos : Form
    {
        private readonly ClienteController _clienteController;
        private readonly RemitoController _remitoController;

        public FormRemitos()
        {
            InitializeComponent();

            btnAbrirLiquidaciones.Click += BtnAbrirLiquidaciones_Click;

            ClienteRepository clienteRepository = new();
            ClienteService clienteService =
                new(clienteRepository);

            _clienteController =
                new ClienteController(clienteService);

            RemitoRepository remitoRepository = new();

            DetalleRemitoRepository detalleRepository =
                new();

            RemitoService remitoService = new(
                remitoRepository,
                detalleRepository);

            _remitoController = new RemitoController(remitoService);
            txtNumeroRemito.Text = _remitoController.ObtenerProximoNumero();
            txtNumeroRemito.ReadOnly = true;

            ConfigurarCombos();
            CargarClientes();
        }

        private void ConfigurarCombos()
        {
            cboCliente.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboCondicionPago.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboCondicionPago.Enabled = false;

            cboCondicionPago.Items.Clear();

            cboCondicionPago.Items.AddRange(
            [
                "Cuenta corriente",
                "Contado"
            ]);

            cboCliente.SelectedIndexChanged +=
                CboCliente_SelectedIndexChanged;
        }

        private void CargarClientes()
        {
            List<Cliente> clientes =
                _clienteController
                    .ListarClientesActivos();

            cboCliente.DataSource = clientes;

            if (clientes.Count > 0)
            {
                cboCliente.SelectedIndex = 0;
                ActualizarCondicionPago();
            }
            else
            {
                MessageBox.Show(
                    "No existen clientes activos para registrar remitos.",
                    "Sin clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void CboCliente_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            ActualizarCondicionPago();
        }

        private void ActualizarCondicionPago()
        {
            if (cboCliente.SelectedItem is not Cliente cliente)
            {
                cboCondicionPago.SelectedIndex = -1;
                return;
            }

            cboCondicionPago.SelectedItem =
                cliente.TieneCuentaCorriente
                    ? "Cuenta corriente"
                    : "Contado";
        }
        private void FormRemitos_Load(object? sender, EventArgs e)
        {
        }

        private void btnGuardarRemito_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboCliente.SelectedItem is not Cliente cliente)
                {
                    MessageBox.Show(
                        "Debe seleccionar un cliente.",
                        "Dato requerido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cboCliente.Focus();
                    return;
                }

                Remito remito = new()
                {
                    NumeroRemito = txtNumeroRemito.Text,
                    Fecha = dtpFecha.Value.Date,
                    IdCliente = cliente.IdCliente,
                    CondicionPago = cboCondicionPago.Text,
                    Estado = "Pendiente"
                };

                DetalleRemito detalle = new()
                {
                    CantidadBultos = (int)nudCantidadBultos.Value,
                    Descripcion = txtDescripcion.Text,
                    ProveedorOrigen = txtProveedorOrigen.Text,
                    NumeroRemitoOrigen = txtRemitoOrigen.Text,
                    ValorDeclarado = nudValorDeclarado.Value,
                    ImporteFlete = nudImporteFlete.Value
                };

                int idRemito =
                    _remitoController.RegistrarRemito(remito, detalle);
                txtNumeroRemito.Text = _remitoController.ObtenerProximoNumero();

                MessageBox.Show($"Remito {remito.NumeroRemito} guardado correctamente.","Registro exitoso",MessageBoxButtons.OK,MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message,"Datos incorrectos",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo guardar el remito.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void LimpiarFormulario()
        {
            txtNumeroRemito.Clear();
            dtpFecha.Value = DateTime.Today;

            nudCantidadBultos.Value = 1;
            txtDescripcion.Clear();
            txtProveedorOrigen.Clear();
            txtRemitoOrigen.Clear();
            nudValorDeclarado.Value = 0;
            nudImporteFlete.Value = 0;

            ActualizarCondicionPago();
            txtNumeroRemito.Text =
        _remitoController.ObtenerProximoNumero();
            txtNumeroRemito.Focus();
        }

        private void BtnAbrirLiquidaciones_Click(
       object? sender,
       EventArgs e)
        {
            using FormSeleccionLiquidacion formulario =
                new FormSeleccionLiquidacion();

            formulario.ShowDialog(this);
        }
    }



}
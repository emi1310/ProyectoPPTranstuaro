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

        private readonly List<DetalleRemito> _detallesRemito = new();

        public FormRemitos()
        {
            InitializeComponent();
            btnAgregarDetalle.Click += BtnAgregarDetalle_Click;

      

            ClienteRepository clienteRepository = new();
            ClienteService clienteService =
                new(clienteRepository);

            _clienteController =
                new ClienteController(clienteService);

            RemitoRepository remitoRepository = new();

            DetalleRemitoRepository detalleRepository =
                new();

            PdfRemitoService pdfRemitoService = new();

            RemitoService remitoService = new(
                remitoRepository,
                detalleRepository,
                pdfRemitoService);

            _remitoController = new RemitoController(remitoService);
            txtNumeroRemito.Text = _remitoController.ObtenerProximoNumero();
            txtNumeroRemito.ReadOnly = true;

            ConfigurarCombos();
            CargarClientes();
        }

        private void ConfigurarCombos()
        {
            cboCliente.DropDownStyle = ComboBoxStyle.DropDown;

            cboCondicionPago.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboCondicionPago.Enabled = true;

            cboCondicionPago.Items.Clear();

            cboCondicionPago.Items.AddRange(
            [
                "Cuenta corriente",
                "Contado"
            ]);

            cboCliente.SelectedIndexChanged +=  CboCliente_SelectedIndexChanged;
        }

        private void CargarClientes()
        {
            List<Cliente> clientes =
                _clienteController
                    .ListarClientesActivos();

            cboCliente.DataSource = clientes;
           

            // Primero neutralizamos el autocompletado
            cboCliente.AutoCompleteMode =
                AutoCompleteMode.None;

            // Permitimos escribir
            cboCliente.DropDownStyle =
                ComboBoxStyle.DropDown;

            // Creamos las sugerencias
            AutoCompleteStringCollection sugerencias =
                new AutoCompleteStringCollection();

            sugerencias.AddRange(
                clientes
                    .Select(c => c.ToString())
                    .ToArray());

            // Asignamos la fuente personalizada
            cboCliente.AutoCompleteCustomSource =
                sugerencias;

            cboCliente.AutoCompleteSource =
                AutoCompleteSource.CustomSource;

            // Finalmente activamos el autocompletado
            cboCliente.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;


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
            _detallesRemito.Clear();
            dgvDetallesRemito.DataSource = null;
            lblTotalRemito.Text = "TOTAL REMITO: $ 0,00";
        }

        private void ActualizarCondicionPago()
        {
            if (cboCondicionPago.SelectedIndex == -1)
            {
                cboCondicionPago.SelectedItem = "Contado";
            }
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
                // versión V2
                //Remito remito = new()
                //{
                //    NumeroRemito = txtNumeroRemito.Text,
                //    Fecha = DateTime.Today,
                //    IdCliente = cliente.IdCliente,
                //    CondicionPago = cboCondicionPago.Text,
                //    Estado = "Pendiente"
                //};
                // versión V3
                Remito remito = new()
                {
                    NumeroRemito = txtNumeroRemito.Text,
                    Fecha = DateTime.Today,
                    IdCliente = cliente.IdCliente,

                    TipoFacturacion = cboCondicionPago.Text == "Cuenta corriente" ? TipoFacturacion.CuentaCorriente : TipoFacturacion.Contado,

                    Estado = EstadoRemito.Pendiente
                };

                // int idRemito = _remitoController.RegistrarRemito(remito, detalle);
                if (_detallesRemito.Count == 0)
                {
                    throw new ArgumentException(
                        "Debe agregar al menos un detalle al remito.");
                }

                ResultadoRegistroRemito resultado =  _remitoController.RegistrarRemito( remito, cliente, _detallesRemito);

                if (resultado.PdfGenerado)
                {
                    MessageBox.Show(
                        $"Remito {remito.NumeroRemito} guardado correctamente.\n\n" +
                        $"PDF generado en:\n{resultado.RutaPdf}",
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        $"Remito {remito.NumeroRemito} guardado correctamente.\n\n" +
                        $"No se pudo generar el PDF:\n{resultado.ErrorPdf}",
                        "Remito guardado - Advertencia PDF",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                
                LimpiarFormulario();

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message,"Datos incorrectos",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo guardar el remito.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                LimpiarFormulario();
            }
        }
        private void LimpiarFormulario()
        {
            _detallesRemito.Clear();

            dgvDetallesRemito.DataSource = null;

            lblTotalRemito.Text = "TOTAL REMITO: $ 0,00";

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

        private void BtnAgregarDetalle_Click(
    object? sender,
    EventArgs e)
        {
            try
            {
                DetalleRemito detalle = new()
                {
                    CantidadBultos = (int)nudCantidadBultos.Value,
                    Descripcion = txtDescripcion.Text,
                    ProveedorOrigen = txtProveedorOrigen.Text,
                    NumeroRemitoOrigen = txtRemitoOrigen.Text,
                    ValorDeclarado = nudValorDeclarado.Value,
                    ImporteFlete = nudImporteFlete.Value
                };

                _detallesRemito.Add(detalle);

                decimal totalRemito = _detallesRemito.Sum( d => d.ImporteFlete);

                lblTotalRemito.Text = $"TOTAL REMITO: {totalRemito:C2}";

                dgvDetallesRemito.DataSource = null;
                dgvDetallesRemito.DataSource = _detallesRemito;
                dgvDetallesRemito.Columns["IdDetalleRemito"].Visible = false;
                dgvDetallesRemito.Columns["IdRemito"].Visible = false;
                dgvDetallesRemito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                nudCantidadBultos.Value = 1;
                txtDescripcion.Clear();
                txtProveedorOrigen.Clear();
                txtRemitoOrigen.Clear();
                nudValorDeclarado.Value = 0;
                nudImporteFlete.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al agregar detalle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }

}
using Trastuaro_V2.Controllers;
using Trastuaro_V2.Modelos;
using Trastuaro_V2.Repositories;
using Trastuaro_V2.Services;

namespace Trastuaro_V2
{
    public partial class Form1 : Form
    {
        private readonly ClienteController _clienteController;

        private readonly TextBox txtNombre = new();
        private readonly TextBox txtDomicilio = new();
        private readonly TextBox txtCuitDni = new();
        private readonly ComboBox cboCondicionIva = new();
        private readonly CheckBox chkCuentaCorriente = new();
        private readonly Button btnGuardar = new();
        private readonly Button btnAbrirRemitos = new();
        private readonly DataGridView dgvClientes = new();

        public Form1()
        {
            InitializeComponent();

            ClienteRepository repository = new();
            ClienteService service = new(repository);
            _clienteController = new ClienteController(service);

            ConfigurarFormulario();
            CargarClientes();
        }

        private void ConfigurarFormulario()
        {
            Text = "Trastuaro V2 - Gestión de Clientes";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1000, 650);
            MinimumSize = new Size(900, 550);

            Label titulo = new()
            {
                Text = "REGISTRO DE CLIENTES",
                Font = new Font(
                    "Segoe UI",
                    16,
                    FontStyle.Bold),
                AutoSize = true,
                Location = new Point(25, 20)
            };

            Label lblNombre = CrearEtiqueta(
                "Nombre / Razón social:",
                30,
                75);

            txtNombre.Location = new Point(250, 72);
            txtNombre.Size = new Size(400, 27);

            Label lblDomicilio = CrearEtiqueta(
                "Domicilio:",
                30,
                115);

            txtDomicilio.Location = new Point(250, 112);
            txtDomicilio.Size = new Size(400, 27);

            Label lblCuitDni = CrearEtiqueta(
                "CUIT / DNI:",
                30,
                155);

            txtCuitDni.Location = new Point(250, 152);
            txtCuitDni.Size = new Size(250, 27);

            Label lblCondicionIva = CrearEtiqueta(
                "Condición frente al IVA:",
                30,
                195);

            cboCondicionIva.Location = new Point(250, 192);
            cboCondicionIva.Size = new Size(250, 28);
            cboCondicionIva.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboCondicionIva.Items.AddRange(
            [
                "Consumidor Final",
                "Responsable Inscripto",
                "Monotributista",
                "Exento"
            ]);

            cboCondicionIva.SelectedIndex = 0;

            chkCuentaCorriente.Text =
                "Tiene cuenta corriente";

            chkCuentaCorriente.AutoSize = true;
            chkCuentaCorriente.Location =
                new Point(530, 195);

            btnGuardar.Text = "GUARDAR CLIENTE";
            btnGuardar.Size = new Size(200, 42);
            btnGuardar.Location = new Point(720, 175);
            btnGuardar.BackColor = Color.SteelBlue;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Click += BtnGuardar_Click;

            btnAbrirRemitos.Text = "GESTIONAR REMITOS";
            btnAbrirRemitos.Size = new Size(200, 42);
            btnAbrirRemitos.Location = new Point(720, 70);
            btnAbrirRemitos.BackColor = Color.SeaGreen;
            btnAbrirRemitos.ForeColor = Color.White;
            btnAbrirRemitos.FlatStyle = FlatStyle.Flat;
            btnAbrirRemitos.Click += BtnAbrirRemitos_Click;

            dgvClientes.Location = new Point(25, 255);
            dgvClientes.Size = new Size(930, 330);

            dgvClientes.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;

            dgvClientes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            Controls.AddRange(
            [
                titulo,
                lblNombre,
                txtNombre,
                lblDomicilio,
                txtDomicilio,
                lblCuitDni,
                txtCuitDni,
                lblCondicionIva,
                cboCondicionIva,
                chkCuentaCorriente,
                btnGuardar,
                btnAbrirRemitos,
                dgvClientes
            ]);
        }

        private static Label CrearEtiqueta(
            string texto,
            int posicionX,
            int posicionY)
        {
            return new Label
            {
                Text = texto,
                AutoSize = true,
                Location = new Point(
                    posicionX,
                    posicionY + 4)
            };
        }

        private void BtnGuardar_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                Cliente cliente = new()
                {
                    NombreRazonSocial = txtNombre.Text,
                    Domicilio = txtDomicilio.Text,
                    CuitDni = txtCuitDni.Text,

                    CondicionIva =
                        cboCondicionIva.SelectedItem
                            ?.ToString()
                        ?? string.Empty,

                    TieneCuentaCorriente =
                        chkCuentaCorriente.Checked,

                    Activo = true
                };

                int idCliente =
                    _clienteController
                        .RegistrarCliente(cliente);

                MessageBox.Show(
                    $"Cliente registrado correctamente.\n" +
                    $"Identificador: {idCliente}",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo guardar el cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = null;

            dgvClientes.DataSource =
                _clienteController
                    .ListarClientesActivos();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDomicilio.Clear();
            txtCuitDni.Clear();
            cboCondicionIva.SelectedIndex = 0;
            chkCuentaCorriente.Checked = false;
            txtNombre.Focus();
        }

        private void BtnAbrirRemitos_Click(
            object? sender,
            EventArgs e)
        {
            using FormRemitos formularioRemitos = new();
            formularioRemitos.ShowDialog();
        }
    }
}
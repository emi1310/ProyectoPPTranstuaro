using Trastuaro_V2.Controllers;
using Trastuaro_V2.Modelos;
using Trastuaro_V2.Repositories;
using Trastuaro_V2.Services;

namespace Trastuaro_V2
{
    public partial class FormLiquidaciones : Form
    {
        private readonly Cliente _cliente;
        private readonly ClienteController _clienteController;
        private readonly RemitoController _remitoController;

        private readonly LiquidacionMensualController _liquidacionController;

        private List<Remito> _remitosPendientes = new();

        public FormLiquidaciones(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;

            ClienteRepository clienteRepository = new();
            ClienteService clienteService =
                new(clienteRepository);

            _clienteController =
                new ClienteController(clienteService);

            RemitoRepository remitoRepository = new();

            DetalleRemitoRepository detalleRemitoRepository =
                new();

            RemitoService remitoService = new(
                remitoRepository,
                detalleRemitoRepository);
            _remitoController = new RemitoController(remitoService);

            

            LiquidacionMensualRepository liquidacionRepository = new();

            DetalleLiquidacionRepository detalleLiquidacionRepository = new();

           // RemitoRepository remitoRepository = new();

            LiquidacionMensualService liquidacionService =
                new(
                    liquidacionRepository,
                    detalleLiquidacionRepository,
                    remitoRepository,
                    clienteRepository
                );

            _liquidacionController =
                new LiquidacionMensualController(liquidacionService);

            ConfigurarPeriodo();
            ConfigurarEstados();
            CargarClientes();



            btnBuscarRemitos.Click += BtnBuscarRemitos_Click;

            btnGenerarLiquidacion.Click += BtnGenerarLiquidacion_Click;
            btnCerrarLiquidacion.Click += BtnCerrarLiquidacion_Click;
        }
                    private void BtnBuscarRemitos_Click(
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

                int mes = cboMes.SelectedIndex + 1;
                int anio = Convert.ToInt32(nudAnio.Value);
                LiquidacionMensual? liquidacionExistente = _liquidacionController.ObtenerPorClienteYPeriodo(cliente.IdCliente, mes, anio);

                if (liquidacionExistente == null)
                {
                    lblEstadoLiquidacion.Text =
                        "Estado liquidación: SIN GENERAR";

                    lblTotalLiquidacion.Text =
                        "Total liquidación: $ 0,00";
                }
                else
                {
                    lblEstadoLiquidacion.Text =
                        $"Estado liquidación: {liquidacionExistente.Estado.ToUpper()}";

                    lblTotalLiquidacion.Text =
                        $"Total liquidación: {liquidacionExistente.Total:C2}";
                }

                string estado = cboEstado.SelectedItem?.ToString() ?? "Pendiente";
                // Acá introduje el reemplazo
                if (cliente.TieneCuentaCorriente)
                {
                    if (estado == "Pendiente")
                    {
                        _remitosPendientes =
                            _remitoController.ObtenerPendientesParaLiquidacion(
                                cliente,
                                mes,
                                anio);
                    }
                    else
                    {
                        _remitosPendientes =
                            _remitoController.ObtenerPorClientePeriodoYEstado(
                                cliente.IdCliente,
                                mes,
                                anio,
                                estado);
                    }
                }
                else
                {
                    _remitosPendientes =
                        _remitoController.ObtenerPorClienteYEstado(
                            cliente.IdCliente,
                            estado);
                }

                dgvRemitos.DataSource = null;
                dgvRemitos.DataSource = _remitosPendientes;
                ConfigurarGrillaRemitos();

                decimal total =
                    _remitosPendientes.Sum(
                        remito => remito.TotalFlete);

                lblTotal.Text = total.ToString("C2");
                List<Remito> pendientesDelPeriodo =
    _remitoController.ObtenerPorClientePeriodoYEstado(
        cliente.IdCliente,
        mes,
        anio,
        "Pendiente");

                // btnCerrarLiquidacion.Enabled = liquidacionExistente != null && liquidacionExistente.Estado == "Abierta" && pendientesDelPeriodo.Count == 0;
                bool puedeCerrar =
     liquidacionExistente != null &&
     liquidacionExistente.Estado == "Abierta" &&
     pendientesDelPeriodo.Count == 0;

                btnCerrarLiquidacion.Enabled = puedeCerrar;

                btnCerrarLiquidacion.Text =
                    puedeCerrar
                        ? "CERRAR LIQUIDACIÓN"
                        : "CIERRE BLOQUEADO";
                btnGenerarLiquidacion.Enabled =  estado == "Pendiente" && _remitosPendientes.Count > 0;

                if (_remitosPendientes.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron remitos pendientes para el período seleccionado.",
                        "Sin remitos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al buscar remitos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ConfigurarEstados()
        {
            cboEstado.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboEstado.Items.Clear();

            cboEstado.Items.AddRange(["Pendiente", "En proceso", "Facturado", "Todos"]);

            cboEstado.SelectedIndex = 0;
        }

        private void BtnCerrarLiquidacion_Click( object? sender, EventArgs e)
        {
            try
            {
                if (cboCliente.SelectedItem is not Cliente cliente)
                {
                    throw new ArgumentException(
                        "Debe seleccionar un cliente.");
                }

                int mes = cboMes.SelectedIndex + 1;
                int anio = Convert.ToInt32(nudAnio.Value);

                LiquidacionMensual? liquidacion =
                    _liquidacionController.ObtenerPorClienteYPeriodo(
                        cliente.IdCliente,
                        mes,
                        anio);

                if (liquidacion == null)
                {
                    throw new InvalidOperationException(
                        "No existe una liquidación para el período seleccionado.");
                }

                DialogResult respuesta =
                    MessageBox.Show(
                        "¿Confirma el cierre de la liquidación?\n\n" +
                        "Una vez cerrada no podrá incorporar nuevos remitos.",
                        "Cerrar liquidación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                _liquidacionController.CerrarLiquidacion(
                    liquidacion.IdLiquidacion);

                btnCerrarLiquidacion.Enabled = false;

                MessageBox.Show(
                    "La liquidación fue cerrada correctamente.",
                    "Liquidación cerrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cerrar la liquidación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnGenerarLiquidacion_Click(
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

                if (_remitosPendientes.Count == 0)
                {
                    throw new ArgumentException(
                        "No existen remitos para liquidar.");
                }

                string mensajeConfirmacion;

                if (cliente.TieneCuentaCorriente)
                {
                    mensajeConfirmacion =
                        "¿Confirma la generación de la liquidación mensual?";
                }
                else
                {
                    mensajeConfirmacion =
                        "¿Confirma la generación de la liquidación directa?";
                }

                DialogResult respuesta = MessageBox.Show(
                    mensajeConfirmacion,
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
                        IdCliente = cliente.IdCliente,
                        Mes = cboMes.SelectedIndex + 1,
                        Anio = Convert.ToInt32(nudAnio.Value),
                        FechaEmision = DateTime.Today,
                        Estado = "Abierta"
                    };

                List<DetalleLiquidacion> detalles =
                    _remitosPendientes
                        .Select(remito =>
                            new DetalleLiquidacion
                            {
                                IdRemito = remito.IdRemito,
                                Importe = remito.TotalFlete
                            })
                        .ToList();

                int idLiquidacion =
                    _liquidacionController
                        .RegistrarLiquidacion(
                            liquidacion,
                            detalles);

                LiquidacionMensual? liquidacionActualizada =
    _liquidacionController.ObtenerPorClienteYPeriodo(
        cliente.IdCliente,
        liquidacion.Mes,
        liquidacion.Anio);

                if (liquidacionActualizada != null)
                {
                    lblTotalLiquidacion.Text =
                        $"Total liquidación: {liquidacionActualizada.Total:C2}";
                }

                if (cliente.TieneCuentaCorriente)
                {
                    lblEstadoLiquidacion.Text =
                        "Estado liquidación: ABIERTA";

                    btnCerrarLiquidacion.Enabled = true;
                }
                else
                {
                    lblEstadoLiquidacion.Text =
                        "Estado liquidación: CERRADA";

                    btnCerrarLiquidacion.Enabled = false;
                }

                MessageBox.Show(
                    $"Liquidación registrada correctamente.\n\n" +
                    $"Cliente: {cliente.NombreRazonSocial}\n" +
                    $"Período: {liquidacion.Mes:D2}/{liquidacion.Anio}\n" +
                    $"Remitos incluidos: {detalles.Count}\n" +
                    $"Total: {detalles.Sum(d => d.Importe):C2}",
                    "Liquidación generada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _remitosPendientes.Clear();
                dgvRemitos.DataSource = null;
                lblTotal.Text = "$ 0,00";
                btnGenerarLiquidacion.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al generar la liquidación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void ConfigurarPeriodo()
        {
            cboMes.Items.Clear();

            cboMes.Items.AddRange(
            [
                "Enero",
                "Febrero",
                "Marzo",
                "Abril",
                "Mayo",
                "Junio",
                "Julio",
                "Agosto",
                "Septiembre",
                "Octubre",
                "Noviembre",
                "Diciembre"
            ]);

            cboMes.SelectedIndex =
                DateTime.Today.Month - 1;

            nudAnio.Value =
                DateTime.Today.Year;
        }

        private void CargarClientes()
        {
            cboCliente.DataSource = null;

            cboCliente.Items.Clear();
            cboCliente.Items.Add(_cliente);

            cboCliente.SelectedIndex = 0;
            cboCliente.Enabled = false;
        }
        private void ConfigurarGrillaRemitos()
        {
            if (dgvRemitos.Columns.Count == 0)
            {
                return;
            }

            dgvRemitos.Columns["IdRemito"].Visible = false;
            dgvRemitos.Columns["IdCliente"].Visible = false;

            dgvRemitos.Columns["NumeroRemito"].HeaderText =
                "N° Remito";

            dgvRemitos.Columns["Fecha"].HeaderText =
                "Fecha";

            dgvRemitos.Columns["CondicionPago"].HeaderText =
                "Condición de pago";

            dgvRemitos.Columns["Estado"].HeaderText =
                "Estado";

            dgvRemitos.Columns["TotalFlete"].HeaderText =
                "Importe";

            dgvRemitos.Columns["NumeroRemito"].Width = 120;
            dgvRemitos.Columns["Fecha"].Width = 130;
            dgvRemitos.Columns["CondicionPago"].Width = 180;
            dgvRemitos.Columns["Estado"].Width = 130;
            dgvRemitos.Columns["TotalFlete"].Width = 150;

            dgvRemitos.Columns["NumeroRemito"].FillWeight = 15;
            dgvRemitos.Columns["Fecha"].FillWeight = 20;
            dgvRemitos.Columns["CondicionPago"].FillWeight = 30;
            dgvRemitos.Columns["Estado"].FillWeight = 20;
            dgvRemitos.Columns["TotalFlete"].FillWeight = 25;

            dgvRemitos.Columns["TotalFlete"]
    .DefaultCellStyle.Alignment =
    DataGridViewContentAlignment.MiddleRight;

            dgvRemitos.Columns["TotalFlete"]
                .DefaultCellStyle.Format = "C2";

            dgvRemitos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
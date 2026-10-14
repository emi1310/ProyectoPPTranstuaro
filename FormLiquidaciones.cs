using Trastuaro_V2.Controllers;
using Trastuaro_V2.Modelos;
using Trastuaro_V2.Repositories;
using Trastuaro_V2.Services;

namespace Trastuaro_V2
{
    public partial class FormLiquidaciones : Form
    {
        private readonly ClienteController _clienteController;
        private readonly RemitoController _remitoController;

        private readonly LiquidacionMensualController _liquidacionController;

        private List<Remito> _remitosPendientes = new();

        public FormLiquidaciones()
        {
            InitializeComponent();

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

            LiquidacionMensualService liquidacionService = new(liquidacionRepository,detalleLiquidacionRepository);

            _liquidacionController = new LiquidacionMensualController(liquidacionService);

            ConfigurarPeriodo();
            CargarClientes();



            btnBuscarRemitos.Click += BtnBuscarRemitos_Click;

            btnGenerarLiquidacion.Click += BtnGenerarLiquidacion_Click;
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

                _remitosPendientes =
                    _remitoController
                        .ObtenerPendientesPorClienteYPeriodo(
                            cliente.IdCliente,
                            mes,
                            anio);

                dgvRemitos.DataSource = null;
                dgvRemitos.DataSource = _remitosPendientes;

                decimal total =
                    _remitosPendientes.Sum(
                        remito => remito.TotalFlete);

                lblTotal.Text = total.ToString("C2");

                btnGenerarLiquidacion.Enabled =
                    _remitosPendientes.Count > 0;

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

                DialogResult respuesta = MessageBox.Show(
                    "¿Confirma la generación de la liquidación mensual?",
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
                        Estado = "Pendiente"
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
                foreach (Remito remito in _remitosPendientes)
                {
                    _remitoController.FinalizarRemito(
                        remito.IdRemito);
                }
                MessageBox.Show(
                    $"Liquidación registrada correctamente.\nNúmero interno: {idLiquidacion}",
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
            List<Cliente> clientes =
                _clienteController
                    .ListarClientesActivos();

            cboCliente.DataSource = clientes;

            if (clientes.Count > 0)
            {
                cboCliente.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(
                    "No existen clientes activos.",
                    "Sin clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
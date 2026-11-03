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

namespace Trastuaro_V2.View
{
    public partial class FormLiquidacionesV3 : Form
    {
        private ClienteController _clienteController;

        private LiquidacionController _liquidacionController;

        private RemitoController _remitoController;
        public FormLiquidacionesV3()
        {
            InitializeComponent();
   
            InicializarControladores();

            ConfigurarCombos();

            CargarClientes();

            ConfigurarEventos();
            ConfigurarGrillaRemitos();

            ActualizarEstadoBotonLiquidacion();
            ActualizarEstadoBotonAnular();
        }


        private void InicializarControladores()
        {
            ClienteRepository clienteRepository =
                new ClienteRepository();

            ClienteService clienteService =
                new ClienteService(
                    clienteRepository);

            _clienteController =
                new ClienteController(
                    clienteService);

            RemitoRepository remitoRepository =
                new RemitoRepository();

            DetalleRemitoRepository detalleRepository =
                new DetalleRemitoRepository();

            PdfRemitoService pdfRemitoService =
                new PdfRemitoService();

            RemitoService remitoService =
                new RemitoService(
                    remitoRepository,
                    detalleRepository,
                    pdfRemitoService);

            _remitoController =
                new RemitoController(
                    remitoService);

            PdfLiquidacionService pdfLiquidacionService =
                new PdfLiquidacionService();

            LiquidacionService liquidacionService =
                new LiquidacionService(
                    pdfLiquidacionService);

            _liquidacionController =
                new LiquidacionController(
                    liquidacionService);
        }

        private void ConfigurarCombos()
        {
            cboModalidad.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboEstado.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboMes.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboEstado.Items.Add(EstadoRemito.Pendiente);
            cboEstado.Items.Add(EstadoRemito.EnProceso);
            cboEstado.Items.Add(EstadoRemito.Facturado);
            cboEstado.Items.Add(EstadoRemito.Anulado);
            cboEstado.Items.Add("Todos");

            cboModalidad.Items.Add("Todos");
            cboModalidad.Items.Add(TipoFacturacion.Contado);
            cboModalidad.Items.Add(TipoFacturacion.CuentaCorriente);
            cboMes.Items.AddRange(
            [
                "Todos",
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

            cboModalidad.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            cboMes.SelectedIndex = DateTime.Today.Month;
        }



        private void ConfigurarGrillaRemitos()
        {
            dgvRemitos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvRemitos.MultiSelect = false;
        }

        private void ConfigurarColumnasGrillaRemitos()
        {
            dgvRemitos.Columns["IdRemito"].Visible = false;
            dgvRemitos.Columns["IdCliente"].Visible = false;

            dgvRemitos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvRemitos.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvRemitos.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvRemitos.Columns["TotalFlete"].HeaderText =
                "Importe";

            dgvRemitos.Columns["TotalFlete"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvRemitos.Columns["TotalFlete"]
                .DefaultCellStyle.Format =
                "$ #,##0.00";

            dgvRemitos.Columns["NumeroRemito"].HeaderText =
                "N° Remito";

            dgvRemitos.Columns["TipoFacturacion"].HeaderText =
                "Modalidad";
        }

        private void ConfigurarEventos()
        {
            dgvRemitos.SelectionChanged += (_, _) =>
            {
                ActualizarEstadoBotonAnular();
                ActualizarDetalleAnulacion();
            };

            btnAnularRemito.Click +=
                BtnAnularRemito_Click;

            btnGenerarLiquidacion.Click +=
                BtnGenerarLiquidacion_Click;

            btnBuscarRemitos.Click +=
                BtnBuscarRemitos_Click;

            cboCliente.SelectedIndexChanged +=
                (_, _) => LimpiarGrillaRemitos();

            cboModalidad.SelectedIndexChanged +=
                (_, _) => LimpiarGrillaRemitos();

            cboEstado.SelectedIndexChanged +=
                (_, _) => LimpiarGrillaRemitos();

            cboMes.SelectedIndexChanged +=
                (_, _) => LimpiarGrillaRemitos();

            nudAnio.ValueChanged +=
                (_, _) => LimpiarGrillaRemitos();
        }
        private void BtnGenerarLiquidacion_Click(
    object? sender,
    EventArgs e)
        {
            try
            {
                if (cboCliente.SelectedItem is not Cliente cliente)
                {
                    throw new InvalidOperationException(
                        "Debe seleccionar un cliente.");
                }

               
                if (dgvRemitos.DataSource
                    is not List<Remito> remitos ||
                    remitos.Count == 0)
                {
                    throw new InvalidOperationException(
                        "No existen remitos para liquidar.");
                }

                DialogResult respuesta =
                    MessageBox.Show(
                        $"Se generará una liquidación con {remitos.Count} remito(s).\n\n" +
                        $"Total: {remitos.Sum(r => r.TotalFlete):C2}\n\n" +
                        "¿Desea continuar?",
                        "Confirmar liquidación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }


                int idLiquidacion;
                ResultadoLiquidacion resultado;

                string modalidad =
                    cboModalidad.SelectedItem?.ToString()
                    ?? "";

                if (modalidad == "Contado")
                {
                    resultado = _liquidacionController.GenerarLiquidacionContado( cliente.IdCliente, cliente, remitos);
                    idLiquidacion = resultado.IdLiquidacion;
                }
                else if (modalidad == "Cuenta corriente")
                {
                    int mes =
                        cboMes.SelectedIndex;

                    int anio =
                        Convert.ToInt32(
                            nudAnio.Value);

                    resultado =  _liquidacionController.GenerarLiquidacionCuentaCorriente( cliente.IdCliente, cliente, mes, anio, remitos);

                    idLiquidacion = resultado.IdLiquidacion;
                }
                else
                {
                    throw new InvalidOperationException(
                        "Debe seleccionar una modalidad válida.");
                }


                if (resultado.PdfGenerado)
                {
                    MessageBox.Show(
                        $"Liquidación N° {idLiquidacion} generada correctamente.\n\n" +
                        $"PDF generado en:\n{resultado.RutaPdf}",
                        "Liquidación generada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        $"Liquidación N° {idLiquidacion} generada correctamente.\n\n" +
                        $"No se pudo generar el PDF:\n{resultado.ErrorPdf}",
                        "Liquidación generada - Advertencia PDF",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

                LimpiarGrillaRemitos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al generar liquidación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void BtnAnularRemito_Click(
     object? sender,
     EventArgs e)
        {
            if (dgvRemitos.CurrentRow?.DataBoundItem
                is not Remito remito)
            {
                return;
            }

            DialogResult respuesta =
                MessageBox.Show(
                    $"¿Desea anular el Remito {remito.NumeroRemito}?",
                    "Confirmar anulación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            using FormMotivoAnulacion formulario =
                new FormMotivoAnulacion();

            DialogResult resultado =
                formulario.ShowDialog();

            if (resultado != DialogResult.OK)
            {
                return;
            }

            string motivo = formulario.Motivo;

            _remitoController.AnularRemito( remito, motivo);

            MessageBox.Show( $"El Remito {remito.NumeroRemito} fue anulado correctamente.", "Remito anulado", MessageBoxButtons.OK,
    MessageBoxIcon.Information);

            LimpiarGrillaRemitos();

           
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

                TipoFacturacion? tipoFacturacion =  ObtenerTipoFacturacionSeleccionado();
                string estado = cboEstado.SelectedItem?.ToString()  ?? "Todos";

                int? mes = cboMes.SelectedIndex == 0 ? null : cboMes.SelectedIndex;

                int? anio =  Convert.ToInt32( nudAnio.Value);

                List<Remito> remitos =
                    _remitoController
                        .ObtenerPorFiltros(
                            cliente.IdCliente,
                            tipoFacturacion,
                            estado,
                            mes,
                            anio);

                dgvRemitos.DataSource = null;
                dgvRemitos.DataSource = remitos;

                ConfigurarColumnasGrillaRemitos();

                ActualizarEstadoBotonLiquidacion();
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

        private TipoFacturacion? ObtenerTipoFacturacionSeleccionado()
        {
            if (cboModalidad.SelectedItem is TipoFacturacion tipoFacturacion)
            {
                return tipoFacturacion;
            }

            return null;
        }
        private void CargarClientes()
        {
            List<Cliente> clientes =
                _clienteController.ListarClientesActivos();

            cboCliente.DataSource = clientes;

            cboCliente.AutoCompleteMode =
                AutoCompleteMode.None;

            cboCliente.DropDownStyle =
                ComboBoxStyle.DropDown;

            AutoCompleteStringCollection sugerencias =
                new AutoCompleteStringCollection();

            sugerencias.AddRange(
                clientes
                    .Select(c => c.ToString())
                    .ToArray());

            cboCliente.AutoCompleteCustomSource =
                sugerencias;

            cboCliente.AutoCompleteSource =
                AutoCompleteSource.CustomSource;

            cboCliente.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;
        }
    

    

        private void LimpiarGrillaRemitos()
        {
            dgvRemitos.DataSource = null;
            ActualizarEstadoBotonLiquidacion();
            ActualizarEstadoBotonAnular();
            txtDetalleAnulacion.Clear();
            txtDetalleAnulacion.Visible = false;
        }

        private bool PuedeGenerarLiquidacion()
        {
            if (cboCliente.SelectedItem is not Cliente)
                return false;

            string modalidad =
                cboModalidad.SelectedItem?.ToString()
                ?? "Todos";

            string estado =
                cboEstado.SelectedItem?.ToString()
                ?? "Todos";

            if (modalidad == "Todos")
                return false;

            if (modalidad == "Cuenta corriente" &&  cboMes.SelectedIndex == 0)
            {
                return false;
            }

            if (estado != "Pendiente")
                return false;

            if (dgvRemitos.Rows.Count == 0)
                return false;

            return true;
        }

        private void ActualizarEstadoBotonLiquidacion()
        {
            bool habilitado =
                PuedeGenerarLiquidacion();

            btnGenerarLiquidacion.Enabled =
                habilitado;

            if (habilitado)
            {
                btnGenerarLiquidacion.Text =
                    "GENERAR LIQUIDACIÓN";

                btnGenerarLiquidacion.BackColor =
                    Color.Blue;

                btnGenerarLiquidacion.ForeColor =
                    Color.White;

                btnGenerarLiquidacion.FlatStyle =
                    FlatStyle.Standard;
            }
            else
            {
                btnGenerarLiquidacion.Text =
                    "LIQUIDACIÓN NO HABILITADA";

                btnGenerarLiquidacion.BackColor =
                    Color.LightGray;

                btnGenerarLiquidacion.ForeColor =
                    Color.DimGray;

                btnGenerarLiquidacion.FlatStyle =
                    FlatStyle.Flat;
            }
        }
        private bool PuedeAnularRemito()
        {
            if (dgvRemitos.CurrentRow?.DataBoundItem
                is not Remito remito)
            {
                return false;
            }

            return remito.Estado ==
                EstadoRemito.Pendiente;
        }
        private void ActualizarEstadoBotonAnular()
        {
            btnAnularRemito.Enabled =
                PuedeAnularRemito();
        }

        private void ActualizarDetalleAnulacion()
        {
            if (dgvRemitos.CurrentRow?.DataBoundItem
                is not Remito remito)
            {
                txtDetalleAnulacion.Clear();
                txtDetalleAnulacion.Visible = false;
                return;
            }

            if (remito.Estado != EstadoRemito.Anulado)
            {
                txtDetalleAnulacion.Clear();
                txtDetalleAnulacion.Visible = false;
                return;
            }

            string fecha =
                remito.FechaAnulacion?.ToString("dd/MM/yyyy")
                ?? "Sin fecha";

            string motivo =
                string.IsNullOrWhiteSpace(remito.MotivoAnulacion)
                    ? "Sin motivo informado"
                    : remito.MotivoAnulacion;

            txtDetalleAnulacion.Text =
                $"Anulado el {fecha} - Motivo: {motivo}";

            txtDetalleAnulacion.Visible = true;
        }
    }
}

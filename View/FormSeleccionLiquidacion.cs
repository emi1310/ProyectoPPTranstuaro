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
    public partial class FormSeleccionLiquidacion : Form

    {
        private readonly ClienteController _clienteController;

        public FormSeleccionLiquidacion()
        {
            InitializeComponent();
            ClienteRepository clienteRepository = new();

            ClienteService clienteService =
                new(clienteRepository);

            _clienteController =
                new ClienteController(clienteService);

            CargarClientes();
            cboCliente.SelectedIndexChanged += CboCliente_SelectedIndexChanged;
            btnContinuar.Click += BtnContinuar_Click;
        }
        private void BtnContinuar_Click(
     object? sender,
     EventArgs e)
        {
            if (cboCliente.SelectedItem is not Cliente cliente)
            {
                MessageBox.Show(
                    "Debe seleccionar un cliente.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cliente.TieneCuentaCorriente)
            {
                using FormLiquidaciones formulario =
                    new FormLiquidaciones(cliente);

                formulario.ShowDialog(this);
            }
            else
            {
                using FormLiquidacionDirecta formulario =
                    new FormLiquidacionDirecta(cliente);

                formulario.ShowDialog(this);
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
                ActualizarModalidad();
            }
        }
        private void CboCliente_SelectedIndexChanged(
    object? sender,
    EventArgs e)
        {
            ActualizarModalidad();
        }

        private void ActualizarModalidad()
        {
            if (cboCliente.SelectedItem is not Cliente cliente)
            {
                lblModalidad.Text = "Modalidad: -";
                return;
            }

            lblModalidad.Text =
                cliente.TieneCuentaCorriente
                    ? "Modalidad: Liquidación mensual"
                    : "Modalidad: Liquidación directa";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trastuaro_V2
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
            btnImprimir.Enabled = false;
            btnClientes.Click += BtnClientes_Click;
            btnRemitos.Click += BtnRemitos_Click;
            btnLiquidaciones.Click += BtnLiquidaciones_Click;
            btnImprimir.Click += BtnImprimir_Click;
            btnSalir.Click += BtnSalir_Click;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnClientes_Click(object? sender, EventArgs e)
        {
            using Form1 formulario =
                new Form1();

            formulario.ShowDialog(this);
        }
        private void BtnRemitos_Click(object? sender, EventArgs e)
        {
            using FormRemitos formulario = new FormRemitos();

            formulario.ShowDialog(this);
        }
        private void BtnLiquidaciones_Click(object? sender, EventArgs e)
        {
            using FormSeleccionLiquidacion formulario =
                new FormSeleccionLiquidacion();

            formulario.ShowDialog(this);
        }

        private void BtnImprimir_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "La opción de impresión será incorporada próximamente.",
                "Imprimir",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir de Trastuaro?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnConsultarLiquidaciones_Click(object sender, EventArgs e)
        {
            using FormHistorialLiquidaciones formulario =
                new FormHistorialLiquidaciones();

            formulario.ShowDialog(this);
        }
    }
}

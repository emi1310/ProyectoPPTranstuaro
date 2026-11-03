using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trastuaro_V2.View;

namespace Trastuaro_V2
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            btnClientes.Click += BtnClientes_Click;
            btnRemitos.Click += BtnRemitos_Click;
            btnLiquidaciones.Click += BtnLiquidaciones_Click;
            btnHistorial.Click += BtnHistorial_Click;
            btnReportes.Click += BtnReportes_Click;
            btnSalir.Click += BtnSalir_Click;
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            panelContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);

            formulario.Show();
        }
        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BtnClientes_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Form1());
        }

        private void BtnRemitos_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormRemitos());
        }

        private void BtnLiquidaciones_Click(object? sender, EventArgs e)
        {
            //AbrirFormularioEnPanel(new FormLiquidacionesPrincipal());
            AbrirFormularioEnPanel(new FormLiquidacionesV3());
        }

        private void BtnHistorial_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormHistorialLiquidaciones());
        }

        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir de Transtuaro?", "Confirmar salida", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void BtnReportes_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormReportes());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

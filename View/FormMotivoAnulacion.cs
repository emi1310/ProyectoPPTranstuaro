using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trastuaro_V2.View
{
    public partial class FormMotivoAnulacion : Form
    {
        public string Motivo { get; private set; } = string.Empty;
        public FormMotivoAnulacion()
        {
            InitializeComponent();
            btnConfirmar.Click += BtnConfirmar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private void BtnConfirmar_Click(
    object? sender,
    EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el motivo de la anulación.",
                    "Motivo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMotivo.Focus();
                return;
            }
            // Acá?
            Motivo = txtMotivo.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click( object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

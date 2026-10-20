namespace Trastuaro_V2
{
    partial class FormSeleccionLiquidacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cboCliente = new ComboBox();
            lblModalidad = new Label();
            btnContinuar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 147);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 32);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(261, 150);
            cboCliente.Margin = new Padding(4);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(385, 40);
            cboCliente.TabIndex = 1;
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Location = new Point(261, 259);
            lblModalidad.Margin = new Padding(4, 0, 4, 0);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(133, 32);
            lblModalidad.TabIndex = 3;
            lblModalidad.Text = "Modalidad:";
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = Color.LemonChiffon;
            btnContinuar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContinuar.ForeColor = SystemColors.ActiveCaptionText;
            btnContinuar.Location = new Point(261, 388);
            btnContinuar.Margin = new Padding(4);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(237, 67);
            btnContinuar.TabIndex = 4;
            btnContinuar.Text = "CONTINUAR";
            btnContinuar.UseVisualStyleBackColor = false;
            // 
            // FormSeleccionLiquidacion
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 576);
            Controls.Add(btnContinuar);
            Controls.Add(lblModalidad);
            Controls.Add(cboCliente);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormSeleccionLiquidacion";
            Text = "FormSeleccionLiquidacion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboCliente;
        private Label lblModalidad;
        private Button btnContinuar;
        private Label lblTituloModalidad;
    }
}
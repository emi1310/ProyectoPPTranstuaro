namespace Trastuaro_V2.View
{
    partial class FormReportes
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
            nudAnio = new NumericUpDown();
            cboMes = new ComboBox();
            btnConsultar = new Button();
            dgvRanking = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            grpResumen = new GroupBox();
            lblValorCantidadLiquidaciones = new Label();
            lblValorCantidadRemitos = new Label();
            lblValorClientesActividad = new Label();
            lblValorContado = new Label();
            lblValorCuentaCorriente = new Label();
            lblValorTotalFacturado = new Label();
            lblValorPeriodo = new Label();
            lblCantidadLiquidaciones = new Label();
            lblCantidadRemitos = new Label();
            lblClientesActividad = new Label();
            lblTotalContado = new Label();
            lblTotalCuentaCorriente = new Label();
            lblTotalFacturado = new Label();
            lblPeriodoResumen = new Label();
            label4 = new Label();
            btnGenerarPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRanking).BeginInit();
            grpResumen.SuspendLayout();
            SuspendLayout();
            // 
            // nudAnio
            // 
            nudAnio.Location = new Point(870, 73);
            nudAnio.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            nudAnio.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(90, 31);
            nudAnio.TabIndex = 0;
            nudAnio.TextAlign = HorizontalAlignment.Right;
            nudAnio.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // cboMes
            // 
            cboMes.FormattingEnabled = true;
            cboMes.Location = new Point(870, 163);
            cboMes.Name = "cboMes";
            cboMes.Size = new Size(165, 33);
            cboMes.TabIndex = 1;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.FromArgb(192, 64, 0);
            btnConsultar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConsultar.ForeColor = Color.White;
            btnConsultar.Location = new Point(870, 237);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(165, 51);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "CONSULTAR";
            btnConsultar.UseVisualStyleBackColor = false;
            // 
            // dgvRanking
            // 
            dgvRanking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRanking.Location = new Point(77, 478);
            dgvRanking.Name = "dgvRanking";
            dgvRanking.RowHeadersWidth = 62;
            dgvRanking.Size = new Size(1020, 402);
            dgvRanking.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(813, 166);
            label1.Name = "label1";
            label1.Size = new Size(51, 25);
            label1.TabIndex = 4;
            label1.Text = "MES:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(809, 75);
            label2.Name = "label2";
            label2.Size = new Size(55, 25);
            label2.TabIndex = 5;
            label2.Text = "AÑO:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(112, 426);
            label3.Name = "label3";
            label3.Size = new Size(403, 28);
            label3.TabIndex = 6;
            label3.Text = "RANKING DE CLIENTES POR FACTURACIÓN";
            // 
            // grpResumen
            // 
            grpResumen.Controls.Add(lblValorCantidadLiquidaciones);
            grpResumen.Controls.Add(lblValorCantidadRemitos);
            grpResumen.Controls.Add(lblValorClientesActividad);
            grpResumen.Controls.Add(lblValorContado);
            grpResumen.Controls.Add(lblValorCuentaCorriente);
            grpResumen.Controls.Add(lblValorTotalFacturado);
            grpResumen.Controls.Add(lblValorPeriodo);
            grpResumen.Controls.Add(lblCantidadLiquidaciones);
            grpResumen.Controls.Add(lblCantidadRemitos);
            grpResumen.Controls.Add(lblClientesActividad);
            grpResumen.Controls.Add(lblTotalContado);
            grpResumen.Controls.Add(lblTotalCuentaCorriente);
            grpResumen.Controls.Add(lblTotalFacturado);
            grpResumen.Controls.Add(lblPeriodoResumen);
            grpResumen.Controls.Add(label4);
            grpResumen.Location = new Point(77, 12);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new Size(629, 397);
            grpResumen.TabIndex = 7;
            grpResumen.TabStop = false;
            // 
            // lblValorCantidadLiquidaciones
            // 
            lblValorCantidadLiquidaciones.Location = new Point(345, 296);
            lblValorCantidadLiquidaciones.Name = "lblValorCantidadLiquidaciones";
            lblValorCantidadLiquidaciones.Size = new Size(125, 25);
            lblValorCantidadLiquidaciones.TabIndex = 14;
            lblValorCantidadLiquidaciones.Text = "\"-\"";
            lblValorCantidadLiquidaciones.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorCantidadRemitos
            // 
            lblValorCantidadRemitos.Location = new Point(345, 251);
            lblValorCantidadRemitos.Name = "lblValorCantidadRemitos";
            lblValorCantidadRemitos.Size = new Size(125, 25);
            lblValorCantidadRemitos.TabIndex = 13;
            lblValorCantidadRemitos.Text = "\"-\"";
            lblValorCantidadRemitos.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorClientesActividad
            // 
            lblValorClientesActividad.Location = new Point(339, 212);
            lblValorClientesActividad.Name = "lblValorClientesActividad";
            lblValorClientesActividad.Size = new Size(131, 25);
            lblValorClientesActividad.TabIndex = 12;
            lblValorClientesActividad.Text = "\"-\"";
            lblValorClientesActividad.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorContado
            // 
            lblValorContado.Location = new Point(339, 172);
            lblValorContado.Name = "lblValorContado";
            lblValorContado.Size = new Size(131, 25);
            lblValorContado.TabIndex = 11;
            lblValorContado.Text = "\"-\"";
            lblValorContado.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorCuentaCorriente
            // 
            lblValorCuentaCorriente.Location = new Point(339, 136);
            lblValorCuentaCorriente.Name = "lblValorCuentaCorriente";
            lblValorCuentaCorriente.Size = new Size(131, 25);
            lblValorCuentaCorriente.TabIndex = 10;
            lblValorCuentaCorriente.Text = "\"-\"";
            lblValorCuentaCorriente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorTotalFacturado
            // 
            lblValorTotalFacturado.Location = new Point(325, 99);
            lblValorTotalFacturado.Name = "lblValorTotalFacturado";
            lblValorTotalFacturado.Size = new Size(145, 25);
            lblValorTotalFacturado.TabIndex = 9;
            lblValorTotalFacturado.Text = "\"-\"";
            lblValorTotalFacturado.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorPeriodo
            // 
            lblValorPeriodo.AutoSize = true;
            lblValorPeriodo.ImageAlign = ContentAlignment.MiddleLeft;
            lblValorPeriodo.Location = new Point(437, 63);
            lblValorPeriodo.Name = "lblValorPeriodo";
            lblValorPeriodo.Size = new Size(33, 25);
            lblValorPeriodo.TabIndex = 8;
            lblValorPeriodo.Text = "\"-\"";
            lblValorPeriodo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCantidadLiquidaciones
            // 
            lblCantidadLiquidaciones.AutoSize = true;
            lblCantidadLiquidaciones.Location = new Point(35, 296);
            lblCantidadLiquidaciones.Name = "lblCantidadLiquidaciones";
            lblCantidadLiquidaciones.Size = new Size(224, 25);
            lblCantidadLiquidaciones.TabIndex = 7;
            lblCantidadLiquidaciones.Text = "Cantidad de Liquidaciones:";
            // 
            // lblCantidadRemitos
            // 
            lblCantidadRemitos.AutoSize = true;
            lblCantidadRemitos.Location = new Point(35, 251);
            lblCantidadRemitos.Name = "lblCantidadRemitos";
            lblCantidadRemitos.Size = new Size(181, 25);
            lblCantidadRemitos.TabIndex = 6;
            lblCantidadRemitos.Text = "Cantidad de Remitos:";
            // 
            // lblClientesActividad
            // 
            lblClientesActividad.AutoSize = true;
            lblClientesActividad.Location = new Point(35, 212);
            lblClientesActividad.Name = "lblClientesActividad";
            lblClientesActividad.Size = new Size(190, 25);
            lblClientesActividad.TabIndex = 5;
            lblClientesActividad.Text = "Clientes con Actividad:";
            // 
            // lblTotalContado
            // 
            lblTotalContado.AutoSize = true;
            lblTotalContado.Location = new Point(35, 172);
            lblTotalContado.Name = "lblTotalContado";
            lblTotalContado.Size = new Size(85, 25);
            lblTotalContado.TabIndex = 4;
            lblTotalContado.Text = "Contado:";
            // 
            // lblTotalCuentaCorriente
            // 
            lblTotalCuentaCorriente.AutoSize = true;
            lblTotalCuentaCorriente.Location = new Point(35, 136);
            lblTotalCuentaCorriente.Name = "lblTotalCuentaCorriente";
            lblTotalCuentaCorriente.Size = new Size(148, 25);
            lblTotalCuentaCorriente.TabIndex = 3;
            lblTotalCuentaCorriente.Text = "Cuenta Corriente:";
            // 
            // lblTotalFacturado
            // 
            lblTotalFacturado.AutoSize = true;
            lblTotalFacturado.Location = new Point(35, 99);
            lblTotalFacturado.Name = "lblTotalFacturado";
            lblTotalFacturado.Size = new Size(136, 25);
            lblTotalFacturado.TabIndex = 2;
            lblTotalFacturado.Text = "Total Facturado:";
            // 
            // lblPeriodoResumen
            // 
            lblPeriodoResumen.AutoSize = true;
            lblPeriodoResumen.Location = new Point(35, 63);
            lblPeriodoResumen.Name = "lblPeriodoResumen";
            lblPeriodoResumen.Size = new Size(77, 25);
            lblPeriodoResumen.TabIndex = 1;
            lblPeriodoResumen.Text = "Período:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(35, 14);
            label4.Name = "label4";
            label4.Size = new Size(340, 28);
            label4.TabIndex = 0;
            label4.Text = "RESULTADO GENERAL DEL PERÍODO";
            // 
            // btnGenerarPdf
            // 
            btnGenerarPdf.BackColor = Color.Blue;
            btnGenerarPdf.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerarPdf.ForeColor = Color.White;
            btnGenerarPdf.Location = new Point(870, 354);
            btnGenerarPdf.Name = "btnGenerarPdf";
            btnGenerarPdf.Size = new Size(165, 55);
            btnGenerarPdf.TabIndex = 8;
            btnGenerarPdf.Text = "GENERAR pdf";
            btnGenerarPdf.UseVisualStyleBackColor = false;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1292, 892);
            Controls.Add(btnGenerarPdf);
            Controls.Add(grpResumen);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvRanking);
            Controls.Add(btnConsultar);
            Controls.Add(cboMes);
            Controls.Add(nudAnio);
            Name = "FormReportes";
            Text = "FormReportes";
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRanking).EndInit();
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudAnio;
        private ComboBox cboMes;
        private Button btnConsultar;
        private DataGridView dgvRanking;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox grpResumen;
        private Label label4;
        private Label lblCantidadRemitos;
        private Label lblClientesActividad;
        private Label lblTotalContado;
        private Label lblTotalCuentaCorriente;
        private Label lblTotalFacturado;
        private Label lblPeriodoResumen;
        private Label lblCantidadLiquidaciones;
        private Label lblValorCantidadLiquidaciones;
        private Label lblValorCantidadRemitos;
        private Label lblValorClientesActividad;
        private Label lblValorContado;
        private Label lblValorCuentaCorriente;
        private Label lblValorTotalFacturado;
        private Label lblValorPeriodo;
        private Button btnGenerarPdf;
    }
}
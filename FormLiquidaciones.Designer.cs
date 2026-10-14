namespace Trastuaro_V2
{
    partial class FormLiquidaciones
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
            lblCliente = new Label();
            cboCliente = new ComboBox();
            lblMes = new Label();
            cboMes = new ComboBox();
            lblAnio = new Label();
            nudAnio = new NumericUpDown();
            btnBuscarRemitos = new Button();
            dgvRemitos = new DataGridView();
            lblTotalTexto = new Label();
            lblTotal = new Label();
            btnGenerarLiquidacion = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRemitos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(646, 66);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(514, 38);
            label1.TabIndex = 0;
            label1.Text = "LIQUIDACIÓN MENSUAL DE REMITOS";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(139, 165);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(100, 32);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(245, 151);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(350, 46);
            cboCliente.TabIndex = 2;
            // 
            // lblMes
            // 
            lblMes.AutoSize = true;
            lblMes.Location = new Point(491, 268);
            lblMes.Name = "lblMes";
            lblMes.Size = new Size(79, 38);
            lblMes.TabIndex = 3;
            lblMes.Text = "Mes:";
            // 
            // cboMes
            // 
            cboMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMes.FormattingEnabled = true;
            cboMes.Location = new Point(627, 260);
            cboMes.Name = "cboMes";
            cboMes.Size = new Size(180, 46);
            cboMes.TabIndex = 4;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(160, 268);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(79, 38);
            lblAnio.TabIndex = 5;
            lblAnio.Text = "Año:";
            // 
            // nudAnio
            // 
            nudAnio.Location = new Point(291, 266);
            nudAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudAnio.Minimum = new decimal(new int[] { 2025, 0, 0, 0 });
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(120, 45);
            nudAnio.TabIndex = 6;
            nudAnio.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // btnBuscarRemitos
            // 
            btnBuscarRemitos.BackColor = Color.FromArgb(255, 255, 192);
            btnBuscarRemitos.Location = new Point(1026, 294);
            btnBuscarRemitos.Name = "btnBuscarRemitos";
            btnBuscarRemitos.Size = new Size(266, 49);
            btnBuscarRemitos.TabIndex = 7;
            btnBuscarRemitos.Text = "BUSCAR REMITOS";
            btnBuscarRemitos.UseVisualStyleBackColor = false;
            // 
            // dgvRemitos
            // 
            dgvRemitos.AllowUserToAddRows = false;
            dgvRemitos.AllowUserToDeleteRows = false;
            dgvRemitos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRemitos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRemitos.Location = new Point(139, 382);
            dgvRemitos.MultiSelect = false;
            dgvRemitos.Name = "dgvRemitos";
            dgvRemitos.ReadOnly = true;
            dgvRemitos.RowHeadersWidth = 62;
            dgvRemitos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRemitos.Size = new Size(1378, 404);
            dgvRemitos.TabIndex = 8;
            // 
            // lblTotalTexto
            // 
            lblTotalTexto.AutoSize = true;
            lblTotalTexto.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalTexto.Location = new Point(491, 836);
            lblTotalTexto.Name = "lblTotalTexto";
            lblTotalTexto.Size = new Size(84, 30);
            lblTotalTexto.TabIndex = 9;
            lblTotalTexto.Text = "TOTAL:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(613, 836);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 30);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "$ 0,00";
            // 
            // btnGenerarLiquidacion
            // 
            btnGenerarLiquidacion.BackColor = Color.SkyBlue;
            btnGenerarLiquidacion.Enabled = false;
            btnGenerarLiquidacion.Location = new Point(1026, 828);
            btnGenerarLiquidacion.Name = "btnGenerarLiquidacion";
            btnGenerarLiquidacion.Size = new Size(351, 63);
            btnGenerarLiquidacion.TabIndex = 11;
            btnGenerarLiquidacion.Text = "GENERAR LIQUIDACION";
            btnGenerarLiquidacion.UseVisualStyleBackColor = false;
            // 
            // FormLiquidaciones
            // 
            AutoScaleDimensions = new SizeF(17F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1663, 903);
            Controls.Add(btnGenerarLiquidacion);
            Controls.Add(lblTotal);
            Controls.Add(lblTotalTexto);
            Controls.Add(dgvRemitos);
            Controls.Add(btnBuscarRemitos);
            Controls.Add(nudAnio);
            Controls.Add(lblAnio);
            Controls.Add(cboMes);
            Controls.Add(lblMes);
            Controls.Add(cboCliente);
            Controls.Add(lblCliente);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Location = new Point(30, 85);
            Margin = new Padding(5);
            Name = "FormLiquidaciones";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Trastuaro Formulario Liquidaciones";
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRemitos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCliente;
        private ComboBox cboCliente;
        private Label lblMes;
        private ComboBox cboMes;
        private Label lblAnio;
        private NumericUpDown nudAnio;
        private Button btnBuscarRemitos;
        private DataGridView dgvRemitos;
        private Label lblTotalTexto;
        private Label lblTotal;
        private Button btnGenerarLiquidacion;
    }
}
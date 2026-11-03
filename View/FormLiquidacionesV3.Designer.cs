namespace Trastuaro_V2.View
{
    partial class FormLiquidacionesV3
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
            cboCliente = new ComboBox();
            cboEstado = new ComboBox();
            cboMes = new ComboBox();
            cboModalidad = new ComboBox();
            nudAnio = new NumericUpDown();
            btnBuscarRemitos = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dgvRemitos = new DataGridView();
            btnGenerarLiquidacion = new Button();
            label5 = new Label();
            btnAnularRemito = new Button();
            txtDetalleAnulacion = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRemitos).BeginInit();
            SuspendLayout();
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(208, 104);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(329, 33);
            cboCliente.TabIndex = 0;
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(636, 158);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(158, 33);
            cboEstado.TabIndex = 1;
 
            // 
            // cboMes
            // 
            cboMes.FormattingEnabled = true;
            cboMes.Location = new Point(636, 104);
            cboMes.Name = "cboMes";
            cboMes.Size = new Size(158, 33);
            cboMes.TabIndex = 2;
            // 
            // cboModalidad
            // 
            cboModalidad.FormattingEnabled = true;
            cboModalidad.Location = new Point(208, 158);
            cboModalidad.Name = "cboModalidad";
            cboModalidad.Size = new Size(213, 33);
            cboModalidad.TabIndex = 3;
            // 
            // nudAnio
            // 
            nudAnio.Location = new Point(872, 104);
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(107, 31);
            nudAnio.TabIndex = 4;
            // 
            // btnBuscarRemitos
            // 
            btnBuscarRemitos.BackColor = SystemColors.Info;
            btnBuscarRemitos.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscarRemitos.Location = new Point(872, 153);
            btnBuscarRemitos.Name = "btnBuscarRemitos";
            btnBuscarRemitos.Size = new Size(240, 38);
            btnBuscarRemitos.TabIndex = 5;
            btnBuscarRemitos.Text = "BUSCAR REMITOS";
            btnBuscarRemitos.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 107);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 6;
            label1.Text = "Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 161);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 7;
            label2.Text = "Modalidad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(560, 161);
            label3.Name = "label3";
            label3.Size = new Size(70, 25);
            label3.TabIndex = 8;
            label3.Text = "Estado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(553, 106);
            label4.Name = "label4";
            label4.Size = new Size(77, 25);
            label4.TabIndex = 9;
            label4.Text = "Período:";
            // 
            // dgvRemitos
            // 
            dgvRemitos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRemitos.Location = new Point(85, 197);
            dgvRemitos.MultiSelect = false;
            dgvRemitos.Name = "dgvRemitos";
            dgvRemitos.RowHeadersWidth = 62;
            dgvRemitos.Size = new Size(1041, 538);
            dgvRemitos.TabIndex = 10;
            // 
            // btnGenerarLiquidacion
            // 
            btnGenerarLiquidacion.BackColor = Color.Blue;
            btnGenerarLiquidacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerarLiquidacion.ForeColor = Color.White;
            btnGenerarLiquidacion.Location = new Point(796, 760);
            btnGenerarLiquidacion.Name = "btnGenerarLiquidacion";
            btnGenerarLiquidacion.Size = new Size(330, 57);
            btnGenerarLiquidacion.TabIndex = 11;
            btnGenerarLiquidacion.Text = "GENERAR LIQUIDACION";
            btnGenerarLiquidacion.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(421, 25);
            label5.Name = "label5";
            label5.Size = new Size(456, 32);
            label5.TabIndex = 12;
            label5.Text = "TABLERO DE OPERACIONES DE REMITOS";
            // 
            // btnAnularRemito
            // 
            btnAnularRemito.BackColor = Color.FromArgb(255, 192, 192);
            btnAnularRemito.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnularRemito.Location = new Point(85, 764);
            btnAnularRemito.Name = "btnAnularRemito";
            btnAnularRemito.Size = new Size(258, 53);
            btnAnularRemito.TabIndex = 13;
            btnAnularRemito.Text = "ANULAR REMITO";
            btnAnularRemito.UseVisualStyleBackColor = false;
            // 
            // txtDetalleAnulacion
            // 
            txtDetalleAnulacion.Location = new Point(391, 764);
            txtDetalleAnulacion.Multiline = true;
            txtDetalleAnulacion.Name = "txtDetalleAnulacion";
            txtDetalleAnulacion.ReadOnly = true;
            txtDetalleAnulacion.Size = new Size(365, 60);
            txtDetalleAnulacion.TabIndex = 14;
            txtDetalleAnulacion.Visible = false;
            // 
            // FormLiquidacionesV3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 822);
            Controls.Add(txtDetalleAnulacion);
            Controls.Add(btnAnularRemito);
            Controls.Add(label5);
            Controls.Add(btnGenerarLiquidacion);
            Controls.Add(dgvRemitos);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBuscarRemitos);
            Controls.Add(nudAnio);
            Controls.Add(cboModalidad);
            Controls.Add(cboMes);
            Controls.Add(cboEstado);
            Controls.Add(cboCliente);
            Name = "FormLiquidacionesV3";
            Text = "FormLiquidacionesV3";
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRemitos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCliente;
        private ComboBox cboEstado;
        private ComboBox cboMes;
        private ComboBox cboModalidad;
        private NumericUpDown nudAnio;
        private Button btnBuscarRemitos;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dgvRemitos;
        private Button btnGenerarLiquidacion;
        private Label label5;
       
        private Button btnAnularRemito;
        public TextBox txtDetalleAnulacion;
    }
}
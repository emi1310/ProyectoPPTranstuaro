namespace Trastuaro_V2
{
    partial class FormHistorialLiquidaciones
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
            btnBuscarLiquidaciones = new Button();
            dgvLiquidaciones = new DataGridView();
            label2 = new Label();
            dgvDetalleLiquidacion = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLiquidaciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleLiquidacion).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 136);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(196, 133);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(182, 33);
            cboCliente.TabIndex = 1;
            // 
            // btnBuscarLiquidaciones
            // 
            btnBuscarLiquidaciones.AutoSize = true;
            btnBuscarLiquidaciones.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscarLiquidaciones.Location = new Point(677, 125);
            btnBuscarLiquidaciones.Name = "btnBuscarLiquidaciones";
            btnBuscarLiquidaciones.Size = new Size(334, 42);
            btnBuscarLiquidaciones.TabIndex = 2;
            btnBuscarLiquidaciones.Text = "BUSCAR LIQUIDACIONES";
            btnBuscarLiquidaciones.UseVisualStyleBackColor = true;
            // 
            // dgvLiquidaciones
            // 
            dgvLiquidaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLiquidaciones.Location = new Point(86, 231);
            dgvLiquidaciones.Name = "dgvLiquidaciones";
            dgvLiquidaciones.RowHeadersWidth = 62;
            dgvLiquidaciones.Size = new Size(1045, 225);
            dgvLiquidaciones.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(89, 504);
            label2.Name = "label2";
            label2.Size = new Size(463, 32);
            label2.TabIndex = 4;
            label2.Text = "Remitos de la liquidación seleccionada:";
            // 
            // dgvDetalleLiquidacion
            // 
            dgvDetalleLiquidacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleLiquidacion.Location = new Point(89, 558);
            dgvDetalleLiquidacion.Name = "dgvDetalleLiquidacion";
            dgvDetalleLiquidacion.RowHeadersWidth = 62;
            dgvDetalleLiquidacion.Size = new Size(1042, 225);
            dgvDetalleLiquidacion.TabIndex = 5;
            // 
            // FormHistorialLiquidaciones
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 797);
            Controls.Add(dgvDetalleLiquidacion);
            Controls.Add(label2);
            Controls.Add(dgvLiquidaciones);
            Controls.Add(btnBuscarLiquidaciones);
            Controls.Add(cboCliente);
            Controls.Add(label1);
            Name = "FormHistorialLiquidaciones";
            Text = "FormHistorialLiquidaciones";
            ((System.ComponentModel.ISupportInitialize)dgvLiquidaciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleLiquidacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboCliente;
        private Button btnBuscarLiquidaciones;
        private DataGridView dgvLiquidaciones;
        private Label label2;
        private DataGridView dgvDetalleLiquidacion;
    }
}
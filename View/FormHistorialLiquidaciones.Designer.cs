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
            dgvLiquidaciones = new DataGridView();
            label2 = new Label();
            dgvDetalleLiquidacion = new DataGridView();
            label3 = new Label();
            btnGenerarPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLiquidaciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleLiquidacion).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(90, 133);
            label1.Name = "label1";
            label1.Size = new Size(80, 28);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // cboCliente
            // 
            cboCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(196, 132);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(396, 33);
            cboCliente.TabIndex = 1;
            cboCliente.SelectedValueChanged += cboCliente_SelectedValueChanged;
            // 
            // dgvLiquidaciones
            // 
            dgvLiquidaciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvLiquidaciones.BackgroundColor = SystemColors.ControlLight;
            dgvLiquidaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLiquidaciones.Location = new Point(86, 190);
            dgvLiquidaciones.Name = "dgvLiquidaciones";
            dgvLiquidaciones.RowHeadersWidth = 62;
            dgvLiquidaciones.Size = new Size(1349, 229);
            dgvLiquidaciones.TabIndex = 3;
            dgvLiquidaciones.CellContentClick += dgvLiquidaciones_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(89, 454);
            label2.Name = "label2";
            label2.Size = new Size(463, 32);
            label2.TabIndex = 4;
            label2.Text = "Remitos de la liquidación seleccionada:";
            // 
            // dgvDetalleLiquidacion
            // 
            dgvDetalleLiquidacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalleLiquidacion.BackgroundColor = SystemColors.ControlLight;
            dgvDetalleLiquidacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleLiquidacion.Location = new Point(89, 503);
            dgvDetalleLiquidacion.Name = "dgvDetalleLiquidacion";
            dgvDetalleLiquidacion.RowHeadersWidth = 62;
            dgvDetalleLiquidacion.Size = new Size(1346, 367);
            dgvDetalleLiquidacion.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(454, 39);
            label3.Name = "label3";
            label3.Size = new Size(507, 32);
            label3.TabIndex = 6;
            label3.Text = "DETALLE DE LIQUIDACIONES TRANSTUARO";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnGenerarPdf
            // 
            btnGenerarPdf.BackColor = Color.Blue;
            btnGenerarPdf.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerarPdf.ForeColor = Color.White;
            btnGenerarPdf.Location = new Point(1215, 132);
            btnGenerarPdf.Name = "btnGenerarPdf";
            btnGenerarPdf.Size = new Size(173, 47);
            btnGenerarPdf.TabIndex = 7;
            btnGenerarPdf.Text = "GUARDAR pdf";
            btnGenerarPdf.UseVisualStyleBackColor = false;
            // 
            // FormHistorialLiquidaciones
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(1464, 882);
            Controls.Add(btnGenerarPdf);
            Controls.Add(label3);
            Controls.Add(dgvDetalleLiquidacion);
            Controls.Add(label2);
            Controls.Add(dgvLiquidaciones);
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
        private DataGridView dgvLiquidaciones;
        private Label label2;
        private DataGridView dgvDetalleLiquidacion;
        private Label label3;
        private Button btnGenerarPdf;
    }
}
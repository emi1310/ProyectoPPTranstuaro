namespace Trastuaro_V2
{
    partial class FormLiquidacionDirecta
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
            label2 = new Label();
            cboEstado = new ComboBox();
            dgvRemitosNuevo = new DataGridView();
            btnBuscarRemitos = new Button();
            label3 = new Label();
            lblTotal = new Label();
            button1 = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRemitosNuevo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 70);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(217, 71);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(19, 25);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 123);
            label2.Name = "label2";
            label2.Size = new Size(131, 25);
            label2.TabIndex = 2;
            label2.Text = "Estado Remito:";
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(265, 125);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(182, 33);
            cboEstado.TabIndex = 3;
            // 
            // dgvRemitosNuevo
            // 
            dgvRemitosNuevo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRemitosNuevo.Location = new Point(113, 245);
            dgvRemitosNuevo.Name = "dgvRemitosNuevo";
            dgvRemitosNuevo.RowHeadersWidth = 62;
            dgvRemitosNuevo.Size = new Size(1143, 366);
            dgvRemitosNuevo.TabIndex = 4;
            // 
            // btnBuscarRemitos
            // 
            btnBuscarRemitos.Location = new Point(642, 189);
            btnBuscarRemitos.Name = "btnBuscarRemitos";
            btnBuscarRemitos.Size = new Size(214, 34);
            btnBuscarRemitos.TabIndex = 5;
            btnBuscarRemitos.Text = "BUSCAR REMITOS";
            btnBuscarRemitos.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(132, 657);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 6;
            label3.Text = "TOTAL:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Silver;
            lblTotal.Location = new Point(239, 657);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(61, 25);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "$ 0,00";
            // 
            // button1
            // 
            button1.Location = new Point(924, 189);
            button1.Name = "button1";
            button1.Size = new Size(236, 34);
            button1.TabIndex = 8;
            button1.Text = " GENERAR LIQUIDACIÓN";
            button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(456, 9);
            label4.Name = "label4";
            label4.Size = new Size(495, 38);
            label4.TabIndex = 9;
            label4.Text = "LIQUIDACIÓN DIRECTA DE REMITOS";
            // 
            // FormLiquidacionDirecta
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1328, 718);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(lblTotal);
            Controls.Add(label3);
            Controls.Add(btnBuscarRemitos);
            Controls.Add(dgvRemitosNuevo);
            Controls.Add(cboEstado);
            Controls.Add(label2);
            Controls.Add(lblCliente);
            Controls.Add(label1);
            Name = "FormLiquidacionDirecta";
            Text = "FormLiquidacionDirecta";
            ((System.ComponentModel.ISupportInitialize)dgvRemitosNuevo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCliente;
        private Label label2;
        private ComboBox cboEstado;
        private DataGridView dgvRemitosNuevo;
        private Button btnBuscarRemitos;
        private Label label3;
        private Label lblTotal;
        private Button button1;
        private Label label4;
    }
}
namespace Trastuaro_V2
{
    partial class FormRemitos
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
            lblTitulo = new Label();
            lblCliente = new Label();
            cboCliente = new ComboBox();
            lblNumeroRemito = new Label();
            txtNumeroRemito = new TextBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblCondicionPago = new Label();
            cboCondicionPago = new ComboBox();
            nudCantidadBultos = new NumericUpDown();
            lblCantidadBultos = new Label();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblProveedorOrigen = new Label();
            txtProveedorOrigen = new TextBox();
            lblRemitoOrigen = new Label();
            txtRemitoOrigen = new TextBox();
            lblValorDeclarado = new Label();
            nudValorDeclarado = new NumericUpDown();
            lblImporteFlete = new Label();
            nudImporteFlete = new NumericUpDown();
            btnGuardarRemito = new Button();
            btnAbrirLiquidaciones = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidadBultos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudValorDeclarado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudImporteFlete).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(300, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(371, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE REMITOS";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(142, 134);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(69, 25);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(241, 131);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(182, 33);
            cboCliente.TabIndex = 2;
            // 
            // lblNumeroRemito
            // 
            lblNumeroRemito.AutoSize = true;
            lblNumeroRemito.Location = new Point(44, 197);
            lblNumeroRemito.Name = "lblNumeroRemito";
            lblNumeroRemito.Size = new Size(167, 25);
            lblNumeroRemito.TabIndex = 3;
            lblNumeroRemito.Text = "Número de Remito:";
            // 
            // txtNumeroRemito
            // 
            txtNumeroRemito.Location = new Point(241, 199);
            txtNumeroRemito.MaxLength = 300;
            txtNumeroRemito.Name = "txtNumeroRemito";
            txtNumeroRemito.Size = new Size(182, 31);
            txtNumeroRemito.TabIndex = 4;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(610, 202);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(61, 25);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(700, 197);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(160, 31);
            dtpFecha.TabIndex = 6;
            // 
            // lblCondicionPago
            // 
            lblCondicionPago.AutoSize = true;
            lblCondicionPago.Location = new Point(49, 269);
            lblCondicionPago.Name = "lblCondicionPago";
            lblCondicionPago.Size = new Size(162, 25);
            lblCondicionPago.TabIndex = 7;
            lblCondicionPago.Text = "Condición de Pago";
            // 
            // cboCondicionPago
            // 
            cboCondicionPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCondicionPago.FormattingEnabled = true;
            cboCondicionPago.Location = new Point(241, 261);
            cboCondicionPago.Name = "cboCondicionPago";
            cboCondicionPago.Size = new Size(182, 33);
            cboCondicionPago.TabIndex = 8;
            // 
            // nudCantidadBultos
            // 
            nudCantidadBultos.Location = new Point(252, 368);
            nudCantidadBultos.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudCantidadBultos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidadBultos.Name = "nudCantidadBultos";
            nudCantidadBultos.Size = new Size(120, 31);
            nudCantidadBultos.TabIndex = 9;
            nudCantidadBultos.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidadBultos
            // 
            lblCantidadBultos.AutoSize = true;
            lblCantidadBultos.Location = new Point(44, 374);
            lblCantidadBultos.Name = "lblCantidadBultos";
            lblCantidadBultos.Size = new Size(167, 25);
            lblCantidadBultos.TabIndex = 10;
            lblCantidadBultos.Text = "Cantidad de bultos:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(55, 435);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(108, 25);
            lblDescripcion.TabIndex = 11;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(241, 414);
            txtDescripcion.MaxLength = 200;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(639, 46);
            txtDescripcion.TabIndex = 12;
            // 
            // lblProveedorOrigen
            // 
            lblProveedorOrigen.AutoSize = true;
            lblProveedorOrigen.Location = new Point(49, 531);
            lblProveedorOrigen.Name = "lblProveedorOrigen";
            lblProveedorOrigen.Size = new Size(175, 25);
            lblProveedorOrigen.TabIndex = 13;
            lblProveedorOrigen.Text = "Proveedor de origen";
            // 
            // txtProveedorOrigen
            // 
            txtProveedorOrigen.Location = new Point(252, 531);
            txtProveedorOrigen.MaxLength = 150;
            txtProveedorOrigen.Name = "txtProveedorOrigen";
            txtProveedorOrigen.Size = new Size(300, 31);
            txtProveedorOrigen.TabIndex = 14;
            // 
            // lblRemitoOrigen
            // 
            lblRemitoOrigen.AutoSize = true;
            lblRemitoOrigen.Location = new Point(49, 591);
            lblRemitoOrigen.Name = "lblRemitoOrigen";
            lblRemitoOrigen.Size = new Size(153, 25);
            lblRemitoOrigen.TabIndex = 15;
            lblRemitoOrigen.Text = "Remito de origen:";
            // 
            // txtRemitoOrigen
            // 
            txtRemitoOrigen.Location = new Point(252, 585);
            txtRemitoOrigen.MaxLength = 50;
            txtRemitoOrigen.Name = "txtRemitoOrigen";
            txtRemitoOrigen.Size = new Size(180, 31);
            txtRemitoOrigen.TabIndex = 16;
            // 
            // lblValorDeclarado
            // 
            lblValorDeclarado.AutoSize = true;
            lblValorDeclarado.Location = new Point(65, 682);
            lblValorDeclarado.Name = "lblValorDeclarado";
            lblValorDeclarado.Size = new Size(135, 25);
            lblValorDeclarado.TabIndex = 17;
            lblValorDeclarado.Text = "Valor declarado";
            // 
            // nudValorDeclarado
            // 
            nudValorDeclarado.DecimalPlaces = 2;
            nudValorDeclarado.Location = new Point(246, 681);
            nudValorDeclarado.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudValorDeclarado.Name = "nudValorDeclarado";
            nudValorDeclarado.Size = new Size(180, 31);
            nudValorDeclarado.TabIndex = 18;
            nudValorDeclarado.ThousandsSeparator = true;
            // 
            // lblImporteFlete
            // 
            lblImporteFlete.AutoSize = true;
            lblImporteFlete.Location = new Point(488, 686);
            lblImporteFlete.Name = "lblImporteFlete";
            lblImporteFlete.Size = new Size(144, 25);
            lblImporteFlete.TabIndex = 19;
            lblImporteFlete.Text = "Importe del flete";
            // 
            // nudImporteFlete
            // 
            nudImporteFlete.DecimalPlaces = 2;
            nudImporteFlete.Location = new Point(700, 680);
            nudImporteFlete.Maximum = new decimal(new int[] { 99000000, 0, 0, 0 });
            nudImporteFlete.Name = "nudImporteFlete";
            nudImporteFlete.Size = new Size(180, 31);
            nudImporteFlete.TabIndex = 20;
            // 
            // btnGuardarRemito
            // 
            btnGuardarRemito.BackColor = Color.Blue;
            btnGuardarRemito.FlatStyle = FlatStyle.Flat;
            btnGuardarRemito.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarRemito.ForeColor = Color.White;
            btnGuardarRemito.Location = new Point(653, 773);
            btnGuardarRemito.Name = "btnGuardarRemito";
            btnGuardarRemito.Size = new Size(227, 42);
            btnGuardarRemito.TabIndex = 21;
            btnGuardarRemito.Text = "GUARDAR REMITO";
            btnGuardarRemito.UseVisualStyleBackColor = false;
            btnGuardarRemito.Click += btnGuardarRemito_Click;
            // 
            // btnAbrirLiquidaciones
            // 
            btnAbrirLiquidaciones.Location = new Point(99, 770);
            btnAbrirLiquidaciones.Name = "btnAbrirLiquidaciones";
            btnAbrirLiquidaciones.Size = new Size(240, 42);
            btnAbrirLiquidaciones.TabIndex = 22;
            btnAbrirLiquidaciones.Text = "Gestionar Liquidaciones";
            btnAbrirLiquidaciones.UseVisualStyleBackColor = true;
            btnAbrirLiquidaciones.Visible = false;
            // 
            // FormRemitos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 849);
            Controls.Add(btnAbrirLiquidaciones);
            Controls.Add(btnGuardarRemito);
            Controls.Add(nudImporteFlete);
            Controls.Add(lblImporteFlete);
            Controls.Add(nudValorDeclarado);
            Controls.Add(lblValorDeclarado);
            Controls.Add(txtRemitoOrigen);
            Controls.Add(lblRemitoOrigen);
            Controls.Add(txtProveedorOrigen);
            Controls.Add(lblProveedorOrigen);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(lblCantidadBultos);
            Controls.Add(nudCantidadBultos);
            Controls.Add(cboCondicionPago);
            Controls.Add(lblCondicionPago);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(txtNumeroRemito);
            Controls.Add(lblNumeroRemito);
            Controls.Add(cboCliente);
            Controls.Add(lblCliente);
            Controls.Add(lblTitulo);
            Name = "FormRemitos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Trastuaro V2 - Registro de Remitos";
            Load += FormRemitos_Load;
            ((System.ComponentModel.ISupportInitialize)nudCantidadBultos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudValorDeclarado).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudImporteFlete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblCliente;
        private ComboBox cboCliente;
        private Label lblNumeroRemito;
        private TextBox txtNumeroRemito;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblCondicionPago;
        private ComboBox cboCondicionPago;
        private NumericUpDown nudCantidadBultos;
        private Label lblCantidadBultos;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblProveedorOrigen;
        private TextBox txtProveedorOrigen;
        private Label lblRemitoOrigen;
        private TextBox txtRemitoOrigen;
        private Label lblValorDeclarado;
        private NumericUpDown nudValorDeclarado;
        private Label lblImporteFlete;
        private NumericUpDown nudImporteFlete;
        private Button btnGuardarRemito;
        private Button btnAbrirLiquidaciones;
    }
}
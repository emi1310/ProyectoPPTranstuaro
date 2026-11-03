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
            btnAgregarDetalle = new Button();
            dgvDetallesRemito = new DataGridView();
            lblTotalRemito = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCantidadBultos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudValorDeclarado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudImporteFlete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesRemito).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(611, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(371, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE REMITOS";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(158, 131);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(69, 25);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            cboCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(241, 131);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(361, 33);
            cboCliente.TabIndex = 2;
            // 
            // lblNumeroRemito
            // 
            lblNumeroRemito.AutoSize = true;
            lblNumeroRemito.Location = new Point(60, 213);
            lblNumeroRemito.Name = "lblNumeroRemito";
            lblNumeroRemito.Size = new Size(167, 25);
            lblNumeroRemito.TabIndex = 3;
            lblNumeroRemito.Text = "Número de Remito:";
            // 
            // txtNumeroRemito
            // 
            txtNumeroRemito.Location = new Point(233, 210);
            txtNumeroRemito.MaxLength = 300;
            txtNumeroRemito.Name = "txtNumeroRemito";
            txtNumeroRemito.Size = new Size(182, 31);
            txtNumeroRemito.TabIndex = 4;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(1264, 213);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(61, 25);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Enabled = false;
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(1365, 208);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(160, 31);
            dtpFecha.TabIndex = 6;
            // 
            // lblCondicionPago
            // 
            lblCondicionPago.AutoSize = true;
            lblCondicionPago.Location = new Point(502, 213);
            lblCondicionPago.Name = "lblCondicionPago";
            lblCondicionPago.Size = new Size(162, 25);
            lblCondicionPago.TabIndex = 7;
            lblCondicionPago.Text = "Condición de Pago";
            // 
            // cboCondicionPago
            // 
            cboCondicionPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCondicionPago.FormattingEnabled = true;
            cboCondicionPago.Location = new Point(701, 210);
            cboCondicionPago.Name = "cboCondicionPago";
            cboCondicionPago.Size = new Size(182, 33);
            cboCondicionPago.TabIndex = 8;
            // 
            // nudCantidadBultos
            // 
            nudCantidadBultos.Location = new Point(317, 273);
            nudCantidadBultos.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudCantidadBultos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidadBultos.Name = "nudCantidadBultos";
            nudCantidadBultos.Size = new Size(80, 31);
            nudCantidadBultos.TabIndex = 9;
            nudCantidadBultos.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidadBultos
            // 
            lblCantidadBultos.AutoSize = true;
            lblCantidadBultos.Location = new Point(60, 275);
            lblCantidadBultos.Name = "lblCantidadBultos";
            lblCantidadBultos.Size = new Size(236, 25);
            lblCantidadBultos.TabIndex = 10;
            lblCantidadBultos.Text = "Cantidad de bultos del ítem:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(60, 380);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(108, 25);
            lblDescripcion.TabIndex = 11;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(174, 380);
            txtDescripcion.MaxLength = 200;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(641, 37);
            txtDescripcion.TabIndex = 12;
            // 
            // lblProveedorOrigen
            // 
            lblProveedorOrigen.AutoSize = true;
            lblProveedorOrigen.Location = new Point(1023, 275);
            lblProveedorOrigen.Name = "lblProveedorOrigen";
            lblProveedorOrigen.Size = new Size(175, 25);
            lblProveedorOrigen.TabIndex = 13;
            lblProveedorOrigen.Text = "Proveedor de origen";
            // 
            // txtProveedorOrigen
            // 
            txtProveedorOrigen.Location = new Point(1225, 272);
            txtProveedorOrigen.MaxLength = 150;
            txtProveedorOrigen.Name = "txtProveedorOrigen";
            txtProveedorOrigen.Size = new Size(300, 31);
            txtProveedorOrigen.TabIndex = 14;
            // 
            // lblRemitoOrigen
            // 
            lblRemitoOrigen.AutoSize = true;
            lblRemitoOrigen.Location = new Point(74, 327);
            lblRemitoOrigen.Name = "lblRemitoOrigen";
            lblRemitoOrigen.Size = new Size(153, 25);
            lblRemitoOrigen.TabIndex = 15;
            lblRemitoOrigen.Text = "Remito de origen:";
            // 
            // txtRemitoOrigen
            // 
            txtRemitoOrigen.Location = new Point(241, 324);
            txtRemitoOrigen.MaxLength = 50;
            txtRemitoOrigen.Name = "txtRemitoOrigen";
            txtRemitoOrigen.Size = new Size(142, 31);
            txtRemitoOrigen.TabIndex = 16;
            // 
            // lblValorDeclarado
            // 
            lblValorDeclarado.AutoSize = true;
            lblValorDeclarado.Location = new Point(491, 327);
            lblValorDeclarado.Name = "lblValorDeclarado";
            lblValorDeclarado.Size = new Size(135, 25);
            lblValorDeclarado.TabIndex = 17;
            lblValorDeclarado.Text = "Valor declarado";
            // 
            // nudValorDeclarado
            // 
            nudValorDeclarado.DecimalPlaces = 2;
            nudValorDeclarado.Location = new Point(633, 325);
            nudValorDeclarado.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudValorDeclarado.Name = "nudValorDeclarado";
            nudValorDeclarado.Size = new Size(182, 31);
            nudValorDeclarado.TabIndex = 18;
            nudValorDeclarado.TextAlign = HorizontalAlignment.Right;
            nudValorDeclarado.ThousandsSeparator = true;
            // 
            // lblImporteFlete
            // 
            lblImporteFlete.AutoSize = true;
            lblImporteFlete.Location = new Point(1054, 327);
            lblImporteFlete.Name = "lblImporteFlete";
            lblImporteFlete.Size = new Size(221, 25);
            lblImporteFlete.TabIndex = 19;
            lblImporteFlete.Text = "Importe por flete del ítem:";
            // 
            // nudImporteFlete
            // 
            nudImporteFlete.DecimalPlaces = 2;
            nudImporteFlete.Location = new Point(1316, 327);
            nudImporteFlete.Maximum = new decimal(new int[] { 99000000, 0, 0, 0 });
            nudImporteFlete.Name = "nudImporteFlete";
            nudImporteFlete.Size = new Size(209, 31);
            nudImporteFlete.TabIndex = 20;
            nudImporteFlete.TextAlign = HorizontalAlignment.Right;
            // 
            // btnGuardarRemito
            // 
            btnGuardarRemito.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardarRemito.BackColor = Color.Blue;
            btnGuardarRemito.FlatStyle = FlatStyle.Flat;
            btnGuardarRemito.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarRemito.ForeColor = Color.White;
            btnGuardarRemito.Location = new Point(60, 771);
            btnGuardarRemito.Name = "btnGuardarRemito";
            btnGuardarRemito.Size = new Size(227, 42);
            btnGuardarRemito.TabIndex = 21;
            btnGuardarRemito.Text = "GUARDAR REMITO";
            btnGuardarRemito.UseVisualStyleBackColor = false;
            btnGuardarRemito.Click += btnGuardarRemito_Click;
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarDetalle.BackColor = Color.FromArgb(255, 255, 192);
            btnAgregarDetalle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarDetalle.Location = new Point(1280, 380);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(274, 42);
            btnAgregarDetalle.TabIndex = 23;
            btnAgregarDetalle.Text = "AGREGAR ÍTEM";
            btnAgregarDetalle.UseVisualStyleBackColor = false;
            // 
            // dgvDetallesRemito
            // 
            dgvDetallesRemito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetallesRemito.BackgroundColor = SystemColors.ControlLight;
            dgvDetallesRemito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallesRemito.Location = new Point(60, 443);
            dgvDetallesRemito.Name = "dgvDetallesRemito";
            dgvDetallesRemito.RowHeadersWidth = 62;
            dgvDetallesRemito.Size = new Size(1494, 306);
            dgvDetallesRemito.TabIndex = 24;
            // 
            // lblTotalRemito
            // 
            lblTotalRemito.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalRemito.AutoSize = true;
            lblTotalRemito.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRemito.Location = new Point(1219, 775);
            lblTotalRemito.Name = "lblTotalRemito";
            lblTotalRemito.Size = new Size(267, 32);
            lblTotalRemito.TabIndex = 25;
            lblTotalRemito.Text = "TOTAL REMITO: $ 0,00";
            // 
            // FormRemitos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(1643, 849);
            Controls.Add(lblTotalRemito);
            Controls.Add(dgvDetallesRemito);
            Controls.Add(btnAgregarDetalle);
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
            Text = "Transtuaro V2 - Registro de Remitos";
            Load += FormRemitos_Load;
            ((System.ComponentModel.ISupportInitialize)nudCantidadBultos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudValorDeclarado).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudImporteFlete).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesRemito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblCliente;
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
        private Button btnAgregarDetalle;
        private DataGridView dgvDetallesRemito;
        private Label lblTotalRemito;
        protected ComboBox cboCliente;
    }
}
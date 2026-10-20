namespace Trastuaro_V2
{
    partial class FormInicio
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            btnClientes = new Button();
            btnRemitos = new Button();
            btnLiquidaciones = new Button();
            btnImprimir = new Button();
            btnSalir = new Button();
            label1 = new Label();
            btnConsultarLiquidaciones = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnClientes
            // 
            btnClientes.BackColor = SystemColors.ControlLightLight;
            btnClientes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = Color.Blue;
            btnClientes.Location = new Point(156, 196);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(207, 45);
            btnClientes.TabIndex = 1;
            btnClientes.Text = "CLIENTES";
            btnClientes.UseVisualStyleBackColor = true;
            // 
            // btnRemitos
            // 
            btnRemitos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemitos.ForeColor = Color.Blue;
            btnRemitos.Location = new Point(156, 267);
            btnRemitos.Name = "btnRemitos";
            btnRemitos.Size = new Size(207, 45);
            btnRemitos.TabIndex = 2;
            btnRemitos.Text = "REMITOS";
            btnRemitos.UseVisualStyleBackColor = true;
            // 
            // btnLiquidaciones
            // 
            btnLiquidaciones.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLiquidaciones.ForeColor = Color.Blue;
            btnLiquidaciones.Location = new Point(485, 196);
            btnLiquidaciones.Name = "btnLiquidaciones";
            btnLiquidaciones.Size = new Size(210, 45);
            btnLiquidaciones.TabIndex = 3;
            btnLiquidaciones.Text = "LIQUIDACIONES";
            btnLiquidaciones.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            btnImprimir.Enabled = false;
            btnImprimir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = Color.Blue;
            btnImprimir.Location = new Point(156, 339);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(207, 45);
            btnImprimir.TabIndex = 4;
            btnImprimir.Text = "IMPRIMIR";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.Blue;
            btnSalir.Location = new Point(485, 339);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(210, 45);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 128, 0);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(22, 15);
            label1.Name = "label1";
            label1.Size = new Size(854, 50);
            label1.TabIndex = 6;
            label1.Text = "TRASTUARO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // btnConsultarLiquidaciones
            // 
            btnConsultarLiquidaciones.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConsultarLiquidaciones.ForeColor = Color.Blue;
            btnConsultarLiquidaciones.Location = new Point(485, 267);
            btnConsultarLiquidaciones.Name = "btnConsultarLiquidaciones";
            btnConsultarLiquidaciones.Size = new Size(210, 45);
            btnConsultarLiquidaciones.TabIndex = 7;
            btnConsultarLiquidaciones.Text = "HISTORIAL";
            btnConsultarLiquidaciones.UseVisualStyleBackColor = true;
            btnConsultarLiquidaciones.Click += btnConsultarLiquidaciones_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(245, 98);
            label2.Name = "label2";
            label2.Size = new Size(378, 30);
            label2.TabIndex = 8;
            label2.Text = "Gestión de Remitos y Liquidaciones";
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Info;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(878, 544);
            Controls.Add(label2);
            Controls.Add(btnConsultarLiquidaciones);
            Controls.Add(label1);
            Controls.Add(btnSalir);
            Controls.Add(btnImprimir);
            Controls.Add(btnLiquidaciones);
            Controls.Add(btnRemitos);
            Controls.Add(btnClientes);
            ForeColor = Color.CornflowerBlue;
            Name = "FormInicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClientes;
        private Button btnRemitos;
        private Button btnLiquidaciones;
        private Button btnImprimir;
        private Button btnSalir;
        private Label label1;
        private Button btnConsultarLiquidaciones;
        private Label label2;
    }
}

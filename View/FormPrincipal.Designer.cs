namespace Trastuaro_V2
{
    partial class FormPrincipal
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
            panelMenu = new Panel();
            btnReportes = new Button();
            panel1 = new Panel();
            label1 = new Label();
            btnSalir = new Button();
            btnHistorial = new Button();
            btnLiquidaciones = new Button();
            btnRemitos = new Button();
            btnClientes = new Button();
            panelContenido = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.AccessibleName = "";
            panelMenu.BackColor = Color.DeepSkyBlue;
            panelMenu.BorderStyle = BorderStyle.FixedSingle;
            panelMenu.Controls.Add(btnReportes);
            panelMenu.Controls.Add(panel1);
            panelMenu.Controls.Add(label1);
            panelMenu.Controls.Add(btnSalir);
            panelMenu.Controls.Add(btnHistorial);
            panelMenu.Controls.Add(btnLiquidaciones);
            panelMenu.Controls.Add(btnRemitos);
            panelMenu.Controls.Add(btnClientes);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(310, 840);
            panelMenu.TabIndex = 0;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.LemonChiffon;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.Location = new Point(69, 536);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(177, 34);
            btnReportes.TabIndex = 7;
            btnReportes.Text = "REPORTES";
            btnReportes.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(298, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 838);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(60, 106);
            label1.Name = "label1";
            label1.Size = new Size(203, 38);
            label1.TabIndex = 6;
            label1.Text = "TRANSTUARO";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(255, 255, 192);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(69, 699);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(177, 34);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.FromArgb(255, 255, 192);
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHistorial.Location = new Point(69, 472);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(177, 34);
            btnHistorial.TabIndex = 3;
            btnHistorial.Text = "HISTORIAL";
            btnHistorial.UseVisualStyleBackColor = false;
            // 
            // btnLiquidaciones
            // 
            btnLiquidaciones.BackColor = Color.FromArgb(255, 255, 192);
            btnLiquidaciones.FlatStyle = FlatStyle.Flat;
            btnLiquidaciones.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLiquidaciones.Location = new Point(69, 406);
            btnLiquidaciones.Name = "btnLiquidaciones";
            btnLiquidaciones.Size = new Size(177, 34);
            btnLiquidaciones.TabIndex = 2;
            btnLiquidaciones.Text = "OPERACIONES";
            btnLiquidaciones.UseVisualStyleBackColor = false;
            // 
            // btnRemitos
            // 
            btnRemitos.BackColor = Color.FromArgb(255, 255, 192);
            btnRemitos.FlatStyle = FlatStyle.Flat;
            btnRemitos.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemitos.Location = new Point(69, 339);
            btnRemitos.Name = "btnRemitos";
            btnRemitos.Size = new Size(177, 34);
            btnRemitos.TabIndex = 1;
            btnRemitos.Text = "REMITOS";
            btnRemitos.UseVisualStyleBackColor = false;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(255, 255, 192);
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClientes.Location = new Point(69, 270);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(177, 34);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "CLIENTES";
            btnClientes.UseVisualStyleBackColor = false;
            // 
            // panelContenido
            // 
            panelContenido.BackColor = Color.Beige;
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(310, 0);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(1326, 840);
            panelContenido.TabIndex = 1;
            panelContenido.Paint += panelContenido_Paint;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1636, 840);
            Controls.Add(panelContenido);
            Controls.Add(panelMenu);
            Name = "FormPrincipal";
            Text = "TRANSTUARO ";
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelContenido;
        private Button btnHistorial;
        private Button btnRemitos;
        private Button btnClientes;
        private Button btnLiquidaciones;
        private Button btnSalir;
        private Label label1;
        private Panel panel1;
        private Button btnReportes;
    }
}
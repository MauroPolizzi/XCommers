namespace XCommerce.Core
{
    partial class _00015_VentaSalon
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
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pnlBusquedaMesa = new System.Windows.Forms.Panel();
            this.pnlLinea2 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtMesa = new System.Windows.Forms.TextBox();
            this.lblMesa = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.pnlBusquedaMesa.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuarioLogin
            // 
            this.lblUsuarioLogin.Size = new System.Drawing.Size(3068, 18);
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 62);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(784, 4);
            this.pnlBorde.TabIndex = 8;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.SteelBlue;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Margin = new System.Windows.Forms.Padding(5);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 62);
            this.menu.TabIndex = 7;
            this.menu.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = global::XCommerce.Properties.Resources.Salir;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(44, 59);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlBusquedaMesa
            // 
            this.pnlBusquedaMesa.BackColor = System.Drawing.Color.DarkGray;
            this.pnlBusquedaMesa.Controls.Add(this.pnlLinea2);
            this.pnlBusquedaMesa.Controls.Add(this.btnBuscar);
            this.pnlBusquedaMesa.Controls.Add(this.txtMesa);
            this.pnlBusquedaMesa.Controls.Add(this.lblMesa);
            this.pnlBusquedaMesa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusquedaMesa.Location = new System.Drawing.Point(0, 66);
            this.pnlBusquedaMesa.Name = "pnlBusquedaMesa";
            this.pnlBusquedaMesa.Size = new System.Drawing.Size(784, 48);
            this.pnlBusquedaMesa.TabIndex = 9;
            // 
            // pnlLinea2
            // 
            this.pnlLinea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLinea2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLinea2.Location = new System.Drawing.Point(0, 45);
            this.pnlLinea2.Name = "pnlLinea2";
            this.pnlLinea2.Size = new System.Drawing.Size(784, 3);
            this.pnlLinea2.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::XCommerce.Properties.Resources.Buscar;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(270, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(31, 28);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtMesa
            // 
            this.txtMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMesa.Location = new System.Drawing.Point(82, 11);
            this.txtMesa.Name = "txtMesa";
            this.txtMesa.Size = new System.Drawing.Size(182, 26);
            this.txtMesa.TabIndex = 1;
            this.txtMesa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMesa_KeyPress);
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.BackColor = System.Drawing.Color.Transparent;
            this.lblMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesa.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMesa.Location = new System.Drawing.Point(24, 14);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(52, 20);
            this.lblMesa.TabIndex = 0;
            this.lblMesa.Text = "Mesa";
            // 
            // _00015_VentaSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnlBusquedaMesa);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.menu);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "_00015_VentaSalon";
            this.Text = "Venta en Salon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.menu, 0);
            this.Controls.SetChildIndex(this.pnlBorde, 0);
            this.Controls.SetChildIndex(this.pnlBusquedaMesa, 0);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlBusquedaMesa.ResumeLayout(false);
            this.pnlBusquedaMesa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBorde;
        public System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel pnlBusquedaMesa;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtMesa;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Panel pnlLinea2;
    }
}
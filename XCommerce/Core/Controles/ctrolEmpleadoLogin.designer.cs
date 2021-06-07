namespace XCommerce.Core.Controles
{
    partial class ctrolEmpleadoLogin
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
            this.lblEmpleadoLogin = new System.Windows.Forms.Label();
            this.imgFoto = new System.Windows.Forms.PictureBox();
            this.menuEmpleado = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).BeginInit();
            this.menuEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmpleadoLogin
            // 
            this.lblEmpleadoLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmpleadoLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEmpleadoLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleadoLogin.ForeColor = System.Drawing.Color.White;
            this.lblEmpleadoLogin.Location = new System.Drawing.Point(45, 0);
            this.lblEmpleadoLogin.Name = "lblEmpleadoLogin";
            this.lblEmpleadoLogin.Size = new System.Drawing.Size(316, 45);
            this.lblEmpleadoLogin.TabIndex = 1;
            this.lblEmpleadoLogin.Text = "Empleado";
            this.lblEmpleadoLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgFoto
            // 
            this.imgFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.imgFoto.Dock = System.Windows.Forms.DockStyle.Left;
            this.imgFoto.Image = global::XCommerce.Properties.Resources.Usuario;
            this.imgFoto.Location = new System.Drawing.Point(0, 0);
            this.imgFoto.Name = "imgFoto";
            this.imgFoto.Size = new System.Drawing.Size(45, 45);
            this.imgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFoto.TabIndex = 0;
            this.imgFoto.TabStop = false;
            // 
            // menuEmpleado
            // 
            this.menuEmpleado.AutoSize = false;
            this.menuEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.menuEmpleado.Dock = System.Windows.Forms.DockStyle.None;
            this.menuEmpleado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menuEmpleado.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuEmpleado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.menuEmpleado.Location = new System.Drawing.Point(361, 0);
            this.menuEmpleado.Name = "menuEmpleado";
            this.menuEmpleado.Size = new System.Drawing.Size(53, 46);
            this.menuEmpleado.TabIndex = 2;
            this.menuEmpleado.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoSize = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarContraseñaToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.toolStripMenuItem1,
            this.salirDelSistemaToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::XCommerce.Properties.Resources.Configuracion;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(48, 43);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // salirDelSistemaToolStripMenuItem
            // 
            this.salirDelSistemaToolStripMenuItem.Name = "salirDelSistemaToolStripMenuItem";
            this.salirDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.salirDelSistemaToolStripMenuItem.Text = "Salir del Sistema";
            this.salirDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salirDelSistemaToolStripMenuItem_Click);
            // 
            // ctrolEmpleadoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.menuEmpleado);
            this.Controls.Add(this.lblEmpleadoLogin);
            this.Controls.Add(this.imgFoto);
            this.MaximumSize = new System.Drawing.Size(414, 45);
            this.MinimumSize = new System.Drawing.Size(414, 45);
            this.Name = "ctrolEmpleadoLogin";
            this.Size = new System.Drawing.Size(414, 45);
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).EndInit();
            this.menuEmpleado.ResumeLayout(false);
            this.menuEmpleado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox imgFoto;
        public System.Windows.Forms.Label lblEmpleadoLogin;
        private System.Windows.Forms.ToolStrip menuEmpleado;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirDelSistemaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}

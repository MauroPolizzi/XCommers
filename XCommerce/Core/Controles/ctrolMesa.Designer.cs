namespace XCommerce.Core.Controles
{
    partial class ctrolMesa
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
            this.components = new System.ComponentModel.Container();
            this.lblNumero = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarDeMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unirMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMontoConsumido = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumero
            // 
            this.lblNumero.BackColor = System.Drawing.Color.Transparent;
            this.lblNumero.ContextMenuStrip = this.menu;
            this.lblNumero.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNumero.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.White;
            this.lblNumero.Location = new System.Drawing.Point(0, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(140, 94);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "1";
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirMesaToolStripMenuItem,
            this.cerrarMesaToolStripMenuItem,
            this.cambiarDeMesaToolStripMenuItem,
            this.unirMesaToolStripMenuItem,
            this.cancelarMesaToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(167, 114);
            // 
            // abrirMesaToolStripMenuItem
            // 
            this.abrirMesaToolStripMenuItem.Name = "abrirMesaToolStripMenuItem";
            this.abrirMesaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.abrirMesaToolStripMenuItem.Text = "Abrir Mesa";
            // 
            // cerrarMesaToolStripMenuItem
            // 
            this.cerrarMesaToolStripMenuItem.Name = "cerrarMesaToolStripMenuItem";
            this.cerrarMesaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cerrarMesaToolStripMenuItem.Text = "Cerrar Mesa";
            // 
            // cambiarDeMesaToolStripMenuItem
            // 
            this.cambiarDeMesaToolStripMenuItem.Name = "cambiarDeMesaToolStripMenuItem";
            this.cambiarDeMesaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cambiarDeMesaToolStripMenuItem.Text = "Cambiar de Mesa";
            // 
            // unirMesaToolStripMenuItem
            // 
            this.unirMesaToolStripMenuItem.Name = "unirMesaToolStripMenuItem";
            this.unirMesaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.unirMesaToolStripMenuItem.Text = "Unir Mesa";
            // 
            // cancelarMesaToolStripMenuItem
            // 
            this.cancelarMesaToolStripMenuItem.Name = "cancelarMesaToolStripMenuItem";
            this.cancelarMesaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cancelarMesaToolStripMenuItem.Text = "Cancelar Mesa";
            // 
            // lblMontoConsumido
            // 
            this.lblMontoConsumido.BackColor = System.Drawing.Color.Transparent;
            this.lblMontoConsumido.ContextMenuStrip = this.menu;
            this.lblMontoConsumido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMontoConsumido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoConsumido.ForeColor = System.Drawing.Color.White;
            this.lblMontoConsumido.Location = new System.Drawing.Point(0, 94);
            this.lblMontoConsumido.Name = "lblMontoConsumido";
            this.lblMontoConsumido.Size = new System.Drawing.Size(140, 45);
            this.lblMontoConsumido.TabIndex = 1;
            this.lblMontoConsumido.Text = "$ 0,00";
            this.lblMontoConsumido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrolMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.Controls.Add(this.lblMontoConsumido);
            this.Controls.Add(this.lblNumero);
            this.Name = "ctrolMesa";
            this.Size = new System.Drawing.Size(140, 139);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblMontoConsumido;
        private System.Windows.Forms.ContextMenuStrip menu;
        public System.Windows.Forms.ToolStripMenuItem abrirMesaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cerrarMesaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cambiarDeMesaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem unirMesaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cancelarMesaToolStripMenuItem;
    }
}

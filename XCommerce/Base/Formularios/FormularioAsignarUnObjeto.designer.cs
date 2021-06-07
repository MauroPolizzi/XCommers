namespace XCommerce.Base.Formularios
{
    partial class FormularioAsignarUnObjeto
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
            this.ctrolSinAsignar = new XCommerce.Core.Controles.ctrolGrillaAsignarConBusqueda();
            this.ctrolAsignado = new XCommerce.Core.Controles.ctrolGrillaAsignarConBusqueda();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 62);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(784, 4);
            this.pnlBorde.TabIndex = 7;
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
            this.menu.TabIndex = 6;
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
            //this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ctrolSinAsignar
            // 
            this.ctrolSinAsignar.BackColor = System.Drawing.Color.White;
            this.ctrolSinAsignar.Location = new System.Drawing.Point(5, 73);
            this.ctrolSinAsignar.MinimumSize = new System.Drawing.Size(271, 354);
            this.ctrolSinAsignar.Name = "ctrolSinAsignar";
            this.ctrolSinAsignar.Size = new System.Drawing.Size(337, 354);
            this.ctrolSinAsignar.TabIndex = 8;
            // 
            // ctrolAsignado
            // 
            this.ctrolAsignado.BackColor = System.Drawing.Color.White;
            this.ctrolAsignado.Location = new System.Drawing.Point(439, 73);
            this.ctrolAsignado.MinimumSize = new System.Drawing.Size(271, 354);
            this.ctrolAsignado.Name = "ctrolAsignado";
            this.ctrolAsignado.Size = new System.Drawing.Size(337, 354);
            this.ctrolAsignado.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::XCommerce.Properties.Resources.Agregar2;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregar.Location = new System.Drawing.Point(353, 165);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 79);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Image = global::XCommerce.Properties.Resources.Quitar2;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitar.Location = new System.Drawing.Point(353, 250);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 79);
            this.btnQuitar.TabIndex = 11;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            // 
            // FormularioAsignarUnObjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.ctrolAsignado);
            this.Controls.Add(this.ctrolSinAsignar);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.menu);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormularioAsignarUnObjeto";
            this.Controls.SetChildIndex(this.menu, 0);
            this.Controls.SetChildIndex(this.pnlBorde, 0);
            this.Controls.SetChildIndex(this.ctrolSinAsignar, 0);
            this.Controls.SetChildIndex(this.ctrolAsignado, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBorde;
        public System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnSalir;
        public Core.Controles.ctrolGrillaAsignarConBusqueda ctrolSinAsignar;
        public Core.Controles.ctrolGrillaAsignarConBusqueda ctrolAsignado;
        public System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.Button btnQuitar;
    }
}
namespace XCommerce.Core.Controles
{
    partial class ctrolVentaArticulo
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.btnLista = new System.Windows.Forms.Button();
            this.btnControles = new System.Windows.Forms.Button();
            this.pnlIzquierdo = new System.Windows.Forms.Panel();
            this.pnlLineaIzquierda = new System.Windows.Forms.Panel();
            this.lblRubro = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpRubros = new System.Windows.Forms.FlowLayoutPanel();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlSuperior.SuspendLayout();
            this.pnlIzquierdo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlSuperior.Controls.Add(this.label1);
            this.pnlSuperior.Controls.Add(this.txtBusqueda);
            this.pnlSuperior.Controls.Add(this.btnControles);
            this.pnlSuperior.Controls.Add(this.btnLista);
            this.pnlSuperior.Controls.Add(this.pnlLinea);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(771, 49);
            this.pnlSuperior.TabIndex = 0;
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlLinea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLinea.Location = new System.Drawing.Point(0, 46);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(771, 3);
            this.pnlLinea.TabIndex = 1;
            // 
            // btnLista
            // 
            this.btnLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLista.BackgroundImage = global::XCommerce.Properties.Resources.Lista;
            this.btnLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLista.Location = new System.Drawing.Point(688, 5);
            this.btnLista.Name = "btnLista";
            this.btnLista.Size = new System.Drawing.Size(35, 35);
            this.btnLista.TabIndex = 2;
            this.btnLista.UseVisualStyleBackColor = true;
            this.btnLista.Click += new System.EventHandler(this.btnLista_Click);
            // 
            // btnControles
            // 
            this.btnControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControles.BackgroundImage = global::XCommerce.Properties.Resources.Controles;
            this.btnControles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnControles.Location = new System.Drawing.Point(729, 5);
            this.btnControles.Name = "btnControles";
            this.btnControles.Size = new System.Drawing.Size(35, 35);
            this.btnControles.TabIndex = 3;
            this.btnControles.UseVisualStyleBackColor = true;
            this.btnControles.Click += new System.EventHandler(this.btnControles_Click);
            // 
            // pnlIzquierdo
            // 
            this.pnlIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlIzquierdo.Controls.Add(this.flpRubros);
            this.pnlIzquierdo.Controls.Add(this.panel1);
            this.pnlIzquierdo.Controls.Add(this.lblRubro);
            this.pnlIzquierdo.Controls.Add(this.pnlLineaIzquierda);
            this.pnlIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierdo.Location = new System.Drawing.Point(0, 49);
            this.pnlIzquierdo.Name = "pnlIzquierdo";
            this.pnlIzquierdo.Size = new System.Drawing.Size(193, 426);
            this.pnlIzquierdo.TabIndex = 1;
            // 
            // pnlLineaIzquierda
            // 
            this.pnlLineaIzquierda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlLineaIzquierda.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLineaIzquierda.Location = new System.Drawing.Point(190, 0);
            this.pnlLineaIzquierda.Name = "pnlLineaIzquierda";
            this.pnlLineaIzquierda.Size = new System.Drawing.Size(3, 426);
            this.pnlLineaIzquierda.TabIndex = 2;
            // 
            // lblRubro
            // 
            this.lblRubro.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRubro.ForeColor = System.Drawing.Color.White;
            this.lblRubro.Location = new System.Drawing.Point(0, 0);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(190, 30);
            this.lblRubro.TabIndex = 3;
            this.lblRubro.Text = "Rubros";
            this.lblRubro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 3);
            this.panel1.TabIndex = 4;
            // 
            // flpRubros
            // 
            this.flpRubros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRubros.Location = new System.Drawing.Point(0, 33);
            this.flpRubros.Name = "flpRubros";
            this.flpRubros.Size = new System.Drawing.Size(190, 393);
            this.flpRubros.TabIndex = 5;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusqueda.Location = new System.Drawing.Point(471, 13);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(197, 20);
            this.txtBusqueda.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(387, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Busqueda";
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.White;
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(193, 49);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(578, 426);
            this.pnlContenedor.TabIndex = 2;
            // 
            // ctrolVentaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlIzquierdo);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "ctrolVentaArticulo";
            this.Size = new System.Drawing.Size(771, 475);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlIzquierdo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Button btnControles;
        private System.Windows.Forms.Button btnLista;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Panel pnlIzquierdo;
        private System.Windows.Forms.FlowLayoutPanel flpRubros;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.Panel pnlLineaIzquierda;
        private System.Windows.Forms.Panel pnlContenedor;
    }
}

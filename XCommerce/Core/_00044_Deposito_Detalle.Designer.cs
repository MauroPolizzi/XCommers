namespace XCommerce.Core
{
    partial class _00044_Deposito_Detalle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imgArticulo = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnAumentarStock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.imgBuscar = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.imgFotoArticulo = new System.Windows.Forms.PictureBox();
            this.pnlSeparadorDetalle = new System.Windows.Forms.Panel();
            this.lblDatos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgArticulo)).BeginInit();
            this.menu.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuarioLogin
            // 
            this.lblUsuarioLogin.Size = new System.Drawing.Size(1177, 18);
            // 
            // imgArticulo
            // 
            this.imgArticulo.Location = new System.Drawing.Point(25, 61);
            this.imgArticulo.Name = "imgArticulo";
            this.imgArticulo.Size = new System.Drawing.Size(229, 232);
            this.imgArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgArticulo.TabIndex = 2;
            this.imgArticulo.TabStop = false;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.SteelBlue;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAumentarStock,
            this.toolStripSeparator1,
            this.btnActualizar,
            this.btnSalir});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Margin = new System.Windows.Forms.Padding(5);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(857, 62);
            this.menu.TabIndex = 7;
            this.menu.Text = "toolStrip1";
            // 
            // btnAumentarStock
            // 
            this.btnAumentarStock.ForeColor = System.Drawing.Color.White;
            this.btnAumentarStock.Image = global::XCommerce.Properties.Resources.Agregar2;
            this.btnAumentarStock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAumentarStock.Name = "btnAumentarStock";
            this.btnAumentarStock.Size = new System.Drawing.Size(96, 59);
            this.btnAumentarStock.Text = "Aumentar Stock";
            this.btnAumentarStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAumentarStock.Click += new System.EventHandler(this.btnAumentarStock_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 62);
            // 
            // btnActualizar
            // 
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = global::XCommerce.Properties.Resources.Actualizar;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(63, 59);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
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
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlBusqueda.Controls.Add(this.pnlBorde);
            this.pnlBusqueda.Controls.Add(this.lblTitulo);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.imgBuscar);
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 62);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(857, 49);
            this.pnlBusqueda.TabIndex = 8;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBorde.Location = new System.Drawing.Point(0, 45);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(857, 4);
            this.pnlBorde.TabIndex = 4;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(7, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(559, 30);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Titulo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(607, 9);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(169, 26);
            this.txtBuscar.TabIndex = 0;
            // 
            // imgBuscar
            // 
            this.imgBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBuscar.BackColor = System.Drawing.Color.Transparent;
            this.imgBuscar.Image = global::XCommerce.Properties.Resources.Buscar;
            this.imgBuscar.Location = new System.Drawing.Point(571, 7);
            this.imgBuscar.Name = "imgBuscar";
            this.imgBuscar.Size = new System.Drawing.Size(32, 30);
            this.imgBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBuscar.TabIndex = 2;
            this.imgBuscar.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(780, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(65, 28);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvGrilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(5, 117);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(571, 312);
            this.dgvGrilla.TabIndex = 9;
            this.dgvGrilla.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_RowEnter);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.imgFotoArticulo);
            this.pnlDetalle.Controls.Add(this.pnlSeparadorDetalle);
            this.pnlDetalle.Controls.Add(this.lblDatos);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetalle.Location = new System.Drawing.Point(582, 111);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(275, 322);
            this.pnlDetalle.TabIndex = 10;
            // 
            // imgFotoArticulo
            // 
            this.imgFotoArticulo.Location = new System.Drawing.Point(35, 60);
            this.imgFotoArticulo.Name = "imgFotoArticulo";
            this.imgFotoArticulo.Size = new System.Drawing.Size(207, 211);
            this.imgFotoArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgFotoArticulo.TabIndex = 2;
            this.imgFotoArticulo.TabStop = false;
            // 
            // pnlSeparadorDetalle
            // 
            this.pnlSeparadorDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlSeparadorDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparadorDetalle.Location = new System.Drawing.Point(0, 34);
            this.pnlSeparadorDetalle.Name = "pnlSeparadorDetalle";
            this.pnlSeparadorDetalle.Size = new System.Drawing.Size(275, 5);
            this.pnlSeparadorDetalle.TabIndex = 1;
            // 
            // lblDatos
            // 
            this.lblDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDatos.Location = new System.Drawing.Point(0, 0);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(275, 34);
            this.lblDatos.TabIndex = 0;
            this.lblDatos.Text = "Datos Adicionales";
            this.lblDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _00044_Deposito_Detalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(857, 461);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.menu);
            this.Name = "_00044_Deposito_Detalle";
            this.Text = "_00044_Deposito_Detalle";
            this.Controls.SetChildIndex(this.menu, 0);
            this.Controls.SetChildIndex(this.pnlBusqueda, 0);
            this.Controls.SetChildIndex(this.dgvGrilla, 0);
            this.Controls.SetChildIndex(this.pnlDetalle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imgArticulo)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgArticulo;
        public System.Windows.Forms.ToolStrip menu;
        public System.Windows.Forms.ToolStripButton btnAumentarStock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton btnActualizar;
        public System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Panel pnlBorde;
        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.PictureBox imgBuscar;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.DataGridView dgvGrilla;
        public System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel pnlSeparadorDetalle;
        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.PictureBox imgFotoArticulo;
    }
}
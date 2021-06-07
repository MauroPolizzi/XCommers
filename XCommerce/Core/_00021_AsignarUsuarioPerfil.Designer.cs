namespace XCommerce.Core
{
    partial class _00021_AsignarUsuarioPerfil
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
            this.btnMarcarTodo = new System.Windows.Forms.Button();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.imgBuscar = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnAsignarEmpleados = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.btnDesmarcarTodo = new System.Windows.Forms.Button();
            this.pnlDatosEmpresa = new System.Windows.Forms.Panel();
            this.txtPerfil = new System.Windows.Forms.TextBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscar)).BeginInit();
            this.menu.SuspendLayout();
            this.pnlDatosEmpresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuarioLogin
            // 
            this.lblUsuarioLogin.Size = new System.Drawing.Size(3650, 18);
            // 
            // btnMarcarTodo
            // 
            this.btnMarcarTodo.Location = new System.Drawing.Point(11, 495);
            this.btnMarcarTodo.Name = "btnMarcarTodo";
            this.btnMarcarTodo.Size = new System.Drawing.Size(142, 28);
            this.btnMarcarTodo.TabIndex = 39;
            this.btnMarcarTodo.Text = "Marca Todo";
            this.btnMarcarTodo.UseVisualStyleBackColor = true;
            this.btnMarcarTodo.Click += new System.EventHandler(this.btnMarcarTodo_Click);
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(11, 165);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(763, 325);
            this.dgvGrilla.TabIndex = 37;
            this.dgvGrilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_CellContentClick);
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
            this.pnlBusqueda.Size = new System.Drawing.Size(784, 45);
            this.pnlBusqueda.TabIndex = 36;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBorde.Location = new System.Drawing.Point(0, 41);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(784, 4);
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
            this.lblTitulo.Size = new System.Drawing.Size(486, 26);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Asignar Usuarios a un Perfil";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(534, 9);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(169, 26);
            this.txtBuscar.TabIndex = 0;
            // 
            // imgBuscar
            // 
            this.imgBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBuscar.BackColor = System.Drawing.Color.Transparent;
            this.imgBuscar.Image = global::XCommerce.Properties.Resources.Buscar;
            this.imgBuscar.Location = new System.Drawing.Point(498, 7);
            this.imgBuscar.Name = "imgBuscar";
            this.imgBuscar.Size = new System.Drawing.Size(32, 30);
            this.imgBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBuscar.TabIndex = 2;
            this.imgBuscar.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(707, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(65, 28);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.SteelBlue;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAsignarEmpleados,
            this.btnActualizar,
            this.btnSalir});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Margin = new System.Windows.Forms.Padding(5);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 62);
            this.menu.TabIndex = 35;
            this.menu.Text = "toolStrip1";
            // 
            // btnAsignarEmpleados
            // 
            this.btnAsignarEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnAsignarEmpleados.Image = global::XCommerce.Properties.Resources.Usuarios;
            this.btnAsignarEmpleados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAsignarEmpleados.Name = "btnAsignarEmpleados";
            this.btnAsignarEmpleados.Size = new System.Drawing.Size(99, 59);
            this.btnAsignarEmpleados.Text = "Asignar Usuarios";
            this.btnAsignarEmpleados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAsignarEmpleados.Click += new System.EventHandler(this.btnAsignarEmpleados_Click);
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
            // btnDesmarcarTodo
            // 
            this.btnDesmarcarTodo.Location = new System.Drawing.Point(159, 495);
            this.btnDesmarcarTodo.Name = "btnDesmarcarTodo";
            this.btnDesmarcarTodo.Size = new System.Drawing.Size(142, 28);
            this.btnDesmarcarTodo.TabIndex = 40;
            this.btnDesmarcarTodo.Text = "Desmarcar Todo";
            this.btnDesmarcarTodo.UseVisualStyleBackColor = true;
            this.btnDesmarcarTodo.Click += new System.EventHandler(this.btnDesmarcarTodo_Click);
            // 
            // pnlDatosEmpresa
            // 
            this.pnlDatosEmpresa.BackColor = System.Drawing.Color.Beige;
            this.pnlDatosEmpresa.Controls.Add(this.txtPerfil);
            this.pnlDatosEmpresa.Controls.Add(this.lblRazonSocial);
            this.pnlDatosEmpresa.Location = new System.Drawing.Point(11, 114);
            this.pnlDatosEmpresa.Name = "pnlDatosEmpresa";
            this.pnlDatosEmpresa.Size = new System.Drawing.Size(763, 45);
            this.pnlDatosEmpresa.TabIndex = 38;
            // 
            // txtPerfil
            // 
            this.txtPerfil.Enabled = false;
            this.txtPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPerfil.Location = new System.Drawing.Point(99, 12);
            this.txtPerfil.Name = "txtPerfil";
            this.txtPerfil.Size = new System.Drawing.Size(650, 22);
            this.txtPerfil.TabIndex = 65;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazonSocial.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblRazonSocial.Location = new System.Drawing.Point(9, 16);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(84, 13);
            this.lblRazonSocial.TabIndex = 68;
            this.lblRazonSocial.Text = "Perfil / Grupo";
            // 
            // _00021_AsignarUsuarioPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnDesmarcarTodo);
            this.Controls.Add(this.btnMarcarTodo);
            this.Controls.Add(this.pnlDatosEmpresa);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.menu);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "_00021_AsignarUsuarioPerfil";
            this.Text = "Asignar Usuarios a un Perfil";
            this.Load += new System.EventHandler(this._00021_AsignarUsuarioPerfil_Load);
            this.Controls.SetChildIndex(this.menu, 0);
            this.Controls.SetChildIndex(this.pnlBusqueda, 0);
            this.Controls.SetChildIndex(this.dgvGrilla, 0);
            this.Controls.SetChildIndex(this.pnlDatosEmpresa, 0);
            this.Controls.SetChildIndex(this.btnMarcarTodo, 0);
            this.Controls.SetChildIndex(this.btnDesmarcarTodo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscar)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlDatosEmpresa.ResumeLayout(false);
            this.pnlDatosEmpresa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMarcarTodo;
        public System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.PictureBox imgBuscar;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnAsignarEmpleados;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Button btnDesmarcarTodo;
        private System.Windows.Forms.Panel pnlDatosEmpresa;
        private System.Windows.Forms.TextBox txtPerfil;
        private System.Windows.Forms.Label lblRazonSocial;
    }
}
namespace XCommerce.Core
{
    partial class _00003_Usuario
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
            this.btnDesmarcarTodo = new System.Windows.Forms.Button();
            this.btnMarcarTodo = new System.Windows.Forms.Button();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.imgBuscar = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.btnCrearUsuarios = new System.Windows.Forms.ToolStripButton();
            this.btnBloquearUsuario = new System.Windows.Forms.ToolStripButton();
            this.btnResetPassword = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscar)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuarioLogin
            // 
            this.lblUsuarioLogin.Size = new System.Drawing.Size(2777, 18);
            // 
            // btnDesmarcarTodo
            // 
            this.btnDesmarcarTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesmarcarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesmarcarTodo.Location = new System.Drawing.Point(181, 396);
            this.btnDesmarcarTodo.Name = "btnDesmarcarTodo";
            this.btnDesmarcarTodo.Size = new System.Drawing.Size(170, 28);
            this.btnDesmarcarTodo.TabIndex = 13;
            this.btnDesmarcarTodo.Text = "Desmarcar Todo";
            this.btnDesmarcarTodo.UseVisualStyleBackColor = true;
            this.btnDesmarcarTodo.Click += new System.EventHandler(this.btnDesmarcarTodo_Click);
            // 
            // btnMarcarTodo
            // 
            this.btnMarcarTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarcarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcarTodo.Location = new System.Drawing.Point(5, 396);
            this.btnMarcarTodo.Name = "btnMarcarTodo";
            this.btnMarcarTodo.Size = new System.Drawing.Size(170, 28);
            this.btnMarcarTodo.TabIndex = 12;
            this.btnMarcarTodo.Text = "Marcar Todo";
            this.btnMarcarTodo.UseVisualStyleBackColor = true;
            this.btnMarcarTodo.Click += new System.EventHandler(this.btnMarcarTodo_Click);
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvGrilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(5, 113);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(772, 277);
            this.dgvGrilla.TabIndex = 11;
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
            this.pnlBusqueda.Size = new System.Drawing.Size(784, 49);
            this.pnlBusqueda.TabIndex = 10;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBorde.Location = new System.Drawing.Point(0, 45);
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
            this.lblTitulo.Size = new System.Drawing.Size(486, 30);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Usuarios";
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
            this.btnSalir,
            this.btnCrearUsuarios,
            this.btnBloquearUsuario,
            this.btnResetPassword,
            this.toolStripSeparator1,
            this.btnActualizar});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Margin = new System.Windows.Forms.Padding(5);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 62);
            this.menu.TabIndex = 9;
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
            // btnCrearUsuarios
            // 
            this.btnCrearUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnCrearUsuarios.Image = global::XCommerce.Properties.Resources.Usuario;
            this.btnCrearUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrearUsuarios.Name = "btnCrearUsuarios";
            this.btnCrearUsuarios.Size = new System.Drawing.Size(44, 59);
            this.btnCrearUsuarios.Text = "Crear";
            this.btnCrearUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCrearUsuarios.Click += new System.EventHandler(this.btnCrearUsuarios_Click);
            // 
            // btnBloquearUsuario
            // 
            this.btnBloquearUsuario.ForeColor = System.Drawing.Color.White;
            this.btnBloquearUsuario.Image = global::XCommerce.Properties.Resources.Candado;
            this.btnBloquearUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBloquearUsuario.Name = "btnBloquearUsuario";
            this.btnBloquearUsuario.Size = new System.Drawing.Size(129, 59);
            this.btnBloquearUsuario.Text = "Bloquear/Desbloquear";
            this.btnBloquearUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBloquearUsuario.Click += new System.EventHandler(this.btnBloquearUsuario_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.Image = global::XCommerce.Properties.Resources.Password;
            this.btnResetPassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(126, 59);
            this.btnResetPassword.Text = "Restaurar  Contraseña";
            this.btnResetPassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
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
            // _00003_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnDesmarcarTodo);
            this.Controls.Add(this.btnMarcarTodo);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.menu);
            this.Name = "_00003_Usuario";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this._00003_Usuario_Load);
            this.Controls.SetChildIndex(this.menu, 0);
            this.Controls.SetChildIndex(this.pnlBusqueda, 0);
            this.Controls.SetChildIndex(this.dgvGrilla, 0);
            this.Controls.SetChildIndex(this.btnMarcarTodo, 0);
            this.Controls.SetChildIndex(this.btnDesmarcarTodo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBuscar)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnDesmarcarTodo;
        public System.Windows.Forms.Button btnMarcarTodo;
        public System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.PictureBox imgBuscar;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripButton btnCrearUsuarios;
        private System.Windows.Forms.ToolStripButton btnBloquearUsuario;
        private System.Windows.Forms.ToolStripButton btnResetPassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnActualizar;
    }
}
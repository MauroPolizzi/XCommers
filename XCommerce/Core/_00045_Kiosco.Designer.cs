namespace XCommerce.Core
{
    partial class _00045_Kiosco
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnContado = new System.Windows.Forms.ToolStripButton();
            this.btnTarjeta = new System.Windows.Forms.ToolStripButton();
            this.btnCtaCte = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.btnCheque = new System.Windows.Forms.ToolStripButton();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.dgvGrillaArticuloAgregado = new System.Windows.Forms.DataGridView();
            this.dgvGrillaBusquedaArticulo = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.txtBuscarFiltro = new System.Windows.Forms.TextBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNombreVendedor = new System.Windows.Forms.TextBox();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtApellidoCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtDniCliente = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbTipoFactura = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtNumFactura = new System.Windows.Forms.TextBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbDeposito = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.nudDescuentoPorcentje = new System.Windows.Forms.NumericUpDown();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaArticuloAgregado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaBusquedaArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuentoPorcentje)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuarioLogin
            // 
            this.lblUsuarioLogin.Size = new System.Drawing.Size(6988, 18);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnContado,
            this.btnTarjeta,
            this.btnCtaCte,
            this.toolStripSeparator1,
            this.btnSalir,
            this.btnCheque});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(909, 77);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnContado
            // 
            this.btnContado.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContado.ForeColor = System.Drawing.Color.White;
            this.btnContado.Image = global::XCommerce.Properties.Resources.icons8_dinero_2;
            this.btnContado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnContado.Name = "btnContado";
            this.btnContado.Size = new System.Drawing.Size(69, 74);
            this.btnContado.Text = "Efectivo";
            this.btnContado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnContado.Click += new System.EventHandler(this.btnContado_Click);
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarjeta.ForeColor = System.Drawing.Color.White;
            this.btnTarjeta.Image = global::XCommerce.Properties.Resources.icons8_tarjetas_bancarias_2;
            this.btnTarjeta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(61, 74);
            this.btnTarjeta.Text = "Tarjeta";
            this.btnTarjeta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCtaCte
            // 
            this.btnCtaCte.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCtaCte.ForeColor = System.Drawing.Color.White;
            this.btnCtaCte.Image = global::XCommerce.Properties.Resources.icons8_museo;
            this.btnCtaCte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCtaCte.Name = "btnCtaCte";
            this.btnCtaCte.Size = new System.Drawing.Size(66, 74);
            this.btnCtaCte.Text = "Cta/Cte";
            this.btnCtaCte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCtaCte.Click += new System.EventHandler(this.btnCtaCte_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 77);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = global::XCommerce.Properties.Resources.Salir;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(54, 74);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCheque
            // 
            this.btnCheque.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheque.ForeColor = System.Drawing.Color.White;
            this.btnCheque.Image = global::XCommerce.Properties.Resources.icons8_cheque_rebotado_50;
            this.btnCheque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheque.Name = "btnCheque";
            this.btnCheque.Size = new System.Drawing.Size(65, 74);
            this.btnCheque.Text = "Cheque";
            this.btnCheque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 77);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(909, 4);
            this.pnlBorde.TabIndex = 6;
            // 
            // dgvGrillaArticuloAgregado
            // 
            this.dgvGrillaArticuloAgregado.AllowUserToAddRows = false;
            this.dgvGrillaArticuloAgregado.AllowUserToDeleteRows = false;
            this.dgvGrillaArticuloAgregado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrillaArticuloAgregado.Location = new System.Drawing.Point(21, 453);
            this.dgvGrillaArticuloAgregado.Name = "dgvGrillaArticuloAgregado";
            this.dgvGrillaArticuloAgregado.Size = new System.Drawing.Size(534, 183);
            this.dgvGrillaArticuloAgregado.TabIndex = 7;
            this.dgvGrillaArticuloAgregado.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrillaArticuloAgregado_RowEnter);
            // 
            // dgvGrillaBusquedaArticulo
            // 
            this.dgvGrillaBusquedaArticulo.AllowUserToAddRows = false;
            this.dgvGrillaBusquedaArticulo.AllowUserToDeleteRows = false;
            this.dgvGrillaBusquedaArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrillaBusquedaArticulo.Location = new System.Drawing.Point(21, 234);
            this.dgvGrillaBusquedaArticulo.Name = "dgvGrillaBusquedaArticulo";
            this.dgvGrillaBusquedaArticulo.Size = new System.Drawing.Size(534, 182);
            this.dgvGrillaBusquedaArticulo.TabIndex = 8;
            this.dgvGrillaBusquedaArticulo.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrillaBusquedaArticulo_RowEnter);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(480, 205);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Location = new System.Drawing.Point(480, 422);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarArticulo.TabIndex = 10;
            this.btnAgregarArticulo.Text = "Agregar";
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(21, 207);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(112, 21);
            this.cmbFiltro.TabIndex = 11;
            // 
            // txtBuscarFiltro
            // 
            this.txtBuscarFiltro.Location = new System.Drawing.Point(139, 207);
            this.txtBuscarFiltro.Name = "txtBuscarFiltro";
            this.txtBuscarFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtBuscarFiltro.TabIndex = 12;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(390, 425);
            this.nudCantidad.Maximum = new decimal(new int[] {
            268435456,
            1042612833,
            542101086,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(84, 20);
            this.nudCantidad.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(335, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cantidad";
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudTotal.Location = new System.Drawing.Point(124, 253);
            this.nudTotal.Maximum = new decimal(new int[] {
            268435456,
            1042612833,
            542101086,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(180, 44);
            this.nudTotal.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 33);
            this.label2.TabIndex = 16;
            this.label2.Text = "Total";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtNombreVendedor);
            this.groupBox1.Controls.Add(this.txtLegajo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(21, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 114);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vendedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nombre";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 18);
            this.label10.TabIndex = 6;
            this.label10.Text = "Legajo";
            // 
            // txtNombreVendedor
            // 
            this.txtNombreVendedor.Location = new System.Drawing.Point(97, 60);
            this.txtNombreVendedor.Name = "txtNombreVendedor";
            this.txtNombreVendedor.Size = new System.Drawing.Size(133, 24);
            this.txtNombreVendedor.TabIndex = 5;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(97, 30);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(133, 24);
            this.txtLegajo.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtApellidoCliente);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNombreCliente);
            this.groupBox2.Controls.Add(this.txtDniCliente);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(280, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 114);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cliente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Apellido";
            // 
            // txtApellidoCliente
            // 
            this.txtApellidoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoCliente.Location = new System.Drawing.Point(88, 82);
            this.txtApellidoCliente.Name = "txtApellidoCliente";
            this.txtApellidoCliente.Size = new System.Drawing.Size(187, 20);
            this.txtApellidoCliente.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Dni";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(88, 56);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(187, 20);
            this.txtNombreCliente.TabIndex = 1;
            // 
            // txtDniCliente
            // 
            this.txtDniCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDniCliente.Location = new System.Drawing.Point(88, 30);
            this.txtDniCliente.Name = "txtDniCliente";
            this.txtDniCliente.Size = new System.Drawing.Size(106, 20);
            this.txtDniCliente.TabIndex = 0;
            this.txtDniCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.cmbTipoFactura);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.dtpFechaFactura);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtDescuento);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtSubTotal);
            this.groupBox3.Controls.Add(this.txtNumFactura);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.nudTotal);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(575, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 340);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Factura";
            // 
            // cmbTipoFactura
            // 
            this.cmbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFactura.FormattingEnabled = true;
            this.cmbTipoFactura.Location = new System.Drawing.Point(107, 56);
            this.cmbTipoFactura.Name = "cmbTipoFactura";
            this.cmbTipoFactura.Size = new System.Drawing.Size(112, 26);
            this.cmbTipoFactura.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(109, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Descuento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 18);
            this.label12.TabIndex = 5;
            this.label12.Text = "Fecha";
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.Enabled = false;
            this.dtpFechaFactura.Location = new System.Drawing.Point(106, 87);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(198, 24);
            this.dtpFechaFactura.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(109, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "Sub Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tipo ";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(222, 221);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(82, 24);
            this.txtDescuento.TabIndex = 5;
            this.txtDescuento.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "N°";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(222, 191);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(82, 24);
            this.txtSubTotal.TabIndex = 4;
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.Location = new System.Drawing.Point(107, 26);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.Size = new System.Drawing.Size(71, 24);
            this.txtNumFactura.TabIndex = 0;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(480, 642);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 20;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(257, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Deposito";
            // 
            // cmbDeposito
            // 
            this.cmbDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeposito.FormattingEnabled = true;
            this.cmbDeposito.Location = new System.Drawing.Point(312, 207);
            this.cmbDeposito.Name = "cmbDeposito";
            this.cmbDeposito.Size = new System.Drawing.Size(112, 21);
            this.cmbDeposito.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(169, 427);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Descuento %";
            // 
            // nudDescuentoPorcentje
            // 
            this.nudDescuentoPorcentje.Location = new System.Drawing.Point(245, 425);
            this.nudDescuentoPorcentje.Maximum = new decimal(new int[] {
            268435456,
            1042612833,
            542101086,
            0});
            this.nudDescuentoPorcentje.Name = "nudDescuentoPorcentje";
            this.nudDescuentoPorcentje.Size = new System.Drawing.Size(84, 20);
            this.nudDescuentoPorcentje.TabIndex = 22;
            // 
            // _00045_Kiosco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(909, 699);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.nudDescuentoPorcentje);
            this.Controls.Add(this.cmbDeposito);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.txtBuscarFiltro);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.btnAgregarArticulo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvGrillaBusquedaArticulo);
            this.Controls.Add(this.dgvGrillaArticuloAgregado);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.toolStrip);
            this.MaximumSize = new System.Drawing.Size(925, 738);
            this.MinimumSize = new System.Drawing.Size(925, 726);
            this.Name = "_00045_Kiosco";
            this.Text = "_00045_Kiosco";
            this.Load += new System.EventHandler(this._00045_Kiosco_Load);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.Controls.SetChildIndex(this.pnlBorde, 0);
            this.Controls.SetChildIndex(this.dgvGrillaArticuloAgregado, 0);
            this.Controls.SetChildIndex(this.dgvGrillaBusquedaArticulo, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.btnAgregarArticulo, 0);
            this.Controls.SetChildIndex(this.cmbFiltro, 0);
            this.Controls.SetChildIndex(this.txtBuscarFiltro, 0);
            this.Controls.SetChildIndex(this.nudCantidad, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbDeposito, 0);
            this.Controls.SetChildIndex(this.nudDescuentoPorcentje, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaArticuloAgregado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaBusquedaArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuentoPorcentje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnContado;
        private System.Windows.Forms.ToolStripButton btnTarjeta;
        private System.Windows.Forms.ToolStripButton btnCtaCte;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.DataGridView dgvGrillaArticuloAgregado;
        private System.Windows.Forms.DataGridView dgvGrillaBusquedaArticulo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.TextBox txtBuscarFiltro;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtDniCliente;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumFactura;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.ToolStripButton btnCheque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNombreVendedor;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtApellidoCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaFactura;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbDeposito;
        private System.Windows.Forms.ComboBox cmbTipoFactura;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudDescuentoPorcentje;
    }
}
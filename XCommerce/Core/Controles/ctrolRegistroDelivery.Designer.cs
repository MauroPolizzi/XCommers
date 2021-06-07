namespace XCommerce.Core.Controles
{
    partial class ctrolRegistroDelivery
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
            this.lblNumeroPedido = new System.Windows.Forms.Label();
            this.lblCadete = new System.Windows.Forms.Label();
            this.lblDatosCadete = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.lblTemporizador = new System.Windows.Forms.Label();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.lblDatosCliente = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cronometro = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblNumeroPedido
            // 
            this.lblNumeroPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNumeroPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroPedido.ForeColor = System.Drawing.Color.White;
            this.lblNumeroPedido.Location = new System.Drawing.Point(7, 6);
            this.lblNumeroPedido.Name = "lblNumeroPedido";
            this.lblNumeroPedido.Size = new System.Drawing.Size(76, 48);
            this.lblNumeroPedido.TabIndex = 0;
            this.lblNumeroPedido.Text = "00000";
            this.lblNumeroPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCadete
            // 
            this.lblCadete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCadete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblCadete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadete.Location = new System.Drawing.Point(293, 6);
            this.lblCadete.Name = "lblCadete";
            this.lblCadete.Size = new System.Drawing.Size(396, 23);
            this.lblCadete.TabIndex = 1;
            this.lblCadete.Text = "Cadete";
            this.lblCadete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDatosCadete
            // 
            this.lblDatosCadete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatosCadete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblDatosCadete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosCadete.Location = new System.Drawing.Point(293, 32);
            this.lblDatosCadete.Name = "lblDatosCadete";
            this.lblDatosCadete.Size = new System.Drawing.Size(395, 22);
            this.lblDatosCadete.TabIndex = 2;
            this.lblDatosCadete.Text = "Datos del Cadete";
            this.lblDatosCadete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(89, 32);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(94, 22);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Location = new System.Drawing.Point(89, 7);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(94, 23);
            this.btnVerDetalle.TabIndex = 4;
            this.btnVerDetalle.Text = "Ver Detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            // 
            // lblTemporizador
            // 
            this.lblTemporizador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTemporizador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemporizador.ForeColor = System.Drawing.Color.White;
            this.lblTemporizador.Location = new System.Drawing.Point(189, 7);
            this.lblTemporizador.Name = "lblTemporizador";
            this.lblTemporizador.Size = new System.Drawing.Size(98, 48);
            this.lblTemporizador.TabIndex = 5;
            this.lblTemporizador.Text = "00:00:00";
            this.lblTemporizador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLinea
            // 
            this.pnlLinea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLinea.Location = new System.Drawing.Point(3, 58);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(686, 3);
            this.pnlLinea.TabIndex = 6;
            // 
            // lblDatosCliente
            // 
            this.lblDatosCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatosCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblDatosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosCliente.Location = new System.Drawing.Point(7, 90);
            this.lblDatosCliente.Name = "lblDatosCliente";
            this.lblDatosCliente.Size = new System.Drawing.Size(680, 22);
            this.lblDatosCliente.TabIndex = 8;
            this.lblDatosCliente.Text = "Datos del Cliente";
            this.lblDatosCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCliente
            // 
            this.lblCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(7, 64);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(681, 23);
            this.lblCliente.TabIndex = 7;
            this.lblCliente.Text = "Cliente";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cronometro
            // 
            //this.cronometro.Tick += new System.EventHandler(this.cronometro_Tick);
            // 
            // ctrolRegistroDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDatosCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.pnlLinea);
            this.Controls.Add(this.lblTemporizador);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblDatosCadete);
            this.Controls.Add(this.lblCadete);
            this.Controls.Add(this.lblNumeroPedido);
            this.Name = "ctrolRegistroDelivery";
            this.Size = new System.Drawing.Size(697, 120);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumeroPedido;
        private System.Windows.Forms.Label lblCadete;
        private System.Windows.Forms.Label lblDatosCadete;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Label lblTemporizador;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Label lblDatosCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Timer cronometro;
    }
}

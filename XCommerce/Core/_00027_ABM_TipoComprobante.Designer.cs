﻿namespace XCommerce.Core
{
    partial class _00027_ABM_TipoComprobante
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudCodigo = new System.Windows.Forms.NumericUpDown();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtLetra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuarioLogin
            // 
            this.lblUsuarioLogin.Size = new System.Drawing.Size(493, 18);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Codigo";
            // 
            // nudCodigo
            // 
            this.nudCodigo.Location = new System.Drawing.Point(101, 102);
            this.nudCodigo.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudCodigo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCodigo.Name = "nudCodigo";
            this.nudCodigo.Size = new System.Drawing.Size(89, 20);
            this.nudCodigo.TabIndex = 0;
            this.nudCodigo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(101, 154);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(359, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(32, 157);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(63, 13);
            this.lblApellido.TabIndex = 42;
            this.lblApellido.Text = "Descripción";
            // 
            // txtLetra
            // 
            this.txtLetra.Location = new System.Drawing.Point(101, 128);
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(89, 20);
            this.txtLetra.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Letra";
            // 
            // _00027_ABM_TipoComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 248);
            this.Controls.Add(this.txtLetra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudCodigo);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblApellido);
            this.MaximumSize = new System.Drawing.Size(536, 287);
            this.MinimumSize = new System.Drawing.Size(536, 287);
            this.Name = "_00027_ABM_TipoComprobante";
            this.Text = "Tipo de Comprobante";
            this.Controls.SetChildIndex(this.lblApellido, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.nudCodigo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtLetra, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtLetra;
        private System.Windows.Forms.Label label2;
    }
}
namespace XCommerce.Core
{
    partial class _00014_ABM_Mesa
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnNuevaSala = new System.Windows.Forms.Button();
            this.cmbSala = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuarioLogin
            // 
            this.lblUsuarioLogin.Size = new System.Drawing.Size(383, 18);
            this.lblUsuarioLogin.Text = "Usuario:  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Codigo";
            // 
            // nudCodigo
            // 
            this.nudCodigo.Location = new System.Drawing.Point(77, 89);
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
            this.nudCodigo.TabIndex = 44;
            this.nudCodigo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(77, 129);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(359, 20);
            this.txtDescripcion.TabIndex = 45;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(9, 132);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(63, 13);
            this.lblApellido.TabIndex = 46;
            this.lblApellido.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 107;
            this.label2.Text = "Sala";
            // 
            // btnNuevaSala
            // 
            this.btnNuevaSala.Location = new System.Drawing.Point(442, 167);
            this.btnNuevaSala.Name = "btnNuevaSala";
            this.btnNuevaSala.Size = new System.Drawing.Size(31, 23);
            this.btnNuevaSala.TabIndex = 106;
            this.btnNuevaSala.Text = "...";
            this.btnNuevaSala.UseVisualStyleBackColor = true;
            this.btnNuevaSala.Click += new System.EventHandler(this.btnNuevaSala_Click);
            // 
            // cmbSala
            // 
            this.cmbSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSala.FormattingEnabled = true;
            this.cmbSala.Location = new System.Drawing.Point(76, 167);
            this.cmbSala.Name = "cmbSala";
            this.cmbSala.Size = new System.Drawing.Size(360, 24);
            this.cmbSala.TabIndex = 105;
            // 
            // _00014_ABM_Mesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNuevaSala);
            this.Controls.Add(this.cmbSala);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudCodigo);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblApellido);
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "_00014_ABM_Mesa";
            this.Text = "Mesa";
            this.Load += new System.EventHandler(this._00014_ABM_Mesa_Load);
            this.Controls.SetChildIndex(this.lblApellido, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.nudCodigo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbSala, 0);
            this.Controls.SetChildIndex(this.btnNuevaSala, 0);
            this.Controls.SetChildIndex(this.label2, 0);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNuevaSala;
        private System.Windows.Forms.ComboBox cmbSala;
    }
}
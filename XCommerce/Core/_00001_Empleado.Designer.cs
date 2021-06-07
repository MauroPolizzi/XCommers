namespace XCommerce.Core
{
    partial class _00001_Empleado
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaIngreso = new System.Windows.Forms.TextBox();
            this.txtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.imgFotoEmpleado = new System.Windows.Forms.PictureBox();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtFechaIngreso);
            this.pnlDetalle.Controls.Add(this.txtFechaNacimiento);
            this.pnlDetalle.Controls.Add(this.txtEmail);
            this.pnlDetalle.Controls.Add(this.imgFotoEmpleado);
            this.pnlDetalle.Controls.SetChildIndex(this.imgFotoEmpleado, 0);
            this.pnlDetalle.Controls.SetChildIndex(this.txtEmail, 0);
            this.pnlDetalle.Controls.SetChildIndex(this.txtFechaNacimiento, 0);
            this.pnlDetalle.Controls.SetChildIndex(this.txtFechaIngreso, 0);
            this.pnlDetalle.Controls.SetChildIndex(this.label1, 0);
            this.pnlDetalle.Controls.SetChildIndex(this.label2, 0);
            this.pnlDetalle.Controls.SetChildIndex(this.label3, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Fecha Ingreso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fecha Cumpleaños";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "E-Mail";
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Enabled = false;
            this.txtFechaIngreso.Location = new System.Drawing.Point(9, 293);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.Size = new System.Drawing.Size(259, 20);
            this.txtFechaIngreso.TabIndex = 12;
            // 
            // txtFechaNacimiento
            // 
            this.txtFechaNacimiento.Enabled = false;
            this.txtFechaNacimiento.Location = new System.Drawing.Point(9, 247);
            this.txtFechaNacimiento.Name = "txtFechaNacimiento";
            this.txtFechaNacimiento.Size = new System.Drawing.Size(259, 20);
            this.txtFechaNacimiento.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(9, 201);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(259, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // imgFotoEmpleado
            // 
            this.imgFotoEmpleado.BackColor = System.Drawing.Color.White;
            this.imgFotoEmpleado.Location = new System.Drawing.Point(78, 40);
            this.imgFotoEmpleado.Name = "imgFotoEmpleado";
            this.imgFotoEmpleado.Size = new System.Drawing.Size(126, 132);
            this.imgFotoEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFotoEmpleado.TabIndex = 9;
            this.imgFotoEmpleado.TabStop = false;
            // 
            // _00001_Empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 461);
            this.Name = "_00001_Empleado";
            this.Text = "Empleados";
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoEmpleado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFechaIngreso;
        private System.Windows.Forms.TextBox txtFechaNacimiento;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.PictureBox imgFotoEmpleado;
    }
}
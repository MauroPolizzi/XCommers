namespace XCommerce.Core.Controles.FormulariosVarios
{
    partial class FControlArticulos
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
            this.flpRubros = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.flpArticulos = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpRubros
            // 
            this.flpRubros.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpRubros.Location = new System.Drawing.Point(0, 0);
            this.flpRubros.Name = "flpRubros";
            this.flpRubros.Size = new System.Drawing.Size(217, 484);
            this.flpRubros.TabIndex = 0;
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlLinea.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLinea.Location = new System.Drawing.Point(217, 0);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(4, 484);
            this.pnlLinea.TabIndex = 1;
            // 
            // flpArticulos
            // 
            this.flpArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpArticulos.Location = new System.Drawing.Point(221, 0);
            this.flpArticulos.Name = "flpArticulos";
            this.flpArticulos.Size = new System.Drawing.Size(653, 484);
            this.flpArticulos.TabIndex = 2;
            // 
            // FControlArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(874, 484);
            this.ControlBox = false;
            this.Controls.Add(this.flpArticulos);
            this.Controls.Add(this.pnlLinea);
            this.Controls.Add(this.flpRubros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FControlArticulos";
            //this.Load += new System.EventHandler(this.FControlArticulos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpRubros;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.FlowLayoutPanel flpArticulos;
    }
}
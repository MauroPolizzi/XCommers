namespace XCommerce.Core
{
    partial class _00006_Empresa
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
            this.imgLogoEmpresa = new System.Windows.Forms.PictureBox();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.imgLogoEmpresa);
            this.pnlDetalle.Controls.SetChildIndex(this.imgLogoEmpresa, 0);
            // 
            // imgLogoEmpresa
            // 
            this.imgLogoEmpresa.BackColor = System.Drawing.Color.White;
            this.imgLogoEmpresa.Location = new System.Drawing.Point(12, 52);
            this.imgLogoEmpresa.Name = "imgLogoEmpresa";
            this.imgLogoEmpresa.Size = new System.Drawing.Size(250, 234);
            this.imgLogoEmpresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogoEmpresa.TabIndex = 4;
            this.imgLogoEmpresa.TabStop = false;
            // 
            // _00006_Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 461);
            this.Name = "_00006_Empresa";
            this.Text = "Empresas";
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogoEmpresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLogoEmpresa;
    }
}
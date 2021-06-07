namespace XCommerce.Core
{
    partial class _00034_Articulo
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
            this.imgFotoArticulo = new System.Windows.Forms.PictureBox();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.imgFotoArticulo);
            this.pnlDetalle.Controls.SetChildIndex(this.imgFotoArticulo, 0);
            // 
            // imgFotoArticulo
            // 
            this.imgFotoArticulo.Image = global::XCommerce.Properties.Resources.ImagenFondo;
            this.imgFotoArticulo.Location = new System.Drawing.Point(34, 60);
            this.imgFotoArticulo.Name = "imgFotoArticulo";
            this.imgFotoArticulo.Size = new System.Drawing.Size(207, 211);
            this.imgFotoArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFotoArticulo.TabIndex = 2;
            this.imgFotoArticulo.TabStop = false;
            // 
            // _00034_Articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 461);
            this.Name = "_00034_Articulo";
            this.Text = "Articulo";
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgFotoArticulo;
    }
}
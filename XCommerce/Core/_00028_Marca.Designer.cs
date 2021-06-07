namespace XCommerce.Core
{
    partial class _00028_Marca
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
            this.imgFotoMarca = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoMarca)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // imgFotoMarca
            // 
            this.imgFotoMarca.Location = new System.Drawing.Point(49, 60);
            this.imgFotoMarca.Name = "imgFotoMarca";
            this.imgFotoMarca.Size = new System.Drawing.Size(188, 190);
            this.imgFotoMarca.TabIndex = 2;
            this.imgFotoMarca.TabStop = false;
            // 
            // _00028_Marca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Name = "_00028_Marca";
            this.Text = "Marca";
            this.Load += new System.EventHandler(this._00028_Marca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoMarca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgFotoMarca;
    }
}
namespace XCommerce.Core.Controles
{
    partial class ctrolFoto
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
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.btnObtenerImagen = new System.Windows.Forms.Button();
            this.imgFoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnObtenerImagen
            // 
            this.btnObtenerImagen.Image = global::XCommerce.Properties.Resources.Camara2;
            this.btnObtenerImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObtenerImagen.Location = new System.Drawing.Point(47, 224);
            this.btnObtenerImagen.Name = "btnObtenerImagen";
            this.btnObtenerImagen.Size = new System.Drawing.Size(131, 42);
            this.btnObtenerImagen.TabIndex = 1;
            this.btnObtenerImagen.Text = "Obtener Imagen";
            this.btnObtenerImagen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObtenerImagen.UseVisualStyleBackColor = true;
            this.btnObtenerImagen.Click += new System.EventHandler(this.btnObtenerImagen_Click);
            // 
            // imgFoto
            // 
            this.imgFoto.BackColor = System.Drawing.Color.White;
            this.imgFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgFoto.Image = global::XCommerce.Properties.Resources.ImagenFondo;
            this.imgFoto.Location = new System.Drawing.Point(15, 14);
            this.imgFoto.Name = "imgFoto";
            this.imgFoto.Size = new System.Drawing.Size(200, 200);
            this.imgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFoto.TabIndex = 0;
            this.imgFoto.TabStop = false;
            // 
            // ctrolFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.Controls.Add(this.btnObtenerImagen);
            this.Controls.Add(this.imgFoto);
            this.MaximumSize = new System.Drawing.Size(230, 277);
            this.MinimumSize = new System.Drawing.Size(230, 277);
            this.Name = "ctrolFoto";
            this.Size = new System.Drawing.Size(230, 277);
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog open;
        public System.Windows.Forms.PictureBox imgFoto;
        public System.Windows.Forms.Button btnObtenerImagen;
    }
}

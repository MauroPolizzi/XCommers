namespace XCommerce.Core.Controles
{
    partial class ctrolTipoVista
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
            this.btnControl = new System.Windows.Forms.Button();
            this.btnLista = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnControl
            // 
            this.btnControl.BackColor = System.Drawing.SystemColors.Control;
            this.btnControl.BackgroundImage = global::XCommerce.Properties.Resources.Controles;
            this.btnControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnControl.Location = new System.Drawing.Point(3, 2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(36, 36);
            this.btnControl.TabIndex = 0;
            this.btnControl.UseVisualStyleBackColor = false;
            // 
            // btnLista
            // 
            this.btnLista.BackgroundImage = global::XCommerce.Properties.Resources.Lista;
            this.btnLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLista.Location = new System.Drawing.Point(45, 2);
            this.btnLista.Name = "btnLista";
            this.btnLista.Size = new System.Drawing.Size(36, 36);
            this.btnLista.TabIndex = 1;
            this.btnLista.UseVisualStyleBackColor = true;
            // 
            // ctrolTipoVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLista);
            this.Controls.Add(this.btnControl);
            this.Name = "ctrolTipoVista";
            this.Size = new System.Drawing.Size(85, 40);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnControl;
        public System.Windows.Forms.Button btnLista;
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace XCommerce.Core.Controles
{
    public partial class ctrolEmpleadoLogin : UserControl
    {
        public ctrolEmpleadoLogin()
        {
            InitializeComponent();
            RedonderImagen();
        }

        private void RedonderImagen()
        {
            var gp = new GraphicsPath();
            gp.AddEllipse(0, 0, this.imgFoto.Width - 3, this.imgFoto.Height - 3);
            var rg = new Region(gp);
            this.imgFoto.Region = rg;
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

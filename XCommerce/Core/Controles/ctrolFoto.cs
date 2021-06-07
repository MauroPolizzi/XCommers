using System;
using System.Drawing;
using System.Windows.Forms;

namespace XCommerce.Core.Controles
{
    public partial class ctrolFoto : UserControl
    {
        public ctrolFoto()
        {
            InitializeComponent();
        }

        private void btnObtenerImagen_Click(object sender, EventArgs e)
        {
            if (open.ShowDialog() == DialogResult.OK)
            {
                imgFoto.Image = !string.IsNullOrEmpty(open.FileName)
                    ? Image.FromFile(open.FileName)
                    : Properties.Resources.ImagenFondo;
            }
            else
            {
                imgFoto.Image = Properties.Resources.ImagenFondo;
            }
        }
    }
}

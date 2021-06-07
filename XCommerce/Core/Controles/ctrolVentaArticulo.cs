using System;
using System.Windows.Forms;
using XCommerce.Core.Controles.FormulariosVarios;

namespace XCommerce.Core.Controles
{
    public partial class ctrolVentaArticulo : UserControl
    {
        public ctrolVentaArticulo()
        {
            InitializeComponent();
            AgregarFormularioLista();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            AgregarFormularioLista();
        }

        private void AgregarFormularioLista()
        {
            var fLista = new fListaArticulos();

            AgregarFormularioPanel(fLista);
        }

        private void btnControles_Click(object sender, EventArgs e)
        {
            AgregarFormularioControl();
        }

        private void AgregarFormularioControl()
        {
            var fControles = new fControlArticulos();

            AgregarFormularioPanel(fControles);
        }

        private void AgregarFormularioPanel(object formHijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(fh);
            this.pnlContenedor.Tag = fh;
            fh.Show();
        }
    }
}

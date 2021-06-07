using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Articulo;
using XCommerce.LogicaNegocio.Articulo.DTOs;
using XCommerce.LogicaNegocio.Deposito;

namespace XCommerce.Core
{
    public partial class _00044_Deposito_Detalle: FormularioBase
    {
        private readonly DepositoServicio _depositoServicio;
        private readonly ArticuloServicio _articuloServicio;

        private long? entidadId;
        private object objetoSeleccionado;

        private long? IdDeposito;
        public _00044_Deposito_Detalle()
        {
            InitializeComponent();
        }
        public _00044_Deposito_Detalle(long? depositoId = null)
            : this()
        {
            _depositoServicio = new DepositoServicio();
            _articuloServicio = new ArticuloServicio();
            //depositoId = _depositoId;
            
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            var deposito = _depositoServicio.ObtenerPorId(depositoId.Value);
            lblTitulo.Text = deposito.Descripcion;

            ActualizarGrilla(depositoId.Value, string.Empty);

            IdDeposito = depositoId;
        }
        public void ActualizarGrilla(long depositoId, string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _articuloServicio.ObtenerPorDeposito(depositoId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["DescripcionArticulo"].Visible = true;
            dgvGrilla.Columns["DescripcionArticulo"].HeaderText = "Articulo";
            dgvGrilla.Columns["DescripcionArticulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgvGrilla.Columns["Cantidad"].Visible = true;
            dgvGrilla.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvGrilla.Columns["Cantidad"].Width = 200;
        }

        public void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (VerificarSiHayDatos())
            {
                entidadId = (long) dgvGrilla["Id", e.RowIndex].Value;
                objetoSeleccionado = dgvGrilla.Rows[e.RowIndex].DataBoundItem;

                var articuloStock = (StockDto)objetoSeleccionado;

                if (articuloStock == null) return;

                var imagenArticulo = _articuloServicio.ObtenrePorId(articuloStock.ArticuloId);

                if (imagenArticulo == null) return;

                imgFotoArticulo.Image = Imagen.Convertir_Bytes_Imagen(imagenArticulo.Foto);
            }
            else
            {
                entidadId = null;
                objetoSeleccionado = null;
            }
        }

        private bool VerificarSiHayDatos()
        {
            if (dgvGrilla.RowCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //============================= BOTONES =======================//
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla(IdDeposito.Value, txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla(IdDeposito.Value,string.Empty);
        }

        private void btnAumentarStock_Click(object sender, EventArgs e)
        {
            var articuloStock = (StockDto)objetoSeleccionado;

            if (articuloStock == null) return;
            
            var fAgregarStock = new _00043_AgregarStock(TipoOperacion.Update, articuloStock.ArticuloId);
            fAgregarStock.ShowDialog();

            ActualizarGrilla(IdDeposito.Value , string.Empty);
        }
    }
}

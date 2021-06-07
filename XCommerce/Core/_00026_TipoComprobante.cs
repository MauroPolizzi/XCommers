using System.IO;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.TipoComprobante;

namespace XCommerce.Core
{
    public partial class _00026_TipoComprobante : FormularioConsulta
    {
        private readonly TipoComprobanteServicio _tipoComprobanteServicio;
        public _00026_TipoComprobante()
            :this(new TipoComprobanteServicio())
        {
            InitializeComponent();
        }

        public _00026_TipoComprobante(TipoComprobanteServicio tipoComprobante)
        {
            _tipoComprobanteServicio = tipoComprobante;

            btnImprimir.Visible = false;
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _tipoComprobanteServicio.ObtenerTodos(cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].HeaderText = "Codigo";
            dgvGrilla.Columns["Codigo"].Width = 100;

            dgvGrilla.Columns["Letra"].Visible = true;
            dgvGrilla.Columns["Letra"].HeaderText = "Letra";
            dgvGrilla.Columns["Letra"].Width = 130;

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Descripcion";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public override bool EjecutarNuevaEntidad()
        {
            var fNuevoTipoComprobante = new _00027_ABM_TipoComprobante(TipoOperacion.Insert);
            fNuevoTipoComprobante.ShowDialog();
            return fNuevoTipoComprobante.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fmodificarTipoComprobante = new _00027_ABM_TipoComprobante(TipoOperacion.Update, _entidadId);
            fmodificarTipoComprobante.ShowDialog();
            return fmodificarTipoComprobante.RealizoAlgunaOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var fEliminarTipoComprobante = new _00027_ABM_TipoComprobante(TipoOperacion.Delete, _entidadId);
            fEliminarTipoComprobante.ShowDialog();
            return fEliminarTipoComprobante.RealizoAlgunaOperacion;
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }
}

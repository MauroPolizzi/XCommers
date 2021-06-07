using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Rubro;
using XCommerce.LogicaNegocio.SubSubRubro;

namespace XCommerce.Core
{
    public partial class _00032_SubRubro : FormularioConsulta
    {
        private readonly SubRubroServicio _subRubroServicio;
        public _00032_SubRubro()
            :this(new SubRubroServicio())
        {
            InitializeComponent();
        }

        public _00032_SubRubro(SubRubroServicio subRubroServicio)
        {
            _subRubroServicio = subRubroServicio;

            btnImprimir.Visible = false;
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _subRubroServicio.ObtenerTodo(cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].Width = 100;
            dgvGrilla.Columns["Codigo"].HeaderText = "Codigo";

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Descripcion";

            dgvGrilla.Columns["EstaEliminadoStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
        }

        public override bool EjecutarNuevaEntidad()
        {
            var fNuevoSubRubro = new _00033_ABM_SubRubro(TipoOperacion.Insert);
            fNuevoSubRubro.ShowDialog();
            return fNuevoSubRubro.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fModificarSubRubro = new _00033_ABM_SubRubro(TipoOperacion.Update,_entidadId);
            fModificarSubRubro.ShowDialog();
            return fModificarSubRubro.RealizoAlgunaOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var fEliminar = new _00033_ABM_SubRubro(TipoOperacion.Delete,_entidadId);
            fEliminar.ShowDialog();
            return fEliminar.RealizoAlgunaOperacion;
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }
}

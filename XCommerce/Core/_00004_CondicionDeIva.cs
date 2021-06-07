using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.CondicionIva;

namespace XCommerce.Core
{
    public partial class _00004_CondicionDeIva : FormularioConsulta
    {
        private readonly CondicionIvaServicio _condicionIvaServicio;
        public _00004_CondicionDeIva()
            :this(new CondicionIvaServicio())
        {
            InitializeComponent();
        }

        public _00004_CondicionDeIva(CondicionIvaServicio condicionIvaServicio)
            :base("Lista Condicion Iva")
        {
            _condicionIvaServicio = condicionIvaServicio;
            btnImprimir.Visible = false;
            lblUsuarioLogin.Text = Identidad.ApyNomEmpleadoLogin;
        }

        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _condicionIvaServicio.ObtenerTodo(cadenaBuscar);
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

            dgvGrilla.Columns["EstaEliminadaStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadaStr"].HeaderText = "Eliminada";
            dgvGrilla.Columns["EstaEliminadaStr"].Width = 120;
        }

        public override bool EjecutarNuevaEntidad()
        {
            var fnuevaCondicion = new _00005_ABM_CondicionDeIva(TipoOperacion.Insert);
            fnuevaCondicion.ShowDialog();
            return fnuevaCondicion.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fModificarCondicion = new _00005_ABM_CondicionDeIva(TipoOperacion.Update,_entidadId);
            fModificarCondicion.ShowDialog();
            return fModificarCondicion.RealizoAlgunaOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var feliminarCondicion = new _00005_ABM_CondicionDeIva(TipoOperacion.Delete,_entidadId);
            feliminarCondicion.ShowDialog();
            return feliminarCondicion.RealizoAlgunaOperacion;
        }
    }
}

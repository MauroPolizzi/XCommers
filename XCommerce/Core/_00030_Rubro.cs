using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Rubro;

namespace XCommerce.Core
{
    public partial class _00030_Rubro : FormularioConsulta
    {
        private readonly RubroServicio _rubroServicio;

        //========================== CONSTRUCTORES =========================//
        public _00030_Rubro()
            :this(new RubroServicio())
        {
            InitializeComponent();
        }

        public _00030_Rubro(RubroServicio rubroServicio)
            :base("Lista de Rubros")
        {
            _rubroServicio = rubroServicio;

            btnImprimir.Visible = false;
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        //========================== GRILLA =========================//
        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _rubroServicio.ObtenerTodo(Identidad.EmpresaId, cadenaBuscar);
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
            dgvGrilla.Columns["Descripcion"].HeaderText = "Rubro";

            dgvGrilla.Columns["EstaEliminadoStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadoStr"].Width = 120;
            dgvGrilla.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
        }

        //========================== COMANDOS =========================//
        public override bool EjecutarNuevaEntidad()
        {
            var fNuevoRubro = new _00031_ABM_Rubro(TipoOperacion.Insert);
            fNuevoRubro.ShowDialog();
            return fNuevoRubro.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fModificarRubro = new _00031_ABM_Rubro(TipoOperacion.Update,_entidadId);
            fModificarRubro.ShowDialog();
            return fModificarRubro.RealizoAlgunaOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var fEliminarRubro = new _00031_ABM_Rubro(TipoOperacion.Delete,_entidadId);
            fEliminarRubro.ShowDialog();
            return fEliminarRubro.RealizoAlgunaOperacion;
        }

        //========================== BUSCAR =========================//

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }
}

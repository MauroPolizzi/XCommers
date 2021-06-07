using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Sala;

namespace XCommerce.Core
{
    public partial class _00011_Sala : FormularioConsulta
    {
        private readonly SalaServicio _salaServicio;

        //=============================== CONSTRUCTOR ==========================//
        public _00011_Sala()
            :this(new SalaServicio())
        {
            InitializeComponent();
        }

        public _00011_Sala(SalaServicio salaServicio)
        {
            _salaServicio = salaServicio;

            btnImprimir.Visible = false;

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

        }

        //=============================== GRILLA ==========================//

        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _salaServicio.ObtenerTodo(Identidad.EmpresaId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].HeaderText = "Codigo";
            dgvGrilla.Columns["Codigo"].Width = 100;

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Descripcion";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["EstaEliminadaStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadaStr"].HeaderText = "Eliminado";
            dgvGrilla.Columns["EstaEliminadaStr"].Width = 100;
        }

        //=============================== COMANDOS ==========================//
        public override bool EjecutarNuevaEntidad()
        {
            var fSalaNueva = new _00012_ABM_Sala(TipoOperacion.Insert);
            fSalaNueva.ShowDialog();
            return fSalaNueva.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fSalaModificar = new _00012_ABM_Sala(TipoOperacion.Update, _entidadId);
            fSalaModificar.ShowDialog();
            return fSalaModificar.RealizoAlgunaOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var fSalaEliminar = new _00012_ABM_Sala(TipoOperacion.Delete,_entidadId);
            fSalaEliminar.ShowDialog();
            return fSalaEliminar.RealizoAlgunaOperacion;
        }

        //=============================== BUSCAR ==========================//

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }


    }
}

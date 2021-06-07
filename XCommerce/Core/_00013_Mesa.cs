using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Mesa;

namespace XCommerce.Core
{
    public partial class _00013_Mesa : FormularioConsulta
    {
        private readonly MesaServicio _mesaServicio;
        public _00013_Mesa()
            :this(new MesaServicio())
        {
            InitializeComponent();
        }

        public _00013_Mesa(MesaServicio mesaServicio)
        {
            _mesaServicio = mesaServicio;

            btnImprimir.Visible = false;

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        //======================= DATOS GRILLA =======================//
        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _mesaServicio.ObtenerTodo(Identidad.EmpresaId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].HeaderText = "Codigo";
            dgvGrilla.Columns["Codigo"].Width = 120;

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Descripcion";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Sala"].Visible = true;
            dgvGrilla.Columns["Sala"].HeaderText = "Sala";
            dgvGrilla.Columns["Sala"].Width = 200;
        }

        //======================== NUEVA MESA =====================//
        public override bool EjecutarNuevaEntidad()
        {
            var fNuevaSala = new _00014_ABM_Mesa(TipoOperacion.Insert);
            fNuevaSala.ShowDialog();
            return fNuevaSala.RealizoAlgunaOperacion;
        }

        //======================== MODIFICAR MESA =====================//
        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fModificarSala = new _00014_ABM_Mesa(TipoOperacion.Update, _entidadId);
            fModificarSala.ShowDialog();
            return fModificarSala.RealizoAlgunaOperacion;
        }

        //======================== ELIMINAR MESA =====================//
        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            //var fEliminarSala = new _00014_ABM_Mesa(TipoOperacion.Delete, _entidadId);
            //fEliminarSala.ShowDialog();
            //return fEliminarSala.RealizoAlgunaOperacion;

            var eliminar = new MesaServicio();
            eliminar.Eliminar(_entidadId);
            return true;
        }

        //======================== BUSCAR MESA =====================//
        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            dgvGrilla.DataSource = _mesaServicio.ObtenerTodo(Identidad.EmpresaId, txtBuscar.Text);
        }
    }
}

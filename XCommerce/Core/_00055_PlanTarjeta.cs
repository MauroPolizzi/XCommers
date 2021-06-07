using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Tarjeta;
using XCommerce.LogicaNegocio.TarjetaPlan;

namespace XCommerce.Core
{
    public partial class _00055_PlanTarjeta: FormularioConsulta
    {
        private readonly PlanTarjetaServicio _planTarjetaServicio;
        private readonly TarjetaServicios _tarjetaServicios;

        private long _tarjetaId;
        public _00055_PlanTarjeta()
        {
            InitializeComponent();
        }

        public _00055_PlanTarjeta(long tarjetaId)
            :this(new PlanTarjetaServicio(),new TarjetaServicios())
        {
            _tarjetaId = tarjetaId;

            var tarjeta = _tarjetaServicios.ObtenerPorId(_tarjetaId);
            lblTitulo.Text = tarjeta.Descripcion;
        }

        public _00055_PlanTarjeta(PlanTarjetaServicio planTarjetaServicio
            , TarjetaServicios tarjetaServicios)
            :this()
        {
            _planTarjetaServicio = planTarjetaServicio;
            _tarjetaServicios = tarjetaServicios;

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            btnImprimir.Visible = false;
        }

        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _planTarjetaServicio.ObtenerTodo(_tarjetaId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Plan";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Alicuota"].Visible = true;
            dgvGrilla.Columns["Alicuota"].HeaderText = "Alicuota";
            dgvGrilla.Columns["Alicuota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public override bool EjecutarNuevaEntidad()
        {
            var fPlanNuevo = new _00056_ABM_PlanTarjeta(TipoOperacion.Insert,_tarjetaId);
            fPlanNuevo.ShowDialog();
            return fPlanNuevo.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fPlanModificar = new _00056_ABM_PlanTarjeta(TipoOperacion.Update, _entidadId);
            fPlanModificar.ShowDialog();
            return fPlanModificar.RealizoAlgunaOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var fPlanEliminar = new _00056_ABM_PlanTarjeta(TipoOperacion.Delete, _entidadId);
            fPlanEliminar.ShowDialog();
            return fPlanEliminar.RealizoAlgunaOperacion;
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }
}

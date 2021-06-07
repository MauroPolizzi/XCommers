using System.Linq;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Empleado;
using XCommerce.LogicaNegocio.Empleado.DTOs;

namespace XCommerce.Core
{
    public partial class _00001_Empleado : FormularioConsultaConDetalle
    {
        private readonly EmpleadoServicio _empleadoServicio;

        public _00001_Empleado()
            :this(new EmpleadoServicio())
        {
            InitializeComponent();
        }

        public _00001_Empleado(EmpleadoServicio empleadoServicio)
            :base("Lista de Empleados")
        {
            _empleadoServicio = empleadoServicio;
            btnImprimir.Visible = false;
            lblUsuarioLogin.Text = Identidad.ApyNomEmpleadoLogin;
        }

        //================================== GRILLA ==========================//
        public override void ActualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _empleadoServicio.Obtener(cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Legajo"].Visible = true;
            dgvGrilla.Columns["Legajo"].Width = 120;
            dgvGrilla.Columns["Legajo"].HeaderText = "Legajo";

            dgvGrilla.Columns["ApyNom"].Visible = true;
            dgvGrilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            dgvGrilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Dni"].Visible = true;
            dgvGrilla.Columns["Dni"].Width = 120;
            dgvGrilla.Columns["Dni"].HeaderText = @"DNI";

            dgvGrilla.Columns["Telefono"].Visible = true;
            dgvGrilla.Columns["Telefono"].Width = 120;
            dgvGrilla.Columns["Telefono"].HeaderText = @"Teléfono";

            dgvGrilla.Columns["Celular"].Visible = true;
            dgvGrilla.Columns["Celular"].Width = 120;
            dgvGrilla.Columns["Celular"].HeaderText = @"Celular";
        }

        public override void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvGrilla_RowEnter(sender, e);

            var empleado = (EmpleadoDto) ObjetoSeleccionado;
            if (empleado == null) return;

            imgFotoEmpleado.Image = Imagen.Convertir_Bytes_Imagen(empleado.Foto);
            txtEmail.Text = empleado.Email;
            txtFechaIngreso.Text = empleado.FechaIngreso.ToShortTimeString();
            txtFechaNacimiento.Text = empleado.FechaNacimiento.ToShortDateString();
        }

        //================================== EJECUTAR ==========================//
        public override bool EjecutarNuevaEntidad()
        {
            var nuevoEmpledo = new _00002_ABM_Empleado(TipoOperacion.Insert);
            nuevoEmpledo.ShowDialog();
            return nuevoEmpledo.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComandoDelete(long? entidadId)
        {
            var eliminarEmpleado = new _00002_ABM_Empleado(TipoOperacion.Delete, entidadId);
            eliminarEmpleado.ShowDialog();
            return eliminarEmpleado.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComanoUpDate(long? entidadId)
        {
            var modificarEmpleado = new _00002_ABM_Empleado(TipoOperacion.Update, entidadId);
            modificarEmpleado.ShowDialog();
            return modificarEmpleado.RealizoAlgunaOperacion;
        }

        

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ActualizarDatos(txtBuscar.Text);
        }
    }
}

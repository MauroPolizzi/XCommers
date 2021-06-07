using System.Reflection;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.CondicionIva;
using XCommerce.LogicaNegocio.Empleado;
using XCommerce.LogicaNegocio.Empleado.DTOs;
using XCommerce.LogicaNegocio.Empresa;
using XCommerce.LogicaNegocio.Empresa.DTOs;
using XCommerce.LogicaNegocio.PrimerIngresoSistema;
using XCommerce.LogicaNegocio.Seguridad;

namespace XCommerce.Core.PrimerAcceso
{
    public partial class FormularioPrimerAcceso : FormularioAbm
    {
        private readonly EmpleadoServicio _empleadoServicio;
        private readonly EmpresaServicio _empresaServicio;
        private readonly CondicionIvaServicio _condicionIvaServicio;
        private readonly ServicioInicio _servicioInicio;

        public FormularioPrimerAcceso()
        {
            InitializeComponent();
        }

        //public FormularioPrimerAcceso(TipoOperacion operacion, long? entidadId = null)
        //    : base(operacion, entidadId)
        //{
        //    InitializeComponent();
        //    _empleadoServicio = new EmpleadoServicio();
        //    _empresaServicio = new EmpresaServicio();
        //    _condicionIvaServicio = new CondicionIvaServicio();
        //    _servicioInicio = new ServicioInicio();

        //    Inicializador();
        //}

        //public override void Inicializador()
        //{
        //    base.Inicializador();

        //    AgregarControlesObligatorios(txtApellido, "Apellido");
        //    AgregarControlesObligatorios(txtNombre, "Nombre");
        //    AgregarControlesObligatorios(txtDni, "DNI");
        //    AgregarControlesObligatorios(rtbDomicilioPersona, "Domicilio");

        //    AgregarControlesObligatorios(txtRazonSocial, "Razon Social");
        //    AgregarControlesObligatorios(txtNombreFantasia, "Nombre Fantasia");
        //    AgregarControlesObligatorios(txtCuit, "CUIT");
        //    AgregarControlesObligatorios(rtbDomicilio, "Domicilio");

        //    // Validacion de Datos Persona
        //    txtApellido.KeyPress += Validar.NoInyeccion;
        //    txtNombre.KeyPress += Validar.NoInyeccion;

        //    txtDni.KeyPress += delegate(object sender, KeyPressEventArgs args)
        //    {
        //        Validar.NoInyeccion(sender, args);
        //        Validar.NoLetras(sender, args);
        //    };

        //    txtCelular.KeyPress += delegate(object sender, KeyPressEventArgs args)
        //    {
        //        Validar.NoInyeccion(sender, args);
        //        Validar.NoLetras(sender, args);
        //    };

        //    txtTelefonoPersona.KeyPress += delegate(object sender, KeyPressEventArgs args)
        //    {
        //        Validar.NoInyeccion(sender, args);
        //        Validar.NoLetras(sender, args);
        //    };

        //    // Validacion de Datos Empresa

        //    PoblarComboCondicionIva();

        //    txtRazonSocial.KeyPress += Validar.NoInyeccion;
        //    txtNombreFantasia.KeyPress += Validar.NoInyeccion;

        //    txtCuit.KeyPress += delegate(object sender, KeyPressEventArgs args)
        //    {
        //        Validar.NoInyeccion(sender, args);
        //        Validar.NoLetras(sender, args);
        //    };

        //    txtTelefono.KeyPress += delegate(object sender, KeyPressEventArgs args)
        //    {
        //        Validar.NoInyeccion(sender, args);
        //        Validar.NoLetras(sender, args);
        //    };

        //    if (Operacion == TipoOperacion.Insert)
        //        nudLegajo.Value = _empleadoServicio.ObtenerSiguienteLegajo();
        //}

        //private void PoblarComboCondicionIva()
        //{
        //    cmbCondicionIva.DataSource = _condicionIvaServicio.Obtener(string.Empty);
        //    cmbCondicionIva.DisplayMember = "Descripcion";
        //    cmbCondicionIva.ValueMember = "Id";
        //}

        //public override void CargarDatos(long? entidadId)
        //{
        //    if (entidadId.HasValue)
        //    {
        //        // Datos de la Persona
        //        var empleado = _empleadoServicio.ObtenerPorId(entidadId.Value);

        //        rtbDomicilioPersona.Text = empleado.Domicilio;
        //        txtApellido.Text = empleado.Apellido;
        //        txtCelular.Text = empleado.Celular;
        //        txtDni.Text = empleado.Dni;
        //        txtEMailPersona.Text = empleado.Email;
        //        txtNombre.Text = empleado.Nombre;
        //        txtTelefonoPersona.Text = empleado.Telefono;
        //        nudLegajo.Value = empleado.Legajo;
        //        dtpFechaIngreso.Value = empleado.FechaIngreso;
        //        dtpFechaNacimiento.Value = empleado.FechaNacimiento;
        //        ctrolFotoEmpleado.imgFoto.Image = Imagen.Convertir_Bytes_Imagen(empleado.Foto);

        //        // Datos de la Empresa
        //        var empresa = _empresaServicio.ObtenerPorId(entidadId.Value);

        //        rtbDomicilio.Text = empresa.Domicilio;
        //        txtRazonSocial.Text = empresa.RazonSocial;
        //        txtNombreFantasia.Text = empresa.NombreFantasia;
        //        txtCuit.Text = empresa.Cuit;
        //        txtEMail.Text = empresa.Email;
        //        txtTelefono.Text = empresa.Telefono;
        //        ctrolFotoEmpresa.imgFoto.Image = Imagen.Convertir_Bytes_Imagen(empresa.Logo);
        //    }
        //    else
        //    {
        //        Mensaje.Mostrar("Error se encontro el Empleado o la Empresa", Mensaje.Tipo.Stop);
        //    }
        //}

        //public override void EjecutarComandoInsert()
        //{
        //    try
        //    {
        //        // Datos del Empleado
        //        var nuevoEmpleado = new EmpleadoDto
        //        {
        //            Apellido = txtApellido.Text,
        //            Domicilio = rtbDomicilioPersona.Text,
        //            Celular = txtCelular.Text,
        //            Dni = txtDni.Text,
        //            Email = txtEMailPersona.Text,
        //            Nombre = txtNombre.Text,
        //            Telefono = txtTelefonoPersona.Text,
        //            Legajo = (int) nudLegajo.Value,
        //            FechaIngreso = dtpFechaIngreso.Value,
        //            FechaNacimiento = dtpFechaNacimiento.Value,
        //            Foto = Imagen.Convertir_Imagen_Bytes(ctrolFotoEmpleado.imgFoto.Image)
        //        };

        //        var nuevoEmpresa = new EmpresaDto
        //        {
        //            RazonSocial = txtRazonSocial.Text,
        //            Domicilio = rtbDomicilio.Text,
        //            Cuit = txtCuit.Text,
        //            Email = txtEMail.Text,
        //            NombreFantasia = txtNombreFantasia.Text,
        //            Telefono = txtTelefono.Text,
        //            Sucursal = (int) numericUpDown1.Value,
        //            Logo = Imagen.Convertir_Imagen_Bytes(ctrolFotoEmpresa.imgFoto.Image),
        //            CondicionIvaId = (long) cmbCondicionIva.SelectedValue
        //        };

        //        _servicioInicio.Insertar(nuevoEmpleado, nuevoEmpresa, Assembly.GetExecutingAssembly());
        //        Close();
        //    }
        //    catch
        //    {
        //        Mensaje.Mostrar("Ocurrió un Error al Grabar los Datos.", Mensaje.Tipo.Stop);
        //    }
        //}

        //public override void LimpiarControles()
        //{
        //    base.LimpiarControles(this);
        //    nudLegajo.Value = _empleadoServicio.ObtenerSiguienteLegajo();
        //}

        //private void btnNuevaCondicionIva_Click(object sender, System.EventArgs e)
        //{
        //    var fNuevaCondicionIva = new _00005_ABM_CondicionDeIva(TipoOperacion.Insert);
        //    fNuevaCondicionIva.ShowDialog();
        //    if (fNuevaCondicionIva.RealizoAlgunaOperacion)
        //        PoblarComboCondicionIva();

        //}

        //public override void FormularioAbm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    RealizoAlgunaOperacion = true;
        //}
    }
}

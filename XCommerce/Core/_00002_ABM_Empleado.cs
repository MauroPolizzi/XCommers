using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Empleado;
using XCommerce.LogicaNegocio.Empleado.DTOs;

namespace XCommerce.Core
{
    public partial class _00002_ABM_Empleado : FormularioAbm
    {
        private readonly EmpleadoServicio _empleadoServicio;

        public _00002_ABM_Empleado()
        {
            InitializeComponent();
        }

        public _00002_ABM_Empleado(TipoOperacion operacion, long? entidadId = null)
            :base(operacion, entidadId)
        {
            InitializeComponent();
            _empleadoServicio = new EmpleadoServicio();
            Inicializador();
        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtApellido, "Apellido");
            AgregarControlesObligatorios(txtNombre,"Nombre");
            AgregarControlesObligatorios(txtDni,"Dni");
            AgregarControlesObligatorios(rtbDomicilio,"Domicilio");
            AgregarControlesObligatorios(txtCelular,"Celular");

            //   VALIDACION DE DATOS
            txtApellido.KeyPress += Validar.NoInyeccion;
            txtNombre.KeyPress += Validar.NoInyeccion;
            txtDni.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoInyeccion(sender, args);
                Validar.NoLetras(sender, args);
            };
            txtCelular.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoInyeccion(sender, args);
                Validar.NoLetras(sender, args);
            };
            txtTelefono.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoInyeccion(sender, args);
                Validar.NoLetras(sender, args);
            };

            if (_operacion == TipoOperacion.Insert)
            {
                nudLegajo.Value = _empleadoServicio.ObtenerSiguieteLegajo();
                nudLegajo.Enabled = false;
            }
        }

        //======================= DATOS ===================//
        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var empleado = _empleadoServicio.ObtenerPorId(entidadId.Value);

                nudLegajo.Value = empleado.Legajo;
                dtpFechaIngreso.Value = empleado.FechaIngreso;
                txtApellido.Text = empleado.Apellido;
                txtNombre.Text = empleado.Nombre;
                txtDni.Text = empleado.Dni;
                dtpFechaNacimiento.Value = empleado.FechaNacimiento;
                rtbDomicilio.Text = empleado.Domicilio;
                txtTelefono.Text = empleado.Telefono;
                txtCelular.Text = empleado.Celular;
                txtEMail.Text = empleado.Email;
                ctrolFoto1.imgFoto.Image = Imagen.Convertir_Bytes_Imagen(empleado.Foto);

                if (_operacion == TipoOperacion.Delete)
                {
                    DesactivarControles(this, false);
                    ctrolFoto1.btnObtenerImagen.Enabled = false;
                }
                else
                {
                    nudLegajo.Enabled = false;
                    txtApellido.Focus();
                }
            }
            else
            {
                Mensaje.Mostrar("Error. no se encontro el empleado", Mensaje.Tipo.Stop);
            }
        }

        //======================= NUEVO EMPLEADO ===================//
        public override void EjecutarComandoInsert()
        {
            if (VerificarDatosNulos())
            {
                try
                {
                    var nuevoEmpleado = new EmpleadoDto
                    {
                        Apellido = txtApellido.Text,
                        Nombre = txtNombre.Text,
                        Dni = txtDni.Text,
                        Domicilio = rtbDomicilio.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        Legajo = (int) nudLegajo.Value,
                        FechaIngreso = dtpFechaIngreso.Value,
                        FechaNacimiento = dtpFechaNacimiento.Value,
                        Email = txtEMail.Text,
                        Foto = Imagen.Convertir_Imagen_Bytes(ctrolFoto1.imgFoto.Image)
                    };
                    _empleadoServicio.Insert(nuevoEmpleado);
                    LimpiarControles(this);
                    txtApellido.Focus();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al guardar los datos", Mensaje.Tipo.Error);

                }
            }
            else
            {
                Mensaje.Mostrar("Faltan ingresar datos necesarios", Mensaje.Tipo.Informacion);
            }
        }

        //======================= MODIFICAR EMPLEADO ===================//
        public override void EjecutarComandoUpDate()
        {
            if (VerificarDatosNulos())
            {
                try
                {
                    var empleadoModificar = new EmpleadoDto
                    {
                        Id = EntidadId.Value,
                        Apellido = txtApellido.Text,
                        Nombre = txtNombre.Text,
                        Dni = txtDni.Text,
                        Domicilio = rtbDomicilio.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        Legajo = (int) nudLegajo.Value,
                        FechaIngreso = dtpFechaIngreso.Value,
                        FechaNacimiento = dtpFechaNacimiento.Value,
                        Email = txtEMail.Text,
                        Foto = Imagen.Convertir_Imagen_Bytes(ctrolFoto1.imgFoto.Image)
                    };
                    _empleadoServicio.Modificar(empleadoModificar);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al moificar los datos", Mensaje.Tipo.Stop);
                }
            }
            else
            {
                Mensaje.Mostrar("Faltan datos necesarios", Mensaje.Tipo.Informacion);
            }
        }

        //======================= ELIMINAR EMPLEADO ===================//
        public override void EjecutarComandoDelete()
        {
            try
            {
                _empleadoServicio.Delete(EntidadId.Value);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("No se pudo eliminar", Mensaje.Tipo.Stop);
            }
        }

        //======================= LIMPIAR CONTROLES ===================//
        public override void LimpiarControles()
        {
            base.LimpiarControles(this);
            nudLegajo.Value = _empleadoServicio.ObtenerSiguieteLegajo();

            ctrolFoto1.imgFoto.Image = Properties.Resources.ImagenFondo;
        }

        //======================= DATOS NULOS ===================//
        private bool VerificarDatosNulos()
        {
            if (string.IsNullOrEmpty(txtApellido.Text)
                || string.IsNullOrEmpty(txtNombre.Text)
                || string.IsNullOrEmpty(txtCelular.Text)
                || string.IsNullOrEmpty(rtbDomicilio.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

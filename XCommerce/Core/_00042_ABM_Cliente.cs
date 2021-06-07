using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Cliente;
using XCommerce.LogicaNegocio.Cliente.DTOs;

namespace XCommerce.Core
{
    public partial class _00042_ABM_Cliente: FormularioAbm
    {
        private readonly ClienteServicio _clienteServicio;
        public _00042_ABM_Cliente()
        {
            InitializeComponent();
        }

        public _00042_ABM_Cliente(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            _clienteServicio = new ClienteServicio();
            Inicializador();
        }
        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtApellido,"Apellido");
            AgregarControlesObligatorios(txtNombre, "Nombre");
            AgregarControlesObligatorios(txtDni,"Dni");
            AgregarControlesObligatorios(rtbDomicilio,"Domiilio");
            AgregarControlesObligatorios(txtTelefono,"Telefono");
            AgregarControlesObligatorios(txtEmail,"Email");
            AgregarControlesObligatorios(dtpFechaNacimiento,"FechaCumpleaños");
            AgregarControlesObligatorios(nudMontoMaximo,"MontoMaximo");

            //*********************** VALIDACION 
            txtApellido.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoNumeros(sender,args);
                Validar.NoSimbolos(sender,args);
                Validar.NoInyeccion(sender,args);
            };
            txtNombre.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
                Validar.NoNumeros(sender,args);
            };
            txtDni.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoLetras(sender, args);
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            rtbDomicilio.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            txtTelefono.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
                Validar.NoLetras(sender, args);
            };
            //***********************

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            if (_operacion == TipoOperacion.Insert)
            {
                txtApellido.Focus();
            }

        }

        //=========================== DATOS  ========================//
        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var cliente = _clienteServicio.ObtenerProId(entidadId.Value);

                txtApellido.Text = cliente.Apellido;
                txtNombre.Text = cliente.Nombre;
                txtDni.Text = cliente.Dni;
                rtbDomicilio.Text = cliente.Domicilio;
                txtTelefono.Text = cliente.Telefono;
                txtCelular.Text = cliente.Celular;
                txtEmail.Text = cliente.Email;
                dtpFechaNacimiento.Value = cliente.FechaNacimiento;
                nudMontoMaximo.Value = cliente.MontoMaximoCompra;

                if (_operacion == TipoOperacion.Delete)
                {
                    DesactivarControles(this,false);
                }
                else
                {
                    txtApellido.Focus();
                }
            }
            else
            {
                Mensaje.Mostrar("No se pudo cargar los datos del cliente", Mensaje.Tipo.Informacion);
            }
        }

        //=========================== INSERTAR =======================//
        public override void EjecutarComandoInsert()
        {
            if (VerificarDatosNulos())
            {
                try
                {
                    var cliente = new ClienteDto
                    {
                        Apellido = txtApellido.Text,
                        Nombre = txtNombre.Text,
                        Dni = txtDni.Text,
                        Domicilio = rtbDomicilio.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        Email = txtEmail.Text,
                        FechaNacimiento = dtpFechaNacimiento.Value,
                        MontoMaximoCompra = nudMontoMaximo.Value,
                    };
                    _clienteServicio.Insertar(cliente);
                    LimpiarControles(this);
                    txtApellido.Focus();
                }
                catch
                {
                    Mensaje.Mostrar("No se pudieron guardar los datos del cliente", Mensaje.Tipo.Informacion);
                }
            }
            else
            {
                Mensaje.Mostrar("Faltan datos necesarios por ingresar", Mensaje.Tipo.Informacion);
            }
        }

        //=========================== MODIFICAR =======================//
        public override void EjecutarComandoUpDate()
        {
            if (VerificarDatosNulos())
            {
                try
                {
                    var clienteModificar = new ClienteDto()
                    {
                        Id = EntidadId.Value,
                        Apellido = txtApellido.Text,
                        Nombre = txtNombre.Text,
                        Dni = txtDni.Text,
                        Domicilio = rtbDomicilio.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        Email = txtEmail.Text,
                        FechaNacimiento = dtpFechaNacimiento.Value,
                        MontoMaximoCompra = nudMontoMaximo.Value,
                    };
                    _clienteServicio.Modificar(clienteModificar);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al moificar los datos", Mensaje.Tipo.Stop);
                }
            }
            else
            {
                Mensaje.Mostrar("Faltan datos necesarios por ingresar", Mensaje.Tipo.Informacion);
            }
        }

        //=========================== ELIMINAR =======================//
        public override void EjecutarComandoDelete()
        {
            try
            {
                _clienteServicio.Eliminar(EntidadId.Value);
            }
            catch 
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar los datos", Mensaje.Tipo.Stop);
            }
        }

        private bool VerificarDatosNulos()
        {
            if (string.IsNullOrEmpty(txtApellido.Text)
                || string.IsNullOrEmpty(txtNombre.Text)
                || string.IsNullOrEmpty(txtTelefono.Text)
                || string.IsNullOrEmpty(txtDni.Text)
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

using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.CondicionIva.DTOs;
using XCommerce.LogicaNegocio.Perfil;
using XCommerce.LogicaNegocio.Perfil.DTOs;

namespace XCommerce.Core
{
    public partial class _00020_ABM_Perfil : FormularioAbm
    {
        private readonly PerfilServicio _perfilServicio;
        public _00020_ABM_Perfil()
        {
            InitializeComponent();
        }

        public _00020_ABM_Perfil(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            _perfilServicio = new PerfilServicio();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            Inicializador();
        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");

            //******************** VALIDACION
            txtDescripcion.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoNumeros(sender,args);
                Validar.NoSimbolos(sender,args);
                Validar.NoSimbolos(sender,args);
            };
            //********************

            if (_operacion == TipoOperacion.Insert)
            {
                txtDescripcion.Focus();
            }
        }

        //========================== CARGAR DATOS ======================//
        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var perfil = _perfilServicio.ObtenerPorId(entidadId.Value);

                txtDescripcion.Text = perfil.Descripcion;

                if (_operacion == TipoOperacion.Delete)
                {
                    txtDescripcion.Enabled = false;
                }
                else
                {
                    txtDescripcion.Focus();
                }
            }
            else
            {
                Mensaje.Mostrar("Ocurrio un error a carar los datos del perfil", Mensaje.Tipo.Informacion);
            }
        }

        //======================= COMANDOS ====================//
        public override void EjecutarComandoInsert()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Mensaje.Mostrar("Falta ingresar una Descripcion", Mensaje.Tipo.Informacion);
            }
            else
            {
                try
                {
                    var perfilNuevo = new PerfilDto
                    {
                        EmpresaId = Identidad.EmpresaId,
                        Descripcion = txtDescripcion.Text,
                    };

                    _perfilServicio.Insertar(perfilNuevo);
                    txtDescripcion.Clear();
                    txtDescripcion.Focus();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio u error al guardar el perfil", Mensaje.Tipo.Informacion);
                }
            }
        }

        public override void EjecutarComandoUpDate()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Mensaje.Mostrar("Falta ingresar una Descripcion", Mensaje.Tipo.Informacion);
            }
            else
            {
                try
                {
                    var modificarPerfil = new PerfilDto
                    {
                        Id = EntidadId.Value,
                        Descripcion = txtDescripcion.Text,
                        EmpresaId = Identidad.EmpresaId,
                    };

                    _perfilServicio.Modificar(modificarPerfil);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al modificar le prefil", Mensaje.Tipo.Informacion);
                }
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _perfilServicio.Eliminar(EntidadId.Value);
                Close();
            }
            catch 
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar el prefil", Mensaje.Tipo.Informacion);
            }
        }
    }
}

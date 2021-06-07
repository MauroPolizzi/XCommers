using System;
using System.Data.Entity.Infrastructure;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.ListaPrecio;
using XCommerce.LogicaNegocio.ListaPrecio.DTOs;

namespace XCommerce.Core
{
    public partial class _00040_ABM_ListaPrecio : FormularioAbm
    {
        private readonly ListaPrecioServicio _listaPrecio;
        public _00040_ABM_ListaPrecio()
        {
            InitializeComponent();
        }

        public _00040_ABM_ListaPrecio(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            _listaPrecio = new ListaPrecioServicio();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            Inicializador();

            if (_operacion == TipoOperacion.Insert)
            {
                txtDescripcion.Focus();
                nudCodigo.Value = _listaPrecio.ObtenerSiguienteCodigo();
                nudCodigo.Enabled = false;
            }
        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion,"Descripcion");

            //*********************** VALIDACION
            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoNumeros(sender, args);
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            //***********************
        }

        //======================= CARGAR DATOS ====================//
        public override void CargarDatos(long? entidadId)
        {
            var lista = _listaPrecio.ObtenerPorId(entidadId.Value);

            nudCodigo.Value = lista.Codigo;
            txtDescripcion.Text = lista.Descripcion;
            //nudRentabilidad.Value = lista.Rentabilidad;

            if (_operacion == TipoOperacion.Delete)
            {
                DesactivarControles(this,false);
            }
            else
            {
                nudCodigo.Enabled = false;
                txtDescripcion.Focus();
            }
        }

        //======================= INSERTAR ====================//
        public override void EjecutarComandoInsert()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Mensaje.Mostrar("Falta ingresar una descripcion", Mensaje.Tipo.Informacion);
            }
            else
            {
                try
                {
                    var listaNueva = new ListaPrecioDto
                    {
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        EmpresaId = Identidad.EmpresaId,
                    };

                    _listaPrecio.Insertar(listaNueva);
                    LimpiarControles(this);
                    nudCodigo.Value = _listaPrecio.ObtenerSiguienteCodigo();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al guardar la lista", Mensaje.Tipo.Informacion);
                }
            }
        }

        //======================= MODIFICAR ====================//
        public override void EjecutarComandoUpDate()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Mensaje.Mostrar("Falta ingresar una descripcion", Mensaje.Tipo.Informacion);
            }
            else
            {
                try
                {
                    var modificarLista = new ListaPrecioDto
                    {
                        Id = EntidadId.Value,
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        EmpresaId = Identidad.EmpresaId,
                    };

                    _listaPrecio.Modificar(modificarLista);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al modificar los datos", Mensaje.Tipo.Informacion);
                }
            }
        }

        //======================= ELIMINAR ====================//
        public override void EjecutarComandoDelete()
        {
            try
            {
                _listaPrecio.Eliminar(EntidadId.Value);
                Close();
            }
            catch 
            {
                Mensaje.Mostrar("Ocurrio unr error al eliminar la lista", Mensaje.Tipo.Informacion);
            }
        }
    }
}

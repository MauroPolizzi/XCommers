using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Marca;
using XCommerce.LogicaNegocio.Marca.DTOs;

namespace XCommerce.Core
{
    public partial class _00029_ABM_Marca : FormularioAbm
    {
        private readonly MarcaServicio _marcaServicio;

        //========================== CONSTRUCTORES =========================//
        public _00029_ABM_Marca()
        {
            InitializeComponent();
        }

        public _00029_ABM_Marca(TipoOperacion operacion, long? entidadId = null)
            :base(operacion,entidadId)
        {
            InitializeComponent();
            _marcaServicio = new MarcaServicio();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
            Inicializador();
        }

        //==========================  =========================//
        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion,"Descripcion");

            //*********** VERIFICACIONES **********************
            txtDescripcion.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            //***************

            if (_operacion == TipoOperacion.Insert)
            {
                nudCodigo.Value = _marcaServicio.ObtenerSiguienteCodigo(Identidad.EmpresaId);
                nudCodigo.Enabled = false;
            }
        }

        //======================== DATOS ========================//
        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var marca = _marcaServicio.ObtenerPorId(entidadId.Value);

                nudCodigo.Value = marca.Codigo;
                txtDescripcion.Text = marca.Descripcion;

                if (_operacion == TipoOperacion.Delete)
                {
                    DesactivarControles(this, false);
                }
                else
                {
                    nudCodigo.Enabled = false;
                    txtDescripcion.Focus();
                }
            }
            else
            {
                Mensaje.Mostrar("No se pudieron cargar los datos", Mensaje.Tipo.Stop);
            }
        }

        //======================= LIMPIAR CONTROLES ===================//
        public override void LimpiarControles()
        {
            base.LimpiarControles(this);
            nudCodigo.Value = _marcaServicio.ObtenerSiguienteCodigo(Identidad.EmpresaId);
        }

        //========================== COMANDOS =========================//
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
                    if (!_marcaServicio.VerificarSiExiste(Identidad.EmpresaId, txtDescripcion.Text,
                        (int) nudCodigo.Value))
                    {
                        var marca = new MarcaDto
                        {
                            Codigo = (int) nudCodigo.Value,
                            Descripcion = txtDescripcion.Text,
                            EmpresaId = Identidad.EmpresaId,
                            EstaEliminada = false
                        };

                        _marcaServicio.Insertar(marca);
                        LimpiarControles(this);
                        txtDescripcion.Focus();
                    }
                    else
                    {
                        Mensaje.Mostrar("Esta Marca ya existe", Mensaje.Tipo.Advertencia);
                    }
                }
                catch
                {
                    Mensaje.Mostrar("No se pudo agregar una marca nueva", Mensaje.Tipo.Informacion);
                }
            }
        }

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
                    var marcaModificar = new MarcaDto
                    {
                        Id = EntidadId.Value,
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        EmpresaId = Identidad.EmpresaId,

                    };

                    _marcaServicio.Modificar(marcaModificar);
                }
                catch
                {
                    Mensaje.Mostrar("No se pudo modificar la marca", Mensaje.Tipo.Informacion);
                }
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _marcaServicio.Eliminar(EntidadId.Value);
            }
            catch
            {
                Mensaje.Mostrar("No se pudo eliminar la marca", Mensaje.Tipo.Stop);
            }
        }
    }
}

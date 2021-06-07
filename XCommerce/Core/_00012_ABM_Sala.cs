using System;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.CondicionIva.DTOs;
using XCommerce.LogicaNegocio.Sala;
using XCommerce.LogicaNegocio.Sala.DTOs;

namespace XCommerce.Core
{
    public partial class _00012_ABM_Sala : FormularioAbm
    {
        private readonly SalaServicio _salaServicio;

        //=============================== CONSTRUCTOR ==========================//
        public _00012_ABM_Sala()
        {
            InitializeComponent();
        }

        public _00012_ABM_Sala(TipoOperacion tipoOperacion, long? entidadId = null)
            :base (tipoOperacion,entidadId)
        {
            InitializeComponent();

            _salaServicio = new SalaServicio();
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
            Inicializador();
        }

        //=============================== DATOS ==========================//
        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion,"Desripcion");

            //********************** VALIDACION
            txtDescripcion.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
            };
            //**********************

            if (_operacion == TipoOperacion.Insert)
            {
                nudCodigo.Value = _salaServicio.ObtenerSiguienteCodigo();
                nudCodigo.Enabled = false;
            }
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var sala = _salaServicio.ObtenePorId(entidadId.Value);

                nudCodigo.Value = sala.Codigo;
                txtDescripcion.Text = sala.Descripcion;

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
                Mensaje.Mostrar("No se pudieron cargar los datos de la sala", Mensaje.Tipo.Informacion);
            }
        }

        //=============================== COMANDOS ==========================//
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
                    var sala = new SalaDto()
                    {
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        EmpresaId = Identidad.EmpresaId,
                        EstaEliminada = false,
                    };

                    _salaServicio.Insertar(sala);
                    nudCodigo.Value = _salaServicio.ObtenerSiguienteCodigo();
                    txtDescripcion.Clear();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al guardar la sala", Mensaje.Tipo.Informacion);
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
                    var salaModificar = new SalaDto
                    {
                        Id = EntidadId.Value,
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        EmpresaId = Identidad.EmpresaId,
                        EstaEliminada = false,
                    };


                    _salaServicio.Modificar(salaModificar);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al modificar la sala", Mensaje.Tipo.Informacion);
                }
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _salaServicio.Eliminar(EntidadId);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar la mesa", Mensaje.Tipo.Informacion);
            }
        }
    }
}

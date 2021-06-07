using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Deposito;
using XCommerce.LogicaNegocio.Deposito.DTOs;

namespace XCommerce.Core
{
    public partial class _00038_ABM_Deposito : FormularioAbm
    {
        private readonly DepositoServicio _depositoServicio;
        public _00038_ABM_Deposito()
        {
            InitializeComponent();
        }

        public _00038_ABM_Deposito(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();
            _depositoServicio = new DepositoServicio();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            Inicializador();
        }

        //============================= INICIALIZADOR =================//
        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");

            //************************** VALIDACION
            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            //***************************

            if (_operacion == TipoOperacion.Insert)
            {
                nudCodigo.Value = _depositoServicio.ObtenerSiguienteCodigo();
                nudCodigo.Enabled = false;
            }
        }

        //============================ DATOS ==========================//
        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var deposito = _depositoServicio.ObtenerPorId(entidadId.Value);

                nudCodigo.Value = deposito.Codigo;
                txtDescripcion.Text = deposito.Descripcion;

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
        }

        //============================== INSERTAR ======================//
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
                    if (!_depositoServicio.VerificarSiExiste((int) nudCodigo.Value, txtDescripcion.Text))
                    {
                        var nuevoDeposito = new DepositoDto
                        {

                            Codigo = (int) nudCodigo.Value,
                            Descripcion = txtDescripcion.Text,
                            EstaEliminado = false,
                            EmpresaId = Identidad.EmpresaId
                        };

                        _depositoServicio.Insertar(nuevoDeposito);
                        nudCodigo.Value = _depositoServicio.ObtenerSiguienteCodigo();
                        txtDescripcion.Clear();
                        txtDescripcion.Focus();
                    }
                    else
                    {
                        Mensaje.Mostrar("Este Deposito ya existe", Mensaje.Tipo.Informacion);
                    }
                }
                catch
                {
                    Mensaje.Mostrar("No se pudieron guardar los datos", Mensaje.Tipo.Informacion);
                }
            }
        }

        //============================== MODIFICAR ======================//
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
                    var modificarDeposito = new DepositoDto
                    {
                        Id = EntidadId.Value,
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        EmpresaId = Identidad.EmpresaId
                    };

                    _depositoServicio.Modificar(modificarDeposito);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al cargar os datos", Mensaje.Tipo.Informacion);
                }
            }
        }

        //============================== ELIMINAR ======================//
        public override void EjecutarComandoDelete()
        {
            try
            {
                _depositoServicio.Eliminar(EntidadId.Value);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar el deposito", Mensaje.Tipo.Informacion);
            }
        }
    }
}

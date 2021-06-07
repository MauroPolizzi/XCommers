using System;
using System.Data.Entity.Validation;
using System.Data.Odbc;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.TipoComprobante;
using XCommerce.LogicaNegocio.TipoComprobante.DTOs;

namespace XCommerce.Core
{
    public partial class _00027_ABM_TipoComprobante : FormularioAbm
    {
        private readonly TipoComprobanteServicio _tipoComprobanteServicio;

        public _00027_ABM_TipoComprobante()
        {
            InitializeComponent();
        }

        public _00027_ABM_TipoComprobante(TipoOperacion tipoOperacion, long? _entidadId = null)
            :base(tipoOperacion,_entidadId)
        {
            InitializeComponent();
            _tipoComprobanteServicio = new TipoComprobanteServicio();
            Inicializador();

        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion,"Descripcion");
            AgregarControlesObligatorios(txtLetra,"Letra");

            //****************** VALIDACION
            txtLetra.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoNumeros(sender, args);
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            //******************

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            if (_operacion == TipoOperacion.Insert)
            {
                nudCodigo.Value = _tipoComprobanteServicio.ObtenerSiguienteCodigo();
                nudCodigo.Enabled = false;
            }
        }

        //======================== DATOS =======================//
        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var comprobante = _tipoComprobanteServicio.ObtenerPorId(entidadId.Value);

                nudCodigo.Value = comprobante.Codigo;
                txtDescripcion.Text = comprobante.Descripcion;
                txtLetra.Text = comprobante.Letra;

                if (_operacion == TipoOperacion.Delete)
                {
                    DesactivarControles(this, false);
                }
                else
                {
                    nudCodigo.Enabled = false;
                    txtLetra.Focus();
                }
            }
            else
            {
                Mensaje.Mostrar("No Pudo econtrar el tipo de comprobante", Mensaje.Tipo.Informacion);
            }
        }

        //======================== COMANDOS ===================//
        public override void EjecutarComandoInsert()
        {
            if (VerificarDatosNulos())
            {
                try
                {
                    if (!_tipoComprobanteServicio.VerificarSiExiste((int) nudCodigo.Value, txtDescripcion.Text,
                        txtLetra.Text))
                    {
                        var comprobanteNuevo = new TipoComprobanteDto
                        {
                            Codigo = (int) nudCodigo.Value,
                            Letra = txtLetra.Text,
                            Descripcion = txtDescripcion.Text,
                            EmpresaId = Identidad.EmpresaId
                        };

                        _tipoComprobanteServicio.Insertar(comprobanteNuevo);
                        LimpiarControles(this);
                        nudCodigo.Value = _tipoComprobanteServicio.ObtenerSiguienteCodigo();
                        txtLetra.Focus();
                    }
                    else
                    {
                        Mensaje.Mostrar("Ya existe este tipo de comprobante", Mensaje.Tipo.Informacion);
                    }
                }
                catch
                {
                    Mensaje.Mostrar("No se pudieron cargar los datos", Mensaje.Tipo.Informacion);
                }
            }
            else
            {
                Mensaje.Mostrar("Faltan datos por ingresar", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoUpDate()
        {
            if (VerificarDatosNulos())
            {
                try
                {
                    //if (!_tipoComprobanteServicio.VerificarSiExiste((int)nudCodigo.Value, txtLetra.Text, txtDescripcion.Text))
                    //{
                    var modificar = new TipoComprobanteDto
                    {
                        Codigo = (int) nudCodigo.Value,
                        Letra = txtLetra.Text,
                        Descripcion = txtDescripcion.Text,
                        EmpresaId = Identidad.EmpresaId
                    };

                    _tipoComprobanteServicio.Modificar(modificar);
                    Close();
                    //}
                    //else
                    //{
                    //    Mensaje.Mostrar("El tipo de comprobante ya existe", Mensaje.Tipo.Informacion);
                    //}
                }
                catch
                {
                    Mensaje.Mostrar("No se pudieron cargar lo datos", Mensaje.Tipo.Informacion);
                }
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _tipoComprobanteServicio.Eliminar(EntidadId.Value);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("No se pudo eliminar el tipo Comprabante", Mensaje.Tipo.Informacion);
            }
        }

        //================== VERIFICAR DATOS =================//
        private bool VerificarDatosNulos()
        {
            if (string.IsNullOrEmpty(txtLetra.Text)
                || string.IsNullOrEmpty(txtDescripcion.Text))
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

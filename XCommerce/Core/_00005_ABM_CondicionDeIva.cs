using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.CondicionIva;
using XCommerce.LogicaNegocio.CondicionIva.DTOs;

namespace XCommerce.Core
{
    public partial class _00005_ABM_CondicionDeIva : FormularioAbm
    {
        private readonly CondicionIvaServicio _condicionIvaServicio;
        public _00005_ABM_CondicionDeIva()
        {
            InitializeComponent();
        }

        public _00005_ABM_CondicionDeIva(TipoOperacion operacion, long? entidadId = null)
            :base(operacion,entidadId)
        {
            InitializeComponent();
            _condicionIvaServicio = new CondicionIvaServicio();
            Inicializador();
        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(nudCodigo, "Codigo");
            AgregarControlesObligatorios(txtDescripcion , "Descripcion");

            // VALIDACION

            txtDescripcion.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoNumeros(sender, args);
                Validar.NoInyeccion(sender, args);
                Validar.NoSimbolos(sender,args);
            };

            if (_operacion == TipoOperacion.Insert)
            {
                nudCodigo.Value = _condicionIvaServicio.ObtenerSiguienteCodigo();
                nudCodigo.Enabled = false;
            }
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var condicionIva = _condicionIvaServicio.ObternerPorId(entidadId.Value);

                nudCodigo.Value = condicionIva.Codigo;
                txtDescripcion.Text = condicionIva.Descripcion;

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

        //====================== NUEVA CONDICION ====================//
        public override void EjecutarComandoInsert()
        {
            if (VerificarDatosNulos())
            {
                try
                {
                    var condicionIVa = new CondicionIvaDto
                    {
                        Descripcion = txtDescripcion.Text,
                        Codigo = (int) nudCodigo.Value,
                    };

                    _condicionIvaServicio.Insertar(condicionIVa);
                    LimpiarControles(this);
                    txtDescripcion.Focus();
                }
                catch
                {
                    Mensaje.Mostrar("No se pudo agregar la Condicion de Iva", Mensaje.Tipo.Stop);
                }
            }
            else
            {
                Mensaje.Mostrar("Faltan datos necesarios", Mensaje.Tipo.Informacion);
            }
        }

        private bool VerificarDatosNulos()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //====================== MODIFICAR CONDICION ====================//
        public override void EjecutarComandoUpDate()
        {
            if (VerificarDatosNulos())
            {
                try
                {
                    var modificarCondicionIva = new CondicionIvaDto
                    {
                        Id = EntidadId.Value,
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text
                    };
                    _condicionIvaServicio.Modificar(modificarCondicionIva);
                    LimpiarControles(this);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("No se encontro la Condicion de Iva par modificar", Mensaje.Tipo.Stop);
                }
            }
            else
            {
                Mensaje.Mostrar("Falta ingresar la descripcion", Mensaje.Tipo.Informacion);
            }
        }

        //====================== ELIMINAR CONDICION ====================//
        public override void EjecutarComandoDelete()
        {
            try
            {
                _condicionIvaServicio.Eliminar(EntidadId.Value);
            }
            catch
            {
                Mensaje.Mostrar("No se enontro la condicion de iva para eliminar", Mensaje.Tipo.Stop);
            }
        }

        //====================== LIMPIAR CONTROLES ====================//
        public override void LimpiarControles()
        {
            base.LimpiarControles(this);
            nudCodigo.Value = _condicionIvaServicio.ObtenerSiguienteCodigo();
        }
    }
}

using System;
using Microsoft.Win32.SafeHandles;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Rubro;
using XCommerce.LogicaNegocio.Rubro.DTOs;
using System.Windows.Forms;

namespace XCommerce.Core
{
    public partial class _00031_ABM_Rubro : FormularioAbm
    {
        private readonly RubroServicio _rubroServicio;
        public _00031_ABM_Rubro()
        {
            InitializeComponent();
        }

        public _00031_ABM_Rubro(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();
            _rubroServicio = new RubroServicio();
            Inicializador();
        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");

            //*********** VERIFICACIONES **********************
            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            //***************

            if (_operacion == TipoOperacion.Insert)
            {
                nudCodigo.Value = _rubroServicio.ObnterSiguineteCodigo(Identidad.EmpresaId);
                nudCodigo.Enabled = false;
            }
        }

        //========================== DATOS ==========================//
        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var rubro = _rubroServicio.ObtenerPorId(entidadId.Value);

                nudCodigo.Value = rubro.Codigo;
                txtDescripcion.Text = rubro.Descripcion;

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
            else
            {
                Mensaje.Mostrar("Ocurrio un error al cargar datos de rubro", Mensaje.Tipo.Advertencia);
            }
        }

        //========================= LIMPIAR CONTROLES ==================//
        public override void LimpiarControles()
        {
            base.LimpiarControles(this);
            nudCodigo.Value = _rubroServicio.ObnterSiguineteCodigo(Identidad.EmpresaId);
        }

        //========================= COMANDOS ==========================//
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
                    if (!_rubroServicio.VerificarSiExiste(Identidad.EmpresaId, txtDescripcion.Text, nudCodigo.Value))
                    {
                        var nuevoRubro = new RubroDto
                        {
                            Codigo = (int) nudCodigo.Value,
                            Descripcion = txtDescripcion.Text,
                            EmpresaId = Identidad.EmpresaId,
                            EstaEliminado = false
                        };
                        _rubroServicio.Insertar(nuevoRubro);
                        LimpiarControles(this);
                        txtDescripcion.Focus();
                    }
                    else
                    {
                        Mensaje.Mostrar("Esta Rubro ya exite", Mensaje.Tipo.Advertencia);
                    }
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al guardar intentar guardar el Rubro", Mensaje.Tipo.Error);
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
                    var modificarRubro = new RubroDto
                    {
                        Id = EntidadId.Value,
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        EmpresaId = Identidad.EmpresaId,
                    };

                    _rubroServicio.Modificar(modificarRubro);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("No se pudieron cargar los datos para modificar", Mensaje.Tipo.Stop);
                }
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _rubroServicio.Eliminar(EntidadId.Value);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("No se pudo eliminar el Rubro", Mensaje.Tipo.Advertencia);
            }
        }
    }
}

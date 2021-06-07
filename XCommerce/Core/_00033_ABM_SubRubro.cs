using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Rubro;
using XCommerce.LogicaNegocio.Seguridad;
using XCommerce.LogicaNegocio.SubRubro.DTOs;
using XCommerce.LogicaNegocio.SubSubRubro;

namespace XCommerce.Core
{
    public partial class _00033_ABM_SubRubro : FormularioAbm
    {
        private readonly SubRubroServicio _subRubroServicio;
        private readonly RubroServicio _rubroServicio;
        public _00033_ABM_SubRubro()
        {
            InitializeComponent();
        }

        public _00033_ABM_SubRubro(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();
            _subRubroServicio = new SubRubroServicio();
            _rubroServicio = new RubroServicio();
            Inicializador();
        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
            AgregarControlesObligatorios(cmbRubro, "Rubro");

            //*********** VERIFICACIONES **********************
            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            //***************

            CargarComboRubro();

            if (_operacion == TipoOperacion.Insert)
            {
                nudCodigo.Value = _subRubroServicio.ObtenerSiguienteCodigo();
                nudCodigo.Enabled = false;
            }
        }

        //======================= COMBO RUBRO ========================//
        private void CargarComboRubro()
        {
            cmbRubro.DataSource = _rubroServicio.ObtenerTodo(Identidad.EmpresaId, string.Empty);
            cmbRubro.DisplayMember = "Descripcion";
            cmbRubro.ValueMember = "Id";
        }

        //========================== DATOS =======================//
        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var subRubro = _subRubroServicio.ObtenerPorId(entidadId.Value);

                nudCodigo.Value = subRubro.Codigo;
                txtDescripcion.Text = subRubro.Descripcion;
                cmbRubro.SelectedValue = subRubro.Id;

                if (_operacion == TipoOperacion.Delete)
                {
                    DesactivarControles(this, false);
                    cmbRubro.Enabled = false;
                }
                else
                {
                    nudCodigo.Enabled = false;
                    txtDescripcion.Focus();
                }
            }
            else
            {
                Mensaje.Mostrar("Ocurrio un error al cargar los datos",Mensaje.Tipo.Informacion);
            }
        }

        //========================= COAMANDOS ======================//
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
                    if (!_subRubroServicio.VerificarSiExiste((int) nudCodigo.Value, txtDescripcion.Text,
                        (long) cmbRubro.SelectedValue))
                    {
                        var subRubroNuevo = new SubRubroDto
                        {
                            Codigo = (int) nudCodigo.Value,
                            Descripcion = txtDescripcion.Text,
                            RubroId = (long) cmbRubro.SelectedValue
                        };

                        _subRubroServicio.Insertar(subRubroNuevo);
                        LimpiarControles(this);
                        nudCodigo.Value = _subRubroServicio.ObtenerSiguienteCodigo();
                        txtDescripcion.Focus();
                    }
                    else
                    {
                        Mensaje.Mostrar("Este Sub Rubro ya exite", Mensaje.Tipo.Advertencia);
                    }
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al guardar los datos", Mensaje.Tipo.Error);
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
                    //if (!_subRubroServicio.VerificarSiExiste((int)nudCodigo.Value, txtDescripcion.Text, (long)cmbRubro.SelectedValue))
                    //{
                    var modificarSubRubro = new SubRubroDto
                    {
                        Id = EntidadId.Value,
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        RubroId = (long) cmbRubro.SelectedValue,
                    };

                    _subRubroServicio.Modificar(modificarSubRubro);
                    Close();
                    //}
                    //else
                    //{
                    //    Mensaje.Mostrar("El Sub Rubro Ya existe", Mensaje.Tipo.Stop);
                    //}
                }
                catch
                {
                    Mensaje.Mostrar("No se pudieron cargar los datos para modificar", Mensaje.Tipo.Informacion);
                }
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _subRubroServicio.Eliminar(EntidadId.Value);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("No se pudo Eliminar el SubRubro", Mensaje.Tipo.Advertencia);
            }
        }

        private void btnNuevoRubro_Click(object sender, EventArgs e)
        {
            var fnuevoRubro = new _00031_ABM_Rubro(TipoOperacion.Insert);
            fnuevoRubro.ShowDialog();
            Close();
            CargarComboRubro();
        }
    }
}

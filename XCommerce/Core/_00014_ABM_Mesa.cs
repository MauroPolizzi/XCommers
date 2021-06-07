using System;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Mesa;
using XCommerce.LogicaNegocio.Mesa.DTOs;
using XCommerce.LogicaNegocio.Sala;
using XCommerce.LogicaNegocio.Seguridad;

namespace XCommerce.Core
{
    public partial class _00014_ABM_Mesa : FormularioAbm
    {
        private readonly MesaServicio _mesaServicio;
        private readonly SalaServicio _salaServicio;

        //=============================== CONSTRUCTOR ==========================//
        public _00014_ABM_Mesa()
        {
            InitializeComponent();
        }

        public _00014_ABM_Mesa(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            _mesaServicio = new MesaServicio();
            _salaServicio = new SalaServicio();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            Inicializador();
        }

        //=============================== DATOS ==========================//
        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion,"Descripcion");

            //************************ VALIDACION
            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender,args);
            };
            //************************

            CargarComboSala();

            if (_operacion == TipoOperacion.Insert)
            {
                nudCodigo.Value = _mesaServicio.ObtenerSiguienteCodigo();
                nudCodigo.Enabled = false;
                txtDescripcion.Focus();
            }
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var mesa = _mesaServicio.ObtenerPorId(entidadId.Value);

                nudCodigo.Value = mesa.Codigo;
                txtDescripcion.Text = mesa.Descripcion;
                cmbSala.Text = mesa.Sala ;

                if (_operacion == TipoOperacion.Delete)
                {
                    DesactivarControles(this, false);
                    cmbSala.Enabled = false;
                }
                else
                {
                    nudCodigo.Enabled = false;
                }

            }
            else
            {
                Mensaje.Mostrar("Ocurrio un error al cargar los datos de la mesa", Mensaje.Tipo.Informacion);
            }
        }

        //=============================== COMBO SALA ==========================//
        private void CargarComboSala()
        {
            cmbSala.DataSource = _salaServicio.ObtenerTodo(Identidad.EmpresaId, string.Empty);
            cmbSala.ValueMember = "Id";
            cmbSala.DisplayMember = "Descripcion";
        }
        private void btnNuevaSala_Click(object sender, EventArgs e)
        {
            var fnuevaSala = new _00012_ABM_Sala(TipoOperacion.Insert);
            fnuevaSala.ShowDialog();
            CargarComboSala();
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
                    var nuevaMesa = new MesaDto
                    {
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        SalaId = (long) cmbSala.SelectedValue,
                        Sala = cmbSala.Text,
                        EstadoMesa = EstadoMesa.Abierta

                    };

                    _mesaServicio.Insertar(nuevaMesa);
                    LimpiarControles(this);
                    nudCodigo.Value = _mesaServicio.ObtenerSiguienteCodigo();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al guardar los datos", Mensaje.Tipo.Informacion);
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
                    var mesaModificar = new MesaDto
                    {
                        Id = EntidadId.Value,
                        Codigo = (int) nudCodigo.Value,
                        Descripcion = txtDescripcion.Text,
                        SalaId = (long) cmbSala.SelectedValue,
                        Sala = cmbSala.Text,
                        EstadoMesa = EstadoMesa.Abierta
                    };

                    _mesaServicio.Modificar(mesaModificar);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al modificar la mesa", Mensaje.Tipo.Informacion);
                }
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _mesaServicio.Eliminar(EntidadId.Value);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar la mesa", Mensaje.Tipo.Informacion);
            }
        }

        private void _00014_ABM_Mesa_Load(object sender, EventArgs e)
        {

        }
    }
}

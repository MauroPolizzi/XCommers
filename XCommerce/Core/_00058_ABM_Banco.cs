using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Banco;
using XCommerce.LogicaNegocio.Banco.DTOs;

namespace XCommerce.Core
{
    public partial class _00058_ABM_Banco: FormularioAbm
    {
        private readonly BancoServicio _bancoServicio;
        public _00058_ABM_Banco()
        {
            InitializeComponent();
        }

        public _00058_ABM_Banco(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            _bancoServicio = new BancoServicio();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            Inicializador();
        }

        //========================== INICIALIADOR ====================//
        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion,"Descripcion");

            //******************** VALIDACION
            txtDescripcion.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender,args);
                Validar.NoInyeccion(sender,args);
            };
            //********************

            if (_operacion == TipoOperacion.Insert)
            {
                txtCodigo.Text = _bancoServicio.ObtenerSiguienteCodigo().ToString("000");
                txtCodigo.Enabled = false;
            }
        }

        //========================== CARGAR DATOS ====================//
        public override void CargarDatos(long? entidadId)
        {
            var banco = _bancoServicio.ObtenerPorId(entidadId);

            txtCodigo.Text = banco.Codigo.ToString("000");
            txtDescripcion.Text = banco.Descripcion;

            if (_operacion == TipoOperacion.Delete)
            {
                DesactivarControles(this,false);
            }
            else
            {
                txtCodigo.Enabled = false;
            }
        }

        //========================== INSERTAR ====================//
        public override void EjecutarComandoInsert()
        {
            try
            {
                var bancoNuevo = new BancoDto
                {
                    Codigo = Convert.ToInt32(txtCodigo.Text),
                    Descripcion = txtDescripcion.Text
                };

                _bancoServicio.Insertar(bancoNuevo);
                txtCodigo.Text = _bancoServicio.ObtenerSiguienteCodigo().ToString("000");
                txtDescripcion.Clear();

            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al guardar los datos", Mensaje.Tipo.Informacion);
            }
        }

        //========================== MODIFICAR ====================//
        public override void EjecutarComandoUpDate()
        {
            try
            {
                var bancoNuevo = new BancoDto
                {
                    Id = EntidadId.Value,
                    Codigo = Convert.ToInt32(txtCodigo.Text),
                    Descripcion = txtDescripcion.Text
                };

                _bancoServicio.Modificar(bancoNuevo);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al modificar los datos", Mensaje.Tipo.Informacion);
            }
        }

        //========================== ELIMINAR ====================//
        public override void EjecutarComandoDelete()
        {
            try
            {
                _bancoServicio.Eliminar(EntidadId);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar", Mensaje.Tipo.Informacion);
            }
        }
    }
}

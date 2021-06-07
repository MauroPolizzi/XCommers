using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Tarjeta;
using XCommerce.LogicaNegocio.Tarjeta.DTOs;

namespace XCommerce.Core
{
    public partial class _00054_ABM_Tarjeta: FormularioAbm
    {
        private readonly TarjetaServicios _tarjetaServicios;
        public _00054_ABM_Tarjeta()
        {
            InitializeComponent();
        }

        public _00054_ABM_Tarjeta(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            _tarjetaServicios = new TarjetaServicios();

            InitializeComponent();

            Inicializador();
        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");

            //**************** VALIDACION
            txtDescripcion.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender,args);
                Validar.NoInyeccion(sender,args);
            };
            //****************

            if (_operacion == TipoOperacion.Insert)
            {
                txtCodigo.Enabled = false;
                txtCodigo.Text = _tarjetaServicios.ObtenerSiguienteCodigo().ToString("000");
            }
        }

        public override void CargarDatos(long? entidadId)
        {
            var datosTarjeta = _tarjetaServicios.ObtenerPorId(entidadId);

            txtCodigo.Text = datosTarjeta.Codigo.ToString("000");
            txtDescripcion.Text = datosTarjeta.Descripcion;

            if (_operacion == TipoOperacion.Delete)
            {
                DesactivarControles(this,false);
            }
            else
            {
                txtCodigo.Enabled = false;
            }
        }

        public override void EjecutarComandoInsert()
        {
            try
            {
                var tarjeta = new TarjetaDto
                {
                    Codigo = Convert.ToInt32(txtCodigo.Text),
                    Descripcion = txtDescripcion.Text,
                    EstaEliminado = false
                };

                _tarjetaServicios.Insertar(tarjeta);
                txtDescripcion.Clear();
                txtCodigo.Text = _tarjetaServicios.ObtenerSiguienteCodigo().ToString("000");
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al crear la tarjeta", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoUpDate()
        {
            try
            {
                var tarjeta = new TarjetaDto
                {
                    Id = EntidadId.Value,
                    Codigo = Convert.ToInt32(txtCodigo.Text),
                    Descripcion = txtDescripcion.Text,
                    EstaEliminado = false
                };

                _tarjetaServicios.Modificar(tarjeta);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al modifiacar la tarjeta", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _tarjetaServicios.Eliminar(EntidadId);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar la tarjeta", Mensaje.Tipo.Informacion);
            }
        }
    }
}

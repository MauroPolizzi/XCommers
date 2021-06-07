using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.TarjetaPlan;
using XCommerce.LogicaNegocio.TarjetaPlan.DTOs;

namespace XCommerce.Core
{
    public partial class _00056_ABM_PlanTarjeta: FormularioAbm
    {
        private readonly PlanTarjetaServicio _planTarjetaServicio;
        public _00056_ABM_PlanTarjeta()
        {
            InitializeComponent();
        }

        public _00056_ABM_PlanTarjeta(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            _planTarjetaServicio = new PlanTarjetaServicio();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            Inicializador();
        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtDescripcion,"Descripcion");
            AgregarControlesObligatorios(nudAlicuota,"Alicuota");

            //********************* VALIDACION
            txtDescripcion.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender,args);
                Validar.NoInyeccion(sender,args);
            };
            //*********************

            if (_operacion == TipoOperacion.Insert)
            {
                txtDescripcion.Focus();
            }
        }

        public override void CargarDatos(long? entidadId)
        {
            var plan = _planTarjetaServicio.ObtenerPorId(entidadId);

            txtDescripcion.Text = plan.Descripcion;
            nudAlicuota.Value = plan.Alicuota;

            if (_operacion == TipoOperacion.Delete)
            {
                DesactivarControles(this,false);
            }
            else
            {
                txtDescripcion.Focus();
            }
        }

        public override void EjecutarComandoInsert()
        {
            try
            {
                var planTarjeta = new PlanTarjetaDto
                {
                    Alicuota = nudAlicuota.Value,
                    Descripcion = txtDescripcion.Text,
                    TarjetaId = EntidadId.Value,
                };

                _planTarjetaServicio.Insertar(planTarjeta);
                txtDescripcion.Clear();
                nudAlicuota.Value = 0;
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al guardar", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoUpDate()
        {
            try
            {
                var planTarjeta = new PlanTarjetaDto
                {
                    Id = EntidadId.Value,
                    Alicuota = nudAlicuota.Value,
                    Descripcion = txtDescripcion.Text,
                };

                _planTarjetaServicio.Modificar(planTarjeta);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al modificar el plan", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _planTarjetaServicio.Eliminar(EntidadId);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar el plan", Mensaje.Tipo.Informacion);
            }
        }
    }
}

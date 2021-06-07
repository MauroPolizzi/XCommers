using System;
using System.Windows.Forms;
using XCommerce.LogicaNegocio.Cliente;
using XCommerce.LogicaNegocio.CuentaCorriente;

namespace XCommerce.Core
{
    public partial class _00049_Pagar_CtaCte: Form
    {
        private readonly ClienteServicio _clienteServicio;
        private readonly CuentaCorrienteServicios _cuentaCorrienteServicios;

        private long _clienteId;
        private long _cuentaId;
        public _00049_Pagar_CtaCte()
        {
            InitializeComponent();
        }

        public _00049_Pagar_CtaCte(long clienteId, long cuentaId)
            :this(new ClienteServicio(), new CuentaCorrienteServicios())
        {
            _clienteId = clienteId;
            _cuentaId = cuentaId;
        }

        public _00049_Pagar_CtaCte(ClienteServicio clienteServicio, CuentaCorrienteServicios cuentaCorrienteServicios)
            :this()
        {
            _clienteServicio = clienteServicio;
            _cuentaCorrienteServicios = cuentaCorrienteServicios;
        }

        private void _00049_Pagar_CtaCte_Load(object sender, EventArgs e)
        {
            CargarDatosCliente();
            CargarDatosCuenta();
        }

        private void CargarDatosCuenta()
        {
            var cuenta = _cuentaCorrienteServicios.ObtenerPorId(_cuentaId);

            txtNumCuenta.Text = cuenta.Descripcion;
            txtMonto.Text = cuenta.Monto.ToString();
            dtpFecha.Value = cuenta.Fecha;
        }

        private void CargarDatosCliente()
        {
            var cliente = _clienteServicio.ObtenerProId(_clienteId);

            txtApyNom.Text = cliente.ApyNom;
            txtDomicilio.Text = cliente.Domicilio;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

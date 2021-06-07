using System;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Comprobante.Delivery;
using XCommerce.LogicaNegocio.Comprobante.Factura;
using XCommerce.LogicaNegocio.Comprobante.Salon;

namespace XCommerce.Core
{
    public partial class _00063_Comprobantes: FormularioBase
    {
        private readonly FacturaServicios _facturaServicios;
        private readonly DeliveryServicios _deliveryServicios;
        private readonly SalonServicios _salonServicios;

        private long _empresaId;
        private int _comprobante;

        private long? _idCompr;
        public _00063_Comprobantes()
        {
            InitializeComponent();

            lblTitulo.Text = "Facturas Kioscos";
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            _idCompr = null;
        }
        public _00063_Comprobantes(long empresaId, int comprobante)
            :this(new FacturaServicios(), new DeliveryServicios(), new SalonServicios())
        {
            _empresaId = empresaId;
            _comprobante = comprobante;
        }

        public _00063_Comprobantes(FacturaServicios facturaServicios
            , DeliveryServicios deliveryServicios, SalonServicios salonServicios)
            :this()
        {
            _facturaServicios = facturaServicios;
            _deliveryServicios = deliveryServicios;
            _salonServicios = salonServicios;
        }

        private void _00063_Comprobantes_Load(object sender, System.EventArgs e)
        {
            if (_comprobante == 1)
            {
                CargarComprobantesFacturas(_empresaId);
            }
            else
            {
                if (_comprobante == 2)
                {
                    CargarComprobantesDelivery(_empresaId);
                }
                else
                {
                    CargarComprobantesSalon(_empresaId);
                }
            }
        }

        private void CargarComprobantesSalon(long empresaId)
        {
            //dgvGrilla.DataSource = _salonServicios.ObtenerTodo(empresaId);
        }

        private void CargarComprobantesDelivery(long empresaId)
        {
            //dgvGrilla.DataSource = _deliveryServicios.ObtenerTodo(empresaId);
        }

        private void CargarComprobantesFacturas(long empresaId)
        {
            dgvGrilla.DataSource = _facturaServicios.ObtenerPorEmpresa(empresaId);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            var detelle = new _00062_Movimientos(_idCompr.Value,1);
            detelle.ShowDialog();
        }

        private void dgvGrilla_RowEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _idCompr = (long) dgvGrilla["Id", e.RowIndex].Value;
            }
            else
            {
                _idCompr = null;
            }
        }
    }
}

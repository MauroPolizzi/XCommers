using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.ComprobanteDetalle;
using XCommerce.LogicaNegocio.Movimineto;

namespace XCommerce.Core
{
    public partial class _00062_Movimientos: FormularioBase
    {
        private readonly MovimientoServicio _movimientoServicio;
        private readonly ComprobanteDetalleServicio _comprobanteDetalleServicio;

        private long _cajaId;

        private long _idCompr;
        private int? _opcion;
        public _00062_Movimientos()
            :this(new MovimientoServicio())
        {
            InitializeComponent();

            lblTitulo.Text = "Movimientos";
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        public _00062_Movimientos(long cajaId)
            :this()
        {
            _cajaId = cajaId;
            _opcion = null;
        }

        public _00062_Movimientos(long idCompr, int opcion)
            :this(new ComprobanteDetalleServicio())
        {
            InitializeComponent();

            lblTitulo.Text = "Detalle de Comprobante";
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            _idCompr = idCompr;
            _opcion = opcion;
        }
        public _00062_Movimientos(MovimientoServicio movimientoServicio)
        {
            _movimientoServicio = movimientoServicio;
        }

        public _00062_Movimientos(ComprobanteDetalleServicio comprobanteDetalleServicio)
        {
            _comprobanteDetalleServicio = comprobanteDetalleServicio;
        }

        private void _00062_Movimientos_Load(object sender, System.EventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            if (_opcion == null)
            {
                dgvGrilla.DataSource = _movimientoServicio.ObtenerTodo(_cajaId);
                FormatearGrilla(this.dgvGrilla);
            }
            else
            {
                dgvGrilla.DataSource = _comprobanteDetalleServicio.ObtenerTodo(_idCompr);
                FormatearGrillaDetalle(this.dgvGrilla);
            }
        }

        private void FormatearGrillaDetalle(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].HeaderText = "Codigo";
            dgvGrilla.Columns["Codigo"].Width = 100;

            dgvGrilla.Columns["Cantidad"].Visible = true;
            dgvGrilla.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvGrilla.Columns["Cantidad"].Width = 100;

            dgvGrilla.Columns["SubTotal"].Visible = true;
            dgvGrilla.Columns["SubTotal"].HeaderText = "Sub Total";
            dgvGrilla.Columns["SubTotal"].Width = 150;

            dgvGrilla.Columns["PrecioUnitario"].Visible = true;
            dgvGrilla.Columns["PrecioUnitario"].HeaderText = "Precio";
            dgvGrilla.Columns["PrecioUnitario"].Width = 150;

            dgvGrilla.Columns["ArticuloDescripcion"].Visible = true;
            dgvGrilla.Columns["ArticuloDescripcion"].HeaderText = "Articulo";
            dgvGrilla.Columns["ArticuloDescripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["TipoMovimiento"].Visible = true;
            dgv.Columns["TipoMovimiento"].HeaderText = "Tipo Movimineto";
            dgv.Columns["TipoMovimiento"].Width = 150;

            dgv.Columns["Fecha"].Visible = true;
            dgv.Columns["Fecha"].HeaderText = "Fecha";
            dgv.Columns["Fecha"].Width = 150;

            dgv.Columns["Monto"].Visible = true;
            dgv.Columns["Monto"].HeaderText = "Monto";
            dgv.Columns["Monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

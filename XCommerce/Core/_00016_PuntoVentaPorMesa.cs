using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.Core.Controles.FormulariosVarios;
using XCommerce.LogicaNegocio.Articulo;
using XCommerce.LogicaNegocio.Articulo.DTOs;
using XCommerce.LogicaNegocio.Comprobante;
using XCommerce.LogicaNegocio.Comprobante.DTOs;
using XCommerce.LogicaNegocio.Configuracion;
using XCommerce.LogicaNegocio.Configuracion.DTOs;
using XCommerce.LogicaNegocio.Empleado;

namespace XCommerce.Core
{
    public partial class _00016_PuntoVentaPorMesa : FormularioBase
    {
        //private readonly ComprobanteServicio _comprobanteServicio;
        //private readonly ConfiguracionServicio _configuracionServicio;
        //private readonly ArticuloServicio _articuloServicio;
        //private readonly EmpleadoServicio _empleadoServicio;

        //private long _mesaId;
        //private long? _mozoId;

        //private ConfiguracionDto _configuracionDto;

        //private ComprobanteDto comprobante;

        //public delegate void ActualizarTotal(decimal total);
        //public event ActualizarTotal ActualizarTotalDelControlMesa;

        //public delegate void ActualizarEstado(EstadoMesa estado);
        //public event ActualizarEstado ActualizarEstadoDelControlMesa;

        //public _00016_PuntoVentaPorMesa()
        //{
        //    InitializeComponent();

        //    _mozoId = null;
        //}

        //public _00016_PuntoVentaPorMesa(ComprobanteServicio comprobanteServicio,
        //    ConfiguracionServicio configuracionServicio,
        //    ArticuloServicio articuloServicio)
        //    : this()
        //{
        //    _comprobanteServicio = comprobanteServicio;
        //    _configuracionServicio = configuracionServicio;
        //    _articuloServicio = articuloServicio;
        //}

        //public _00016_PuntoVentaPorMesa(long mesaId)
        //    : this(new ComprobanteServicio(), new ConfiguracionServicio(), new ArticuloServicio())
        //{
        //    _mesaId = mesaId;
        //}

        //private void AddFormInPanel(object formHijo)
        //{
        //    if (this.pnlContenedor.Controls.Count > 0)
        //        this.pnlContenedor.Controls.RemoveAt(0);

        //    Form fh = formHijo as Form;
        //    fh.TopLevel = false;
        //    fh.FormBorderStyle = FormBorderStyle.None;
        //    fh.Dock = DockStyle.Fill;
        //    this.pnlContenedor.Controls.Add(fh);
        //    this.pnlContenedor.Tag = fh;
        //    fh.Show();
        //}

        //public virtual void OnActualizarTotalDelControlMesa(decimal total)
        //{
        //    ActualizarTotalDelControlMesa?.Invoke(total);
        //}

        //protected virtual void OnActualizarEstadoDelControlMesa(EstadoMesa estado)
        //{
        //    ActualizarEstadoDelControlMesa?.Invoke(estado);
        //}

        //private void btnVolver_Click(object sender, System.EventArgs e)
        //{
        //    this.Close();
        //}

        //private void btnArticulosPorControles_Click(object sender, System.EventArgs e)
        //{
        //    var formArticulosPorControles = new FControlArticulos();
        //    formArticulosPorControles.AgregarArticuloParaLaVenta += AgregarArticuloParaLaVenta;
        //    AddFormInPanel(formArticulosPorControles);
        //}

        //private void btnArticulosPorLista_Click(object sender, System.EventArgs e)
        //{
        //    var formArticulosPorLista = new FListaArticulos();

        //    AddFormInPanel(formArticulosPorLista);
        //}

        //private void nudTotal_ValueChanged(object sender, System.EventArgs e)
        //{
        //    OnActualizarTotalDelControlMesa(nudTotal.Value);
        //}

        //private void _00016_PuntoVentaPorMesa_Load(object sender, System.EventArgs e)
        //{
        //    //_configuracionDto = _configuracionServicio.Obtener(Identidad.EmpresaId);
        //    btnArticulosPorControles.PerformClick();
        //    ObtenerComprobante();
        //    OnActualizarEstadoDelControlMesa(EstadoMesa.Abierta);
        //}

        //private void ObtenerComprobante()
        //{
        //    comprobante = _comprobanteServicio.Obtener(_mesaId);

        //    if (comprobante != null)
        //    {
        //        AsignarDatosComprobante(comprobante);
        //    }
        //    else
        //    {
        //        var nuevoComprobante = new SalonDto
        //        {
        //            EmpresaId = Identidad.EmpresaId,
        //            UsuarioId = Identidad.UsuarioLoginId,
        //            Fecha = DateTime.Now,
        //            Descuento = 0m,
        //            Comensales = 1,
        //            MesaId = _mesaId,
        //            TipoComprobanteId = _configuracionDto.TipoComprobantePorDefectoId,
        //            Items = new List<ItemDto>()
        //        };

        //        _comprobanteServicio.Generar(nuevoComprobante);
        //        ObtenerComprobante();
        //    }
        //}

        //private void AsignarDatosComprobante(ComprobanteDto comprobante)
        //{
        //    nudTotal.Value = comprobante.Total;

        //    txtApyNomEmpleado.Text = comprobante.ApyNomEmpleado;
        //    txtCodigoEmpleado.Text = comprobante.CodigoEmpleado.ToString();

        //    dgvGrilla.DataSource = comprobante.Items.ToList();

        //    nudTotal.Value = comprobante.Total;

        //    nudComensales.Value = comprobante.Comensales;
        //    _mozoId = comprobante.EmpleadoId;

        //    FormatearGrilla(dgvGrilla);
        //}

        //public override void FormatearGrilla(DataGridView dgv)
        //{
        //    base.FormatearGrilla(dgv);

        //    dgv.Columns["Descripcion"].Visible = true;
        //    dgv.Columns["Descripcion"].HeaderText = "Articulo";
        //    dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //    dgv.Columns["PrecioUnitario"].Visible = true;
        //    dgv.Columns["PrecioUnitario"].HeaderText = "Precio";
        //    dgv.Columns["PrecioUnitario"].Width = 100;

        //    dgv.Columns["Cantidad"].Visible = true;
        //    dgv.Columns["Cantidad"].HeaderText = "Cant.";
        //    dgv.Columns["Cantidad"].Width = 70;
        //}

        //private void AgregarArticuloParaLaVenta(ArticuloDto articulo)
        //{
        //    var item = new ItemDto
        //    {
        //        ArticuloId = articulo.Id,
        //        Cantidad = 1,
        //        Codigo = articulo.Codigo,
        //        Descripcion = articulo.Descripcion,
        //        PrecioUnitario = 10
        //    };

        //    _comprobanteServicio.AgregarItem(item, comprobante.Id, _mozoId, (int)nudComensales.Value);
        //    ObtenerComprobante();
        //}

        //private void nudComensales_ValueChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtCodigoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {

        //    }
        //}
    }
}

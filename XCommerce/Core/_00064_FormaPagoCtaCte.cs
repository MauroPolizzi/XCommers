using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Articulo;
using XCommerce.LogicaNegocio.Caja;
using XCommerce.LogicaNegocio.Cliente;
using XCommerce.LogicaNegocio.Comprobante;
using XCommerce.LogicaNegocio.Comprobante.DTOs;
using XCommerce.LogicaNegocio.Comprobante.Factura;
using XCommerce.LogicaNegocio.Comprobante.Factura.DTOs;
using XCommerce.LogicaNegocio.ComprobanteDetalle.DTOs;
using XCommerce.LogicaNegocio.CuentaCorriente;
using XCommerce.LogicaNegocio.FormaPago.CuentaCte;
using XCommerce.LogicaNegocio.FormaPago.CuentaCte.DTOs;
using XCommerce.LogicaNegocio.Movimineto;
using XCommerce.LogicaNegocio.Movimineto.DTOs;
using XCommerce.LogicaNegocio.Precio.DTOs;

namespace XCommerce.Core
{
    public partial class _00064_FormaPagoCtaCte: FormularioBase
    {
        private readonly FacturaServicios _facturaServicios;
        private readonly CuentaCorrienteServicios _cuentaCorrienteServicios;
        private readonly ComprobanteServicio _comprobanteServicio;
        private readonly CtaCteServicio _ctaCteServicio;
        private readonly CajaServicios _cajaServicios;
        private readonly MovimientoServicio _movimientoServicio;
        private readonly ArticuloServicio _articuloServicio;
        private readonly ClienteServicio _clienteServicio;

        private ComprobanteFacturaDto _comprobante;
        private List<listaDetalleDto> _detalleArticulos;
        private List<PrecioDto> _listaArticulos;
        public _00064_FormaPagoCtaCte()
        {
            InitializeComponent();
            
            txtNumCtaCte.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender,args);
                Validar.NoInyeccion(sender,args);
                Validar.NoLetras(sender,args);
            };

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        public _00064_FormaPagoCtaCte(ComprobanteFacturaDto comprobante, List<listaDetalleDto> detalleArticulos, List<PrecioDto> listaArticulo)
            :this(new FacturaServicios(),new CuentaCorrienteServicios(),
                 new ComprobanteServicio(), new CtaCteServicio(),
                 new CajaServicios(), new MovimientoServicio()
                 ,new ArticuloServicio(), new ClienteServicio())
        {
            _comprobante = comprobante;
            _detalleArticulos = detalleArticulos;
            _listaArticulos = listaArticulo;
        }

        public _00064_FormaPagoCtaCte(FacturaServicios facturaServicios
            , CuentaCorrienteServicios cuentaCorrienteServicios
            , ComprobanteServicio comprobanteServicio
            , CtaCteServicio ctaCteServicio
            , CajaServicios cajaServicios
            , MovimientoServicio movimientoServicio
            , ArticuloServicio articuloServicio
            , ClienteServicio clienteServicio)
            :this()
        {
            _facturaServicios = facturaServicios;
            _cuentaCorrienteServicios = cuentaCorrienteServicios;
            _comprobanteServicio = comprobanteServicio;
            _ctaCteServicio = ctaCteServicio;
            _cajaServicios = cajaServicios;
            _movimientoServicio = movimientoServicio;
            _articuloServicio = articuloServicio;
            _clienteServicio = clienteServicio;
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                var cuentaCliente = _cuentaCorrienteServicios.ObtenerPorNum(txtNumCtaCte.Text);

                if (cuentaCliente.ClienteId == 0)
                {
                    Mensaje.Mostrar("No se encontro una cta cte con este num", Mensaje.Tipo.Informacion);
                }
                else
                {
                    var cliente = _clienteServicio.ObtenerProId(cuentaCliente.ClienteId);

                    if (cliente.MontoMaximoCompra >= _comprobante.Total)
                    {
                        _facturaServicios.Crear(_comprobante);

                        var idCompr = _comprobanteServicio.ObtenerIdMayor();

                        var formaPago = new CtaCteDto
                        {
                            ComprobanteId = idCompr,
                            Monto = _comprobante.Total,
                            TipoFormaPago = TipoFormaPago.CuentaCorriente,
                            ClienteId = cuentaCliente.ClienteId
                        };

                        _ctaCteServicio.Crear(formaPago);

                        _comprobanteServicio.CrearDetalle(_detalleArticulos, idCompr);

                        var Caja = _cajaServicios.ObtenerCajaEmpresa(Identidad.EmpresaId);

                        var movimiento = new MovimientoDto
                        {
                            ComprobanteId = idCompr,
                            TipoMovimiento = TipoMovimiento.Ingreso,
                            CajaId = Caja.Id,
                            UsuarioId = Identidad.UsuarioLoginId,
                            Monto = _comprobante.Total,
                            Fecha = DateTime.Now
                        };

                        _movimientoServicio.Crear(movimiento);

                        _articuloServicio.DescontarStock(_listaArticulos);

                        _cuentaCorrienteServicios.AumentarSaldo(cuentaCliente, _comprobante.Total);

                        Close();
                    }
                    else
                    {
                        Mensaje.Mostrar("No tiene Saldo Suficiente", Mensaje.Tipo.Informacion);
                    }
                }
            }
            catch
            {
                Mensaje.Mostrar("Ourrio un error al realizar la venta", Mensaje.Tipo.Informacion);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumCtaCte.Clear();
        }
    }
}

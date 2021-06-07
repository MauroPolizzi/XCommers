using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Articulo;
using XCommerce.LogicaNegocio.Caja;
using XCommerce.LogicaNegocio.Cliente;
using XCommerce.LogicaNegocio.Comprobante;
using XCommerce.LogicaNegocio.Comprobante.Factura;
using XCommerce.LogicaNegocio.Comprobante.Factura.DTOs;
using XCommerce.LogicaNegocio.ComprobanteDetalle;
using XCommerce.LogicaNegocio.ComprobanteDetalle.DTOs;
using XCommerce.LogicaNegocio.Deposito;
using XCommerce.LogicaNegocio.Empleado;
using XCommerce.LogicaNegocio.FormaPago.Efectivo;
using XCommerce.LogicaNegocio.FormaPago.Efectivo.DTOs;
using XCommerce.LogicaNegocio.Movimineto;
using XCommerce.LogicaNegocio.Movimineto.DTOs;
using XCommerce.LogicaNegocio.Precio.DTOs;
using XCommerce.LogicaNegocio.TipoComprobante;

namespace XCommerce.Core
{
    public partial class _00045_Kiosco: FormularioBase
    {
        private readonly ClienteServicio _clienteServicio;
        private readonly EmpleadoServicio _empleadoServicio;
        private readonly ArticuloServicio _articuloServicio;
        private readonly DepositoServicio _depositoServicio;
        private readonly TipoComprobanteServicio _tipoComprobanteServicio;
        private readonly ComprobanteServicio _comprobanteServicio;
        private readonly FacturaServicios _facturaServicios;
        private readonly EfectivoServicio _efectivoServicio;
        private readonly CajaServicios _cajaServicios;
        private readonly MovimientoServicio _movimientoServicio;
        private readonly ComprobanteDetalleServicio _comprobanteDetalleServicio;

        private long? _articuloId;
        private string _objetoSeleccionado;

        public List<PrecioDto> _listaArticulos;

        private List<listaDetalleDto> _detalleArticulos;

        public decimal subTotal;
        public _00045_Kiosco()
        {
            InitializeComponent();

            _clienteServicio = new ClienteServicio();
            _empleadoServicio = new EmpleadoServicio();
            _articuloServicio = new ArticuloServicio();
            _depositoServicio = new DepositoServicio();
            _tipoComprobanteServicio = new TipoComprobanteServicio();
            _comprobanteServicio = new ComprobanteServicio();
            _facturaServicios = new FacturaServicios();
            _efectivoServicio = new EfectivoServicio();
            _cajaServicios = new CajaServicios();
            _movimientoServicio = new MovimientoServicio();
            _comprobanteDetalleServicio = new ComprobanteDetalleServicio();

            _articuloId = null;
            _objetoSeleccionado = null;

            _listaArticulos = new List<PrecioDto>();

            _detalleArticulos = new List<listaDetalleDto>();
            subTotal = 0;

            dgvGrillaBusquedaArticulo.DataSource = null;
        }

        private void _00045_Kiosco_Load(object sender, EventArgs e)
        {
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            //******************** VALIDACIONES CLIENTE
            txtDniCliente.KeyPress += delegate (object o, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
                Validar.NoLetras(sender, args);
            };
            txtApellidoCliente.KeyPress += delegate(object o, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender,args);
                Validar.NoInyeccion(sender, args);
                Validar.NoLetras(sender, args);
                Validar.NoNumeros(sender, args);
            };
            txtNombreCliente.KeyPress += delegate (object o, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
                Validar.NoLetras(sender, args);
                Validar.NoNumeros(sender, args);
            };

            //******************** VALIDACIONES EMPLEADO
            txtLegajo.KeyPress += delegate (object o, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
                Validar.NoLetras(sender, args);
                Validar.NoNumeros(sender,args);
            };
            txtNombreVendedor.KeyPress += delegate (object o, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
                Validar.NoLetras(sender, args);
                Validar.NoNumeros(sender,args);
            };

            //******************** VALIDACIONES TXT BUSCAR
            txtBuscarFiltro.KeyPress += delegate (object o, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };

            CargarDatosEmpleado();
            CargarFiltroArticulo();
            CargarDeposito();
            CargarTipoFactura();
            CargarNumComprobante();
        }

        //============================ NUMERO COMPROBANTE ==================//
        private void CargarNumComprobante()
        {
            txtNumFactura.Text = _comprobanteServicio.ObtenerSiguienteNumero().ToString("0000");
        }

        //==================== COMBO TIPO FACTURA =================//
        private void CargarTipoFactura()
        {
            cmbTipoFactura.DataSource = _tipoComprobanteServicio.ObtenerTodos(string.Empty);
            cmbTipoFactura.DisplayMember = "Descripcion";
            cmbTipoFactura.ValueMember = "Id";
        }

        //==================== COMBO DEPOSITO =================//
        private void CargarDeposito()
        {
            cmbDeposito.DataSource = _depositoServicio.ObtenerTodo(Identidad.EmpresaId, string.Empty);
            cmbDeposito.DisplayMember = "Descripcion";
            cmbDeposito.ValueMember = "Id";
        }

        //==================== COMBO FILTRO ===============//
        private void CargarFiltroArticulo()
        {
            cmbFiltro.DataSource = Enum.GetValues(typeof(FiltroArticuloVenta));
        }

        //==================== CLIENTE ====================//
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int) e.KeyChar == (int) Keys.Enter)
            {
                CargarDatosClientes();
            }
        }
        private void CargarDatosClientes()
        {
            var cliente = _clienteServicio.ObtenerPorDni(txtDniCliente.Text);

            if (cliente == null)
            {
                Mensaje.Mostrar("No existe el cliente", Mensaje.Tipo.Informacion);
            }
            else
            {
                txtNombreCliente.Text = cliente.Nombre;
                txtApellidoCliente.Text = cliente.Apellido;
            }
        }

        //==================== EMPLEADO ====================//
        private void CargarDatosEmpleado()
        {
            var empleado = _empleadoServicio.ObtenerPorNombre($"{Identidad.NombreEmpleado}");

            txtLegajo.Text = empleado.Legajo.ToString();
            txtNombreVendedor.Text = empleado.ApyNom;
        }
        
        //==================== GRILLA BUSCA ARTICULO ===================//
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbDeposito.DisplayMember == null)
            {
                Mensaje.Mostrar("No hay deposito donde buscar los articulos", Mensaje.Tipo.Informacion);
            }
            else
            {
                var articuloEnDeposito =
                    _articuloServicio.ObtenerPorDeposito((long) cmbDeposito.SelectedValue, txtBuscarFiltro.Text);
                if (articuloEnDeposito == null)
                {
                    Mensaje.Mostrar("No hay disponible en deposito", Mensaje.Tipo.Informacion);
                }
                else
                {
                    CargarGrillaBusqueda(txtBuscarFiltro.Text);
                }
            }
        }

        private void CargarGrillaBusqueda(string cadenaBuscar)
        {
            dgvGrillaBusquedaArticulo.DataSource =
                _articuloServicio.ObtenerArticuloPrecio(Identidad.EmpresaId, cadenaBuscar);
            FormatearGrilla(this.dgvGrillaBusquedaArticulo);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["NombreArticulo"].Visible = true;
            dgv.Columns["NombreArticulo"].HeaderText = "Articulo";
            dgv.Columns["NombreArticulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["PreioPublico"].Visible = true;
            dgv.Columns["PreioPublico"].HeaderText = "Precio";
            dgv.Columns["PreioPublico"].Width = 150;
        }

        //====================== SALIR ====================//
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //======================= ROW ENTER ===========================//

        private void dgvGrillaBusquedaArticulo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrillaBusquedaArticulo.RowCount > 0)
            {
                _articuloId = (long)dgvGrillaBusquedaArticulo["Id", e.RowIndex].Value;
                _objetoSeleccionado = dgvGrillaBusquedaArticulo["NombreArticulo", e.RowIndex].Value.ToString();
            }
            else
            {
                _articuloId = null;
                _objetoSeleccionado = null;
            }
        }

        private void dgvGrillaArticuloAgregado_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrillaArticuloAgregado.RowCount > 0)
            {
                _articuloId = (long)dgvGrillaArticuloAgregado["Id", e.RowIndex].Value;
                _objetoSeleccionado = dgvGrillaArticuloAgregado["NombreArticulo", e.RowIndex].Value.ToString();
            }
            else
            {
                _articuloId = null;
                _objetoSeleccionado = null;
            }
        }

        //======================= AGREGAR  ARTICULOS ===========================//
        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value > 0)
            {
                var productoPrecio = _articuloServicio.ObtenerArticuloPrecio(Identidad.EmpresaId,_objetoSeleccionado);

                var producto = productoPrecio.FirstOrDefault(x => x.NombreArticulo == _objetoSeleccionado);

                var cantidadDeposito = VerificarStockArticulo(producto.ArticuloId, nudCantidad.Value);

                if (nudCantidad.Value <= cantidadDeposito)
                {
                    var preSubTotal = 0m;
                    var descuento = 0m;

                    for (int i = 0; i < nudCantidad.Value; i++)
                    {
                        _listaArticulos.Add(producto);
                        preSubTotal += producto.PreioPublico;
                    }

                    descuento += (preSubTotal / 100) * nudDescuentoPorcentje.Value;
                    subTotal += preSubTotal;

                    var detalle = new listaDetalleDto
                    {
                        ArticuloId = producto.ArticuloId,
                        Cantidad = nudCantidad.Value,
                        Codigo = _comprobanteDetalleServicio.ObtenerSiguienteCodigo()
                    };

                    _detalleArticulos.Add(detalle);

                    dgvGrillaArticuloAgregado.DataSource = _listaArticulos;

                    txtSubTotal.Text = subTotal.ToString();
                    txtDescuento.Text = descuento.ToString();
                    nudTotal.Value = subTotal - descuento;

                    FormatearGrilla(this.dgvGrillaArticuloAgregado);

                    nudDescuentoPorcentje.Value = 0;
                    nudCantidad.Value = 0;
                }
                else
                {
                    Mensaje.Mostrar("No hay stock suficiente" + Environment.NewLine + $"Quedan disponibles {cantidadDeposito}", Mensaje.Tipo.Informacion);
                }
            }
        }

        //======================= QUITAR ARTICULOS ===========================//
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvGrillaArticuloAgregado.RowCount > 0)
            {
                if (nudCantidad.Value > 0)
                {
                    var productoPrecio =
                        _articuloServicio.ObtenerArticuloPrecio(Identidad.EmpresaId, _objetoSeleccionado);

                    var producto = productoPrecio.FirstOrDefault(x => x.NombreArticulo == _objetoSeleccionado);

                    var preSubTotal = 0m;
                    var descuento = 0m;

                    for (int i = 0; i < nudCantidad.Value; i++)
                    {
                        _listaArticulos.Remove(producto);
                        preSubTotal += producto.PreioPublico;
                    }

                    descuento -= (preSubTotal / 100) * nudDescuentoPorcentje.Value;
                    subTotal -= preSubTotal;

                    foreach (var articulo in _detalleArticulos)
                    {
                        if (articulo.ArticuloId == producto.ArticuloId)
                        {
                            if (articulo.Cantidad == nudCantidad.Value)
                            {
                                _detalleArticulos.Remove(articulo);
                            }
                            else
                            {
                                articulo.Cantidad -= nudCantidad.Value;
                            }
                        }
                    }
                    //var detalle = new listaDetalleDto()
                    //{
                    //    ArticuloId = producto.ArticuloId,
                    //    Cantidad = nudCantidad.Value,
                    //};

                    //_detalleArticulos.(detalle);

                    dgvGrillaArticuloAgregado.DataSource = _listaArticulos;

                    txtSubTotal.Text = subTotal.ToString();
                    txtDescuento.Text = descuento.ToString();
                    nudTotal.Value = subTotal - descuento;
                }
                else
                {
                    Mensaje.Mostrar("Indique la cantidad que desea quitar", Mensaje.Tipo.Informacion);
                }
            }
        }
        
        //===============>>>>>>>>>>>>>>>>>     VENTA --- EFECTIVO

        private void btnContado_Click(object sender, EventArgs e)
        {
            if (nudTotal.Value > 0 && txtDniCliente.Text != null)
            {
                var cliente = _clienteServicio.ObtenerPorDni(txtDniCliente.Text);

                var comprobante = new ComprobanteFacturaDto
                {
                    Numero = Convert.ToInt64(txtNumFactura.Text),
                    ClienteId = cliente.Id,
                    Descuento = Convert.ToDecimal(txtDescuento.Text),
                    EmpresaId = Identidad.EmpresaId,
                    Fecha = DateTime.Now,
                    SubTotal = Convert.ToDecimal(txtSubTotal.Text),
                    TipoComprobanteId = (long)cmbTipoFactura.SelectedValue,
                    Total = nudTotal.Value,
                    UsuarioId = Identidad.UsuarioLoginId,
                };

                _facturaServicios.Crear(comprobante);

                var idCompr = _comprobanteServicio.ObtenerIdMayor();

                var formaPago = new EfectivoDto
                {
                    ComprobanteId = idCompr,
                    Monto = nudTotal.Value,
                    TipoFormaPago = TipoFormaPago.Efectivo,
                };

                _efectivoServicio.Crear(formaPago);

                _comprobanteServicio.CrearDetalle(_detalleArticulos, idCompr);

                var Caja = _cajaServicios.ObtenerCajaEmpresa(Identidad.EmpresaId);

                var movimiento = new MovimientoDto
                {
                    ComprobanteId = idCompr,
                    TipoMovimiento = TipoMovimiento.Ingreso,
                    CajaId = Caja.Id,
                    UsuarioId = Identidad.UsuarioLoginId,
                    Monto = nudTotal.Value,
                    Fecha = DateTime.Now
                };

                _movimientoServicio.Crear(movimiento);
                
                _articuloServicio.DescontarStock(_listaArticulos);

                LimpiarTodoControl();
            }
            else
            {
                Mensaje.Mostrar("No hay nada para vender", Mensaje.Tipo.Informacion);
            }
        }

        //===============>>>>>>>>>>>>>>>>>     VENTA --- CUENTA CORRIENTE
        private void btnCtaCte_Click(object sender, EventArgs e)
        {
            if (nudTotal.Value > 0 && txtDniCliente.Text != null)
            {
                var cliente = _clienteServicio.ObtenerPorDni(txtDniCliente.Text);

                var comprobante = new ComprobanteFacturaDto
                {
                    Numero = Convert.ToInt64(txtNumFactura.Text),
                    ClienteId = cliente.Id,
                    Descuento = Convert.ToDecimal(txtDescuento.Text),
                    EmpresaId = Identidad.EmpresaId,
                    Fecha = DateTime.Now,
                    SubTotal = Convert.ToDecimal(txtSubTotal.Text),
                    TipoComprobanteId = (long)cmbTipoFactura.SelectedValue,
                    Total = nudTotal.Value,
                    UsuarioId = Identidad.UsuarioLoginId,
                };

                var CtaCte = new _00064_FormaPagoCtaCte(comprobante, _detalleArticulos, _listaArticulos);
                CtaCte.ShowDialog();

                LimpiarTodoControl();
            }
            else
            {
                Mensaje.Mostrar("No hay nada para vender", Mensaje.Tipo.Informacion);
            }
        }
        //======================= METDOS EXTRAS ===========================//

        private decimal VerificarStockArticulo(long productoId, decimal cantidad)
        {
            var cantidadStock = _articuloServicio.ObtenreStockArticulo(productoId);

            return cantidadStock.Cantidad;
        }
        private void LimpiarTodoControl()
        {
            txtDniCliente.Clear();
            txtApellidoCliente.Clear();
            txtNombreCliente.Clear();

            txtBuscarFiltro.Clear();

            nudDescuentoPorcentje.Value = 0;
            nudCantidad.Value = 0;

            txtSubTotal.Clear();
            txtDescuento.Clear();
            nudTotal.Value = 0;

            _listaArticulos = null;
        }

        
    }
}

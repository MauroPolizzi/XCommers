using System;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Cliente;
using XCommerce.LogicaNegocio.CuentaCorriente;
using XCommerce.LogicaNegocio.CuentaCorriente.DTOs;
using XCommerce.LogicaNegocio.CuentaCorrienteProveedor;
using XCommerce.LogicaNegocio.CuentaCorrienteProveedor.DTOs;
using XCommerce.LogicaNegocio.Proveedor;

namespace XCommerce.Core
{
    public partial class _00048_CuentaCorriente: FormularioBase
    {
        private readonly CuentaCorrienteServicios _cuentaCorrienteServicios;
        private readonly ClienteServicio _clienteServicio;

        private readonly ProveedorServicios _proveedorServicios;
        private readonly CtaCteProveedorServicios _ctaCteProveedorServicios;

        private long _clienteId;
        private long? _cuentaId;

        private long? _proveedorId;
        public _00048_CuentaCorriente()
        {
            InitializeComponent();
            _cuentaId = null;
            _proveedorId = null;
        }

        //>>>>>>>>>>>>>>>>>>>>>>>>> CLIENTE <<<<<<<<<<<<<<<<<<<<<<<<<//
        public _00048_CuentaCorriente(long clienteId)
            :this(new CuentaCorrienteServicios(), new ClienteServicio())
        {
            _clienteId = clienteId;

        }

        public _00048_CuentaCorriente(CuentaCorrienteServicios cuentaCorrienteServicios
            , ClienteServicio clienteServicio)
            :this()
        {
            _cuentaCorrienteServicios = cuentaCorrienteServicios;
            _clienteServicio = clienteServicio;
        }


        //>>>>>>>>>>>>>>>>>>>>>>>>> PROVEEDOR <<<<<<<<<<<<<<<<<<<<<<<<<<<//
        public _00048_CuentaCorriente(long proveedorId, string prov)
            : this(new ProveedorServicios(), new CtaCteProveedorServicios())
        {
            _proveedorId = proveedorId;
        }

        public _00048_CuentaCorriente(
            ProveedorServicios proveedorServicios,
            CtaCteProveedorServicios cuentaCorrienteProveedorServicios)
            : this()
        {
            _proveedorServicios = proveedorServicios;
            _ctaCteProveedorServicios = cuentaCorrienteProveedorServicios;
        }

        //============================= LOAD =======================//
        private void _00048_CuentaCorriente_Load(object sender, EventArgs e)
        {
            ACtualizarDatos(string.Empty);

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            if (_proveedorId == null)
            {
                CargarCliente();
            }
            else
            {
                CargarProveedor();
            }
            
        }

        //====================== PROVEEDOR ====================//
        private void CargarProveedor()
        {
            var proveedor = _proveedorServicios.ObtenerPorId(_proveedorId);
            lblTitulo.Text = proveedor.RazonSocial;
        }

        //====================== CLIENTE ======================//
        private void CargarCliente()
        {
            var cliente = _clienteServicio.ObtenerProId(_clienteId);
            lblTitulo.Text = cliente.ApyNom;
        }

        //====================== DATOS DE LA GRILLA ================//
        public void ACtualizarDatos(string cadenaBuscar)
        {
            if (_proveedorId == null)
            {
                this.dgvGrilla.DataSource = _cuentaCorrienteServicios.ObtenerCuentas(_clienteId, cadenaBuscar);
                FormatearGrilla(this.dgvGrilla);
            }
            else
            {
                this.dgvGrilla.DataSource = _ctaCteProveedorServicios.ObtenerCuentas(_proveedorId.Value, cadenaBuscar);
                FormatearGrillaProv(this.dgvGrilla);
            }
        }
        
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Fecha"].Visible = true;
            dgvGrilla.Columns["Fecha"].HeaderText = "Fecha Actualiacion";
            dgvGrilla.Columns["Fecha"].Width = 125;

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Numero de Cuenta";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Monto"].Visible = true;
            dgvGrilla.Columns["Monto"].HeaderText = "Monto";
            dgvGrilla.Columns["Monto"].Width = 125;
        }

        private void FormatearGrillaProv(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Fecha"].Visible = true;
            dgv.Columns["Fecha"].HeaderText = "Fecha Actualiacion";
            dgv.Columns["Fecha"].Width = 125;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = "Numero de Cuenta";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Monto"].Visible = true;
            dgv.Columns["Monto"].HeaderText = "Monto";
            dgv.Columns["Monto"].Width = 125;
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _cuentaId = (long)dgvGrilla["id", e.RowIndex].Value;
            }
            else
            {
                _cuentaId = null;
            }
        }

        //======================= COMANDOS ====================//
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_proveedorId == null)
                {
                    var desCuenta = _cuentaCorrienteServicios.ObtenerPorCliente(_clienteId);

                    if (desCuenta != null)
                    {
                        var numCuenta = Convert.ToInt32(desCuenta);

                        var nuevaCuenta = new CuentaCorrienteDto
                        {
                            Descripcion = (numCuenta + 1).ToString("00000000"),
                            Fecha = DateTime.Now,
                            Monto = 0,
                            TipoMovimiento = TipoMovimiento.Ingreso,
                            ClienteId = _clienteId
                        };

                        _cuentaCorrienteServicios.Insertar(nuevaCuenta);
                        ACtualizarDatos(string.Empty);
                    }
                    else
                    {
                        var nuevaCuenta = new CuentaCorrienteDto
                        {
                            Descripcion = 1.ToString("00000000"),
                            Fecha = DateTime.Now,
                            Monto = 0,
                            TipoMovimiento = TipoMovimiento.Ingreso,
                            ClienteId = _clienteId
                        };

                        _cuentaCorrienteServicios.Insertar(nuevaCuenta);
                        ACtualizarDatos(string.Empty);
                    }

                    Mensaje.Mostrar("Cuenta Corriente creada con exito", Mensaje.Tipo.Informacion);
                }
                //   ++++  PROVEEDORES
                else
                {
                    var desCuenta = _ctaCteProveedorServicios.ObtenerPorProveedor(_proveedorId);

                    if (desCuenta != null)
                    {
                        var numCuenta = Convert.ToInt32(desCuenta);

                        var nuevaCuenta = new CtaCteProveedorDto
                        {
                            Descripcion = (numCuenta + 1).ToString("00000000"),
                            Fecha = DateTime.Now,
                            Monto = 0,
                            TipoMovimiento = TipoMovimiento.Ingreso,
                            ProveedorId = _proveedorId.Value
                        };

                        _ctaCteProveedorServicios.Insertar(nuevaCuenta);
                        ACtualizarDatos(string.Empty);
                    }
                    else
                    {
                        var nuevaCuenta = new CtaCteProveedorDto
                        {
                            Descripcion = 1.ToString("00000000"),
                            Fecha = DateTime.Now,
                            Monto = 0,
                            TipoMovimiento = TipoMovimiento.Ingreso,
                            ProveedorId = _proveedorId.Value
                        };

                        _ctaCteProveedorServicios.Insertar(nuevaCuenta);
                        ACtualizarDatos(string.Empty);
                    }

                    Mensaje.Mostrar("Cuenta Corriente creada con exito", Mensaje.Tipo.Informacion);
                }
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al crear la cuenta", Mensaje.Tipo.Informacion);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_proveedorId == null)
                {
                    _cuentaCorrienteServicios.Eliminar(_cuentaId.Value);
                    ACtualizarDatos(string.Empty);
                }
                else
                {
                    _ctaCteProveedorServicios.Eliminar(_proveedorId);
                    ACtualizarDatos(string.Empty);
                }
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar la cuenta", Mensaje.Tipo.Informacion);
            }
        }

        //======================== PAGAR =========================//
        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_proveedorId == null)
                {
                    var pagarCuenta = new _00049_Pagar_CtaCte(_clienteId, _cuentaId.Value);
                    pagarCuenta.ShowDialog();
                }
            }
            catch
            {
                Mensaje.Mostrar("Posiblemente no exista alguna cuenta para pagar", Mensaje.Tipo.Informacion);
            }
            
        }

        //======================= ACTUALIZAR =====================//
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ACtualizarDatos(string.Empty);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }

        //======================= SALIR =====================//
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

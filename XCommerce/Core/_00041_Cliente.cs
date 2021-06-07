using System;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Cliente;
using XCommerce.LogicaNegocio.CuentaCorriente;
using XCommerce.LogicaNegocio.CuentaCorriente.DTOs;

namespace XCommerce.Core
{
    public partial class _00041_Cliente: FormularioConsulta
    {
        private readonly ClienteServicio _clienteServicio;
        private readonly CuentaCorrienteServicios _cuentaCorriente;

        private ToolStripButton btnCuentaCorriente;
        private ToolStripButton btnNuevaCuenta;
        public _00041_Cliente()
            :this(new ClienteServicio(),new CuentaCorrienteServicios())
        {
            InitializeComponent();

            CrearBoton("btnNuevaCuenta", btnNuevaCuenta);
            CrearBoton("btnCtaCte", btnCuentaCorriente);
            
        }

        public _00041_Cliente(ClienteServicio clienteServicio,CuentaCorrienteServicios cuentaCorrienteServicios)
        {
            _clienteServicio = clienteServicio;
            _cuentaCorriente = cuentaCorrienteServicios;

            btnImprimir.Visible = false;
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            btnNuevaCuenta = new ToolStripButton("Nueva Cta Cte", Properties.Resources.icons8_banco, btnNuevaCuenta_Click);
            btnCuentaCorriente = new ToolStripButton("Ver Cuentas Corrientes",Properties.Resources.Moneda,btnCuentaCorriente_Click);
            
        }

        //========================= METODOS DEL BOTON =====================//
        private void CrearBoton(string name, ToolStripButton boton)
        {
            boton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Left;
            boton.ForeColor = System.Drawing.Color.White;
            boton.ImageTransparentColor = System.Drawing.Color.Magenta;
            boton.Name = name;
            boton.Size = new System.Drawing.Size(44, 59);
            boton.TextImageRelation = TextImageRelation.ImageAboveText;

            this.menu.Items.Add(boton);
        }

        private void btnCuentaCorriente_Click(object sender, EventArgs e)
        {
            var fCtaCte = new _00048_CuentaCorriente(_entidadId.Value);
            fCtaCte.ShowDialog();
            ACtualizarDatos(string.Empty);
        }

        private void btnNuevaCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                var desCuenta = _cuentaCorriente.ObtenerPorCliente(_entidadId);

                if (desCuenta != null)
                {
                    var numCuenta = Convert.ToInt32(desCuenta);

                    var nuevaCuenta = new CuentaCorrienteDto
                    {
                        Descripcion = (numCuenta + 1).ToString("00000000"),
                        Fecha = DateTime.Now,
                        Monto = 0,
                        TipoMovimiento = TipoMovimiento.Ingreso,
                        ClienteId = _entidadId.Value
                    };

                    _cuentaCorriente.Insertar(nuevaCuenta);
                }
                else
                {
                    var nuevaCuenta = new CuentaCorrienteDto
                    {
                        Descripcion = 1.ToString("00000000"),
                        Fecha = DateTime.Now,
                        Monto = 0,
                        TipoMovimiento = TipoMovimiento.Ingreso,
                        ClienteId = _entidadId.Value
                    };

                    _cuentaCorriente.Insertar(nuevaCuenta);
                }

                Mensaje.Mostrar("Cuenta Corriente creada con exito", Mensaje.Tipo.Informacion);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al crear la cuenta", Mensaje.Tipo.Informacion);
            }
        }

        //========================== DATOS GRILLA =========================//
        public override void ACtualizarDatos(string cadenabuscar)
        {
            this.dgvGrilla.DataSource = _clienteServicio.ObtenerTodo(cadenabuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            //dgvGrilla.Columns["Item"].Visible = true;
            //dgvGrilla.Columns["Item"].HeaderText = "";
            //dgvGrilla.Columns["Item"].Width = 20;

            dgvGrilla.Columns["ApyNom"].Visible = true;
            dgvGrilla.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgvGrilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Dni"].Visible = true;
            dgvGrilla.Columns["Dni"].HeaderText = "Dni";
            dgvGrilla.Columns["Dni"].Width = 120;

            dgvGrilla.Columns["Email"].Visible = true;
            dgvGrilla.Columns["Email"].HeaderText = "Email";
            dgvGrilla.Columns["Email"].Width = 120;

            dgvGrilla.Columns["EstaBloqueadoStr"].Visible = true;
            dgvGrilla.Columns["EstaBloqueadoStr"].HeaderText = "Bloqueado";
            dgvGrilla.Columns["EstaBloqueadoStr"].Width = 60;

            dgvGrilla.Columns["MontoMaximoCompra"].Visible = true;
            dgvGrilla.Columns["MontoMaximoCompra"].HeaderText = "Monto Maximo";
            dgvGrilla.Columns["MontoMaximoCompra"].Width = 120;

            dgvGrilla.Columns["TieneCuentaCorrienteStr"].Visible = true;
            dgvGrilla.Columns["TieneCuentaCorrienteStr"].HeaderText = "Cuenta Corriente";
            dgvGrilla.Columns["TieneCuentaCorrienteStr"].Width = 120;
        }

        //=========================== NUEVO CLIENTE =======================//
        public override bool EjecutarNuevaEntidad()
        {
            var nuevoCliente = new _00042_ABM_Cliente(TipoOperacion.Insert);
            nuevoCliente.ShowDialog();
            return nuevoCliente.RealizoAlgunaOperacion;
        }

        //=========================== MODIFICAR CLIENTE =======================//
        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var modificarCliente = new _00042_ABM_Cliente(TipoOperacion.Update, _entidadId);
            modificarCliente.ShowDialog();
            return modificarCliente.RealizoAlgunaOperacion;
        }

        //=========================== ELIMINAR CLIENTE =======================//
        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var eliminarCliente = new _00042_ABM_Cliente(TipoOperacion.Delete, _entidadId);
            eliminarCliente.ShowDialog();
            return eliminarCliente.RealizoAlgunaOperacion;
        }

        //=========================== BUSCAR CLIENTE =======================//
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }
}

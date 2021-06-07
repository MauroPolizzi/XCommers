using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Proveedor;

namespace XCommerce.Core
{
    public partial class _00051_Proveedor: FormularioConsulta
    {
        private readonly ProveedorServicios _proveedorServicios;

        private ToolStripButton btnCtaCteProv;
        public _00051_Proveedor()
            :this(new ProveedorServicios())
        {
            InitializeComponent();

            CrearBotones(btnCtaCteProv, "btnCtaCteProv");
        }

        public _00051_Proveedor(ProveedorServicios proveedorServicios)
        {
            _proveedorServicios = proveedorServicios;

            btnImprimir.Visible = false;

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            btnCtaCteProv = new ToolStripButton("Ver Cta Cte", Properties.Resources.Moneda, btnCtaCteProv_Click);
        }


        private void CrearBotones(ToolStripButton boton, string name)
        {
            boton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Left;
            boton.ForeColor = System.Drawing.Color.White;
            boton.ImageTransparentColor = System.Drawing.Color.Magenta;
            boton.Name = name;
            boton.Size = new System.Drawing.Size(44, 59);
            boton.TextImageRelation = TextImageRelation.ImageAboveText;

            this.menu.Items.Add(boton);
        }

        private void btnCtaCteProv_Click(object sender, EventArgs e)
        {
            var fCtaCteProv = new _00048_CuentaCorriente(_entidadId.Value,"Proveedor");
            fCtaCteProv.ShowDialog();
            ACtualizarDatos(string.Empty);
        }

        //======================= DATOS GRILLA ===================//
        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _proveedorServicios.ObtenerTodo(cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["RazonSocial"].Visible = true;
            dgvGrilla.Columns["RazonSocial"].HeaderText = "RazonSocial";
            dgvGrilla.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Direccion"].Visible = true;
            dgvGrilla.Columns["Direccion"].HeaderText = "Direcion";
            dgvGrilla.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Telefono"].Visible = true;
            dgvGrilla.Columns["Telefono"].HeaderText = "Telefono";
            dgvGrilla.Columns["Telefono"].Width = 100;

            dgvGrilla.Columns["Email"].Visible = true;
            dgvGrilla.Columns["Email"].HeaderText = "E-Mail";
            dgvGrilla.Columns["Email"].Width = 100;
            
        }

        //======================= NUEVO ===================//
        public override bool EjecutarNuevaEntidad()
        {
            var fProveedorNuevo = new _00052_AMB_Proveedor(TipoOperacion.Insert);
            fProveedorNuevo.ShowDialog();
            return fProveedorNuevo.RealizoAlgunaOperacion;
        }

        //======================= MODIFICAR ===================//
        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fProveedorModificar = new _00052_AMB_Proveedor(TipoOperacion.Update, _entidadId);
            fProveedorModificar.ShowDialog();
            return fProveedorModificar.RealizoAlgunaOperacion;
        }

        //======================= ELIMINAR ===================//
        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var fProveedorEliminar = new _00052_AMB_Proveedor(TipoOperacion.Delete,_entidadId);
            fProveedorEliminar.ShowDialog();
            return fProveedorEliminar.RealizoAlgunaOperacion;
        }

        //======================= BUSCAR ===================//
        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }
}

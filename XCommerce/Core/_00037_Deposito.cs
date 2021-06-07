using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Deposito;

namespace XCommerce.Core
{
    public partial class _00037_Deposito : FormularioConsulta
    {
        private readonly DepositoServicio _depositoServicio;

        private ToolStripButton btnVerDeposito;
        public _00037_Deposito()
            :this(new DepositoServicio())
        {
            InitializeComponent();

            //===============>>>>>>>>>>>>>
            CrearBotones(btnVerDeposito, "btnVerDeposito");
            //===============>>>>>>>>>>>>>
        }

        private void CrearBotones(ToolStripButton boton, string nombre)
        {
            boton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Left;
            boton.ForeColor = System.Drawing.Color.White;
            boton.ImageTransparentColor = System.Drawing.Color.Magenta;
            boton.Name = nombre;
            boton.Size = new System.Drawing.Size(44, 59);
            boton.TextImageRelation = TextImageRelation.ImageAboveText;

            this.menu.Items.Add(boton);
        }

        public _00037_Deposito(DepositoServicio depositoServicio)
        {
            _depositoServicio = depositoServicio;
            btnImprimir.Visible = false;
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            btnVerDeposito = new ToolStripButton("Ver Deposito", Properties.Resources.Producto, btnVerDeposito_Click);

            ACtualizarDatosDeposito(Identidad.EmpresaId, string.Empty);
        }

        //=========================================>>>>>>>>>>>>>>>>>>
        private void btnVerDeposito_Click(object sender, EventArgs e)
        {
            var fverDeposito = new _00044_Deposito_Detalle(_entidadId);
            fverDeposito.ShowDialog();
        }
        //=========================================>>>>>>>>>>>>>>>>>>

        public  void ACtualizarDatosDeposito(long empresaId, string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _depositoServicio.ObtenerTodo(Identidad.EmpresaId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].HeaderText = "Codigo";
            dgvGrilla.Columns["Codigo"].Width = 100;

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Descripcion";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["EstaEliminadoStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgvGrilla.Columns["EstaEliminadoStr"].Width = 100;
        }

        public override bool EjecutarNuevaEntidad()
        {
            var fNuevo = new _00038_ABM_Deposito(TipoOperacion.Insert);
            fNuevo.ShowDialog();
            return fNuevo.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fModificar = new _00038_ABM_Deposito(TipoOperacion.Update, _entidadId.Value);
            fModificar.ShowDialog();
            return fModificar.RealizoAlgunaOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var fEliminar = new _00038_ABM_Deposito(TipoOperacion.Delete, _entidadId.Value);
            fEliminar.ShowDialog();
            return fEliminar.RealizoAlgunaOperacion;
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ACtualizarDatosDeposito(Identidad.EmpresaId,txtBuscar.Text);
        }
    }
}

using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Tarjeta;

namespace XCommerce.Core
{
    public partial class _00053_Tarjeta: FormularioConsulta
    {
        private readonly TarjetaServicios _tarjetaServicios;

        private ToolStripButton btnPlanTarjeta;
        public _00053_Tarjeta()
            :this(new TarjetaServicios())
        {
            InitializeComponent();

            CrearBotones(btnPlanTarjeta, "btnPlanTrjet");
        }

        public _00053_Tarjeta(TarjetaServicios tarjetaServicios)
        {
            _tarjetaServicios = tarjetaServicios;

            btnImprimir.Visible = false;

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            btnPlanTarjeta = new ToolStripButton("Plan Tarjeta",Properties.Resources.icons8_tarjetas_bancarias_2,
                btnPlanTarjeta_Click);
        }

        private void btnPlanTarjeta_Click(object sender, EventArgs e)
        {
            var fPlanTarjeta = new _00055_PlanTarjeta(_entidadId.Value);
            fPlanTarjeta.ShowDialog();
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
        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _tarjetaServicios.ObtenerTodo(cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].Width = 80;

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Tarjeta";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public override bool EjecutarNuevaEntidad()
        {
            var ftarjeta = new _00054_ABM_Tarjeta(TipoOperacion.Insert);
            ftarjeta.ShowDialog();
            return ftarjeta.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var ftarjeta = new _00054_ABM_Tarjeta(TipoOperacion.Update,_entidadId);
            ftarjeta.ShowDialog();
            return ftarjeta.RealizoAlgunaOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var ftarjeta = new _00054_ABM_Tarjeta(TipoOperacion.Delete,_entidadId);
            ftarjeta.ShowDialog();
            return ftarjeta.RealizoAlgunaOperacion;
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }

}

using System;
using System.Drawing;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.ListaPrecio;

namespace XCommerce.Core
{
    public partial class _00039_ListaPrecio : FormularioConsulta
    {
        private readonly ListaPrecioServicio _listaPrecioServicio;

        private ToolStripButton btnExaminarLista;
        public _00039_ListaPrecio()
            :this(new ListaPrecioServicio())
        {
            InitializeComponent();

            //=====================>>>>>>>>>>>>>>
            CrearBotones(btnExaminarLista,"Examinar");
            //=====================>>>>>>>>>>>>>>
        }

        public _00039_ListaPrecio(ListaPrecioServicio listaPrecioServicio)
        {
            _listaPrecioServicio = listaPrecioServicio;

            btnImprimir.Visible = false;

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            //=====================>>>>>>>>>>>>>>
            btnExaminarLista = new ToolStripButton("Examinar", Properties.Resources.icons8_monedas_3, btnExaminarLista_Click);
            //=====================>>>>>>>>>>>>>>
            
        }

        //=========================  BOTON ======================//
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

        private void btnExaminarLista_Click(object sender, EventArgs e)
        {
            var lista = new _00046_Precio(_entidadId.Value);
            lista.ShowDialog();
        }

        //========================= GRILLA ======================//
        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _listaPrecioServicio.ObtenerTodo(Identidad.EmpresaId, cadenaBuscar);
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

            dgvGrilla.Columns["EstaEliminadaStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadaStr"].HeaderText = "Eliminado";
            dgvGrilla.Columns["EstaEliminadaStr"].Width = 100;
        }

        //========================= EJECUTAR =======================//
        public override bool EjecutarNuevaEntidad()
        {
            var fNuevaLista = new _00040_ABM_ListaPrecio(TipoOperacion.Insert);
            fNuevaLista.ShowDialog();
            return fNuevaLista.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fModificarLista = new _00040_ABM_ListaPrecio(TipoOperacion.Update,_entidadId);
            fModificarLista.ShowDialog();
            return fModificarLista.RealizoAlgunaOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var fEliminarLista = new _00040_ABM_ListaPrecio(TipoOperacion.Delete,_entidadId);
            fEliminarLista.ShowDialog();
            return fEliminarLista.RealizoAlgunaOperacion;
        }

        //=========================== BUSCAR =========================//
        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }
}

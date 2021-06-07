using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Articulo;
using XCommerce.LogicaNegocio.Articulo.DTOs;

namespace XCommerce.Core
{
    public partial class _00034_Articulo : FormularioConsultaConDetalle
    {
        private readonly ArticuloServicio _articuloServicio;

        private ToolStripButton btnAgregarStock;
        private ToolStripButton btnAsignaraPrecio;
        public _00034_Articulo()
            :this(new ArticuloServicio())
        {
            InitializeComponent();

            //===============>>>>>>>>>>>>>
            CrearBotones(btnAgregarStock, "btnAgregarStock");
            CrearBotones(btnAsignaraPrecio,"Asignar Precio");
            //===============>>>>>>>>>>>>>
        }
        public _00034_Articulo(ArticuloServicio articuloServicio)
        {
            _articuloServicio = articuloServicio;

            btnImprimir.Visible = false;
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            btnAgregarStock = new ToolStripButton("Agregar Stock", Properties.Resources.Agregar2, btnAgregarStock_Click);
            btnAsignaraPrecio = new ToolStripButton("Asignar Precio",Properties.Resources.icons8_banco_2,btnAsignarPrecio_Click);
        }

        //============================= BOTON STOCK =======================//
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

        private void btnAsignarPrecio_Click(object sender, EventArgs e)
        {
            var fPrecio = new _00047_ABM_Precio(TipoOperacion.Insert,EntidadId.Value);
            fPrecio.ShowDialog();
        }
        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            var fAgregarStock = new _00043_AgregarStock(TipoOperacion.Insert,EntidadId.Value);
            fAgregarStock.ShowDialog();
            //return fAgregarStock.RealizoAlgunaOperacion;
        }
        //=============================== GRILLA ==========================//
        public override void ActualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _articuloServicio.ObtenerTodo(Identidad.EmpresaId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["CodigoBarra"].Visible = true;
            dgvGrilla.Columns["CodigoBarra"].HeaderText = "Codigo de Barra";
            dgvGrilla.Columns["CodigoBarra"].Width = 120;

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Nombre Articulo";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Abreviatura"].Visible = true;
            dgvGrilla.Columns["Abreviatura"].HeaderText = "Abreviatura";
            dgvGrilla.Columns["Abreviatura"].Width = 100;

            dgvGrilla.Columns["SubRubro"].Visible = true;
            dgvGrilla.Columns["SubRubro"].HeaderText = "Sub Rubro";
            dgvGrilla.Columns["SubRubro"].Width = 120;

            dgvGrilla.Columns["TipoArticulo"].Visible = true;
            dgvGrilla.Columns["TipoArticulo"].HeaderText = "Tipo de Articulo";
            dgvGrilla.Columns["TipoArticulo"].Width = 120;
        }

        public override void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvGrilla_RowEnter(sender, e);

            var articulo = (ArticuloDto) ObjetoSeleccionado;
            if (articulo == null) return;

            imgFotoArticulo.Image = Imagen.Convertir_Bytes_Imagen(articulo.Foto);
        }

        //============================== EJECUTAR =========================//
        public override bool EjecutarNuevaEntidad()
        {
            var fNuevoArticulo = new _00035_ABM_Articulo(TipoOperacion.Insert);
            fNuevoArticulo.ShowDialog();
            return fNuevoArticulo.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComanoUpDate(long? entidadId)
        {
            var fModificarArticulo = new _00035_ABM_Articulo(TipoOperacion.Update,entidadId.Value);
            fModificarArticulo.ShowDialog();
            return fModificarArticulo.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComandoDelete(long? entidadId)
        {
            var fEliminarArticulo = new _00035_ABM_Articulo(TipoOperacion.Delete,entidadId.Value);
            fEliminarArticulo.ShowDialog();
            return fEliminarArticulo.RealizoAlgunaOperacion;
        }

        //=============================== BUSCAR ==========================//
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(txtBuscar.Text);
        }
    }
}

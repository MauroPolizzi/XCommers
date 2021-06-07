using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Marca;
using XCommerce.LogicaNegocio.Marca.DTOs;

namespace XCommerce.Core
{
    public partial class _00028_Marca : FormularioConsulta
    {
        private readonly MarcaServicio _marcaServicio;

        //========================== CONTRUCTORES =========================//
        public _00028_Marca()
            :this(new MarcaServicio())
        {
            InitializeComponent();
        }

        public _00028_Marca(MarcaServicio marcaServicio)
            :base("Lista de Marcas")
        {
            _marcaServicio = marcaServicio;
        }

        private void _00028_Marca_Load(object sender, System.EventArgs e)
        {
            ACtualizarDatos(string.Empty);

            btnImprimir.Visible = false;
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        //========================== GRILLA =========================//
        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _marcaServicio.ObtenerTodo(Identidad.EmpresaId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].HeaderText = "Codigo";
            dgvGrilla.Columns["Codigo"].Width = 120;

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Descripcion";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dgvGrilla.Columns["EstaEliminadaStr"].Visible = true;
            //dgvGrilla.Columns["EstaEliminadaStr"].HeaderText = "Eliminada";
            //dgvGrilla.Columns["EstaEliminadaStr"].Width = 150;
        }

        public override void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvGrilla_RowEnter(sender, e);

            var marca = (MarcaDto) _objetoSleccionado;
            if(marca == null) return;

        }

        //========================== COMANDOS =========================//
        public override bool EjecutarNuevaEntidad()
        {
            var fnuevaMarca = new _00029_ABM_Marca(TipoOperacion.Insert);
            fnuevaMarca.ShowDialog();
            return fnuevaMarca.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fModificarMarca = new _00029_ABM_Marca(TipoOperacion.Update,_entidadId);
            fModificarMarca.ShowDialog();
            return fModificarMarca.RealizoAlgunaOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var fEliminarMarca = new _00029_ABM_Marca(TipoOperacion.Delete,_entidadId);
            fEliminarMarca.ShowDialog();
            return fEliminarMarca.RealizoAlgunaOperacion;
        }

        //========================== BUSCAR =========================//
        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }
}

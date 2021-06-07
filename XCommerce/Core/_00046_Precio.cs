using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Precio;

namespace XCommerce.Core
{
    public partial class _00046_Precio: FormularioConsulta
    {
        private readonly PrecioServicio _precioServicio;
        private long _listaId;
        public _00046_Precio()
        {
            InitializeComponent();
        }

        public _00046_Precio(long entidadId)
        {
            InitializeComponent();
            _listaId = entidadId;

            _precioServicio = new PrecioServicio();

            btnImprimir.Visible = false;

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }
        //======================== GRILLA ==============================//
        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _precioServicio.ObtenerTodo(_listaId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["FechaActualizacion"].Visible = true;
            dgvGrilla.Columns["FechaActualizacion"].HeaderText = "Fecha";
            dgvGrilla.Columns["FechaActualizacion"].Width = 100;

            dgvGrilla.Columns["NombreArticulo"].Visible = true;
            dgvGrilla.Columns["NombreArticulo"].HeaderText = "Producto";
            dgvGrilla.Columns["NombreArticulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["PrecioCosto"].Visible = true;
            dgvGrilla.Columns["PrecioCosto"].HeaderText = "$ Costo";
            dgvGrilla.Columns["PrecioCosto"].Width = 100;

            dgvGrilla.Columns["Rentabilidad"].Visible = true;
            dgvGrilla.Columns["Rentabilidad"].HeaderText = "Rentabilidad %";
            dgvGrilla.Columns["Rentabilidad"].Width = 100;

            dgvGrilla.Columns["PreioPublico"].Visible = true;
            dgvGrilla.Columns["PreioPublico"].HeaderText = "$ Publico";
            dgvGrilla.Columns["PreioPublico"].Width = 100;
            
        }

        //======================== NUEVO ==============================//

        //public override bool EjecutarNuevaEntidad()
        //{
        //var fnuevoPrecio = new _00047_ABM_Precio(TipoOperacion.Insert);
        //fnuevoPrecio.ShowDialog();
        //return fnuevoPrecio.RealizoAlgunaOperacion;
        //}

        //======================== MODIFICAR ==============================//
        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var modificarPrecio = new _00047_ABM_Precio(TipoOperacion.Update, _entidadId);
            modificarPrecio.ShowDialog();
            return modificarPrecio.RealizoAlgunaOperacion;
        }

        //======================== ELIMINAR ==============================//
        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var eliminarPrecio = new _00047_ABM_Precio(TipoOperacion.Delete, _entidadId);
            eliminarPrecio.ShowDialog();
            return eliminarPrecio.RealizoAlgunaOperacion;
        }
    }
}

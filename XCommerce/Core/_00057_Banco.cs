using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Banco;

namespace XCommerce.Core
{
    public partial class _00057_Banco: FormularioConsulta
    {
        private readonly BancoServicio _bancoServicio;
        public _00057_Banco()
            :this(new BancoServicio())
        {
            InitializeComponent();

        }

        public _00057_Banco(BancoServicio bancoServicio)
        {
            _bancoServicio = bancoServicio;
        }

        private void _00057_Banco_Load(object sender, EventArgs e)
        {

        }

        //========================== GRILLA ====================//
        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _bancoServicio.ObtenerTodo(cadenaBuscar);
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
        }

        //========================== EJECUTAR COMANDOS ====================//
        public override bool EjecutarNuevaEntidad()
        {
            var nuevoBanco = new _00058_ABM_Banco(TipoOperacion.Insert);
            nuevoBanco.ShowDialog();
            return nuevoBanco.RealizoAlgunaOperacion;
        }

        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var banco = new _00058_ABM_Banco(TipoOperacion.Update,_entidadId);
            banco.ShowDialog();
            return banco.RealizoAlgunaOperacion;
        }


        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var bancoEliminar = new _00058_ABM_Banco(TipoOperacion.Delete,_entidadId);
            bancoEliminar.ShowDialog();
            return bancoEliminar.RealizoAlgunaOperacion;
        }

        //========================== BUSCAR ====================//
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }
}

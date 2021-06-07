using System;
using System.Drawing;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Perfil;
using XCommerce.LogicaNegocio.Seguridad;

namespace XCommerce.Core
{
    public partial class _00019_Perfil : FormularioConsulta
    {
        private readonly PerfilServicio _perfilServicio;

        private ToolStripButton btnAsignarPerfil;
        private ToolStripButton btnQuitarPerfil;

        private ToolStripButton btnAsignarFormulario;
        private ToolStripButton btnQuitarFormulario;
        public _00019_Perfil()
            :this(new PerfilServicio())
        {
            InitializeComponent();

            CrearBotones("btnAsignarPrefil", btnAsignarPerfil);
            CrearBotones("btnQuitarPrefil", btnQuitarPerfil);
            CrearBotones("btnAsignarFormulario", btnAsignarFormulario);
            CrearBotones("btnQuitarFormulario", btnQuitarFormulario);
        }

        public _00019_Perfil(PerfilServicio perfilServicio)
        {
            _perfilServicio = perfilServicio;

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
            btnImprimir.Visible = false;

            btnAsignarPerfil = new ToolStripButton("Asignar Usuarios",Properties.Resources.icons8_agregar_administrador,btnAsignarUsuario_Click);
            btnQuitarPerfil = new ToolStripButton("Quitar Usuarios", Properties.Resources.icons8_retire_del_administrador_2, btnQuitarUsuario_Click);
            btnAsignarFormulario = new ToolStripButton("Asignar Formularios", Properties.Resources.icons8_agregar_carpeta_64, btnAsignarFormularios_Click);
            btnQuitarFormulario = new ToolStripButton("Quitar Formularios", Properties.Resources.icons8_eliminar_carpeta_64, btnQuitarFormularios_Click);
        }

        //========================== CREAR BOTONES =======================//
        private void CrearBotones(string name, ToolStripButton boton)
        {
            boton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Left;
            boton.ForeColor = System.Drawing.Color.White;
            boton.ImageTransparentColor = System.Drawing.Color.Magenta;
            boton.Name = name;
            boton.Size = new System.Drawing.Size(44, 59);
            boton.TextImageRelation = TextImageRelation.ImageAboveText;
            boton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            boton.TextImageRelation = TextImageRelation.ImageAboveText;

            this.menu.Items.Add(boton);
        }

        //========================= EVENTOS DE LOS BOTONES AGREGADOS ==================//
        private void btnAsignarUsuario_Click(object sender, EventArgs e)
        {
            var fAsignarPerfil = new _00021_AsignarUsuarioPerfil(_entidadId.Value);
            fAsignarPerfil.ShowDialog();
        }
        private void btnQuitarUsuario_Click(object sender, EventArgs e)
        {
            var fQuitarPerfil = new _00022_QuitarUsuarioPerfil(_entidadId.Value);
            fQuitarPerfil.ShowDialog();
        }
        private void btnAsignarFormularios_Click(object sender, EventArgs e)
        {
            var fAsignarFormulario = new _00023_AsignarFormularioPerfil(_entidadId.Value);
            fAsignarFormulario.ShowDialog();
        }
        private void btnQuitarFormularios_Click(object sender, EventArgs e)
        {
            var fQuitarFormularios = new _00024_QuitarFormularioPerfil(_entidadId.Value);
            fQuitarFormularios.ShowDialog();
        }

        //============================ DATOS GRILAS =========================//
        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _perfilServicio.ObtenerTodo(cadenaBuscar,Identidad.EmpresaId);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Perfil";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["CantidadUsuarios"].Visible = true;
            dgvGrilla.Columns["CantidadUsuarios"].HeaderText = "Cant Usuarios";
            dgvGrilla.Columns["CantidadUsuarios"].Width = 200;
        }

        //========================= NUEVO PERFIL ==========================//
        public override bool EjecutarNuevaEntidad()
        {
            var fnuevoPerfil = new _00020_ABM_Perfil(TipoOperacion.Insert);
            fnuevoPerfil.ShowDialog();
            return fnuevoPerfil.RealizoAlgunaOperacion;
        }

        //========================= MODIFICAR PERFIL ==========================//
        public override bool EjecutarModificarEntidad(long? _entidadId)
        {
            var fmodificarPerfil = new _00020_ABM_Perfil(TipoOperacion.Update, _entidadId.Value);
            fmodificarPerfil.ShowDialog();
            return fmodificarPerfil.RealizoAlgunaOperacion;
        }

        //========================= ELIMINAR PERFIL ==========================//
        public override bool EjecutarEliminarEntidad(long? _entidadId)
        {
            var feliminarPerfil = new _00020_ABM_Perfil(TipoOperacion.Delete, _entidadId.Value);
            feliminarPerfil.ShowDialog();
            return feliminarPerfil.RealizoAlgunaOperacion;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ACtualizarDatos(txtBuscar.Text);
        }
    }
}

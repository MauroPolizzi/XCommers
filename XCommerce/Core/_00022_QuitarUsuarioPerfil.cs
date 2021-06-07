using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Perfil;
using XCommerce.LogicaNegocio.UsuarioPerfil;
using XCommerce.LogicaNegocio.UsuarioPerfil.DTOs;

namespace XCommerce.Core
{
    public partial class _00022_QuitarUsuarioPerfil : FormularioBase
    {
        private readonly UsuarioPerfilServicio _usuarioPerfilServicio;
        private readonly PerfilServicio _perfilServicio;
        private long _perfilId;
        public _00022_QuitarUsuarioPerfil()
        {
            InitializeComponent();
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        public _00022_QuitarUsuarioPerfil(long perfilId)
            :this(new UsuarioPerfilServicio() , new PerfilServicio())
        {
            _perfilId = perfilId;
        }

        public _00022_QuitarUsuarioPerfil(UsuarioPerfilServicio usuarioPerfilServicio, PerfilServicio perfilServicio)
            :this()
        {
            _usuarioPerfilServicio = usuarioPerfilServicio;
            _perfilServicio = perfilServicio;
        }

        private void _00022_QuitarUsuarioPerfil_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
            CargarDatoPerfil(_perfilId);
        }

        //=================== CARGAR DATOS PERFIL ================//
        public void CargarDatoPerfil(long perfilId)
        {
            var perfil = _perfilServicio.ObtenerPorId(perfilId);

            txtPerfil.Text = perfil.Descripcion;
        }

        //========================== DATOS ======================//
        public void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _usuarioPerfilServicio.ObtenerUsuariosAsignados(_perfilId, cadenaBuscar);
            FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Item"].Visible = true;
            dgvGrilla.Columns["Item"].HeaderText = "Item";
            dgvGrilla.Columns["Item"].Width = 80;

            dgvGrilla.Columns["Usuario"].Visible = true;
            dgvGrilla.Columns["Usuario"].HeaderText = "Usuario";
            dgvGrilla.Columns["Usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["DniEmpleado"].Visible = true;
            dgvGrilla.Columns["DniEmpleado"].HeaderText = "Dni";
            dgvGrilla.Columns["DniEmpleado"].Width = 100;

            dgvGrilla.Columns["ApyNomEmpleado"].Visible = true;
            dgvGrilla.Columns["ApyNomEmpleado"].HeaderText = "Apellido y Nombre";
            dgvGrilla.Columns["ApyNomEmpleado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //======================= BOTONES ====================//
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMarcarTodo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrilla.RowCount; i++)
            {
                dgvGrilla["Item",i].Value = true;
            }
        }

        private void btnDesmarcarTodo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrilla.RowCount; i++)
            {
                dgvGrilla["Item", i].Value = false;
            }
        }

        //======================== BOTON QUITAR ====================//
        private void btnAsignarEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                var usuariosAsignados = (List<UsuarioPerfilDto>) dgvGrilla.DataSource;

                _usuarioPerfilServicio.QuitarUsuario(_perfilId,usuariosAsignados.Where(x => x.Item).ToList());

                ActualizarDatos(string.Empty);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al quitar el usuario", Mensaje.Tipo.Informacion);
            }
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(((DataGridView)sender).RowCount <= 0) return;

            if (e.RowIndex >= 0)
            {
                ((DataGridView) sender).EndEdit();
            }
        }
    }
}

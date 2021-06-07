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
    public partial class _00021_AsignarUsuarioPerfil : FormularioBase
    {
        private long _perfilId;

        private readonly UsuarioPerfilServicio _usuarioPerfilServicio;
        private readonly PerfilServicio _perfilServicio;
        public _00021_AsignarUsuarioPerfil()
        {
            InitializeComponent();
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        public _00021_AsignarUsuarioPerfil(long perfilId)
            :this(new PerfilServicio(),new UsuarioPerfilServicio())
        {
            _perfilId = perfilId;
        }

        public _00021_AsignarUsuarioPerfil(PerfilServicio perfilServicio, UsuarioPerfilServicio usuarioPerfilServicio)
            :this()
        {
            _usuarioPerfilServicio = usuarioPerfilServicio;
            _perfilServicio = perfilServicio;
        }

        //===================== LOAD ======================//
        private void _00021_AsignarUsuarioPerfil_Load(object sender, EventArgs e)
        {
            CargarDatoPerfil();
            ActualizarDatos(string.Empty);
        }

        //===================== DATOS ======================//
        private void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _usuarioPerfilServicio.ObtenerUsuarioNoAsignado(cadenaBuscar, _perfilId);

            FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Item"].Visible = true;
            dgvGrilla.Columns["Item"].HeaderText = "Item";
            dgvGrilla.Columns["Item"].Width = 50;

            dgvGrilla.Columns["ApyNomEmpleado"].Visible = true;
            dgvGrilla.Columns["ApyNomEmpleado"].HeaderText = "Apellido y Nombre";
            dgvGrilla.Columns["ApyNomEmpleado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["DniEmpleado"].Visible = true;
            dgvGrilla.Columns["DniEmpleado"].HeaderText = "Dni";
            dgvGrilla.Columns["DniEmpleado"].Width = 100;

            dgvGrilla.Columns["Usuario"].Visible = true;
            dgvGrilla.Columns["Usuario"].HeaderText = "Usuario";
            dgvGrilla.Columns["Usuario"].Width = 200;

        }

        //===================== DATOS PERFIL ======================//
        private void CargarDatoPerfil()
        {
            var perfil = _perfilServicio.ObtenerPorId(_perfilId);
            txtPerfil.Text = perfil.Descripcion;
        }

        //===================== BOTONESD ======================//
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

        //======================== ASIGNAR USUARIO =====================//
        private void btnAsignarEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioAsignar = (List < UsuarioPerfilDto >) dgvGrilla.DataSource;

                _usuarioPerfilServicio.AsignarUsuario(_perfilId, usuarioAsignar.Where(x => x.Item).ToList());

                ActualizarDatos(string.Empty);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al asignar el usuaraio", Mensaje.Tipo.Informacion);
            }
        }

        //======================== BOTONES DE MARCAR =====================//
        private void btnMarcarTodo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrilla.RowCount; i++)
            {
                dgvGrilla["Item", i].Value = true;
            }
        }

        private void btnDesmarcarTodo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrilla.RowCount; i++)
            {
                dgvGrilla["Item", i].Value = false;
            }
        }

        //======================== EVENTO DE GRILLA =====================//
        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView) sender).RowCount <= 0) return;

            if (e.RowIndex >= 0)
            {
                ((DataGridView) sender).EndEdit();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Usuario;
using XCommerce.LogicaNegocio.Usuario.DTOs;

namespace XCommerce.Core
{
    public partial class _00003_Usuario : FormularioBase
    {
        private readonly UsuarioServicio _usuarioServicio;
        public _00003_Usuario()
        :this(new UsuarioServicio())
        {
            InitializeComponent();
        }

        public _00003_Usuario(UsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;

            //lblTitulo.Text = "Usuarios";
            lblUsuarioLogin.Text = Identidad.ApyNomEmpleadoLogin;
        }

        private void _00003_Usuario_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void ActualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _usuarioServicio.ObtenerTodo(cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Item"].Visible = true;
            dgvGrilla.Columns["Item"].Width = 100;
            dgvGrilla.Columns["Item"].HeaderText = "Item";

            dgvGrilla.Columns["ApyNomEmpleado"].Visible = true;
            dgvGrilla.Columns["ApyNomEmpleado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ApyNomEmpleado"].HeaderText = "Apellido y Nombre";

            dgvGrilla.Columns["NombreUsuario"].Visible = true;
            dgvGrilla.Columns["NombreUsuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["NombreUsuario"].HeaderText = "Nombre Usuario";

            dgvGrilla.Columns["BloqueadoStr"].Visible = true;
            dgvGrilla.Columns["BloqueadoStr"].Width = 100;
            dgvGrilla.Columns["BloqueadoStr"].HeaderText = "Bloqueado";
        }
        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).RowCount <= 0) return;

            if (e.RowIndex >= 0)
            {
                ((DataGridView)sender).EndEdit();
            }
        }

        //============================ BOTONES ===========================//
        private void btnCrearUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = (List<UsuarioDto>)dgvGrilla.DataSource;

                if (usuario.Any())
                {
                    _usuarioServicio.CrearUsuario(usuario.Where(x => x.Item && x.NombreUsuario == "NO ASIGNADO").ToList());
                    ActualizarDatos(string.Empty);
                }
                else
                {
                    Mensaje.Mostrar("No hay empleados cargados", Mensaje.Tipo.Informacion);
                }
            }
            catch 
            {
                Mensaje.Mostrar("Ocurrio un error al crear el usuario", Mensaje.Tipo.Informacion);
            }
        }

        private void btnBloquearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                var bloquearUsuario = (List<UsuarioDto>) dgvGrilla.DataSource;

                if (bloquearUsuario.Any())
                {
                    _usuarioServicio.BloquearDesbloquear(bloquearUsuario.Where(x =>x .Item && x.NombreUsuario != "NO ASIGNADO").ToList());
                    ActualizarDatos(string.Empty);
                }
                else
                {
                    Mensaje.Mostrar("No hay usuario generado", Mensaje.Tipo.Stop);
                }
            }
            catch
            {
                Mensaje.Mostrar("No se pudo Bloquear el Usuario", Mensaje.Tipo.Error);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                var usuPassword = (List<UsuarioDto>) dgvGrilla.DataSource;

                if (usuPassword.Any())
                {
                    _usuarioServicio.ResetContraseña(usuPassword.Where(x => x.Item && x.Nombre != "NO ASIGNADO").ToList());
                    Mensaje.Mostrar("Contraseña Restablecida", Mensaje.Tipo.Informacion);
                    ActualizarDatos(string.Empty);
                }
                else
                {
                    Mensaje.Mostrar("No se encontro el usuario", Mensaje.Tipo.Stop);
                }
            }
            catch 
            {
                Mensaje.Mostrar("Ocurrio un error, No se encontro el usuario", Mensaje.Tipo.Stop);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(txtBuscar.Text);
        }

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
    }
}

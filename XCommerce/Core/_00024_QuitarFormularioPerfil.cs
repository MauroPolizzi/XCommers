using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.FormularioPerfil;
using XCommerce.LogicaNegocio.FormularioPerfil.DTOs;
using XCommerce.LogicaNegocio.Perfil;

namespace XCommerce.Core
{
    public partial class _00024_QuitarFormularioPerfil : FormularioBase
    {
        private readonly FormularioPerfilServicio _formularioPerfilServicio;
        private readonly PerfilServicio _perfilServicio;

        private long _perfilId;
        public _00024_QuitarFormularioPerfil()
        {
            InitializeComponent();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        public _00024_QuitarFormularioPerfil(long perfilId)
            :this(new FormularioPerfilServicio(), new PerfilServicio())
        {
            _perfilId = perfilId;
        }

        public _00024_QuitarFormularioPerfil(FormularioPerfilServicio formularioPerfilServicio,
            PerfilServicio perfilServicio)
            :this()
        {
            _formularioPerfilServicio = formularioPerfilServicio;
            _perfilServicio = perfilServicio;
        }

        //============================== LOAD DE QUITAR FORMULARIO =================//
        private void _00024_QuitarFormularioPerfil_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);

            CargarDatoPerfil();
        }

        //========================= DATOS GRILLA ======================//
        private void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _formularioPerfilServicio.ObtenerFormulariosAsignados(cadenaBuscar,_perfilId);
            FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Item"].Visible = true;
            dgvGrilla.Columns["Item"].HeaderText = "Item";
            dgvGrilla.Columns["Item"].Width = 80;

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].HeaderText = "Codigo";
            dgvGrilla.Columns["Codigo"].Width = 80;

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = "Descripcion";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //========================= DATOS DEL PERFIL ================//
        private void CargarDatoPerfil()
        {
            var perfil = _perfilServicio.ObtenerPorId(_perfilId);

            txtPerfil.Text = perfil.Descripcion;
        }

        //=================== BOTONES ====================//
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
        
        //======================= BOTONES DE MARCAR =======================//
        private void btnMarcarTodo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrilla.RowCount; i++)
            {
                dgvGrilla["Item", i].Value = true;
            }
        }

        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrilla.RowCount; i++)
            {
                dgvGrilla["Item", i].Value = false;
            }
        }

        //========================== QUITAR FORMULARIO ======================//
        private void btnAsignarEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                var formulario = (List<FormularioPerfilDto>) dgvGrilla.DataSource;

                _formularioPerfilServicio.QuitarFormulario(_perfilId, formulario.Where(x=>x.Item).ToList());

                ActualizarDatos(string.Empty);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al quitar el formulario", Mensaje.Tipo.Informacion);
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

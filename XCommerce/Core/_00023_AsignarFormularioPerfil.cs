using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Perfil;
using XCommerce.LogicaNegocio.FormularioPerfil;
using XCommerce.LogicaNegocio.FormularioPerfil.DTOs;

namespace XCommerce.Core
{
    public partial class _00023_AsignarFormularioPerfil : FormularioBase
    {
        private readonly FormularioPerfilServicio _formularioPerfilServicio;
        private readonly PerfilServicio _perfilServicio;

        private long _perfilId;

        public _00023_AsignarFormularioPerfil()
        {
            InitializeComponent();
        }

        public _00023_AsignarFormularioPerfil(long perfilId)
            :this(new FormularioPerfilServicio(), new PerfilServicio())
        {
            _perfilId = perfilId;
        }

        public _00023_AsignarFormularioPerfil(FormularioPerfilServicio formularioPerfilServicio, PerfilServicio perfilServicio)
            :this()
        {
            _formularioPerfilServicio = formularioPerfilServicio;
            _perfilServicio = perfilServicio;
        }

        private void _00023_AsignarFormularioPerfil_Load(object sender, EventArgs e)
        {
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            ActualizarDatos(string.Empty);

            CargarDatoPerfil();
        }

        //====================== DATOS DEL PERFIL =========================//
        private void CargarDatoPerfil()
        {
            var perfil = _perfilServicio.ObtenerPorId(_perfilId);

            txtPerfil.Text = perfil.Descripcion;
        }

        //====================== DATOS DE LA GRILLA ======================//
        private void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _formularioPerfilServicio.ObtenerFormulariosNoAsignados(cadenaBuscar, _perfilId);
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

        //========================== BOTONES ==========================//
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

        private void btnAsignar_Click(object sender, EventArgs e)
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

        //======================= ASIGNAR FORMULARIOS =======================//
        private void btnAsignarEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                var formulario = (List < FormularioPerfilDto > )dgvGrilla.DataSource;

                _formularioPerfilServicio.AsignarFormulario(_perfilId,formulario.Where(x => x.Item).ToList());

                ActualizarDatos(string.Empty);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al asignar le formulario", Mensaje.Tipo.Informacion);
            }
        }
    }
}

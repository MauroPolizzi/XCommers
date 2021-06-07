using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Formulario;
using XCommerce.LogicaNegocio.Formulario.DTOs;

namespace XCommerce.Core
{
    public partial class _00018_Formulario : FormularioBase
    {
        private readonly FormularioServicio _formularioServicio;
        public _00018_Formulario()
            :this(new FormularioServicio())
        {
            InitializeComponent();
        }

        public _00018_Formulario(FormularioServicio formularioServicio)
        {
            _formularioServicio = formularioServicio;

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        private void _00018_Formulario_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _formularioServicio.ObtenerTodo(cadenaBuscar, Assembly.GetExecutingAssembly());
            FormatearGrilla(dgvGrilla);
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

            dgvGrilla.Columns["DescripcionCompleta"].Visible = true;
            dgvGrilla.Columns["DescripcionCompleta"].HeaderText = "Nom Completo";
            dgvGrilla.Columns["DescripcionCompleta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["ExisteStr"].Visible = true;
            dgvGrilla.Columns["ExisteStr"].HeaderText = "Existe";
            dgvGrilla.Columns["ExisteStr"].Width = 100;
        }

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

        private void btnCrearFormularios_Click(object sender, EventArgs e)
        {
            try
            {
                var formulario = (List<FormularioDto>) dgvGrilla.DataSource;
                _formularioServicio.Insertar(formulario.Where(x => !x.Existe).ToList());
                ActualizarDatos(string.Empty);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al crear el formulario", Mensaje.Tipo.Informacion);
                ActualizarDatos(string.Empty);
            }
        }
    }
}

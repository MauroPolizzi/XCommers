using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Empleado.DTOs;
using XCommerce.LogicaNegocio.Empresa;
using XCommerce.LogicaNegocio.EmpresaEmpleado;
using XCommerce.LogicaNegocio.Usuario.DTOs;

namespace XCommerce.Core
{
    public partial class _00009_QuitarEmpleadoEmpresa : FormularioBase
    {
        private long _empresaId;
        private readonly EmpresaEmpleadoServicio _empresaEmpleadoServicio;
        private readonly EmpresaServicio _empresaServicio;
        public _00009_QuitarEmpleadoEmpresa()
            :this(new EmpresaEmpleadoServicio(), new EmpresaServicio())
        {
            InitializeComponent();
        }
        public _00009_QuitarEmpleadoEmpresa(long? empresaId)
            :this()
        {
            CargarDatosEmpresa(empresaId);
        }
        public _00009_QuitarEmpleadoEmpresa(EmpresaEmpleadoServicio empresaEmpleadoServicio
            ,EmpresaServicio empresaServicio)
        {
            _empresaEmpleadoServicio = empresaEmpleadoServicio;
            _empresaServicio = empresaServicio;

            lblUsuarioLogin.Text = Identidad.ApyNomEmpleadoLogin;
        }
        private void CargarDatosEmpresa(long? empresaId)
        {
            if (!empresaId.HasValue) Mensaje.Mostrar("Ocurrio un error al cargar la empresa", Mensaje.Tipo.Informacion);

            var empresa = _empresaServicio.ObtenerPorId(empresaId.Value);

            if (empresa == null)
            {
                Mensaje.Mostrar("Ocurrio un error al obtener la empresa", Mensaje.Tipo.Informacion);
                return;
            }

            _empresaId = empresaId.Value;
            txtRazonSocial.Text = empresa.RazonSocial;
            txtNombreFantasia.Text = empresa.NombreFantasia;
            txtCondicionIva.Text = empresa.CondicionIva;
            txtCuit.Text = empresa.Cuit;
            txtSucursal.Text = empresa.Sucursal.ToString();
            imgFoto.Image = Imagen.Convertir_Bytes_Imagen(empresa.Logo);
        }

        private void _00009_QuitarEmpleadoEmpresa_Load(object sender, EventArgs e)
        {
            CargarGrilla(string.Empty);
        }

        private void CargarGrilla(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _empresaEmpleadoServicio.EmpleadosAsignados(_empresaId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Item"].Visible = true;
            dgvGrilla.Columns["Item"].Width = 40;
            dgvGrilla.Columns["Item"].HeaderText = @"Item";

            dgvGrilla.Columns["Legajo"].Visible = true;
            dgvGrilla.Columns["Legajo"].Width = 120;
            dgvGrilla.Columns["Legajo"].HeaderText = @"Legajo";

            dgvGrilla.Columns["ApyNom"].Visible = true;
            dgvGrilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            dgvGrilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Dni"].Visible = true;
            dgvGrilla.Columns["Dni"].Width = 120;
            dgvGrilla.Columns["Dni"].HeaderText = @"DNI";

            dgvGrilla.Columns["Telefono"].Visible = true;
            dgvGrilla.Columns["Telefono"].Width = 120;
            dgvGrilla.Columns["Telefono"].HeaderText = @"Teléfono";

            dgvGrilla.Columns["Celular"].Visible = true;
            dgvGrilla.Columns["Celular"].Width = 120;
            dgvGrilla.Columns["Celular"].HeaderText = @"Teléfono";

        }
        private void btnQuitarEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                var empleado = (List<EmpleadoDto>) dgvGrilla.DataSource;

                if (empleado.Any())
                {
                    _empresaEmpleadoServicio.QuitarEmpleado(_empresaId, empleado.Where(x => x.Item).ToList());
                    CargarGrilla(string.Empty);
                }
                else
                {
                    Mensaje.Mostrar("No se pudo quitar el empleado de la empresa", Mensaje.Tipo.Informacion);
                }
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al encontrar el empleado", Mensaje.Tipo.Informacion);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrilla(string.Empty);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text);
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).RowCount <= 0) return;

            if (e.RowIndex >= 0)
            {
                ((DataGridView)sender).EndEdit();
            }
        }
    }
}

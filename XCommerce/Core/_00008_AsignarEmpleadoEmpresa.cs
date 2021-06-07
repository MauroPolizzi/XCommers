using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Empleado;
using XCommerce.LogicaNegocio.Empleado.DTOs;
using XCommerce.LogicaNegocio.Empresa;
using XCommerce.LogicaNegocio.Empresa.DTOs;
using XCommerce.LogicaNegocio.EmpresaEmpleado;
using XCommerce.LogicaNegocio.Usuario.DTOs;

namespace XCommerce.Core
{
    public partial class _00008_AsignarEmpleadoEmpresa : FormularioBase
    {
        private long _entidadId;

        private readonly EmpresaEmpleadoServicio _empresaEmpleadoServicio;
        private readonly EmpresaServicio _empresaServicio;

        public _00008_AsignarEmpleadoEmpresa(long? entidadId)
            : this()
        {
            CargarDatosEmpresa(entidadId);
        }

        public _00008_AsignarEmpleadoEmpresa()
            :this(new EmpresaEmpleadoServicio(),new EmpresaServicio())
        {
            InitializeComponent();
        }
        public _00008_AsignarEmpleadoEmpresa(
            EmpresaEmpleadoServicio empresaEmpleadoServicio, EmpresaServicio empresaServicio)
        {
            _empresaEmpleadoServicio = empresaEmpleadoServicio ;
            _empresaServicio = empresaServicio;

            lblUsuarioLogin.Text = Identidad.ApyNomEmpleadoLogin;
        }


    private void _00008_AsignarEmpleadoEmpresa_Load(object sender, EventArgs e)
        {
            //CargarComboEmpresas();
            CargarGrillaEmpleados(string.Empty);
            
        }
        private void CargarDatosEmpresa(long? entidadId)
        {
            if (!entidadId.HasValue) Mensaje.Mostrar("Ocurrio un error al obtner la empresa", Mensaje.Tipo.Error);
            
            var empresaParaAsignarEmpelado = _empresaServicio.ObtenerPorId(entidadId.Value);

            if (empresaParaAsignarEmpelado == null)
            {
                Mensaje.Mostrar(
                    "No se encontro la empresa", Mensaje.Tipo.Error);
                return;
            }

            _entidadId = entidadId.Value;
            cmbEmpresas.Text = empresaParaAsignarEmpelado.RazonSocial;
            txtCuit.Text = empresaParaAsignarEmpelado.Cuit;
            txtCondicionIva.Text = empresaParaAsignarEmpelado.CondicionIva;
            txtNombreFantasia.Text = empresaParaAsignarEmpelado.NombreFantasia;
            txtSucursal.Text = Convert.ToString(empresaParaAsignarEmpelado.Sucursal);
            imgFoto.Image = Imagen.Convertir_Bytes_Imagen(empresaParaAsignarEmpelado.Logo);
        }
        private void CargarComboEmpresas()
        {
            cmbEmpresas.DataSource = _empresaServicio.ObtenerTodo(string.Empty);
            cmbEmpresas.ValueMember = "Id";
            cmbEmpresas.DisplayMember = "RazonSocial";
        }

        //=========================== GRILLA ===============================//
        private void CargarGrillaEmpleados(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _empresaEmpleadoServicio.EmpleadosNoAsignados(_entidadId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Item"].Visible = true;
            dgvGrilla.Columns["Item"].HeaderText = "";
            dgvGrilla.Columns["Item"].Width = 40;

            dgvGrilla.Columns["ApyNom"].Visible = true;
            dgvGrilla.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgvGrilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Legajo"].Visible = true;
            dgvGrilla.Columns["Legajo"].HeaderText = "Legajo";
            dgvGrilla.Columns["Legajo"].Width = 80;

            dgvGrilla.Columns["Dni"].Visible = true;
            dgvGrilla.Columns["Dni"].HeaderText = "Dni";
            dgvGrilla.Columns["Dni"].Width = 100;

            dgvGrilla.Columns["Telefono"].Visible = true;
            dgvGrilla.Columns["Telefono"].HeaderText = "Telefono";
            dgvGrilla.Columns["Telefono"].Width = 80;

            dgvGrilla.Columns["Email"].Visible = true;
            dgvGrilla.Columns["Email"].HeaderText = "Email";
            dgvGrilla.Columns["Email"].Width = 200;

        }

        //======================== EVENTO COMBO ============================//
        private void cmbEmpresas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var empresaCombo = (EmpresaDto) cmbEmpresas.SelectedItem;

            txtCuit.Text = empresaCombo.Cuit;
            txtCondicionIva.Text = empresaCombo.CondicionIva;
            txtNombreFantasia.Text = empresaCombo.NombreFantasia;
            txtSucursal.Text = Convert.ToString(empresaCombo.Sucursal);
            imgFoto.Image = Imagen.Convertir_Bytes_Imagen(empresaCombo.Logo);
        }

        //======================== BOTONES ============================//
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrillaEmpleados(txtBuscar.Text);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrillaEmpleados(string.Empty);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAsignarEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                var empleadoNoAsignado = (List < EmpleadoDto >) dgvGrilla.DataSource;

                if (empleadoNoAsignado.Any())
                {
                    _empresaEmpleadoServicio.AsignarEmpleado(_entidadId, empleadoNoAsignado
                        .Where(x => x.Item).ToList());
                    Mensaje.Mostrar("Empleado Asignado Correctamente", Mensaje.Tipo.Informacion);
                    CargarGrillaEmpleados(string.Empty);
                }
                else
                {
                    Mensaje.Mostrar("No hay empleados cargados", Mensaje.Tipo.Informacion);
                }
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al asignar el empleado", Mensaje.Tipo.Error);
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

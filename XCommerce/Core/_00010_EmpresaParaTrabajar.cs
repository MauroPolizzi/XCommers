using System;
using System.Net.Mime;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Empleado;
using XCommerce.LogicaNegocio.Empresa;
using XCommerce.LogicaNegocio.Empresa.DTOs;
using XCommerce.LogicaNegocio.EmpresaEmpleado;
using XCommerce.LogicaNegocio.Usuario;

namespace XCommerce.Core
{
    public partial class _00010_EmpresaParaTrabajar : FormularioBase
    {
        private long _empleadoId;
        private EmpresaDto _empresaDto;

        private readonly EmpresaEmpleadoServicio _empresaEmpleaadoServicio;
        public _00010_EmpresaParaTrabajar()
            :this(new EmpresaEmpleadoServicio())
        {
            InitializeComponent();
        }

        public _00010_EmpresaParaTrabajar(long empleadoId)
            : this(new EmpresaEmpleadoServicio())
        {
            InitializeComponent();
            lblUsuarioLogin.Text = Identidad.ApyNomEmpleadoLogin;
            _empleadoId = empleadoId;
        }
        public _00010_EmpresaParaTrabajar(EmpresaEmpleadoServicio empresaEmpleadoServicio)
        {
            _empresaEmpleaadoServicio = empresaEmpleadoServicio;
        }

        private void _00010_EmpresaParaTrabajar_Load(object sender, EventArgs e)
        {
            CargarEmpresas(_empleadoId);
        }

        private void CargarEmpresas(long _empleadoId)
        {
            dgvGrilla.DataSource = _empresaEmpleaadoServicio.ObtenerEmpresasEmpleado(_empleadoId);

            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Sucursal"].Visible = true;
            dgvGrilla.Columns["Sucursal"].Width = 100;
            dgvGrilla.Columns["Sucursal"].HeaderText = "Sucursal";


            dgvGrilla.Columns["RazonSocial"].Visible = true;
            dgvGrilla.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["RazonSocial"].HeaderText = "Razon Social";

            dgvGrilla.Columns["Telefono"].Visible = true;
            dgvGrilla.Columns["Telefono"].Width = 120;
            dgvGrilla.Columns["Telefono"].HeaderText = "Telefono";
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _empresaDto = (EmpresaDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                _empresaDto = null;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (_empresaDto == null)
            {
                Mensaje.Mostrar("Por favor seleccione una empresa", Mensaje.Tipo.Stop);
                return;
            }
            else
            {
                Identidad.Empresa = _empresaDto.RazonSocial;
                Identidad.EmpresaId = _empresaDto.Id;
                Identidad.LogoEmpresa = Imagen.Convertir_Bytes_Imagen(_empresaDto.Logo);
                
                Close();
            }
        }
    }
}

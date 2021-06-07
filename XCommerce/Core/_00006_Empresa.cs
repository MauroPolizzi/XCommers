using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Empresa;
using XCommerce.LogicaNegocio.Empresa.DTOs;

namespace XCommerce.Core
{
    public partial class _00006_Empresa : FormularioConsultaConDetalle
    {
        private readonly EmpresaServicio _empresaServicio;

        //====>>>>>>>>>>>>>>>>>>>> DECLARAR BOTONES

        private ToolStripButton btnAsignarEmpleados;
        private ToolStripButton btnQuitarEmpleados;

        //====>>>>>>>>>>>>>>>>>>>>

        public _00006_Empresa()
            :this(new EmpresaServicio())
        {
            InitializeComponent();
            CrearBotones(btnAsignarEmpleados, "btnAsignarEmplaedos");
            CrearBotones(btnQuitarEmpleados, "btnQuitarEmplaedos");
        }
        public _00006_Empresa(EmpresaServicio empresaServicio)
            :base("Lista de Empresas")
        {
            _empresaServicio = empresaServicio;
            btnImprimir.Visible = false;
            lblUsuarioLogin.Text = Identidad.ApyNomEmpleadoLogin;

            //====>>>>>>>>>>>>>>>>>>>>

            btnAsignarEmpleados = new ToolStripButton("Asignar Empleados",Properties.Resources.Usuarios,btnAsignarEmpleados_Click);
            btnQuitarEmpleados = new ToolStripButton("Quitar Emplaedos", Properties.Resources.Usuarios, btnQuitarEmpleados_Click);

            //====>>>>>>>>>>>>>>>>>>>>
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _empresaServicio.ObtenerTodo(cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["Sucursal"].Visible = true;
            dgvGrilla.Columns["Sucursal"].Width = 100;
            dgvGrilla.Columns["Sucursal"].HeaderText = "Sucursal";

            dgvGrilla.Columns["RazonSocial"].Visible = true;
            dgvGrilla.Columns["RazonSocial"].HeaderText = "Razon Social";
            dgvGrilla.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Cuit"].Visible = true;
            dgvGrilla.Columns["Cuit"].HeaderText = "Cuit";
            dgvGrilla.Columns["Cuit"].Width = 120;

            dgvGrilla.Columns["Telefono"].Visible = true;
            dgvGrilla.Columns["Telefono"].HeaderText = "Telefono";
            dgvGrilla.Columns["Telefono"].Width = 200;
        }

        public override bool EjecutarNuevaEntidad()
        {
            var fnuevaEmpresa = new _00007_ABM_Empresa(TipoOperacion.Insert);
            fnuevaEmpresa.ShowDialog();
            return fnuevaEmpresa.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComanoUpDate(long? entidadId)
        {
            var fmodificarEmpresa = new _00007_ABM_Empresa(TipoOperacion.Update, entidadId);
            fmodificarEmpresa.ShowDialog();
            return fmodificarEmpresa.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComandoDelete(long? entidadId)
        {
            var feliminarEmpresa  = new _00007_ABM_Empresa(TipoOperacion.Delete,entidadId);
            feliminarEmpresa.ShowDialog();
            return feliminarEmpresa.RealizoAlgunaOperacion;
        }

        public override void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvGrilla_RowEnter(sender, e);

            var empresa = (EmpresaDto) ObjetoSeleccionado;
            if (empresa == null) return;

            imgLogoEmpresa.Image = Imagen.Convertir_Bytes_Imagen(empresa.Logo);
        }

        private void CrearBotones(ToolStripButton boton, string name)
        {
            boton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Left;
            boton.ForeColor = System.Drawing.Color.White;
            boton.ImageTransparentColor = System.Drawing.Color.Magenta;
            boton.Name = name;
            boton.Size = new System.Drawing.Size(44, 59);
            boton.TextImageRelation = TextImageRelation.ImageAboveText;

            this.menu.Items.Add(boton);
        }

        //>>>>>>>>>>>>>>>>>>>>>> EVENTOS BOTONES POR CODIGO <<<<<<<<<<<<<<<<<<<
        private void btnQuitarEmpleados_Click(object sender, EventArgs e)
        {
            var fQuitarEmpleados = new _00009_QuitarEmpleadoEmpresa(EntidadId);
            fQuitarEmpleados.ShowDialog();
        }
        private void btnAsignarEmpleados_Click(object sender, EventArgs e)
        {
            var fQuitarEmpleados = new _00008_AsignarEmpleadoEmpresa(EntidadId);
            fQuitarEmpleados.ShowDialog();
        }
    }
}

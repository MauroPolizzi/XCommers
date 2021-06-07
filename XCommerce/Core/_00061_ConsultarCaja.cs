using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Caja;

namespace XCommerce.Core
{
    public partial class _00061_ConsultarCaja: FormularioConsulta
    {
        private readonly CajaServicios _cajaServicios;

        private ToolStripButton btnMovimientos;
        public _00061_ConsultarCaja()
            :this(new CajaServicios())
        {
            InitializeComponent();
            btnImprimir.Visible = false;

            CrearBoton("btnMovimiento",btnMovimientos);
        }

        private void CrearBoton(string name, ToolStripButton boton)
        {
            boton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Left;
            boton.ForeColor = System.Drawing.Color.White;
            boton.ImageTransparentColor = System.Drawing.Color.Magenta;
            boton.Name = name;
            boton.Size = new System.Drawing.Size(44, 59);
            boton.TextImageRelation = TextImageRelation.ImageAboveText;

            this.menu.Items.Add(boton);
        }

        public _00061_ConsultarCaja(CajaServicios cajaServicios)
        {
            _cajaServicios = cajaServicios;

            btnMovimientos = new ToolStripButton("Ver Movimientos",Properties.Resources.icons8_expandir_80, btnMovimientos_Click);
        }

        public void btnMovimientos_Click(object ssender, EventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                var movimientos = new _00062_Movimientos(_entidadId.Value);
                movimientos.ShowDialog();
            }
            
        }
        public override void ACtualizarDatos(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _cajaServicios.ObtenerTodas(Identidad.EmpresaId, cadenaBuscar);
            FormatearGrilla(this.dgvGrilla);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgvGrilla.Columns["FechaApertura"].Visible = true;
            dgvGrilla.Columns["FechaApertura"].Width = 150;

            dgvGrilla.Columns["FechaCierre"].Visible = true;
            dgvGrilla.Columns["FechaCierre"].Width = 150;

            dgvGrilla.Columns["MontoApertura"].Visible = true;
            dgvGrilla.Columns["MontoApertura"].Width = 150;

            dgvGrilla.Columns["MontoCierre"].Visible = true;
            dgvGrilla.Columns["MontoCierre"].Width = 150;

            dgvGrilla.Columns["MontoSistema"].Visible = true;
            dgvGrilla.Columns["MontoSistema"].Width = 150;

            dgvGrilla.Columns["Diferencia"].Visible = true;
            dgvGrilla.Columns["Diferencia"].Width = 150;
            
        }
    }
}

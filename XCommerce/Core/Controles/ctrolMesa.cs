using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Core.Controles.FormulariosVarios;
using Color = System.Drawing.Color;

namespace XCommerce.Core.Controles
{
    public partial class ctrolMesa : UserControl
    {
        private long _mesaId;
        private EstadoMesa _estado;

        public long MesaId
        {
            set
            {
                _mesaId = value;

            }
        }

        public int Numero
        {
            set
            {
                lblNumero.Text = $@"{value}";

            }
        }

        public int NumeroMesa => int.Parse(lblNumero.Text);

        public EstadoMesa Estado
        {
            set
            {
                _estado = value;
                abrirMesaToolStripMenuItem.Visible = true;
                cerrarMesaToolStripMenuItem.Visible = true;
                cambiarDeMesaToolStripMenuItem.Visible = true;
                cancelarMesaToolStripMenuItem.Visible = true;
                unirMesaToolStripMenuItem.Visible = true;

                switch (value)
                {
                    case EstadoMesa.Abierta:
                        this.BackColor = Color.DarkGreen;
                        abrirMesaToolStripMenuItem.Visible = false;
                        break;
                    case EstadoMesa.Cerrada:
                        this.BackColor = Color.DarkRed;
                        cerrarMesaToolStripMenuItem.Visible = false;
                        cambiarDeMesaToolStripMenuItem.Visible = false;
                        cancelarMesaToolStripMenuItem.Visible = false;
                        unirMesaToolStripMenuItem.Visible = false;
                        break;
                    case EstadoMesa.Reservada:
                        this.BackColor = Color.DarkBlue;
                        cerrarMesaToolStripMenuItem.Visible = false;
                        cambiarDeMesaToolStripMenuItem.Visible = false;
                        cancelarMesaToolStripMenuItem.Visible = false;
                        unirMesaToolStripMenuItem.Visible = false;
                        break;
                    case EstadoMesa.FueraServicio:
                        this.BackColor = Color.Black;
                        abrirMesaToolStripMenuItem.Visible = false;
                        cerrarMesaToolStripMenuItem.Visible = false;
                        cambiarDeMesaToolStripMenuItem.Visible = false;
                        cancelarMesaToolStripMenuItem.Visible = false;
                        unirMesaToolStripMenuItem.Visible = false;
                        break;
                }
            }
        }

        public decimal MontoConsumido
        {
            set
            {
                lblMontoConsumido.Text = $@"{value:C}";

            }
        }


        //========================== Constructor del Control Mesa =======================//
        public ctrolMesa()
        {
            InitializeComponent();
        }

        //public void ClickAbrirMesa(object sender, EventArgs e)
        //{
        //    AbrirPuntoVenta();
        //}

        //public void AbrirPuntoVenta()
        //{
        //    if (this._estado == EstadoMesa.Abierta)
        //    {
        //        var formPuntoVentaPorMesa = new _00016_PuntoVentaPorMesa(_mesaId);
        //        formPuntoVentaPorMesa.ActualizarTotalDelControlMesa += ActualizarTotal;
        //        formPuntoVentaPorMesa.ActualizarEstadoDelControlMesa += ActualizarEstado;
        //        formPuntoVentaPorMesa.ShowDialog();
        //    }
        //}

        //public void ActualizarTotal(decimal totalFacturado)
        //{
        //    MontoConsumido = totalFacturado;
        //}

        //public void ActualizarEstado(EstadoMesa estadoMesa)
        //{
        //    Estado = estadoMesa;
        //}

        //public void lblNumero_DoubleClick(object sender, EventArgs e)
        //{
        //    AbrirPuntoVenta();
        //}
    }
}

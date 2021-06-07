using System.Windows.Forms;
using XCommerce.AccesoDatos;

namespace XCommerce.Core.Controles.FormulariosVarios
{
    public partial class FAbrirMesa : Form
    {
        private long _mesaId;
        public delegate void ActualizarEstado(EstadoMesa estadoMesa);
        public event ActualizarEstado ActualizarEstadoMesa;

        public FAbrirMesa(long mesaId)
        {
            InitializeComponent();

            _mesaId = mesaId;
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnAbrirMesa_Click(object sender, System.EventArgs e)
        {
            //if (AbrirMesa(_mesaId))
            //{
            //    OnActualizarEstadoMesa(EstadoMesa.Abierta);
            //    Close();
            //}
        }

        protected virtual void OnActualizarEstadoMesa(EstadoMesa estadomesa)
        {
            ActualizarEstadoMesa?.Invoke(estadomesa);
        }
    }
}

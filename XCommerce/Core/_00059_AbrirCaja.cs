using System;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Caja;
using XCommerce.LogicaNegocio.Caja.DTOs;

namespace XCommerce.Core
{
    public partial class _00059_AbrirCaja: FormularioBase
    {
        private readonly CajaServicios _cajaServicios;
        public _00059_AbrirCaja()
            :this(new CajaServicios())
        {
            InitializeComponent();

        }

        public _00059_AbrirCaja(CajaServicios cajaServicios)
        {
            _cajaServicios = cajaServicios;
        }

        private void btnAbrirCaja_Click(object sender, System.EventArgs e)
        {
            if (nudMontoApertura.Value == 0)
            {
                Mensaje.Mostrar("No se puede abrir Caja con $0", Mensaje.Tipo.Informacion);
                return;
            }
            else
            {
                var caja = new CajaDto
                {
                    UsuarioApertura = Identidad.UsuarioLoginId,
                    MontoApertura = nudMontoApertura.Value,
                    FechaApertura = DateTime.Now,
                    EmpresaId = Identidad.EmpresaId,
                    MontoSistema = nudMontoApertura.Value,
                };

                _cajaServicios.AbrirCaja(caja);
                Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

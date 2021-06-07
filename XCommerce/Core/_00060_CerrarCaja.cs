using System;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Caja;
using XCommerce.LogicaNegocio.Caja.DTOs;

namespace XCommerce.Core
{
    public partial class _00060_CerrarCaja: FormularioBase
    {
        private readonly CajaServicios _cajaServicios;
        public _00060_CerrarCaja()
            :this(new CajaServicios())
        {
            InitializeComponent();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        public _00060_CerrarCaja(CajaServicios cajaServicios)
        {
            _cajaServicios = cajaServicios;
        }

        private void _00060_CerrarCaja_Load(object sender, System.EventArgs e)
        {
            CargarMontoSistema();
        }

        private void CargarMontoSistema()
        {
            var caja = _cajaServicios.ObtenerCajaEmpresa(Identidad.EmpresaId);

            if (caja.Id != 0)
            {
                nudMontoSistema.Value = (decimal)caja.MontoSistema;
            }
            
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            var resultado = (numericUpDown1.Value / 2 )
                            + numericUpDown2.Value
                            + (numericUpDown3.Value * 5)
                            + (numericUpDown4.Value * 10)
                            + (numericUpDown5.Value * 20)
                            + (numericUpDown6.Value * 50)
                            + (numericUpDown7.Value * 100)
                            + (numericUpDown8.Value * 200)
                            + (numericUpDown9.Value * 500)
                            + (numericUpDown10.Value * 1000);

            nudDieneroContado.Value = resultado;
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                var caja = _cajaServicios.ObtenerCajaEmpresa(Identidad.EmpresaId);

                var cerrar = new CajaDto
                {
                    Id = caja.Id,
                    Diferencia = nudMontoSistema.Value - nudDejarCaja.Value,
                    EmpresaId = Identidad.EmpresaId,
                    FechaCierre = DateTime.Now,
                    MontoCierre = nudDejarCaja.Value,
                    UsuarioCierre = Identidad.UsuarioLoginId
                };

                _cajaServicios.CerrarCaja(cerrar);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al cerrar la caja", Mensaje.Tipo.Informacion);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

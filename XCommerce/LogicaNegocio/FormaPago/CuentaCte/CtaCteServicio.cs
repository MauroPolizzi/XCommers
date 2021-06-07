using System;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.FormaPago.CuentaCte.DTOs;

namespace XCommerce.LogicaNegocio.FormaPago.CuentaCte
{
    public class CtaCteServicio
    {
        public void Crear(CtaCteDto formaPago)
        {
            using (var context = new ModeloDatosContainer())
            {
                var pagoCtaCte = new AccesoDatos.FormaPagoCuentaCorriente
                {
                    ClienteId = formaPago.ClienteId,
                    ComprobanteId = formaPago.ComprobanteId,
                    Monto = formaPago.Monto,
                    TipoFormaPago = formaPago.TipoFormaPago,
                };

                context.FormaPagos.Add(pagoCtaCte);
                context.SaveChanges();
            }
        }
    }
}

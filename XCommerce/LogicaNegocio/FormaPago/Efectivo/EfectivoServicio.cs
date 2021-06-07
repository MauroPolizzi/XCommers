using System;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.FormaPago.Efectivo.DTOs;

namespace XCommerce.LogicaNegocio.FormaPago.Efectivo
{
    public class EfectivoServicio
    {
        public long Crear(EfectivoDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var efectivo = new FormaPagoEfectivo
                {
                    ComprobanteId = dto.ComprobanteId,
                    Monto = dto.Monto,
                    TipoFormaPago = dto.TipoFormaPago
                };

                context.FormaPagos.Add(efectivo);
                context.SaveChanges();

                return efectivo.Id;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.ComprobanteDetalle.DTOs;

namespace XCommerce.LogicaNegocio.ComprobanteDetalle
{
    public class ComprobanteDetalleServicio
    {
        public int ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloDatosContainer())
            {
                var codigo = context.DetalleComprobantes.OfType<DetalleComprobante>().Max(x => x.Codigo);

                if (codigo == null)
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(codigo) + 1;
                }
            }
        }

        public IEnumerable<ComprobanteDetalleDto> ObtenerTodo(long idCompr)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.DetalleComprobantes
                    .AsNoTracking()
                    .Where(x => x.ComprobanteId == idCompr)
                    .Select(x => new ComprobanteDetalleDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        ArticuloId = x.ArticuloId,
                        Cantidad = x.Cantidad,
                        ComprobanteId = x.ComprobanteId,
                        SubTotal = x.SubTotal,
                        PrecioUnitario = x.PrecioUnitario,
                        ArticuloDescripcion = x.Descripcion
                    }).ToList();
            }
        }
    }
}

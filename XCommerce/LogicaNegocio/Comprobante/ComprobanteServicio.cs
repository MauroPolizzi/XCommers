using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.ComprobanteDetalle.DTOs;

namespace XCommerce.LogicaNegocio.Comprobante
{
    public class ComprobanteServicio
    {
        public long ObtenerSiguienteNumero()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Comprobantes.OfType<AccesoDatos.Comprobante>().Any()
                    ? context.Comprobantes.OfType<AccesoDatos.Comprobante>().Max(x => x.Numero) + 1
                    : 1;
            }
        }

        public long ObtenerIdMayor()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Comprobantes.OfType<AccesoDatos.Comprobante>().Max(x => x.Id);
            }
        }

        public void CrearDetalle(List<listaDetalleDto> detalleArticulos, long idCompr)
        {
            using (var context = new ModeloDatosContainer())
            {
                foreach (var dto in detalleArticulos)
                {
                    var articulo = context.Articulos.FirstOrDefault(x => x.Id == dto.ArticuloId);
                    var precio = context.Precios.FirstOrDefault(x => x.ArticuloId == dto.ArticuloId);

                    var detalleComprobante = new AccesoDatos.DetalleComprobante
                    {
                        ArticuloId = dto.ArticuloId,
                        Cantidad = dto.Cantidad,
                        ComprobanteId = idCompr,
                        Codigo = dto.Codigo.ToString("000"),
                        Descripcion = articulo.Descripcion,
                        PrecioUnitario = precio.PrecioPublico,
                        SubTotal = precio.PrecioPublico * dto.Cantidad
                    };

                    context.DetalleComprobantes.Add(detalleComprobante);
                }
                context.SaveChanges();
            }
        }
    }
}

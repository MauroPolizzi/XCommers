using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Comprobante.Factura.DTOs;

namespace XCommerce.LogicaNegocio.Comprobante.Factura
{
    public class FacturaServicios
    {
        public long Crear(ComprobanteFacturaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var comprobante = new AccesoDatos.Factura
                {
                    ClienteId = dto.ClienteId,
                    Descuento = dto.Descuento,
                    EmpresaId = dto.EmpresaId,
                    Fecha = dto.Fecha,
                    Numero = dto.Numero,
                    SubTotal = dto.SubTotal,
                    TipoComprobanteId = dto.TipoComprobanteId,
                    Total = dto.Total,
                    UsuarioId = dto.UsuarioId,
                };

                context.Comprobantes.Add(comprobante);
                context.SaveChanges();

                return comprobante.Id;
            }
        }

        public IEnumerable<ComprobanteFacturaDto> ObtenerPorEmpresa(long empresaId)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Comprobantes.OfType<AccesoDatos.Factura>()
                    .AsNoTracking()
                    .Where(x => x.EmpresaId == empresaId)
                    .Select(x => new ComprobanteFacturaDto
                    {
                        Id = x.Id,
                        ClienteId = x.ClienteId,
                        Descuento = x.Descuento,
                        EmpresaId = x.EmpresaId,
                        Fecha = x.Fecha,
                        Numero = x.Numero,
                        SubTotal = x.SubTotal,
                        TipoComprobanteId = x.TipoComprobanteId,
                        Total = x.Total,
                        UsuarioId = x.UsuarioId
                    }).OrderBy(x => x.Fecha).ToList();
            }
        }
    }
}

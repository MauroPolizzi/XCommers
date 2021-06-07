using System;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Movimineto.DTOs;

namespace XCommerce.LogicaNegocio.Movimineto
{
    public class MovimientoServicio
    {
        public long Crear(MovimientoDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var movimiento = new AccesoDatos.Movimiento
                {
                    ComprobanteId = dto.ComprobanteId,
                    TipoMovimiento = dto.TipoMovimiento,
                    CajaId = dto.CajaId,
                    UsuarioId = dto.UsuarioId,
                    Monto = dto.Monto,
                    Fecha = dto.Fecha
                };

                context.Movimientos.Add(movimiento);

                var caja = context.Cajas
                    .FirstOrDefault(x => x.Id == dto.CajaId);

                if (dto.TipoMovimiento == TipoMovimiento.Ingreso)
                {
                    caja.MontoSistema += dto.Monto;
                }
                else
                {
                    caja.MontoSistema -= dto.Monto;
                }
                
                context.SaveChanges();

                return movimiento.Id;
            }
        }

        public IEnumerable<MovimientoDto> ObtenerTodo(long cajaId)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Movimientos
                    .AsNoTracking()
                    .Where(x => x.CajaId == cajaId)
                    .Select(x => new MovimientoDto
                    {
                        CajaId = x.CajaId,
                        ComprobanteId = x.ComprobanteId,
                        Fecha = x.Fecha,
                        Id = x.Id,
                        Monto = x.Monto,
                        TipoMovimiento = x.TipoMovimiento,
                        UsuarioId = x.UsuarioId
                    }).OrderBy(x => x.Fecha).ToList();
            }
        }
    }
}

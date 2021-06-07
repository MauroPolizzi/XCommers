using System;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.TarjetaPlan.DTOs;

namespace XCommerce.LogicaNegocio.TarjetaPlan
{
    public class PlanTarjetaServicio
    {
        public IEnumerable<PlanTarjetaDto> ObtenerTodo(long tarjetaId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.PlanTarjetas
                    .AsNoTracking()
                    .Where(x => x.TarjetaId == tarjetaId &&
                                x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new PlanTarjetaDto
                    {
                        Id = x.Id,
                        TarjetaId = x.TarjetaId,
                        Descripcion = x.Descripcion,
                        Alicuota = x.Alicuota,
                    }).ToList();
            }
        }

        public long Insertar(PlanTarjetaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var plan = new AccesoDatos.PlanTarjeta
                {
                    Alicuota = dto.Alicuota,
                    Descripcion = dto.Descripcion,
                    TarjetaId = dto.TarjetaId,
                };

                context.PlanTarjetas.Add(plan);
                context.SaveChanges();

                return plan.Id;
            }
        }

        public PlanTarjetaDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var planEncontrado = context.PlanTarjetas
                    .FirstOrDefault(x => x.Id == entidadId);

                if (planEncontrado == null) throw new Exception("No existe");

                return new PlanTarjetaDto
                {
                    Id = planEncontrado.Id,
                    Descripcion = planEncontrado.Descripcion,
                    Alicuota = planEncontrado.Alicuota,
                    TarjetaId = planEncontrado.TarjetaId
                };
            }
        }

        public void Modificar(PlanTarjetaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var planEncontrado = context.PlanTarjetas
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (planEncontrado == null) throw new Exception("No existe");

                planEncontrado.Descripcion = dto.Descripcion;
                planEncontrado.Alicuota = dto.Alicuota;

                context.SaveChanges();
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {

                var planEncontrado = context.PlanTarjetas
                    .FirstOrDefault(x => x.Id == entidadId);

                if (planEncontrado == null) throw new Exception("No existe");

                context.PlanTarjetas.Remove(planEncontrado);
                context.SaveChanges();
            }
        }
    }
}

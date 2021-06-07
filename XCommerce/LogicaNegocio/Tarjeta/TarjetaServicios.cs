using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Tarjeta.DTOs;

namespace XCommerce.LogicaNegocio.Tarjeta
{
    public class TarjetaServicios
    {
        public IEnumerable<TarjetaDto> ObtenerTodo(string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                int codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                return context.Tarjetas
                    .AsNoTracking()
                    .Where(x => x.EstaEliminada == false
                                && (x.Descripcion.Contains(cadenaBuscar)
                                    || x.Codigo == codigo))
                    .Select(x => new TarjetaDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminada,
                    }).OrderBy(x => x.Descripcion).ToList();
            }
        }

        public int ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Tarjetas.OfType<AccesoDatos.Tarjeta>().Any()
                    ? context.Tarjetas.OfType<AccesoDatos.Tarjeta>().Max(x => x.Codigo) + 1
                    : 1;
            }
        }

        public long Insertar(TarjetaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var tarjeta = new AccesoDatos.Tarjeta
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    EstaEliminada = dto.EstaEliminado,
                };

                context.Tarjetas.Add(tarjeta);
                context.SaveChanges();

                return tarjeta.Id;
            }
        }

        public TarjetaDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var tarjetaEncontrada = context.Tarjetas.OfType<AccesoDatos.Tarjeta>()
                    .FirstOrDefault(x => x.Id == entidadId);

                if (tarjetaEncontrada == null) throw new Exception("No existe");

                return new TarjetaDto
                {
                    Id = tarjetaEncontrada.Id,
                    Descripcion = tarjetaEncontrada.Descripcion,
                    Codigo = tarjetaEncontrada.Codigo,
                    EstaEliminado = tarjetaEncontrada.EstaEliminada
                };
            }
        }

        public void Modificar(TarjetaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var tarjetaModificar = context.Tarjetas.OfType<AccesoDatos.Tarjeta>()
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (tarjetaModificar == null) throw new Exception("No existe");

                tarjetaModificar.Descripcion = dto.Descripcion;

                context.SaveChanges();

            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var tarjetaModificar = context.Tarjetas.OfType<AccesoDatos.Tarjeta>()
                    .FirstOrDefault(x => x.Id == entidadId);

                if (tarjetaModificar == null) throw new Exception("No existe");

                tarjetaModificar.EstaEliminada = !tarjetaModificar.EstaEliminada;

                context.SaveChanges();
            }
        }
    }
}

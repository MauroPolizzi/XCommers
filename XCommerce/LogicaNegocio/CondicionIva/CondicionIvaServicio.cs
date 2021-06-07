using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.CondicionIva.DTOs;

namespace XCommerce.LogicaNegocio.CondicionIva
{
    public class CondicionIvaServicio
    {
        public IEnumerable<CondicionIvaDto> ObtenerTodo(string cadenaBuscar, bool estado = false)
        {
            using (var context = new ModeloDatosContainer())
            {
                int codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                return context.CondicionIvas.OfType<AccesoDatos.CondicionIva>()
                    .AsNoTracking()
                    .Where(x => x.EstaEliminada == estado &&
                                (x.Descripcion.Contains(cadenaBuscar)
                                 || x.Codigo == codigo))
                    .Select(x => new CondicionIvaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Codigo = x.Codigo,
                        EstaEliminada = x.EstaEliminada,
                    }).OrderBy(x => x.Descripcion).ToList();
            }
        }

        public CondicionIvaDto ObternerPorId( long condicioId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var condicionIva = context.CondicionIvas.OfType<AccesoDatos.CondicionIva>()
                    .FirstOrDefault(x => x.Id == condicioId);
                if (condicionIva == null) throw new Exception("No se encontro Condicion de Iva");

                return new CondicionIvaDto
                {
                    Id = condicionIva.Id,
                    Descripcion = condicionIva.Descripcion,
                    Codigo = condicionIva.Codigo,
                    EstaEliminada = condicionIva.EstaEliminada
                };
            }
        }

        public int ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.CondicionIvas.OfType<AccesoDatos.CondicionIva>().Any()
                    ? context.CondicionIvas.OfType<AccesoDatos.CondicionIva>().Max(x => x.Codigo) + 1
                    : 1;
            }
        }

        public long Insertar(CondicionIvaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var nuevaCondicionIva = new AccesoDatos.CondicionIva
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    EstaEliminada = dto.EstaEliminada
                };

                context.CondicionIvas.Add(nuevaCondicionIva);
                context.SaveChanges();

                return nuevaCondicionIva.Id;
            }
        }

        public void Modificar(CondicionIvaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var modificarCondicionIva = context.CondicionIvas
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (modificarCondicionIva == null) throw new Exception("No se encontro la Condicion Iva");

                modificarCondicionIva.Codigo = dto.Codigo;
                modificarCondicionIva.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public void Eliminar(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var eliminarCondicion = context.CondicionIvas
                    .FirstOrDefault(x => x.Id == entidadId);

                if (eliminarCondicion == null) throw new Exception("No se pudo eliminar la condicion de iva");

                eliminarCondicion.EstaEliminada = !eliminarCondicion.EstaEliminada;
                context.SaveChanges();
            }
        }
    }
}

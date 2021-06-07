using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.SubRubro.DTOs;

namespace XCommerce.LogicaNegocio.SubSubRubro
{
    public class SubRubroServicio
    {
        public IEnumerable<SubRubroDto> ObtenerTodo(string cadenaBuscar, bool estado = false)
        {
            using (var context = new ModeloDatosContainer())
            {
                int codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                return context.SubRubros.OfType<AccesoDatos.SubRubro>()
                    .AsNoTracking()
                    .Include(x => x.Rubro)
                    .Where(x => x.EstaEliminado == estado
                    && (x.Codigo == codigo || x.Descripcion.Contains(cadenaBuscar)
                    || x.Rubro.Descripcion.Contains(cadenaBuscar)))
                    .Select(x => new SubRubroDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        RubroId = x.RubroId,
                        Rubro = x.Rubro.Descripcion,
                    }).ToList();
            }
        }

        public int ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.SubRubros.OfType<AccesoDatos.SubRubro>().Any()
                    ? context.SubRubros.OfType<AccesoDatos.SubRubro>().Max(x => x.Codigo) + 1
                    : 1;
            }
        }

        public SubRubroDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var subrubro = context.SubRubros
                    .AsNoTracking()
                    .Include(x => x.Rubro)
                    .FirstOrDefault(x => x.Id == entidadId);

                if (subrubro == null) throw new Exception("No existe el SubRubro");

                return new SubRubroDto
                {
                    Id = subrubro.Id,
                    Codigo = subrubro.Codigo,
                    Descripcion = subrubro.Descripcion,
                    EstaEliminado = subrubro.EstaEliminado,
                    RubroId = subrubro.RubroId,
                    Rubro = subrubro.Rubro.Descripcion,
                };
            }
        }

        //==================================================================================================//
        public bool VerificarSiExiste(int codigo, string descripcion, long rubroId, long? subRubroId = null)
        {
            using (var context = new ModeloDatosContainer())
            {
                if (subRubroId.HasValue)
                {
                    return context.SubRubros
                        .AsNoTracking()
                        .Any(x => x.Id != subRubroId && x.RubroId == rubroId &&
                                  x.Descripcion.Contains(descripcion));
                }
                else
                {
                    return context.SubRubros
                        .AsNoTracking()
                        .Any(x => x.RubroId == rubroId && x.Descripcion.Contains(descripcion));
                }
            }
        }

        //==================================================================================================//
        public long Insertar(SubRubroDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var nuevoSubRubro = new AccesoDatos.SubRubro
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    RubroId = dto.RubroId,
                    EstaEliminado = dto.EstaEliminado
                };

                context.SubRubros.Add(nuevoSubRubro);
                context.SaveChanges();

                return nuevoSubRubro.Id;
            }
        }

        public void Modificar(SubRubroDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var modificarSubRubro = context.SubRubros
                    .FirstOrDefault(x => x.Id == dto.Id);

                modificarSubRubro.Codigo = dto.Codigo;
                modificarSubRubro.Descripcion = dto.Descripcion;
                modificarSubRubro.RubroId = dto.RubroId;

                context.SaveChanges();
            }
        }

        public void Eliminar(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var eliminarSubRubro = context.SubRubros.OfType<AccesoDatos.SubRubro>()
                    .FirstOrDefault(x => x.Id == entidadId);

                if(eliminarSubRubro == null) throw new Exception("No existe el Sub Rubro para eliminar");

                eliminarSubRubro.EstaEliminado = !eliminarSubRubro.EstaEliminado;

                context.SaveChanges();
            }
        }
    }
}

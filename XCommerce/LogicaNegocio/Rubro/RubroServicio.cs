using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Rubro.DTOs;

namespace XCommerce.LogicaNegocio.Rubro
{
    public class RubroServicio
    {
        internal object ObtenerTodo(long empresaId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                int codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                return context.Rubros
                    .AsNoTracking()
                    .Where(x => x.EmpresaId == empresaId
                                && x.EstaEliminado == false
                                && (x.Descripcion.Contains(cadenaBuscar) || x.Codigo == codigo))
                    .Select(x => new RubroDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        EmpresaId = x.EmpresaId,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public int  ObnterSiguineteCodigo(long empresaId)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Rubros.OfType<AccesoDatos.Rubro>().Any(x => x.EmpresaId == empresaId)
                    ? context.Rubros.OfType<AccesoDatos.Rubro>().Where(x => x.EmpresaId == empresaId)
                          .Max(x => x.Codigo) + 1
                    : 1;
            }
        }
        public RubroDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var rubro = context.Rubros.OfType<AccesoDatos.Rubro>()
                    .FirstOrDefault(x => x.Id == entidadId);

                if(rubro == null) throw new Exception("Ocurrio un error al obtener el rubro");
                
                return new RubroDto
                {
                    Id = entidadId,
                    Codigo = rubro.Codigo,
                    Descripcion = rubro.Descripcion,
                    EmpresaId = rubro.EmpresaId,
                    EstaEliminado = rubro.EstaEliminado
                };
            }
        }

        internal bool VerificarSiExiste(long empresaId, string descripcion, decimal codigo, long? rubroId = null)
        {
            using (var context = new ModeloDatosContainer())
            {
                if (rubroId.HasValue)
                {
                    return context.Rubros
                        .AsNoTracking()
                        .Any(x => x.EmpresaId == empresaId && x.Id != rubroId
                                  && (x.Descripcion == descripcion || x.Codigo == codigo));
                }
                else
                {
                    return context.Rubros
                        .AsNoTracking()
                        .Any(x => x.EmpresaId == empresaId && (x.Descripcion == descripcion || x.Codigo == codigo));
                }
            }
        }

        public long Insertar(RubroDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var rubroNuevo = new AccesoDatos.Rubro
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    EmpresaId = dto.EmpresaId,
                    EstaEliminado = dto.EstaEliminado
                };

                context.Rubros.Add(rubroNuevo);

                context.SaveChanges();

                return rubroNuevo.Id;
            }
        }

        public void Modificar(RubroDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var modificarRubro = context.Rubros.OfType<AccesoDatos.Rubro>()
                    .FirstOrDefault(x => x.Id == dto.Id);

                modificarRubro.Codigo = dto.Codigo;
                modificarRubro.Descripcion = dto.Descripcion;
                modificarRubro.EmpresaId = dto.EmpresaId;

                context.SaveChanges();
            }
        }

        public void Eliminar(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var eliminarRubro = context.Rubros
                    .FirstOrDefault(x => x.Id == entidadId);

                if(eliminarRubro == null) throw new Exception("No hay rubro cargado");

                eliminarRubro.EstaEliminado = !eliminarRubro.EstaEliminado;
                context.SaveChanges();
            }
        }
    }
}

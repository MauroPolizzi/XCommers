using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using XCommerce.AccesoDatos;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.TipoComprobante.DTOs;

namespace XCommerce.LogicaNegocio.TipoComprobante
{
    public class TipoComprobanteServicio
    {
        public IEnumerable<TipoComprobanteDto> ObtenerTodos(string cadenaBuscar, bool estado = false)
        {
            using (var context = new ModeloDatosContainer())
            {
                int codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                return context.TipoComprobantes.OfType<AccesoDatos.TipoComprobante>()
                    .AsNoTracking()
                    .Where(x => x.EstaEliminado == estado && (x.Descripcion.Contains(cadenaBuscar)
                                                  || x.Codigo == codigo
                                                  || x.Letra.Contains(cadenaBuscar)))
                    .Select(x => new TipoComprobanteDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        Letra = x.Letra
                    }).OrderBy(x => x.Codigo).ThenBy(x => x.Letra).ToList();
            }
        }

        public int ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.TipoComprobantes.OfType<AccesoDatos.TipoComprobante>().Any()
                    ? context.TipoComprobantes.OfType<AccesoDatos.TipoComprobante>().Max(x => x.Codigo) + 1
                    : 1 ;
            }
        }

        public TipoComprobanteDto ObtenerPorId (long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var comprobante = context.TipoComprobantes
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == entidadId);

                if (comprobante == null) throw new Exception("No se encontraron los datos");

                return new TipoComprobanteDto()
                {
                    Id = comprobante.Id,
                    Codigo = comprobante.Codigo,
                    Descripcion = comprobante.Descripcion,
                    Letra = comprobante.Letra,
                    EstaEliminado = comprobante.EstaEliminado
                };
            }
        }

        public bool VerificarSiExiste(int codigo, string letra, string descripcion, long? comprobanteId = null)
        {
            using (var context = new ModeloDatosContainer())
            {
                if (comprobanteId.HasValue)
                {
                    return context.TipoComprobantes
                        .AsNoTracking()
                        .Any(x => x.Id != comprobanteId
                        && (x.Letra == letra
                                        || x.Descripcion == descripcion));
                }
                else
                {
                    return context.TipoComprobantes
                        .AsNoTracking()
                        .Any(x => x.Letra == letra
                                  || x.Descripcion == descripcion);
                }
            }
        }

        public long Insertar(TipoComprobanteDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var nuevoComprobante = new AccesoDatos.TipoComprobante
                {
                    Codigo = dto.Codigo,
                    Letra = dto.Letra,
                    Descripcion = dto.Descripcion,
                    EstaEliminado = dto.EstaEliminado,
                    EmpresaId = dto.EmpresaId
                };

                context.TipoComprobantes.Add(nuevoComprobante);
                context.SaveChanges();

                return nuevoComprobante.Id;
            }
        }

        public void Modificar(TipoComprobanteDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var modificarComprobante = context.TipoComprobantes.FirstOrDefault(x => x.Id == dto.Id);

                if (modificarComprobante == null)
                    throw new Exception("Ocurrio un error al modificar los datos");

                modificarComprobante.Codigo = dto.Codigo;
                modificarComprobante.Letra = dto.Letra;
                modificarComprobante.Descripcion = dto.Descripcion;
                modificarComprobante.EmpresaId = dto.EmpresaId;

                context.SaveChanges();
            }
        }

        public void Eliminar(long comprobanteId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var eliminarComprobante = context.TipoComprobantes.FirstOrDefault(x => x.Id == comprobanteId);

                if (eliminarComprobante == null) throw new Exception("No existe el tipo de comprobante");

                eliminarComprobante.EstaEliminado = !eliminarComprobante.EstaEliminado;
                context.SaveChanges();
            }
        }
    }
}

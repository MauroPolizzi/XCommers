using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32.SafeHandles;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Articulo.DTOs;
using XCommerce.LogicaNegocio.Precio.DTOs;

namespace XCommerce.LogicaNegocio.Precio
{
    class PrecioServicio
    {
        public IEnumerable<PrecioDto> ObtenerTodo(long entidadId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Precios
                    .AsNoTracking()
                    .Where(x => x.ListaPrecioId == entidadId)
                    .Select(x => new PrecioDto
                    {
                        Id = x.Id,
                        ArticuloId = x.ArticuloId,
                        EmpresaId = x.EmpresaId,
                        FechaActualizacion = x.FechaActualizacion,
                        //ListaPrecios = x.ListaPrecio,
                        NombreArticulo = x.Articulo.Descripcion,
                        PrecioCosto = x.PrecioCosto,
                        PreioPublico = x.PrecioPublico,
                        Rentabilidad = x.Rentabilidad
                    }).OrderBy(x => x.NombreArticulo).ThenBy(x => x.PrecioCosto).ToList();
            }
        }

        //========================= OBTENER POR ID ====================//
        public PrecioDto ObtenerPorId(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var precioArt = context.Precios
                    .FirstOrDefault(x => x.Id == value);

                if(precioArt == null) throw new Exception("No Articulo no tiene precio");

                return new PrecioDto
                {
                    Id = precioArt.Id,
                    ArticuloId = precioArt.ArticuloId,
                    EmpresaId = precioArt.EmpresaId,
                    FechaActualizacion = precioArt.FechaActualizacion,
                    ListaPrecioId = precioArt.ListaPrecioId,
                    PrecioCosto = precioArt.PrecioCosto,
                    PreioPublico = precioArt.PrecioPublico,
                    Rentabilidad = precioArt.Rentabilidad,
                    NombreArticulo = precioArt.Articulo.Descripcion,
                };
            }
        }

        //========================= INSERTAR ====================//
        public void Insertar(PrecioDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var precioNuevo = new AccesoDatos.Precio
                {
                    ArticuloId = dto.ArticuloId,
                    EmpresaId = dto.EmpresaId,
                    FechaActualizacion = dto.FechaActualizacion,
                    ListaPrecioId = dto.ListaPrecioId,
                    PrecioCosto = dto.PrecioCosto,
                    PrecioPublico = dto.PreioPublico,
                    Rentabilidad = dto.Rentabilidad,
                };
                context.Precios.Add(precioNuevo);
                context.SaveChanges();
            }
        }

        //========================= MODIFICAR ====================//
        public void Modificar(PrecioDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var precioModificar = context.Precios.OfType<AccesoDatos.Precio>()
                    .FirstOrDefault(x => x.Id == dto.Id);

                if(precioModificar == null) throw new Exception("No existe el precio");

                precioModificar.ListaPrecioId = dto.ListaPrecioId;
                precioModificar.FechaActualizacion = dto.FechaActualizacion;
                precioModificar.PrecioCosto = dto.PrecioCosto;
                precioModificar.PrecioPublico = dto.PreioPublico;
                precioModificar.Rentabilidad = dto.Rentabilidad;

                context.SaveChanges();
            }
        }

        //========================= ELIMINAR ====================//
        public void Eliminar(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var eliminarPrecio = context.Precios
                    .FirstOrDefault(x => x.Id == value);

                if(eliminarPrecio == null) throw new Exception("No se pudo eliminar");

                context.Precios.Remove(eliminarPrecio);

                context.SaveChanges();
            }
        }
    }
}

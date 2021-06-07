using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Marca.DTOs;

namespace XCommerce.LogicaNegocio.Marca
{
    public class MarcaServicio
    {
        //========================== OBTENER =========================//
        public IEnumerable<MarcaDto> ObtenerTodo(long empresaId , string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                int codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                return context.Marcas
                    .AsNoTracking()
                    .Where(x => x.EmpresaId == empresaId 
                    && x.EstaEliminada == false
                    && (x.Codigo == codigo || x.Descripcion.Contains(cadenaBuscar)))
                    .Select(x => new MarcaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Codigo = x.Codigo,
                        EstaEliminada = x.EstaEliminada,
                        EmpresaId = x.EmpresaId
                    }).ToList();
            }
        }

        public MarcaDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var marca = context.Marcas.OfType<AccesoDatos.Marca>()
                    .FirstOrDefault(x => x.Id == entidadId);
                if(marca == null) throw new Exception("Hubo en error al encontrar la marca");

                return new MarcaDto
                {
                    Id = marca.Id,
                    Descripcion = marca.Descripcion,
                    Codigo = marca.Codigo,
                    EstaEliminada = marca.EstaEliminada,
                    EmpresaId = marca.EmpresaId
                };
            }
        }

        //==========================  =========================//
        public int ObtenerSiguienteCodigo(long empresaId)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Marcas.OfType<AccesoDatos.Marca>().Any(x => x.EmpresaId == empresaId)
                    ? context.Marcas.OfType<AccesoDatos.Marca>()
                    .Where(x => x.EmpresaId == empresaId).Max(x => x.Codigo) + 1
                    : 1;
            }
        }

        public bool VerificarSiExiste(long empresaId, string descripcion, int codigo, long? marcaId = null)
        {
            using (var context = new ModeloDatosContainer())
            {
                if (marcaId.HasValue)
                {
                    return context.Rubros
                        .AsNoTracking()
                        .Any(x => x.EmpresaId == empresaId && x.Id != marcaId
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
        
        //========================== METODOS =========================//
        public long Insertar(MarcaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var nuevaMarca = new AccesoDatos.Marca
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    EstaEliminada = false,
                    EmpresaId = dto.EmpresaId
                };

                context.Marcas.Add(nuevaMarca);
                context.SaveChanges();

                return nuevaMarca.Id;
            }
        }

        public void Modificar(MarcaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var modificarMarca = context.Marcas.OfType<AccesoDatos.Marca>()
                    .FirstOrDefault(x => x.Id == dto.Id);
                
                modificarMarca.Codigo = dto.Codigo;
                modificarMarca.Descripcion = dto.Descripcion;
                modificarMarca.EmpresaId = dto.EmpresaId;

                context.SaveChanges();
            }
        }

        public void Eliminar(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var marcaEliminar = context.Marcas.OfType<AccesoDatos.Marca>()
                    .FirstOrDefault(x => x.Id == entidadId);

                if (marcaEliminar == null) throw new Exception("No se encontro la marca");

                marcaEliminar.EstaEliminada = !marcaEliminar.EstaEliminada;
                context.SaveChanges();
            }
        }
    }
}

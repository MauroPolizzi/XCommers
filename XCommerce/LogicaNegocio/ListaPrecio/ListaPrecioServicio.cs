using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.Pkcs;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.ListaPrecio.DTOs;

namespace XCommerce.LogicaNegocio.ListaPrecio
{
    public class ListaPrecioServicio
    {
        public IEnumerable<ListaPrecioDto> ObtenerTodo (long empresaId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                int codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                return context.ListaPrecios
                    .AsNoTracking()
                    .Where(x => x.EstaEliminada == false
                                && x.EmpresaId == empresaId && (x.Descripcion.Contains(cadenaBuscar)
                                                                || x.Codigo == codigo))
                    .Select(x => new ListaPrecioDto
                    {
                        Id = x.Id,
                        EmpresaId = x.EmpresaId,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        EstaEliminada = x.EstaEliminada,
                    }).ToList();
            }
        }

        //======================= CODIGO ====================//
        public int ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.ListaPrecios.OfType<AccesoDatos.ListaPrecio>().Any()
                    ? context.ListaPrecios.OfType<AccesoDatos.ListaPrecio>().Max(x => x.Codigo) + 1
                    : 1;
            }
        }

        //======================= ID ====================//
        public ListaPrecioDto ObtenerPorId(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var list = context.ListaPrecios
                    .FirstOrDefault(x => x.Id == value);

                if (list == null) throw new Exception("No existe la lista");

                return new ListaPrecioDto
                {
                    Id = list.Id,
                    Codigo = list.Codigo,
                    Descripcion = list.Descripcion,
                    EmpresaId = list.EmpresaId,
                    EstaEliminada = list.EstaEliminada,
                };
            }
        }

        //======================= INSERTAR ====================//
        public long Insertar(ListaPrecioDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var nuevaLista = new AccesoDatos.ListaPrecio
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    EmpresaId = dto.EmpresaId,
                    EstaEliminada = false,
                };

                context.ListaPrecios.Add(nuevaLista);
                context.SaveChanges();

                return nuevaLista.Id;
            }
        }

        //======================= MODIFICAR ====================//
        public void Modificar(ListaPrecioDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var listaModificar = context.ListaPrecios
                    .FirstOrDefault(x => x.Id == dto.Id);

                if(listaModificar == null) throw new Exception("Error al modificar");

                listaModificar.Descripcion = dto.Descripcion;
               

                context.SaveChanges();
            }
            
        }

        //======================= ELIMINAR ====================//
        public void Eliminar(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var eliminarLista = context.ListaPrecios
                    .FirstOrDefault(x => x.Id == value);

                if (eliminarLista == null) throw new Exception("Error al eliminar");

                eliminarLista.EstaEliminada = !eliminarLista.EstaEliminada;

                context.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Perfil.DTOs;

namespace XCommerce.LogicaNegocio.Perfil
{
    public class PerfilServicio
    {
        public object ObtenerTodo(string cadenaBuscar, long empresaId)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Perfiles
                    .AsNoTracking()
                    .Where(x => x.EmpresaId == empresaId && x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new PerfilDto
                    {
                        Id = x.Id,
                        EmpresaId = x.EmpresaId,
                        Descripcion = x.Descripcion,
                        //CantidadUsuarios = x.
                    }).ToList();
            }
        }

        public PerfilDto ObtenerPorId(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var perfil = context.Perfiles
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == value);

                if(perfil == null) throw new Exception("El perfil no existe");

                return new PerfilDto
                {
                    EmpresaId = perfil.EmpresaId,
                    Descripcion = perfil.Descripcion,
                    Id = perfil.Id
                };
            }
        }

        public long Insertar(PerfilDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var perfilNuevo = new AccesoDatos.Perfil
                {
                    EmpresaId = dto.EmpresaId,
                    Descripcion = dto.Descripcion,
                };

                context.Perfiles.Add(perfilNuevo);

                context.SaveChanges();

                return perfilNuevo.Id;
            }
        }

        public void Modificar(PerfilDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var modificarPerfil = context.Perfiles
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (modificarPerfil == null) throw new Exception("El perfil no existe");


                modificarPerfil.Descripcion = dto.Descripcion;
                modificarPerfil.EmpresaId = dto.EmpresaId;

                context.SaveChanges();
            }
        }

        public void Eliminar(long perfilId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var perfil = context.Perfiles
                    .FirstOrDefault(x => x.Id == perfilId);

                if(perfil == null) throw new Exception("No se encontro el perfil");

                context.Perfiles.Remove(perfil);
                context.SaveChanges();
            }
        }
    }
}

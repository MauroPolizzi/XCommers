using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.UsuarioPerfil.DTOs;

namespace XCommerce.LogicaNegocio.UsuarioPerfil
{
    public class UsuarioPerfilServicio
    {
        public IEnumerable<UsuarioPerfilDto> ObtenerUsuarioNoAsignado(string cadenaBuscar, long _perfilId)
        {
            using (var context = new ModeloDatosContainer())
            {
                //===> OBTENER TODOS LOS USUARIOS
                
                var usuarios = context.Usuarios
                    .Include("Empleado")
                    .AsNoTracking()
                    .Select(x => new UsuarioPerfilDto
                    {
                        ApellidoEmpleado = x.Empleado.Apellido,
                        NombreEmpleado = x.Empleado.Nombre,
                        DniEmpleado = x.Empleado.Dni,
                        Usuario = x.Nombre,
                        UsuarioId = x.Id,
                        Item = false
                    }).ToList();

                //===> OBTENER LOS USUARIOS ASIGNADOS
                var usuarioAsignado = context.Usuarios
                    .Include("Empelado")
                    .Include("Perfiles")
                    .AsNoTracking()
                    .Where(x => x.Perfiles.Any(p => p.Id == _perfilId))
                    .Select(x => new UsuarioPerfilDto
                    {
                        ApellidoEmpleado = x.Empleado.Apellido,
                        NombreEmpleado = x.Empleado.Nombre,
                        DniEmpleado = x.Empleado.Dni,
                        Usuario = x.Nombre,
                        UsuarioId = x.Id,
                        Item = false
                    })
                    .ToList();

                //===> COMPARAMOS LOS DOS PARA VER CUAL FALTA 

                var resultado = usuarios
                    .Except(usuarioAsignado, new UsuarioPerfilCompare())
                    .Where(x => x.ApellidoEmpleado.Contains(cadenaBuscar)
                                || x.DniEmpleado == cadenaBuscar
                                || x.NombreEmpleado.Contains(cadenaBuscar)
                                || x.Usuario.Contains(cadenaBuscar))
                    .ToList();

                return resultado;
            }
        }

        public IEnumerable<UsuarioPerfilDto> ObtenerUsuariosAsignados(long _perfilId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                var usuriosAsignado = context.Usuarios
                    .Include("Prefiles")
                    .Include("Empleado")
                    .AsNoTracking()
                    .Where(x => x.Perfiles.Any(p => p.Id == _perfilId))
                    .Select(x => new UsuarioPerfilDto
                    {
                        ApellidoEmpleado = x.Empleado.Apellido,
                        NombreEmpleado = x.Empleado.Nombre,
                        DniEmpleado = x.Empleado.Dni,
                        Item = false,
                        Usuario = x.Nombre,
                        UsuarioId = x.Id,
                    }).ToList();

                var resultado = usuriosAsignado
                    .Where(x => x.ApellidoEmpleado.Contains(cadenaBuscar)
                                || x.NombreEmpleado.Contains(cadenaBuscar)
                                || x.DniEmpleado == cadenaBuscar
                                || x.Usuario.Contains(cadenaBuscar)).ToList();

                return resultado;
            }
        }

        public void AsignarUsuario(long _perfilId, List<UsuarioPerfilDto> listaUsuario)
        {
            using (var context = new ModeloDatosContainer())
            {
                //=======>> OBTENGO EL PERFIL POR ID

                var perfil = context.Perfiles.FirstOrDefault(x => x.Id == _perfilId);

                if(perfil == null) throw new Exception("No se encontro el perfil");

                //===>> UBICAMOS EL USUARIO EN LA LISTA

                foreach (var usu in listaUsuario)
                {
                    var usuario = context.Usuarios.FirstOrDefault(x => x.Id == usu.UsuarioId);

                    perfil.Usuarios.Add(usuario);
                }
                context.SaveChanges();
            }
        }

        public void QuitarUsuario(long perfilId, List<UsuarioPerfilDto> listaUsuarios)
        {
            using (var context = new ModeloDatosContainer())
            {
                //======>> BUSCO EL PERFIL POR ID
                var perfil = context.Perfiles.FirstOrDefault(x => x.Id == perfilId);

                if(perfil == null) throw new Exception("No se encontro el perfil");

                //=====>> UBICAMOS EL USUARIO
                foreach (var usu in listaUsuarios)
                {
                    var usuario = context.Usuarios.FirstOrDefault(x => x.Id == usu.UsuarioId);

                    perfil.Usuarios.Remove(usuario);
                }

                context.SaveChanges();
            }
        }
    }

}

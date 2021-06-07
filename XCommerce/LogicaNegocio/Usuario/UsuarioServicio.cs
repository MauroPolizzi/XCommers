using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using XCommerce.AccesoDatos;
using XCommerce.Base.Clases;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Usuario.DTOs;

namespace XCommerce.LogicaNegocio.Usuario
{
    public class UsuarioServicio
    {
        public IEnumerable<UsuarioDto> ObtenerTodo(string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                int legajo = -1;
                int.TryParse(cadenaBuscar, out legajo);

                return context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Include(x => x.Usuarios)
                    .Where(x => x.EstaEliminado == false &&
                                (x.Nombre.Contains(cadenaBuscar)
                                || x.Apellido.Contains(cadenaBuscar)
                                || x.Dni == cadenaBuscar
                                || x.Legajo == legajo
                                || x.Usuarios.Any(u => u.Nombre.Contains(cadenaBuscar))))
                    .Select(x => new UsuarioDto
                    {
                        Item = false,
                        EmpleadoId = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        UsuarioId = x.Usuarios.Any() ? x.Usuarios.FirstOrDefault().Id : (long?) null,
                        NombreUsuario = x.Usuarios.Any() ? x.Usuarios.FirstOrDefault().Nombre : "NO ASIGNADO",
                        Bloqueado = x.Usuarios.Any() && x.Usuarios.FirstOrDefault().EstaBloqueado
                    }).OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                    .ToList();
            }
        }
        
        public void CrearUsuario(List<UsuarioDto> listaUsuario)
        {
            using (var context = new ModeloDatosContainer())
            {
                foreach (var usuario in listaUsuario)
                {
                    var nombreUsuario = GenerarNombreUsuario(usuario.Nombre, usuario.Apellido);
                    
                    var nuevoUsuario = new AccesoDatos.Usuario
                    {
                        Nombre = nombreUsuario,
                        EmpleadoId = usuario.EmpleadoId,
                        EstaBloqueado = false,
                        Password = Encriptar.EncriptarCadena(ConstanteSeguridad.PasswordPorDefecto)
                    };
                    context.Usuarios.Add(nuevoUsuario);
                }
                context.SaveChanges();
            }
        }

        private string GenerarNombreUsuario(string nombre, string apellido)
        {
            var contador = 1;

            var nombreUsuario =
                $"{nombre.Trim().ToLower().Substring(0, contador)}{apellido.Trim().ToLower()}";

            using (var context = new ModeloDatosContainer())
            {
                while (context.Usuarios.Any(x => x.Nombre == nombreUsuario))
                {
                    contador++;
                    nombreUsuario =
                        $"{nombre.Trim().ToLower().Substring(0, contador)}{apellido.Trim().ToLower()}";
                }
            }
            return nombreUsuario;
        }

        public void BloquearDesbloquear(List<UsuarioDto> list)
        {
            using (var context = new ModeloDatosContainer())
            {
                foreach (var usuario in list)
                {
                    var usuarioParaBloqDesbloq = context.Usuarios
                        .FirstOrDefault(x => x.Id == usuario.UsuarioId);

                    if (usuarioParaBloqDesbloq == null) throw new Exception("No se encontro el usuario");

                    usuarioParaBloqDesbloq.EstaBloqueado = !usuarioParaBloqDesbloq.EstaBloqueado;
                }
                context.SaveChanges();
            }
        }

        public void CambiarPassword(long usuarioLoginId, string passwordActual, string passwordNueva)
        {
            using (var context = new ModeloDatosContainer())
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == usuarioLoginId);

                if(usuario == null) throw new Exception("El usuario no existe");

                var passActual = Encriptar.EncriptarCadena(passwordActual);
                var passNueva = Encriptar.EncriptarCadena(passwordNueva);

                if (usuario.Password != passActual) throw new Exception("La contraseña actual es incorrecta");

                usuario.Password = passNueva;
                context.SaveChanges();
            }
        }

        public void ResetContraseña(List<UsuarioDto> list)
        {
            using (var context = new ModeloDatosContainer())
            {
                foreach (var usuarioDto in list)
                {
                    var usuario = context.Usuarios.OfType<AccesoDatos.Usuario>()
                        .FirstOrDefault(x => x.Id == usuarioDto.UsuarioId);

                    if(usuario == null) throw new Exception("No existe el usuario");

                    usuario.Password = Encriptar.EncriptarCadena(ConstanteSeguridad.PasswordPorDefecto);
                }
                context.SaveChanges();
            }
        }

        public void CambiarEstado(string usuario)
        {
            using (var context = new ModeloDatosContainer())
            {
                var usuarioEnontrado = context.Usuarios.OfType<AccesoDatos.Usuario>()
                    .FirstOrDefault(x => x.Nombre == usuario);

                if(usuarioEnontrado == null) throw new Exception("No se encontro el usuario");

                usuarioEnontrado.EstaBloqueado = true;
                context.SaveChanges();
            }
        }
    }
}

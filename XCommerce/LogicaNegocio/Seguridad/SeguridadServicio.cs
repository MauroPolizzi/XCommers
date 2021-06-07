using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Base.Clases;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Usuario.DTOs;

namespace XCommerce.LogicaNegocio.Seguridad
{
    public class SeguridadServicio
    {
        public UsuarioDto VerificarAccesoAlSistema(string usuario, string password)
        {
            using (var context = new ModeloDatosContainer())
            {
                if (usuario == ConstanteSeguridad.UsuarioAdministrador
                    && password == ConstanteSeguridad.PasswordAdministrador)
                {
                    return new UsuarioDto
                    {
                        Apellido = string.Empty,
                        Nombre = "Administrador",
                        Bloqueado = false,
                        EmpleadoId = 0,
                        Foto = Properties.Resources.Usuario,
                        NombreUsuario = ConstanteSeguridad.UsuarioAdministrador,
                        UsuarioId = 0,
                    };
                }
                else
                {
                    var usuarioLogin = context.Usuarios
                        .AsNoTracking()
                        .Include("Empleado")
                        .FirstOrDefault(x => x.Nombre == usuario && x.Password == password);

                    if (usuarioLogin != null)
                    {
                        return new UsuarioDto
                        {
                            UsuarioId = usuarioLogin.Id,
                            NombreUsuario = usuario,
                            Apellido = usuarioLogin.Empleado.Apellido,
                            Nombre = usuarioLogin.Empleado.Nombre,
                            Bloqueado = usuarioLogin.EstaBloqueado,
                            EmpleadoId = usuarioLogin.EmpleadoId,
                            Foto = Imagen.Convertir_Bytes_Imagen(usuarioLogin.Empleado.Foto),
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}

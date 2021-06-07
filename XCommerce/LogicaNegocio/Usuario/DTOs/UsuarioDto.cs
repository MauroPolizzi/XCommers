
using System.Drawing;

namespace XCommerce.LogicaNegocio.Usuario.DTOs
{
    public class UsuarioDto
    {
        // Datos del Empleado
        public long EmpleadoId { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public Image Foto { get; set; }

        public bool Item { get; set; }

        public string ApyNomEmpleado => $"{Apellido} {Nombre}";

        // Datos del Usuario
        public long? UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public bool Bloqueado { get; set; }
        public string BloqueadoStr => Bloqueado ? "SI" : "NO";
    }
}

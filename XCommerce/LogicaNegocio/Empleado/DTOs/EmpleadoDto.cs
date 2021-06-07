using System;

namespace XCommerce.LogicaNegocio.Empleado.DTOs
{
    public class EmpleadoDto
    {
        public long Id { get; set; }
        public bool Item { get; set; }
        public int Legajo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public string ApyNom => $"{Apellido} {Nombre}";

        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public byte[] Foto { get; set; }
        public bool Eliminado { get; set; }
    }
}

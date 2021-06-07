using System;

namespace XCommerce.LogicaNegocio.Cliente.DTOs
{
    public class ClienteDto
    {
        public long Id { get; set; }
        public bool Item { get; set; }
        //public int Legajo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public string ApyNom => $"{Apellido} {Nombre}";

        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public bool EstaEliminado { get; set; }
        public bool EstaBloqueado { get; set; }

        public string EstaBloqueadoStr => EstaEliminado ? "SI" : "NO";
        public decimal MontoMaximoCompra { get; set; }
        public bool TieneCuentaCorriente { get; set; }

        public string TieneCuentaCorrienteStr => TieneCuentaCorriente ? "SI" : "NO";
    }
}

using System;

namespace XCommerce.LogicaNegocio.Tarjeta.DTOs
{
    public class TarjetaDto
    {
        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstaEliminado { get; set; }
        public string EstaEliminadoStr => EstaEliminado ? "Si" : "NO";
    }
}

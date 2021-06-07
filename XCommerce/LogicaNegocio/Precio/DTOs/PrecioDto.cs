using System;

namespace XCommerce.LogicaNegocio.Precio.DTOs
{
    public class PrecioDto
    {
        public long Id { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PreioPublico { get; set; }
        public decimal Rentabilidad { get; set; }
        public long EmpresaId { get; set; }
        public long ArticuloId { get; set; }
        public string NombreArticulo { get; set; }
        public long ListaPrecioId { get; set; }

        //public List<ListaPrecioDto> ListaPrecios { get; set; }
    }
}

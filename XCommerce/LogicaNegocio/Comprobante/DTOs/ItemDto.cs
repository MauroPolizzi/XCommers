namespace XCommerce.LogicaNegocio.Comprobante.DTOs
{
    public class ItemDto
    {
        public long? Id { get; set; }
        public long ArticuloId { get; set; }

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Cantidad { get; set; }

        public decimal SubTotal => PrecioUnitario * Cantidad;
    }
}

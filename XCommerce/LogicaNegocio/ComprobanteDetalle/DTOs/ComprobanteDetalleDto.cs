namespace XCommerce.LogicaNegocio.ComprobanteDetalle.DTOs
{
    public class ComprobanteDetalleDto
    {
        public long Id { get; set; }
        public long ComprobanteId { get; set; }
        public string Codigo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public long ArticuloId { get; set; }
        public string ArticuloDescripcion { get; set; }
    }
}

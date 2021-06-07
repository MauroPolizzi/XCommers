namespace XCommerce.LogicaNegocio.Articulo.DTOs
{
    public class StockDto
    {
        public long Id { get; set; }
        public long DepositoId { get; set; }
        public long ArticuloId { get; set; }
        public string DescripcionArticulo  { get; set; }
        public decimal Cantidad { get; set; }
    }
}

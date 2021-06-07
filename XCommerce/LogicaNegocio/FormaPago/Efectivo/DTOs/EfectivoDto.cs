using XCommerce.AccesoDatos;

namespace XCommerce.LogicaNegocio.FormaPago.Efectivo.DTOs
{
    public class EfectivoDto
    {
        public long Id { get; set; }
        public long ComprobanteId { get; set; }
        public decimal Monto { get; set; }
        public TipoFormaPago TipoFormaPago { get; set; }
    }
}

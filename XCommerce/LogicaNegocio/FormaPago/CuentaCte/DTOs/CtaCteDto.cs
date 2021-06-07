using XCommerce.AccesoDatos;

namespace XCommerce.LogicaNegocio.FormaPago.CuentaCte.DTOs
{
    public class CtaCteDto
    {
        public long Id { get; set; }
        public long ComprobanteId { get; set; }
        public TipoFormaPago TipoFormaPago { get; set; }
        public decimal Monto { get; set; }
        public long ClienteId { get; set; }
    }
}

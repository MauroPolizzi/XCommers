using System;

namespace XCommerce.LogicaNegocio.Comprobante.Factura.DTOs
{
    public class ComprobanteFacturaDto
    {
        public long Id { get; set; }
        public long Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public long EmpresaId { get; set; }
        public long UsuarioId { get; set; }
        public long ClienteId { get; set; }
        public long TipoComprobanteId { get; set; }
    }
}

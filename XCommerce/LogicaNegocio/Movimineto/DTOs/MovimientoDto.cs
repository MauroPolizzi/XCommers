using System;
using XCommerce.AccesoDatos;

namespace XCommerce.LogicaNegocio.Movimineto.DTOs
{
    public class MovimientoDto
    {
        public long Id { get; set; }
        public long ComprobanteId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public long CajaId { get; set; }
        public long UsuarioId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}

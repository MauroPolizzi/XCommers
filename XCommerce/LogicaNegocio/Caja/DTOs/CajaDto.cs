using System;

namespace XCommerce.LogicaNegocio.Caja.DTOs
{
    public class CajaDto
    {
        public long Id { get; set; }
        public long UsuarioApertura { get; set; }
        public string UsuarioAperturaNom { get; set; }
        public long? UsuarioCierre { get; set; }
        public string UsuarioCierreNom { get; set; }
        public decimal MontoApertura { get; set; }
        public decimal? MontoCierre { get; set; }

        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public decimal? MontoSistema { get; set; }
        public decimal? Diferencia { get; set; }

        public long EmpresaId { get; set; }
    }
}

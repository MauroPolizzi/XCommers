namespace XCommerce.LogicaNegocio.Configuracion.DTOs
{
    public class ConfiguracionDto
    {
        public long Id { get; set; }
        public long EmpresaId { get; set; }
        public long TipoComprobantePorDefectoId { get; set; }
        public long ListaPrecioPorDefectoId { get; set; }
        public long DepositoPorDefectoId { get; set; }
        public bool PuestoDeCajaSeparado { get; set; }
        public bool SeCobraCubiertos { get; set; }
        public decimal MontoPorCubierto { get; set; }
        public long ClientePorDefectoId { get; set; }
        public bool GrabarProductoEnTodosDepositos { get; set; }
    }
}

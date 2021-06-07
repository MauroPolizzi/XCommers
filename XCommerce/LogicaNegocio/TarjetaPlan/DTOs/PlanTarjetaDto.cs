namespace XCommerce.LogicaNegocio.TarjetaPlan.DTOs
{
    public class PlanTarjetaDto
    {
        public long Id { get; set; }
        public long TarjetaId { get; set; }
        public string Descripcion { get; set; }
        public decimal Alicuota { get; set; }
    }
}

namespace XCommerce.LogicaNegocio.TipoComprobante.DTOs
{
    public class TipoComprobanteDto
    {
        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Letra { get; set; }
        public bool EstaEliminado { get; set; }
        public long EmpresaId { get; set; }

        public string EstaEliminadoStr => EstaEliminado ? "SI" : "NO";
    }
}

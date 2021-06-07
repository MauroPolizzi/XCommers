namespace XCommerce.LogicaNegocio.Sala.DTOs
{
    public class SalaDto
    {
        public long Id { get; set; }
        public long EmpresaId { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Empresa { get; set; }
        public bool EstaEliminada { get; set; }
        public int CantidadMesas { get; set; }

        public string EstaEliminadaStr => EstaEliminada ? "SI" : "NO";
    }
}

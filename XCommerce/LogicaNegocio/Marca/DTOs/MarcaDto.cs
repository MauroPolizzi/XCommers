namespace XCommerce.LogicaNegocio.Marca.DTOs
{
    public class MarcaDto
    {
        public long Id { get; set; }
        public long EmpresaId { get; set; }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstaEliminada { get; set; }

        public string EstaEliminadaStr => EstaEliminada ? "SI" : "NO";
    }
}

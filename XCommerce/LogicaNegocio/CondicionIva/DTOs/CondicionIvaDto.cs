namespace XCommerce.LogicaNegocio.CondicionIva.DTOs
{
    public class CondicionIvaDto
    {
        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstaEliminada { get; set; }

        public string EstaEliminadaStr => EstaEliminada ? "SI" : "NO";
    }
}

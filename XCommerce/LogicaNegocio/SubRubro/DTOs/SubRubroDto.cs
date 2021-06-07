namespace XCommerce.LogicaNegocio.SubRubro.DTOs
{
    public class SubRubroDto
    {
        public long Id { get; set; }
        public long RubroId { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstaEliminado { get; set; }
        public string Rubro { get; set; }   
        public string EstaEliminadoStr => EstaEliminado ? "SI" : "NO";
    }
}

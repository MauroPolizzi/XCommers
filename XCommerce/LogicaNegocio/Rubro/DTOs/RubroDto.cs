namespace XCommerce.LogicaNegocio.Rubro.DTOs
{
    public class RubroDto
    {
        public long Id { get; set; }
        public long EmpresaId { get; set; }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstaEliminado { get; set; }

        public string EstaEliminadoStr => EstaEliminado ? "SI" : "NO";
    }
}

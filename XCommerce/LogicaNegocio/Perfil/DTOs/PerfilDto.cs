namespace XCommerce.LogicaNegocio.Perfil.DTOs
{
    public class PerfilDto
    {
        public long Id { get; set; }
        public long EmpresaId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadUsuarios { get; set; }
    }
}

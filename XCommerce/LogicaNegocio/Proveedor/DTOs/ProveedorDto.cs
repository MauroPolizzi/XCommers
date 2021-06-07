namespace XCommerce.LogicaNegocio.Proveedor.DTOs
{
    public class ProveedorDto
    {
        public long Id {get;set;}
        public string RazonSocial {get;set;}
        public string Direccion {get;set;}
        public string Telefono {get;set;}
        public string Email {get;set;}
        public string CondicionIva { get; set; }
        public long CondicionIvaId {get;set;}
    }
}

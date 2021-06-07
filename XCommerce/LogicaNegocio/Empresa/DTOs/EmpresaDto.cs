namespace XCommerce.LogicaNegocio.Empresa.DTOs
{
    public class EmpresaDto
    {
        public long Id { get; set; }
        public int Sucursal { get; set; }
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string Cuit { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public long CondicionIvaId { get; set; }
        public string CondicionIva { get; set; }
        public byte[] Logo { get; set; }

        public string NombreCompleto => $"{Sucursal.ToString().PadLeft(5, '0')} - {RazonSocial}";

        public string NombreCompletoConCuit => $"{Sucursal.ToString().PadLeft(5, '0')} - {RazonSocial} - CUIT: {Cuit}";
    }
}

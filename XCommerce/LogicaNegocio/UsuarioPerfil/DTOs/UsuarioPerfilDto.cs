namespace XCommerce.LogicaNegocio.UsuarioPerfil.DTOs
{
    public class UsuarioPerfilDto
    {
        public bool Item { get; set; }

        public long UsuarioId { get; set; }
        public string Usuario { get; set; }

        public string ApellidoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string DniEmpleado { get; set; }

        public string ApyNomEmpleado => $"{ApellidoEmpleado} {NombreEmpleado}";

    }
}

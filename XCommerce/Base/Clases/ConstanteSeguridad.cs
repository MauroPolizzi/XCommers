namespace XCommerce.Base.Clases
{
    public static class ConstanteSeguridad
    {
        public static int CantidadIngresosFallidos = 3;

        private static string _password = @"P$assword";
        // ================================================ //
        private static string _usuarioAdmin = @"admin";
        private static string _passwordAdmin = @"123";
        // ================================================ //
        public static string PasswordPorDefecto => $"{_password}";
        // ================================================ //
        public static string UsuarioAdministrador => $"{_usuarioAdmin}";
        public static string PasswordAdministrador => $"{_passwordAdmin}";
    }
}

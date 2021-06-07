using System.Drawing;

namespace XCommerce.Base.Helpers
{
    public static class Identidad
    {
        // ================================================================= //
        // =============          Datos del Usuario          =============== //
        // ================================================================= //
        public static string UsuarioLogin { get; set; }
        public static long UsuarioLoginId { get; set; }

        // ================================================================= //
        // =============          Datos del Empleado         =============== //
        // ================================================================= //
        public static string ApellidoEmpleado { get; set; }
        public static string NombreEmpleado { get; set; }
        public static Image Foto { get; set; }
        public static string ApyNomEmpleadoLogin => $"{ApellidoEmpleado} {NombreEmpleado}";
        public static long EmpleadoLoginId { get; set; }

        // ================================================================= //
        // =============        Datos de la Empresa          =============== //
        // ================================================================= //
        public static long EmpresaId { get; set; }
        public static string Empresa { get; set; }
        public static Image LogoEmpresa { get; set; }
    }
}

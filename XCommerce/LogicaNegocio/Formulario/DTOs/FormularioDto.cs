namespace XCommerce.LogicaNegocio.Formulario.DTOs
{
    public class FormularioDto
    {
        public long Id  { get; set; }

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCompleta { get; set; }

        public bool Existe { get; set; }
        public string ExisteStr => Existe ? "SI" : "NO";
    }
}

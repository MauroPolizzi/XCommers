using System.Windows.Forms;
using XCommerce.AccesoDatos;

namespace XCommerce.LogicaNegocio.Mesa.DTOs
{
    public class MesaDto
    {
        public long Id { get; set; }
        public long SalaId  { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Sala { get; set; }



        public EstadoMesa EstadoMesa { get; set; }
        public decimal Monto { get; set; }
    }
}

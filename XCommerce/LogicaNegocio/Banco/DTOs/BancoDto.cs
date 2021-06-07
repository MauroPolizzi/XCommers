using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.LogicaNegocio.Banco.DTOs
{
    public class BancoDto
    {
        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstaEliminado { get; set; }
    }
}

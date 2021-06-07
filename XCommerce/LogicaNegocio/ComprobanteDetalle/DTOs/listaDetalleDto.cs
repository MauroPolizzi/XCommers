using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.LogicaNegocio.ComprobanteDetalle.DTOs
{
    public class listaDetalleDto
    {
        public long ArticuloId { get; set; }
        public decimal Cantidad { get; set; }
        public int Codigo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.LogicaNegocio.CuentaCorriente.DTOs
{
    public class CuentaCorrienteDto
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
    }
}

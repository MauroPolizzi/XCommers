using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.LogicaNegocio.CuentaCorrienteProveedor.DTOs
{
    public class CtaCteProveedorDto
    {
        public long Id { get; set; }
        public long ProveedorId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

    }
}

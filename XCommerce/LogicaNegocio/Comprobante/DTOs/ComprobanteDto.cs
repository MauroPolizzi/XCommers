using System;
using System.Collections.Generic;
using System.Linq;

namespace XCommerce.LogicaNegocio.Comprobante.DTOs
{
    public class ComprobanteDto
    {
        public ComprobanteDto()
        {
            Items = new List<ItemDto>();
        }

        public long Id { get; set; }
        public long EmpresaId { get; set; }

        public long? EmpleadoId { get; set; }
        public int CodigoEmpleado { get; set; }
        public string ApyNomEmpleado { get; set; }

        public long UsuarioId { get; set; }
        public long ClienteId { get; set; }

        public long TipoComprobanteId { get; set; }
        public long MesaId { get; set; }
        
        public DateTime Fecha { get; set; }
        public int Comensales { get; set; }

        public decimal SubTotal => Items.Sum(x => x.SubTotal);
        
        public decimal Descuento { get; set; }

        public decimal Total => SubTotal - Descuento;

        public List<ItemDto> Items { get; set; }
    }
}

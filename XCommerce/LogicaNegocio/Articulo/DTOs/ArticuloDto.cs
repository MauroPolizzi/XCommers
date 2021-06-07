using System.Collections.Generic;
using XCommerce.AccesoDatos;

namespace XCommerce.LogicaNegocio.Articulo.DTOs
{
    public class ArticuloDto
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public long MarcaId { get; set; }
        public string Marca { get; set; }
        public long RubroId { get; set; }
        public string Rubro { get; set; }
        public long SubRubroId { get; set; }
        public string SubRubro { get; set; }
        public byte[] Foto { get; set; }
        public bool ActivarLimiteVenta { get; set; }
        public decimal CantidadLimiteVenta { get; set; }
        public bool PermiteStockNegativo { get; set; }
        public bool EstaDiscontinuado { get; set; }
        public TipoArticulo TipoArticulo { get; set; }
        public decimal StockMaximo { get; set; }
        public decimal StockMinimo { get; set; }
        public bool DescuentaStock { get; set; }
        public bool SePuedeFraccionar { get; set; }
        public string Detalle { get; set; }
        public bool EstaEliminado { get; set; }
        public string EstaEliminadoStr => EstaEliminado ? "SI" : "NO";

        //public decimal Stock { get; set; }
        public List<StockDto> Stock { get; set; }

        public long EmpresaId { get; set; }


        public decimal Cantidad { get; set; }
        public decimal PrecioPublico { get; set; }

    }
}

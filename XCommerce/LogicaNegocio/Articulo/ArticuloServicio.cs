using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Articulo.DTOs;
using XCommerce.LogicaNegocio.Precio.DTOs;

namespace XCommerce.LogicaNegocio.Articulo
{
    public class ArticuloServicio
    {
        public IEnumerable<ArticuloDto> ObtenerTodo(long empresaId ,string cadenaBuscar, bool? estado = false)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Articulos.OfType<AccesoDatos.Articulo>()
                    .Include(x => x.Marca)
                    .Include(x => x.SubRubro)
                    .Include(x => x.SubRubro.Rubro)
                    .Include(x=> x.Stocks)
                    .Include("Stock.Deposito")
                    .AsNoTracking()
                    .Where(x => x.EstaEliminado == false &&
                    x.Stocks.Any(s => s.Deposito.EmpresaId == empresaId)
                    && x.Descripcion.Contains(cadenaBuscar)
                                || x.CodigoBarra == cadenaBuscar
                                || x.Abreviatura.Contains(cadenaBuscar))
                    .Select(x => new ArticuloDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        //Codigo = x.Stocks.FirstOrDefault(y => y.ArticuloId == x.Id).Cantidad,
                        CodigoBarra = x.CodigoBarra,
                        Abreviatura = x.Abreviatura,
                        Descripcion = x.Descripcion,
                        Marca = x.Marca.Descripcion,
                        MarcaId = x.MarcaId,
                        Rubro = x.SubRubro.Rubro.Descripcion,
                        RubroId = x.SubRubro.RubroId,
                        SubRubro = x.SubRubro.Descripcion,
                        SubRubroId = x.SubRubroId,
                        Foto = x.Foto,
                        ActivarLimiteVenta = x.ActivarLimiteVenta,
                        CantidadLimiteVenta = x.CantidadLimiteVenta,
                        PermiteStockNegativo = x.PermiteStockNegativo,
                        EstaDiscontinuado = x.EstaDiscontinuado,
                        TipoArticulo = x.TipoArticulo,
                        StockMinimo = x.StockMinimo,
                        StockMaximo = x.StockMaximo,
                        DescuentaStock = x.DescuentaStock,
                        SePuedeFraccionar = x.SePuedeFraccionar,
                        Detalle = x.Detalle,
                        EstaEliminado = x.EstaEliminado,
                        EmpresaId = empresaId
                        //Stock = x.Stocks
                    }).ToList();
            }
        }

        public StockDto ObtenreStockArticulo(long articuloId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var stockArticulo = context.Stocks
                    .Include(x => x.Articulo)
                    .FirstOrDefault(x => x.ArticuloId == articuloId);

                return new StockDto
                {
                    Id = stockArticulo.Id,
                    ArticuloId = stockArticulo.ArticuloId,
                    Cantidad = stockArticulo.Cantidad,
                    DepositoId = stockArticulo.DepositoId,
                    DescripcionArticulo = stockArticulo.Articulo.Descripcion,
                };
            }
        }

        //============================ ID ===============================//
        public ArticuloDto ObtenrePorId(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var articulo = context.Articulos
                    .Include(x => x.Marca)
                    .Include(x => x.SubRubro)
                    .Include(x => x.SubRubro.Rubro)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == value);

                if(articulo == null) throw new Exception("No Existe ningun articulo");

                return new ArticuloDto
                {
                    Id = articulo.Id,
                    Codigo = articulo.Codigo,
                    CodigoBarra = articulo.CodigoBarra,
                    Abreviatura = articulo.Abreviatura,
                    Descripcion = articulo.Descripcion,
                    Marca = articulo.Marca.Descripcion,
                    MarcaId = articulo.MarcaId,
                    Rubro = articulo.SubRubro.Rubro.Descripcion,
                    RubroId = articulo.SubRubro.RubroId,
                    SubRubro = articulo.SubRubro.Descripcion,
                    SubRubroId = articulo.SubRubroId,
                    Foto = articulo.Foto,
                    ActivarLimiteVenta = articulo.ActivarLimiteVenta,
                    CantidadLimiteVenta = articulo.CantidadLimiteVenta,
                    PermiteStockNegativo = articulo.PermiteStockNegativo,
                    EstaDiscontinuado = articulo.EstaDiscontinuado,
                    TipoArticulo = articulo.TipoArticulo,
                    StockMinimo = articulo.StockMinimo,
                    StockMaximo = articulo.StockMaximo,
                    DescuentaStock = articulo.DescuentaStock,
                    SePuedeFraccionar = articulo.SePuedeFraccionar,
                    Detalle = articulo.Detalle,
                    EstaEliminado = articulo.EstaEliminado
                };
            }
        }

        public IEnumerable<PrecioDto> ObtenerArticuloPrecio(long empresaId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                var PreciosReturn = new List<PrecioDto>();

                var precios = context.Precios.Where(x => x.EmpresaId == empresaId
                && (x.Articulo.Descripcion.Contains(cadenaBuscar)
                || x.Articulo.Abreviatura.Contains(cadenaBuscar)
                || x.Articulo.CodigoBarra == cadenaBuscar)).ToList();

                foreach (var precio in precios)
                {
                    if (PreciosReturn.Count == 0)
                    {
                        PreciosReturn.Add(new PrecioDto
                        {
                            ArticuloId = precio.ArticuloId,
                            FechaActualizacion = precio.FechaActualizacion,
                            NombreArticulo = precio.Articulo.Descripcion,
                            PreioPublico = precio.PrecioPublico,
                        });
                    }
                    else
                    {
                        if (PreciosReturn.Any(x => x.ArticuloId != precio.ArticuloId))
                        {
                            PreciosReturn.Add(new PrecioDto
                            {
                                ArticuloId = precio.ArticuloId,
                                FechaActualizacion = precio.FechaActualizacion,
                                NombreArticulo = precio.Articulo.Descripcion,
                                PreioPublico = precio.PrecioPublico,
                            });
                        }
                        else
                        {
                            if (PreciosReturn.Max(x => x.FechaActualizacion) < precio.FechaActualizacion)
                            {
                                var preciossss = PreciosReturn.FirstOrDefault(x => x.ArticuloId == precio.ArticuloId);
                                preciossss.FechaActualizacion = precio.FechaActualizacion;
                                preciossss.PreioPublico = precio.PrecioPublico;
                            }
                        }
                    }
                }
                return PreciosReturn;
            }
        }

        //============================ STOCK ===============================//
        public void AgregarStock(StockDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var nuevoStock = new AccesoDatos.Stock
                {
                    Id = dto.Id,
                    ArticuloId = dto.ArticuloId,
                    DepositoId = dto.DepositoId,
                    Cantidad = dto.Cantidad,
                };

                context.Stocks.Add(nuevoStock);

                context.SaveChanges();
            }
        }

        
        public IEnumerable<StockDto> ObtenerPorDeposito(long depositoId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Stocks
                    .Include(x => x.Articulo)
                    .AsNoTracking()
                    .Where(x => x.DepositoId == depositoId
                    && x.Articulo.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new StockDto
                    {
                        Id = x.Id,
                        ArticuloId = x.ArticuloId,
                        DescripcionArticulo = x.Articulo.Descripcion,
                        Cantidad = x.Cantidad,
                        DepositoId = x.DepositoId,
                    }).ToList();
            }
        }
        public StockDto ObtenerArticuloDeposito(long depositoId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                var stock = context.Stocks
                    .Include(x => x.Articulo)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.DepositoId == depositoId
                                && x.Articulo.Descripcion.Contains(cadenaBuscar));

                if (stock == null) throw new Exception("No existe");

                    return new StockDto
                    {
                        //Id = stock.
                        //ArticuloId = x.ArticuloId,
                        //DescripcionArticulo = x.Articulo.Descripcion,
                        //Cantidad = x.Cantidad,
                        //DepositoId = x.DepositoId,
                    };
            }
        }

        public void AumentarStock(StockDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var stock = context.Stocks
                    .FirstOrDefault(x => x.ArticuloId == dto.ArticuloId);

                //if (stock.Cantidad == null) throw new Exception("No existe");

                //stock.Id = dto.Id;
                stock.ArticuloId = dto.ArticuloId;
                stock.DepositoId = dto.DepositoId;
                stock.Cantidad += dto.Cantidad;

                context.SaveChanges();
            }
        }

        //============================ METODOS ===============================//
        public long Insertar (ArticuloDto dto, long empresaId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var nuevoArticulo = new AccesoDatos.Articulo
                {
                    Codigo = dto.Codigo,
                    CodigoBarra = dto.CodigoBarra,
                    Abreviatura = dto.Abreviatura,
                    Descripcion = dto.Descripcion,
                    MarcaId = dto.MarcaId,
                    //RubroId = dto.RubroId,
                    SubRubroId = dto.SubRubroId,
                    Foto = dto.Foto,
                    ActivarLimiteVenta = dto.ActivarLimiteVenta,
                    CantidadLimiteVenta = dto.CantidadLimiteVenta,
                    PermiteStockNegativo = dto.PermiteStockNegativo,
                    EstaDiscontinuado = dto.EstaDiscontinuado,
                    TipoArticulo = dto.TipoArticulo,
                    StockMinimo = dto.StockMinimo,
                    StockMaximo = dto.StockMaximo,
                    DescuentaStock = dto.DescuentaStock,
                    SePuedeFraccionar = dto.SePuedeFraccionar,
                    Detalle = dto.Detalle,
                    EstaEliminado = dto.EstaEliminado,
                    Stocks = new List<Stock>(),
                    EmpresaId = dto.EmpresaId
                };

                context.Articulos.Add(nuevoArticulo);

                context.SaveChanges();

                return nuevoArticulo.Id;
            }
        }
        
        public void Modificar(ArticuloDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var modificarArticulo = context.Articulos
                    .FirstOrDefault(x => x.Id == dto.Id);

                if(modificarArticulo == null) throw new Exception("No se pudieron cargar os datos para modificar");

                modificarArticulo.Codigo = dto.Codigo;
                modificarArticulo.CodigoBarra = dto.CodigoBarra;
                modificarArticulo.Descripcion = dto.Descripcion;
                modificarArticulo.Abreviatura = dto.Abreviatura;
                modificarArticulo.MarcaId = dto.MarcaId;
                modificarArticulo.SubRubroId = dto.SubRubroId;
                modificarArticulo.Foto = dto.Foto;
                modificarArticulo.ActivarLimiteVenta = dto.ActivarLimiteVenta;
                modificarArticulo.CantidadLimiteVenta = dto.CantidadLimiteVenta;
                modificarArticulo.PermiteStockNegativo = dto.PermiteStockNegativo;
                modificarArticulo.EstaDiscontinuado = dto.EstaDiscontinuado;
                modificarArticulo.TipoArticulo = dto.TipoArticulo;
                modificarArticulo.StockMaximo = dto.StockMaximo;
                modificarArticulo.StockMinimo = dto.StockMinimo;
                modificarArticulo.DescuentaStock = dto.DescuentaStock;
                modificarArticulo.SePuedeFraccionar = dto.SePuedeFraccionar;
                modificarArticulo.Detalle = dto.Detalle;
                modificarArticulo.EstaEliminado = dto.EstaEliminado;

                context.SaveChanges();
            }
        }

        public void Eliminar(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var articuloEliminar = context.Articulos
                    .FirstOrDefault(x => x.Id == value);

                if (articuloEliminar == null) throw new Exception("No se encontro la Articulo");

                articuloEliminar.EstaEliminado = !articuloEliminar.EstaEliminado;
                context.SaveChanges();
            }
        }

        public void DescontarStock(List<PrecioDto> listaArticulos)
        {
            using (var context = new ModeloDatosContainer())
            {
                foreach (var articulo in listaArticulos)
                {
                    var art = context.Stocks.FirstOrDefault(x => x.ArticuloId == articulo.ArticuloId);

                    art.Cantidad --;
                }

                context.SaveChanges();
            }
        }
    }
}

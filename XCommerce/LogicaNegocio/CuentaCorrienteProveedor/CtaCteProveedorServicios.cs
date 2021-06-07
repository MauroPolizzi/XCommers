using System;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.CuentaCorrienteProveedor.DTOs;

namespace XCommerce.LogicaNegocio.CuentaCorrienteProveedor
{
    public class CtaCteProveedorServicios
    {
        public IEnumerable<CtaCteProveedorDto> ObtenerCuentas(long proveedorId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.CuentaCorrienteProveedores
                    .AsNoTracking()
                    .Where(x => x.ProveedorId == proveedorId &&
                                x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new CtaCteProveedorDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Fecha = x.Fecha,
                        Monto = x.Monto,
                        TipoMovimiento = x.TipoMovimiento,
                        ProveedorId = x.ProveedorId
                    }).OrderBy(x => x.Fecha).ThenBy(x => x.Descripcion).ToList();
            }
        }

        public string ObtenerPorProveedor(long? proveedorId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var proveedor = context.CuentaCorrienteProveedores
                    .OfType<AccesoDatos.CuentaCorrienteProveedor>().Max(x => x.Descripcion);

                if (proveedor == null)
                {
                    return null;
                }
                else
                {
                    return proveedor;
                }

            }
        }

        public void Insertar(CtaCteProveedorDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cuentaNueva = new AccesoDatos.CuentaCorrienteProveedor
                {
                    Descripcion = dto.Descripcion,
                    Fecha = dto.Fecha,
                    Monto = dto.Monto,
                    ProveedorId = dto.ProveedorId,
                    TipoMovimiento = dto.TipoMovimiento,
                };

                context.CuentaCorrienteProveedores.Add(cuentaNueva);
                context.SaveChanges();
            }
        }

        public void Eliminar(long? proveedorId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var prov = context.CuentaCorrienteProveedores
                    .FirstOrDefault(x => x.ProveedorId == proveedorId);

                if(prov == null) throw new Exception("No se pudo eliminar");

                context.CuentaCorrienteProveedores.Remove(prov);
                context.SaveChanges();
            }
        }
    }
}

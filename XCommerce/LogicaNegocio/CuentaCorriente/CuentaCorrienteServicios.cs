using System;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.CuentaCorriente.DTOs;

namespace XCommerce.LogicaNegocio.CuentaCorriente
{
    public class CuentaCorrienteServicios
    {
        public IEnumerable<CuentaCorrienteDto> ObtenerCuentas(long clienteId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.CuentaCorrientes
                    .Include("CuentaCorrientes")
                    .AsNoTracking()
                    .Where(x => x.ClienteId == clienteId && x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new CuentaCorrienteDto
                    {
                        Id = x.Id,
                        ClienteId = x.ClienteId,
                        Descripcion = x.Descripcion,
                        Fecha = x.Fecha,
                        Monto = x.Monto,
                    }).OrderBy(x => x.Fecha).ThenBy(x => x.Descripcion)
                    .ToList();
            }
        }

        public long Insertar(CuentaCorrienteDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cuenta = new AccesoDatos.CuentaCorriente
                {
                    ClienteId = dto.ClienteId,
                    Descripcion = dto.Descripcion,
                    Fecha = dto.Fecha,
                    Monto = dto.Monto,
                    TipoMovimiento = dto.TipoMovimiento,
                };

                context.CuentaCorrientes.Add(cuenta);

                var cliente = context.Personas.OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Id == dto.ClienteId);

                cliente.TieneCuentaCorriente = true;

                context.SaveChanges();

                return cuenta.Id;
            }
        }

        public CuentaCorrienteDto ObtenerPorNum(string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                var numCta = context.CuentaCorrientes
                    .FirstOrDefault(x => x.Descripcion == cadenaBuscar);

                if (numCta == null)
                {
                    return new CuentaCorrienteDto
                    {
                        ClienteId = 0
                    };
                }
                else
                {
                    return new CuentaCorrienteDto
                    {
                        ClienteId = numCta.ClienteId,
                        Descripcion = numCta.Descripcion,
                        Fecha = numCta.Fecha,
                        Id = numCta.Id,
                        Monto = numCta.Monto,
                        TipoMovimiento = numCta.TipoMovimiento
                    };
                }
            }
        }

        public void Modificar(CuentaCorrienteDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cuenta = context.CuentaCorrientes
                    .FirstOrDefault(x => x.Id == dto.Id);

                if(cuenta == null) throw new Exception("No se encontro la cuenta");

                cuenta.Descripcion = dto.Descripcion;
                cuenta.Monto = dto.Monto;
                cuenta.Fecha = dto.Fecha;

                context.SaveChanges();
            }
        }

        public CuentaCorrienteDto ObtenerPorId (long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cuenta = context.CuentaCorrientes
                    .FirstOrDefault(x => x.Id == entidadId);

                if(cuenta == null) throw new Exception("No se encontro la cuenta");

                return new CuentaCorrienteDto
                {
                    Id = cuenta.Id,
                    Descripcion = cuenta.Descripcion,
                    ClienteId = cuenta.ClienteId,
                    Fecha = cuenta.Fecha,
                    Monto = cuenta.Monto,
                    TipoMovimiento = cuenta.TipoMovimiento,
                };

            }
        }

        public string ObtenerPorCliente(long? _entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cuenta = context.CuentaCorrientes
                    .OfType<AccesoDatos.CuentaCorriente>().Max(x => x.Descripcion);

                if (cuenta == null)
                {
                    return null;
                }
                else
                {
                    return cuenta;
                }

            }
        }

        public void Eliminar(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cuenta = context.CuentaCorrientes
                    .FirstOrDefault(x => x.Id == value);

                if (cuenta == null) throw new Exception("No se encontro la cuenta");

                context.CuentaCorrientes.Remove(cuenta);
                
                context.SaveChanges();
            }
        }

        public void AumentarSaldo(CuentaCorrienteDto dto, decimal total)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cuenta = context.CuentaCorrientes
                    .FirstOrDefault(x => x.ClienteId == dto.ClienteId
                                         && x.Descripcion == dto.Descripcion);

                cuenta.Monto += total;

                context.SaveChanges();
            }
        }
    }
}

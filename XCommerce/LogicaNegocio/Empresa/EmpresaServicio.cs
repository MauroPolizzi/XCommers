using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Empresa.DTOs;

namespace XCommerce.LogicaNegocio.Empresa
{
    public class EmpresaServicio
    {
        public EmpresaServicio()
        {
            using (var context  = new ModeloDatosContainer())
            {
                var empresaInicial = new AccesoDatos.Empresa
                {
                    Sucursal = 1,
                    Articulos = null,
                    Cajas = null,
                    Comprobantes = null,
                    CondicionIva = null,
                    Configuraciones = null,
                    Cuit = "01",
                    Depositos = null,
                    Domicilio = "s",
                    Telefono = "1",
                    Mail = "@",
                    Logo = null,
                    Empleados = null,
                    Salas = null,

                };

                context.Empresas.Add(empresaInicial);
                context.SaveChanges();
                //return empresaInicial;
            }
        }

        public IEnumerable<EmpresaDto> ObtenerTodo(string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                int sucursal = -1;
                int.TryParse(cadenaBuscar, out sucursal);

                return context.Empresas.OfType<AccesoDatos.Empresa>()
                    .Include("ConicionIva")
                    .AsNoTracking()
                    .Where(x => x.NombreFantasia.Contains(cadenaBuscar)
                                || x.RazonSocial.Contains(cadenaBuscar)
                                || x.Sucursal == sucursal)
                    .Select(x => new EmpresaDto
                    {
                        Id = x.Id,
                        Sucursal = x.Sucursal,
                        RazonSocial = x.RazonSocial,
                        NombreFantasia = x.NombreFantasia,
                        Cuit = x.Cuit,
                        Domicilio = x.Domicilio,
                        Email = x.Mail,
                        Telefono = x.Telefono,
                        CondicionIva = x.CondicionIva.Descripcion,
                        CondicionIvaId = x.CondicionIvaId,
                        Logo = x.Logo
                    }).OrderBy(x => x.NombreFantasia).ThenBy(x => x.RazonSocial).ToList();
            }
        }

        public EmpresaDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var empresa = context.Empresas.OfType<AccesoDatos.Empresa>()
                    .Include("CondicionIva")
                    .FirstOrDefault(x => x.Id == entidadId);

                if (empresa == null) throw new Exception("La empresa no existe");

                return new EmpresaDto
                {
                    Id = empresa.Id,
                    Sucursal = empresa.Sucursal,
                    RazonSocial = empresa.RazonSocial,
                    NombreFantasia = empresa.NombreFantasia,
                    Cuit = empresa.Cuit,
                    Domicilio = empresa.Domicilio,
                    Telefono = empresa.Telefono,
                    Email = empresa.Mail,
                    CondicionIva = empresa.CondicionIva.Descripcion,
                    CondicionIvaId = empresa.CondicionIvaId,
                    Logo = empresa.Logo
                };
            }
        }

        public decimal ObtenerSiguienteSucursal()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Empresas.OfType<AccesoDatos.Empresa>().Any()
                    ? context.Empresas.OfType<AccesoDatos.Empresa>().Max(x => x.Sucursal) + 1
                    : 1;
            }
        }

        public long Insertar(EmpresaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var empresaNueva = new AccesoDatos.Empresa
                {
                    Sucursal = dto.Sucursal,
                    RazonSocial = dto.RazonSocial,
                    NombreFantasia = dto.NombreFantasia,
                    Cuit = dto.Cuit,
                    Domicilio = dto.Domicilio,
                    Telefono = dto.Telefono,
                    Mail = dto.Email,
                    CondicionIvaId = dto.CondicionIvaId,
                    Logo = dto.Logo
                };

                context.Empresas.Add(empresaNueva);
                context.SaveChanges();

                return empresaNueva.Id;
            }
        }

        public void Modificar(EmpresaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var empresaModificar = context.Empresas
                    .FirstOrDefault(x => x.Id == dto.Id);

                if(empresaModificar == null) throw new Exception("No se pudo cargar los datos de empresa");
                
                empresaModificar.Sucursal = dto.Sucursal;
                empresaModificar.RazonSocial = dto.RazonSocial;
                empresaModificar.NombreFantasia = dto.NombreFantasia;
                empresaModificar.Cuit = dto.Cuit;
                empresaModificar.Domicilio = dto.Domicilio;
                empresaModificar.Telefono = dto.Telefono;
                empresaModificar.Mail = dto.Email;
                empresaModificar.CondicionIvaId = dto.CondicionIvaId;
                empresaModificar.Logo = dto.Logo;

                context.SaveChanges();
            }
        }

        public void Eliminar(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var empresaEliminar = context.Empresas
                    .FirstOrDefault(x => x.Id == entidadId);

                if(empresaEliminar == null) throw new Exception("No se encontro la empresa");

                context.Empresas.Remove(empresaEliminar);
                context.SaveChanges();
            }
        }
    }
}

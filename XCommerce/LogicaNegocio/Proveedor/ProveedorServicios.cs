using System;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Proveedor.DTOs;

namespace XCommerce.LogicaNegocio.Proveedor
{
    public class ProveedorServicios
    {
        public IEnumerable<ProveedorDto> ObtenerTodo(string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Proveedores
                    .AsNoTracking()
                    .Where(x => x.Domicilio.Contains(cadenaBuscar)
                                || x.Email.Contains(cadenaBuscar)
                                || x.RazonSocial.Contains(cadenaBuscar)
                                || x.Telefono == cadenaBuscar)
                    .Select(x => new ProveedorDto
                    {
                        Id = x.Id,
                        CondicionIvaId = x.CondicionIvaId,
                        CondicionIva = x.CondicionIva.Descripcion,
                        Direccion = x.Domicilio,
                        Telefono = x.Telefono,
                        Email = x.Email,
                        RazonSocial = x.RazonSocial
                    }).OrderBy(x => x.RazonSocial).ToList();
            }
        }

        //============================ OBTENER POR ID ===========================//
        public ProveedorDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var proveedor = context.Proveedores
                    .FirstOrDefault(x => x.Id == entidadId);

                if (proveedor == null) throw new Exception("No existe e proveedor");

                return new ProveedorDto
                {
                    Id = proveedor.Id,
                    RazonSocial = proveedor.RazonSocial,
                    Direccion = proveedor.Domicilio,
                    Telefono = proveedor.Telefono,
                    Email = proveedor.Email,
                    CondicionIvaId = proveedor.CondicionIvaId,
                    CondicionIva = proveedor.CondicionIva.Descripcion
                    
                };
            }
        }

        //============================ NUEVO ===========================//
        public long Insertar(ProveedorDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var proveedor = new AccesoDatos.Proveedor
                {
                    RazonSocial = dto.RazonSocial,
                    Domicilio = dto.Direccion,
                    Telefono = dto.Telefono,
                    Email = dto.Email,
                    CondicionIvaId = dto.CondicionIvaId
                };

                context.Proveedores.Add(proveedor);
                context.SaveChanges();

                return proveedor.Id;
            }
        }

        //============================ MODIFICAR ===========================//
        public void Modificar(ProveedorDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var proveedor = context.Proveedores
                    .FirstOrDefault(x => x.Id == dto.Id);

                if(proveedor == null) throw new Exception("No existe el proveedor");

                proveedor.RazonSocial = dto.RazonSocial;
                proveedor.Domicilio = dto.Direccion;
                proveedor.Telefono = dto.Telefono;
                proveedor.Email = dto.Email;
                proveedor.CondicionIvaId = dto.CondicionIvaId;

                context.SaveChanges();
            }
        }

        //============================ ELIMINAR ===========================//
        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {

                var proveedorEliminar = context.Proveedores
                    .FirstOrDefault(x => x.Id == entidadId);

                if(proveedorEliminar == null) throw new Exception("No existe");

                context.Proveedores.Remove(proveedorEliminar);
                context.SaveChanges();
            }
        }
    }
}

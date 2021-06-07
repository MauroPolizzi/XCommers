using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Empleado.DTOs;
using XCommerce.LogicaNegocio.Empresa.DTOs;
using XCommerce.LogicaNegocio.EmpresaEmpleado.Clases;

namespace XCommerce.LogicaNegocio.EmpresaEmpleado
{
    public class EmpresaEmpleadoServicio
    {
        public ICollection<EmpresaDto> ObtenerEmpresasEmpleado(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Empresas.OfType<AccesoDatos.Empresa>()
                    .AsNoTracking()
                    .Where(x => x.Empleados.Any(z => z.Id == entidadId))
                    .Select(x => new EmpresaDto
                    {
                        Id = x.Id,
                        Sucursal = x.Sucursal,
                        NombreFantasia = x.NombreFantasia,
                        RazonSocial = x.RazonSocial,
                        Cuit = x.Cuit,
                        CondicionIvaId = x.CondicionIvaId,
                        Domicilio = x.Domicilio,
                        Email = x.Mail,
                        Logo = x.Logo,
                        Telefono = x.Telefono,
                    }).OrderBy(x => x.Sucursal).ThenBy(x => x.RazonSocial)
                    .ToList();
            }
        }

        //=============================== ASIGNAR EMPLEADOS ==============================//
        public ICollection<EmpleadoDto> EmpleadosNoAsignados(long _entidadId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                int legajo = -1;
                int.TryParse(cadenaBuscar, out legajo);

                var empleadosAsignados = context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Include(x => x.Empresas)
                    .Where(x => !x.EstaEliminado && x.Empresas.Any(e => e.Id == _entidadId))
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Celular = x.Celular,
                        Telefono = x.Telefono,
                        Dni = x.Dni,
                        Domicilio = x.Domicilio,
                        Email = x.Email,
                        FechaIngreso = x.FechaIngreso,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        Eliminado = x.EstaEliminado,
                        Legajo = x.Legajo,
                    }).ToList();

                var empleados = context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Include(x => x.Empresas)
                    .Where(x => !x.EstaEliminado)
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Celular = x.Celular,
                        Telefono = x.Telefono,
                        Dni = x.Dni,
                        Domicilio = x.Domicilio,
                        Email = x.Email,
                        FechaIngreso = x.FechaIngreso,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        Eliminado = x.EstaEliminado,
                        Legajo = x.Legajo,
                    }).ToList();

                return empleados.Except(empleadosAsignados, new EmpresaEmpleadoCompare())
                    .Where(x => x.Legajo == legajo
                                || x.Apellido.Contains(cadenaBuscar)
                                || x.Nombre.Contains(cadenaBuscar)
                                || x.Dni == cadenaBuscar)
                    .OrderBy(x => x.Apellido).ThenBy(x => x.Nombre).ToList();
            }
        }
        public void AsignarEmpleado(long empresaId, List<EmpleadoDto> listaEmpleadosNoAsignados)
        {
            using (var context = new ModeloDatosContainer())
            {
                var empresa = context.Empresas.FirstOrDefault(x => x.Id == empresaId);

                if (empresa == null) throw new Exception("Ocurrio un error al obtener la empresa");

                foreach (var emple in listaEmpleadosNoAsignados)
                {
                    var empleado = context.Personas.OfType<AccesoDatos.Empleado>()
                        .FirstOrDefault(x => x.Id == emple.Id);

                    if (empleado == null) throw new Exception("Ocurrio un error al encontrar el empleado");

                    empresa.Empleados.Add(empleado);
                }

                context.SaveChanges();
            }
        }

        //=============================== QUITAR EMPLEADOS ==============================//
        public ICollection<EmpleadoDto> EmpleadosAsignados(long empresaId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                int legajo = -1;
                int.TryParse(cadenaBuscar, out legajo);

                var empleadoAsignado = context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Include(x => x.Empresas)
                    .Where(x => !x.EstaEliminado
                                && x.Empresas.Any(e => e.Id == empresaId)
                                && (x.Legajo == legajo
                                    || x.Nombre.Contains(cadenaBuscar)
                                    || x.Apellido.Contains(cadenaBuscar)
                                    || x.Dni == cadenaBuscar))
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Celular = x.Celular,
                        Dni = x.Dni,
                        Domicilio = x.Domicilio,
                        Email = x.Email,
                        FechaIngreso = x.FechaIngreso,
                        FechaNacimiento = x.FechaNacimiento,
                        Legajo = x.Legajo,
                        Nombre = x.Nombre,
                        Telefono = x.Telefono,
                        Foto = x.Foto,
                        Eliminado = x.EstaEliminado
                    })
                    .OrderBy(x => x.Apellido).ThenBy(x => x.Nombre).ToList();

                return empleadoAsignado;
            }
        }
        public void QuitarEmpleado(long _empresaId, List<EmpleadoDto> list)
        {
            using (var context = new ModeloDatosContainer())
            {
                var empresa = context.Empresas.FirstOrDefault(x => x.Id == _empresaId);

                if (empresa == null) throw new Exception("Ocurrió un error al obtener la Empresa");

                foreach (var emple in list)
                {
                    var empleado = context.Personas.OfType<AccesoDatos.Empleado>()
                        .FirstOrDefault(x => x.Id == emple.Id);

                    if (empleado == null) throw new Exception("Ocurrió un error al obtener un empleado");

                    empresa.Empleados.Remove(empleado);
                }

                context.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Empleado.DTOs;

namespace XCommerce.LogicaNegocio.Empleado
{
    public class EmpleadoServicio
    {
        public IEnumerable<EmpleadoDto> Obtener (string cadenaBuscar, bool estado = false)
        {
            using (var context = new ModeloDatosContainer())
            {
                int legajo = -1;
                int.TryParse(cadenaBuscar, out legajo);

                return context.Personas.OfType<AccesoDatos.Empleado>()
                    .AsNoTracking()
                    .Where(x => x.EstaEliminado == estado
                    && (x.Nombre.Contains(cadenaBuscar)
                    || x.Apellido.Contains(cadenaBuscar)
                    || x.Dni== cadenaBuscar
                    || x.Legajo == legajo))
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
                    Foto = x.Foto,
                    FechaIngreso = x.FechaIngreso,
                    FechaNacimiento = x.FechaNacimiento,
                    Legajo = x.Legajo,
                    Eliminado = x.EstaEliminado
                }).OrderBy(x=> x.Apellido).ThenBy(x=>x.Nombre)
                .ToList();
            }
        }
        // ========================= OBTENER POR ID ====================== //
        public EmpleadoDto ObtenerPorId(long empleadoId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var empleado = context.Personas.OfType<AccesoDatos.Empleado>()
                    .FirstOrDefault(x => x.Id == empleadoId);
                if (empleado == null) throw new Exception("El Empleado no existe");

                return new EmpleadoDto
                {
                    Id = empleado.Id,
                    Apellido = empleado.Apellido,
                    Nombre = empleado.Nombre,
                    Dni = empleado.Dni,
                    Domicilio = empleado.Domicilio,
                    Telefono = empleado.Telefono,
                    Celular = empleado.Celular,
                    Foto = empleado.Foto,
                    FechaIngreso = empleado.FechaIngreso,
                    FechaNacimiento = empleado.FechaNacimiento,
                    Legajo = empleado.Legajo,
                    Email = empleado.Email,
                    Eliminado = empleado.EstaEliminado,
                };
            }
        }
        // ====================== OBTENER SIGUIENTE LEGAJO ====================== //
        public int ObtenerSiguieteLegajo()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Personas.OfType<AccesoDatos.Empleado>().Any()
                    ? context.Personas.OfType<AccesoDatos.Empleado>().Max(x => x.Legajo) + 1
                    : 1;
            }
        }

        public EmpleadoDto ObtenerPorNombre(string nombre)
        {
            using (var context = new ModeloDatosContainer())
            {
                var empleado = context.Personas.OfType<AccesoDatos.Empleado>()
                    .FirstOrDefault(x => x.Nombre == nombre);

                if(empleado == null) throw new Exception("No se encuentra el empleado");

                return new EmpleadoDto
                {
                    Id = empleado.Id,
                    Apellido = empleado.Apellido,
                    Nombre = empleado.Nombre,
                    Dni = empleado.Dni,
                    Domicilio = empleado.Domicilio,
                    Telefono = empleado.Telefono,
                    Celular = empleado.Celular,
                    Foto = empleado.Foto,
                    FechaIngreso = empleado.FechaIngreso,
                    FechaNacimiento = empleado.FechaNacimiento,
                    Legajo = empleado.Legajo,
                    Email = empleado.Email,
                    Eliminado = empleado.EstaEliminado,
                };
            }
        }

        // =========================    INSERTAR    ====================== //
        public long Insert (EmpleadoDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var empleadoNuevo = new AccesoDatos.Empleado
                    {
                        Apellido = dto.Apellido,
                        Nombre = dto.Nombre,
                        Telefono = dto.Telefono,
                        Celular = dto.Celular,
                        Dni = dto.Dni,
                        Domicilio = dto.Domicilio,
                        Foto = dto.Foto,
                        FechaIngreso = dto.FechaIngreso,
                        FechaNacimiento = dto.FechaNacimiento,
                        Legajo = dto.Legajo,
                        EstaEliminado = false,
                        Email = dto.Email
                    };
                context.Personas.Add(empleadoNuevo);
                context.SaveChanges();

                return empleadoNuevo.Id;
            }
        }
        // =========================    ELIMINAR    ====================== //
        public void Delete(long empleadoId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var eliminarEmpleado = context.Personas.OfType<AccesoDatos.Empleado>()
                    .FirstOrDefault(x => x.Id == empleadoId);

                if (eliminarEmpleado == null) throw new Exception("No se encontro el empleado");

                eliminarEmpleado.EstaEliminado = !eliminarEmpleado.EstaEliminado;
                context.SaveChanges();
            }
        }
        // =========================    MODIFICAR   ====================== //
        public void Modificar(EmpleadoDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var empleadoModificar = context.Personas.OfType<AccesoDatos.Empleado>()
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (empleadoModificar == null) throw new Exception("No se encontro el empleado");

                empleadoModificar.Apellido = dto.Apellido;
                empleadoModificar.Nombre = dto.Nombre;
                empleadoModificar.Telefono = dto.Telefono;
                empleadoModificar.Celular = dto.Celular;
                empleadoModificar.Dni = dto.Dni;
                empleadoModificar.Domicilio = dto.Domicilio;
                empleadoModificar.Foto = dto.Foto;
                empleadoModificar.FechaIngreso = dto.FechaIngreso;
                empleadoModificar.FechaNacimiento = dto.FechaNacimiento;
                empleadoModificar.Legajo = dto.Legajo;

                context.SaveChanges();

            }
        }

    }
}

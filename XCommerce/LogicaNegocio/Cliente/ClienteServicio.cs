using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Cliente.DTOs;

namespace XCommerce.LogicaNegocio.Cliente
{
    public class ClienteServicio
    {
        public IEnumerable<ClienteDto> ObtenerTodo(string cadenabuscar, bool? estado = false)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Personas.OfType<AccesoDatos.Cliente>()
                    .AsNoTracking()
                    .Where(x => x.EstaEliminado == estado
                                && (x.Apellido.Contains(cadenabuscar)
                                || x.Nombre.Contains(cadenabuscar)
                                || x.Dni == cadenabuscar))
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Domicilio = x.Domicilio,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Email = x.Email,
                        FechaNacimiento = x.FechaNacimiento,
                        EstaEliminado = false,
                        EstaBloqueado = false,
                        MontoMaximoCompra = x.MontoMaximoCompra,
                        TieneCuentaCorriente = x.TieneCuentaCorriente,
                    }).OrderBy(x => x.Apellido).ThenBy(x => x.Nombre).ToList();
            }
        }

        public ClienteDto ObtenerPorDni(string dni)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cliente = context.Personas.OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Dni == dni);

                if (cliente == null) return null;

                return new ClienteDto
                {
                    Apellido = cliente.Apellido,
                    Nombre = cliente.Nombre,
                    Celular = cliente.Celular,
                    Dni = cliente.Dni,
                    Domicilio = cliente.Domicilio,
                    Email = cliente.Email,
                    EstaEliminado = cliente.EstaEliminado,
                    EstaBloqueado = cliente.EstaBloqueado,
                    Id = cliente.Id,
                    Telefono = cliente.Telefono,
                    FechaNacimiento = cliente.FechaNacimiento,
                    MontoMaximoCompra = cliente.MontoMaximoCompra,
                    TieneCuentaCorriente = cliente.TieneCuentaCorriente
                };
            }
        }

        public ClienteDto ObtenerProId(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cliente = context.Personas.OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Id == value);

                if (cliente == null) throw new Exception("No existe el cliente");

                return new ClienteDto
                {
                    Id = cliente.Id,
                    Apellido = cliente.Apellido,
                    Nombre = cliente.Nombre,
                    Dni = cliente.Dni,
                    Domicilio = cliente.Domicilio,
                    Telefono = cliente.Telefono,
                    Celular = cliente.Celular,
                    Email = cliente.Email,
                    FechaNacimiento = cliente.FechaNacimiento,
                    EstaEliminado = false,
                    EstaBloqueado = false,
                    MontoMaximoCompra = cliente.MontoMaximoCompra,
                    TieneCuentaCorriente = cliente.TieneCuentaCorriente,
                };
            }
        }

        public long Insertar(ClienteDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var clienteNuevo = new AccesoDatos.Cliente
                {
                    Apellido = dto.Apellido,
                    Nombre = dto.Nombre,
                    Telefono = dto.Telefono,
                    Celular = dto.Celular,
                    Dni = dto.Dni,
                    Domicilio = dto.Domicilio,
                    FechaNacimiento = dto.FechaNacimiento,
                    EstaEliminado = false,
                    EstaBloqueado = false,
                    Email = dto.Email,
                    TieneCuentaCorriente = dto.TieneCuentaCorriente,
                    MontoMaximoCompra = dto.MontoMaximoCompra
                };
                context.Personas.Add(clienteNuevo);
                context.SaveChanges();

                return clienteNuevo.Id;
            }
        }

        public void Modificar(ClienteDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var clienteModificar = context.Personas.OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (clienteModificar == null) throw new Exception("No se encontro el empleado");

                clienteModificar.Apellido = dto.Apellido;
                clienteModificar.Nombre = dto.Nombre;
                clienteModificar.Telefono = dto.Telefono;
                clienteModificar.Celular = dto.Celular;
                clienteModificar.Dni = dto.Dni;
                clienteModificar.Domicilio = dto.Domicilio;
                clienteModificar.FechaNacimiento = dto.FechaNacimiento;
                clienteModificar.Email = dto.Email;
                clienteModificar.MontoMaximoCompra = dto.MontoMaximoCompra;
                clienteModificar.TieneCuentaCorriente = dto.TieneCuentaCorriente;
                clienteModificar.EstaBloqueado = false;
                clienteModificar.EstaEliminado = false;
                
                context.SaveChanges();

            }
        }

        public void Eliminar(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var eliminarCliente = context.Personas.OfType<AccesoDatos.Cliente>()
                    .FirstOrDefault(x => x.Id == value);

                if (eliminarCliente == null) throw new Exception("No se encontro el cliente");

                eliminarCliente.EstaEliminado = !eliminarCliente.EstaEliminado;
                context.SaveChanges();
            }
        }
    }
}

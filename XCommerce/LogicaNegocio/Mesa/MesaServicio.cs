using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Mesa.DTOs;

namespace XCommerce.LogicaNegocio.Mesa
{
    public class MesaServicio
    {
        public IEnumerable<MesaDto> ObtenerTodo(long empresaId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Mesas.OfType<AccesoDatos.Mesa>()
                    .Include(x => x.Sala)
                    .AsNoTracking()
                    .Where(x => x.Sala.EmpresaId == empresaId &&
                    (x.Descripcion.Contains(cadenaBuscar)
                    || x.Sala.Descripcion.Contains(cadenaBuscar)))
                    .Select(x => new MesaDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        Sala = x.Sala.Descripcion,
                        SalaId = x.SalaId
                    }).ToList();
            }
        }

        //======================= OBTENER POR ID =========================//
        public MesaDto ObtenerPorId(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var mesa = context.Mesas
                    .Include(x => x.Sala)
                    .FirstOrDefault(x => x.Id == value);

                if (mesa == null) throw new Exception("NO existe la mesa");

                return new MesaDto
                {
                    Id = mesa.Id,
                    Codigo = mesa.Codigo,
                    Descripcion = mesa.Descripcion,
                    EstadoMesa = mesa.EstadoMesa,
                    SalaId = mesa.SalaId,
                    Sala = mesa.Sala.Descripcion
                };
            }
        }

        //======================= OBTENER SIGUIENTE CODIGO =========================//
        public decimal ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Mesas.OfType<AccesoDatos.Mesa>().Any()
                    ? context.Mesas.OfType<AccesoDatos.Mesa>().Max(x => x.Codigo) + 1
                    : 1;
            }
        }

        //======================= OBTENER POR SALA =========================//
        public IEnumerable<MesaDto> ObtenerPorSala(long salaId)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Mesas
                    .Include(x => x.Comprobantes_Salon)
                    .AsNoTracking()
                    .Where(x => x.SalaId == salaId)
                    .Select(x => new MesaDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        EstadoMesa = x.EstadoMesa,
                        Sala = x.Sala.Descripcion,
                        SalaId = x.SalaId,
                        //Monto = x.EstadoMesa == EstadoMesa.Abierta
                        //? x.Comprobantes_Salon
                        //    .FirstOrDefault(c => c.MesaId == x.Id
                        //                         && c.Estado == EstadoSalon.EnProceso).Total
                        //: 1m
                    }).OrderBy(x => x.Codigo)
                    .ToList();
            }
        }

        //======================= INSSERTAR =========================//
        public void Insertar(MesaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var nuevaMesa = new AccesoDatos.Mesa
                {
                    Id = dto.Id,
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    SalaId = dto.SalaId,
                    EstadoMesa = dto.EstadoMesa
                };

                context.Mesas.Add(nuevaMesa);
                context.SaveChanges();
            }
        }

        //======================= MODIFICAR =========================//
        public void Modificar(MesaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var modificarMesa = context.Mesas
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (modificarMesa == null) throw new Exception("No se ncotro la mesa");

                modificarMesa.Id = dto.Id;
                modificarMesa.Codigo = dto.Codigo;
                modificarMesa.Descripcion = dto.Descripcion;
                modificarMesa.SalaId = dto.SalaId;
                modificarMesa.EstadoMesa = dto.EstadoMesa;

                context.SaveChanges();

            }
        }

        //======================= ELIMINAR =========================//
        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var nuevo = context.Mesas.FirstOrDefault(x => x.Id == entidadId.Value);

                if(nuevo == null) throw new Exception("No hay mesa para eliminar");
                
                context.Mesas.Remove(nuevo);
                context.SaveChanges();
            }
        }
    }
}

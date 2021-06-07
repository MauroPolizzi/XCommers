using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Sala.DTOs;

namespace XCommerce.LogicaNegocio.Sala
{
    public class SalaServicio
    {
        //=============================== OBTENER ==========================//
        public IEnumerable<SalaDto> ObtenerTodo (long empresaId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                int codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                return context.Salas.OfType<AccesoDatos.Sala>()
                    .Include(x => x.Empresa)
                    .AsNoTracking()
                    .Where(x => x.EstaEliminada == false
                                && x.EmpresaId == empresaId
                                && (x.Descripcion.Contains(cadenaBuscar)
                                    || x.Codigo == codigo))
                    .Select(x => new SalaDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        EmpresaId = x.EmpresaId,
                        Empresa = x.Empresa.NombreFantasia,
                        EstaEliminada = x.EstaEliminada,
                    }).ToList();
            }
        }

        public SalaDto ObtenePorId(long value)
        {
            using (var context = new ModeloDatosContainer())
            {
                var sala = context.Salas.OfType<AccesoDatos.Sala>()
                    .FirstOrDefault(x => x.Id == value);

                if(sala == null) throw new Exception("No Existe la sala");

                return new SalaDto
                {
                    Id = sala.Id,
                    Codigo = sala.Codigo,
                    Descripcion = sala.Descripcion,
                    EmpresaId = sala.EmpresaId,
                    EstaEliminada = sala.EstaEliminada,
                };
            }
        }

        public decimal ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Salas.OfType<AccesoDatos.Sala>().Any()
                    ? context.Salas.OfType<AccesoDatos.Sala>().Max(x => x.Codigo) + 1
                    : 1;
            }
        }

        //=============================== METODOS ==========================//

        public long Insertar(SalaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var sala = new AccesoDatos.Sala
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    EmpresaId = dto.EmpresaId,
                    EstaEliminada = dto.EstaEliminada,
                };

                context.Salas.Add(sala);
                context.SaveChanges();

                return sala.Id;
            }
        }

        public void Modificar(SalaDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var salaModificar = context.Salas.OfType<AccesoDatos.Sala>()
                    .FirstOrDefault(x => x.Id == dto.Id);

                if(salaModificar == null) throw new Exception("No se pudo modificar");

                //salaModificar.Id = dto.Id;
                salaModificar.Codigo = dto.Codigo;
                salaModificar.Descripcion = dto.Descripcion;
                salaModificar.EmpresaId = dto.EmpresaId;

                context.SaveChanges();
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var eliminar = context.Salas
                    .FirstOrDefault(x => x.Id == entidadId);

                if(eliminar == null) throw new Exception("No se pudo eliminar");

                eliminar.EstaEliminada = !eliminar.EstaEliminada;

                context.SaveChanges();
            }
        }
    }
}

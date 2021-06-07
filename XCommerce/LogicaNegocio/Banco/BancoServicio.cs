using System;
using System.Collections.Generic;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Banco.DTOs;

namespace XCommerce.LogicaNegocio.Banco
{
    public class BancoServicio
    {
        public IEnumerable<BancoDto> ObtenerTodo(string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                int codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                return context.Bancos
                    .AsNoTracking()
                    .Where(x => x.EstaEliminado == false &&
                                (x.Descripcion.Contains(cadenaBuscar)
                                 || x.Codigo == codigo))
                    .Select(x => new BancoDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Codigo = x.Codigo,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        //======================== OBTENER SIGUIENTE CODIGO =======================//
        public int ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Bancos.OfType<AccesoDatos.Banco>().Any()
                    ? context.Bancos.OfType<AccesoDatos.Banco>().Max(x => x.Codigo) + 1
                    : 1;
            }
        }

        //======================== OBTENER POR ID =======================//
        public BancoDto ObtenerPorId(long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var banco = context.Bancos
                    .FirstOrDefault(x => x.Id == entidadId);

                if (banco == null) throw new Exception("No existe");

                return new BancoDto
                {
                    Id = banco.Id,
                    Codigo = banco.Codigo,
                    Descripcion = banco.Descripcion,
                    EstaEliminado = banco.EstaEliminado
                };
            }
        }

        //======================== METODOS =======================//
        public long Insertar(BancoDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var banco = new AccesoDatos.Banco
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    EstaEliminado = false,
                };

                context.Bancos.Add(banco);
                context.SaveChanges();

                return banco.Id;
            }
        }

        public void Modificar(BancoDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var banco = context.Bancos
                    .FirstOrDefault(x => x.Id == dto.Id);

                if(banco == null) throw new Exception("No existe");

                banco.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public void Eliminar(long? entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var banco = context.Bancos
                    .FirstOrDefault(x => x.Id == entidadId);

                if (banco == null) throw new Exception("No existe");

                banco.EstaEliminado = !banco.EstaEliminado;
                context.SaveChanges();
            }
        }
    }
}

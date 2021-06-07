using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Articulo.DTOs;
using XCommerce.LogicaNegocio.Deposito.DTOs;

namespace XCommerce.LogicaNegocio.Deposito
{
    public class DepositoServicio
    {
        public IEnumerable<DepositoDto> ObtenerTodo (long empresaId, string cadenaBuscar, bool? estado = false)
        {
            using (var context = new ModeloDatosContainer())
            {
                int codigo = -1;
                int.TryParse(cadenaBuscar, out codigo);

                return context.Depositos.OfType<AccesoDatos.Deposito>()
                    .AsNoTracking()
                    .Where(x => x.EstaEliminado == estado
                    && x.EmpresaId == empresaId
                                && (x.Codigo == codigo
                                    || x.Descripcion.Contains(cadenaBuscar)))
                                    .Select(x => new DepositoDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        EmpresaId = x.EmpresaId
                    }).ToList();
            }
        }

        public int ObtenerSiguienteCodigo()
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Depositos.OfType<AccesoDatos.Deposito>().Any()
                    ? context.Depositos.OfType<AccesoDatos.Deposito>().Max(x => x.Codigo) + 1
                    : 1;
            }
        }

        public DepositoDto ObtenerPorId (long depositoId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var deposito = context.Depositos.OfType<AccesoDatos.Deposito>()
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == depositoId);

                if (deposito == null) throw new Exception("El deposito no existe");

                return new DepositoDto
                {
                    Id = deposito.Id,
                    Codigo = deposito.Codigo,
                    Descripcion = deposito.Descripcion,
                    EstaEliminado = deposito.EstaEliminado,
                    EmpresaId = deposito.EmpresaId
                };
            }
        }

        public bool VerificarSiExiste(int codigo, string descripcion, long? depositoId = null)
        {
            using (var context = new ModeloDatosContainer())
            {
                if (depositoId.HasValue)
                {
                    return context.Depositos
                        .AsNoTracking()
                        .Any(x => x.Id != depositoId && (x.Codigo == codigo || x.Descripcion.Contains(descripcion)));
                }
                else
                {
                    return context.Depositos
                        .AsNoTracking()
                        .Any(x => x.Codigo == codigo || x.Descripcion.Contains(descripcion));
                }
            }
        }
        public long Insertar(DepositoDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var nuevoDeposito = new AccesoDatos.Deposito
                {
                    Codigo = dto.Codigo,
                    Descripcion = dto.Descripcion,
                    EstaEliminado = dto.EstaEliminado,
                    EmpresaId = dto.EmpresaId
                };

                context.Depositos.Add(nuevoDeposito);

                context.SaveChanges();

                return nuevoDeposito.Id;
            }
        }
        public void Modificar(DepositoDto dto)
        {
            using (var context = new ModeloDatosContainer())
            {
                var depositoModificar = context.Depositos.OfType<AccesoDatos.Deposito>()
                    .FirstOrDefault(x => x.Id == dto.Id);

                //if (depositoModificar == null) throw new Exception("No se pudieron cargar los datos para modificar");

                depositoModificar.Codigo = dto.Codigo;
                depositoModificar.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public void Eliminar(long entidadId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var eliminarDeposito = context.Depositos
                    .FirstOrDefault(x => x.Id == entidadId);

                if (eliminarDeposito == null) throw new Exception("No existe el deposito para eliminar");

                eliminarDeposito.EstaEliminado = !eliminarDeposito.EstaEliminado;

                context.SaveChanges();
            }
        }
    }
}

using System.Collections.Generic;
using XCommerce.LogicaNegocio.Empleado.DTOs;

namespace XCommerce.LogicaNegocio.EmpresaEmpleado.Clases
{
    public class EmpresaEmpleadoCompare : IEqualityComparer<EmpleadoDto>
    {
        public bool Equals(EmpleadoDto x, EmpleadoDto y)
        {
            if (object.ReferenceEquals(x, y)) return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(EmpleadoDto empresaDto)
        {
            return empresaDto.Id.GetHashCode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.LogicaNegocio.FormularioPerfil.DTOs
{
    class FormularioPerfilCompare: IEqualityComparer<FormularioPerfilDto>
    {
        public bool Equals(FormularioPerfilDto x, FormularioPerfilDto y)
        {
            //====>> SACO REFERENCIA DE SI X ,Y TIENEN DATOS
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

            //DEVUELVO EL FORMULARIO Q SE ENCUENTRE EN AMBAS LISTAS
            return x.FormularioId == y.FormularioId;
        }

        public int GetHashCode(FormularioPerfilDto obj)
        {
            return obj.FormularioId.GetHashCode();
        }
    }
}

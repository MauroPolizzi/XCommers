using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.LogicaNegocio.UsuarioPerfil.DTOs
{
    public class UsuarioPerfilCompare : IEqualityComparer<UsuarioPerfilDto>
    {
        //------------------------>> RECIBIMOS LAS DOS LISTAS DEL SERVICIO 
        //------------------------>> Y LAS COMPRAMOS 
        public bool Equals(UsuarioPerfilDto x, UsuarioPerfilDto y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

            return x.UsuarioId == y.UsuarioId;
        }

        public int GetHashCode(UsuarioPerfilDto obj)
        {
            return obj.UsuarioId.GetHashCode();
        }
    }
}

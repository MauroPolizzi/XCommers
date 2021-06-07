using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.FormularioPerfil.DTOs;

namespace XCommerce.LogicaNegocio.FormularioPerfil
{
    public class FormularioPerfilServicio
    {
        public IEnumerable<FormularioPerfilDto> ObtenerFormulariosNoAsignados(string cadenaBuscar, long _perfilId)
        {
            using (var context = new ModeloDatosContainer())
            {
                //====>> OBTENGO TODOS LOS FORMULARIOS
                var formularios = context.Formularios
                    .AsNoTracking()
                    .Select(x => new FormularioPerfilDto
                    {
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        FormularioId = x.Id,
                        Item = false
                    }).ToList();

                //====>> OBTENER LOS FORMULARIOS ASIGNADOS
                var formulariosAsignados = context.Formularios
                    .Include("Perfiles")
                    .AsNoTracking()
                    .Where(x => x.Perfiles.Any(p => p.Id == _perfilId))
                    .Select(x => new FormularioPerfilDto
                    {
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        FormularioId = x.Id,
                        Item = false,
                    }).ToList();

                //HACEMOS UNA RESTA ENTRE LOS DOS CON EL COMPARE
                var resultado = formularios
                    .Except(formulariosAsignados, new FormularioPerfilCompare())
                    .Where(x => x.Descripcion.Contains(cadenaBuscar)
                                || x.Codigo == cadenaBuscar)
                    .ToList();

                return resultado;

            }
        }

        public IEnumerable<FormularioPerfilDto> ObtenerFormulariosAsignados(string cadenaBuscar, long _perfilId)
        {
            using (var context = new ModeloDatosContainer())
            {
                var formulario = context.Formularios
                    .Include("Perfiles")
                    .AsNoTracking()
                    .Where(x => x.Perfiles.Any(p => p.Id == _perfilId))
                    .Select(x => new FormularioPerfilDto
                    {
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        FormularioId = x.Id,
                        Item = false
                    }).ToList();

                var resultado = formulario
                    .Where(x => x.Descripcion.Contains(cadenaBuscar)
                                || x.Codigo == cadenaBuscar)
                    .ToList();

                return resultado;
            }
        }

        public void AsignarFormulario(long perfilId,List<FormularioPerfilDto> listaFormularios)
        {
            using (var context = new ModeloDatosContainer())
            {
                //====>> OBTENGO EL PERFIL
                var perfil = context.Perfiles
                    .FirstOrDefault(x => x.Id == perfilId);

                //====>> VEO QUE NO SEA NULO
                if(perfil == null) throw new Exception("No se encontro el perfil");

                //====>> RECORRO LA LISTA
                foreach (var form in listaFormularios)
                {
                    //====>> BUSCO EL FORMULARIO POR ID EN LA LISTA DE LOS FORMULARIOS
                    var formulario = context.Formularios.FirstOrDefault(x => x.Id == form.FormularioId);

                    //====>> LE AGREGO AL PERFIL EL USUARIO
                    perfil.Formularios.Add(formulario);
                }

                //====>> GUARDO LOS DATOS
                context.SaveChanges();
            }
        }

        public void QuitarFormulario(long _perfilId, List<FormularioPerfilDto> listaFormulario)
        {
            using (var context = new ModeloDatosContainer())
            {
                var perfil = context.Perfiles
                    .FirstOrDefault(x => x.Id == _perfilId);

                if(perfil == null) throw new Exception("No se encontro el perfil");

                foreach (var form in listaFormulario)
                {
                    var formulario = context.Formularios.FirstOrDefault(x => x.Id == form.FormularioId);

                    perfil.Formularios.Remove(formulario);
                }

                context.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Formulario.DTOs;

namespace XCommerce.LogicaNegocio.Formulario
{
    public class FormularioServicio
    {
        public IEnumerable<FormularioDto> ObtenerTodo(string cadenaBuscar, Assembly assembly)
        {
            var listaFormularios = new List<FormularioDto>();

            using (var context = new ModeloDatosContainer())
            {
                var formularioDB = context.Formularios
                    .AsNoTracking()
                    .ToList();

                foreach (var objeto in assembly.GetTypes())
                {
                    if(!objeto.Name[0].Equals('_')) continue;

                    var formulario = new FormularioDto
                    {
                        Codigo = objeto.Name.Substring(1,5),
                        Descripcion = objeto.Name.Substring(7, objeto.Name.Length -7),
                        DescripcionCompleta = objeto.Name,
                        Existe = formularioDB.Any(x => x.DescripcionCompleta == objeto.Name)
                    };

                    listaFormularios.Add(formulario);
                }
            }
            return listaFormularios
                .Where(x => x.Codigo == cadenaBuscar
                            || x.Descripcion.Contains(cadenaBuscar)).ToList();
        }

        public void Insertar(List<FormularioDto> formulario)
        {
            using (var context = new ModeloDatosContainer())
            {
                foreach (var dto in formulario)
                {
                    context.Formularios.Add(new AccesoDatos.Formulario
                    {
                        Codigo = dto.Codigo,
                        Descripcion = dto.Descripcion,
                        DescripcionCompleta = dto.DescripcionCompleta,
                        EstaEliminado = false,
                    });
                }
                context.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.Caja.DTOs;

namespace XCommerce.LogicaNegocio.Caja
{
    public class CajaServicios
    {
        public CajaDto ObtenerCajaEmpresa(long empresaId)
        {
            using (var context = new ModeloDatosContainer())
            {
                //var cajasEmpresa = context.Cajas.OfType<AccesoDatos.Caja>()
                //    .Where(x => x.EmpresaId == empresaId).ToList();

                if (true)
                {
                    return new CajaDto
                    {
                        Id = 0,
                        UsuarioApertura = 0,
                        UsuarioCierre = 0,
                        MontoApertura = 0,
                        MontoCierre = 0,
                        FechaApertura = DateTime.Now,
                        FechaCierre = DateTime.Now,
                        MontoSistema = 0,
                        Diferencia = 0,
                        EmpresaId = 0
                    };
                }
                else
                {
                    //var idUltimaCaja = cajasEmpresa.Max(x => x.Id);

                    //var ultimaCaja = context.Cajas.FirstOrDefault(x => x.Id == idUltimaCaja);

                    //return new CajaDto
                    //{
                    //    Id = ultimaCaja.Id,
                    //    UsuarioApertura = ultimaCaja.UsuarioAperturaId,
                    //    UsuarioCierre = ultimaCaja.UsuarioCierreId,
                    //    MontoApertura = ultimaCaja.MontoApertura,
                    //    MontoCierre = ultimaCaja.MontoCierre,
                    //    FechaApertura = ultimaCaja.FechaApertura,
                    //    FechaCierre = ultimaCaja.FechaCierre,
                    //    MontoSistema = ultimaCaja.MontoSistema,
                    //    Diferencia = ultimaCaja.Diferencia,
                    //    EmpresaId = ultimaCaja.EmpresaId
                    //};
                }
            }
        }

        public long AbrirCaja(CajaDto caja)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cajaAbrir = new AccesoDatos.Caja
                {
                    //UsuarioAperturaId = caja.UsuarioApertura,
                    //UsuarioCierre = null,
                    MontoApertura = caja.MontoApertura,
                    MontoCierre = null,
                    FechaApertura = caja.FechaApertura,
                    FechaCierre = null,
                    MontoSistema = caja.MontoSistema,
                    Diferencia = null,
                    //EmpresaId = caja.EmpresaId
                };

                context.Cajas.Add(cajaAbrir);
                context.SaveChanges();

                return cajaAbrir.Id;
            }
        }

        public void CerrarCaja(CajaDto cerrar)
        {
            using (var context = new ModeloDatosContainer())
            {
                var cajaEmpresa = context.Cajas
                    .FirstOrDefault(x => x.Id == cerrar.Id);

                if(cajaEmpresa == null) throw new Exception("No se encontro caja");

                cajaEmpresa.Diferencia = cerrar.Diferencia;
                cajaEmpresa.FechaCierre = cerrar.FechaCierre;
                cajaEmpresa.MontoCierre = cerrar.MontoCierre;
                cajaEmpresa.UsuarioCierreId = cerrar.UsuarioCierre;

                context.SaveChanges();
            }
        }

        public IEnumerable<CajaDto> ObtenerTodas(long empresaId, string cadenaBuscar)
        {
            using (var context = new ModeloDatosContainer())
            {
                return context.Cajas.OfType<AccesoDatos.Caja>()
                    .AsNoTracking()
                    .Where(x => x.EmpresaId == empresaId)
                    .Select(x => new CajaDto
                    {
                        Id = x.Id,
                        Diferencia = x.Diferencia,
                        EmpresaId = x.EmpresaId,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        MontoSistema = x.MontoSistema,
                        UsuarioApertura = x.UsuarioAperturaId,
                        UsuarioAperturaNom = x.UsuarioApertura.Nombre,
                        UsuarioCierre = x.UsuarioCierreId,
                        UsuarioCierreNom = x.UsuarioCierre.Nombre,
                    }).OrderBy(x => x.FechaCierre).ToList();
            }
        }
    }
}

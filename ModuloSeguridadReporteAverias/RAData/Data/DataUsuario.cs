﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RAData.Context;
using RAEntities.Entities;

namespace RAData.Data
{
    public class DataUsuario
    {
       

        public DataUsuario()
        {
  
        }

        public async Task<Login> buscarUsuario(string usuario, string contrasenna)
        {
            Login login = new Login();
            var buscarLogin = new Login();
            using (var _context = new BDContext())
            {
                buscarLogin = await (from ua in _context.TRA_Usuario
                                     where ua.TC_Nombre == usuario && ua.TC_Contrasennia == contrasenna
                                     select new Login
                                     {
                                         ID = ua.TN_IdUsuario,
                                         Usuario = ua.TC_Nombre+' '+ua.TC_Apellido,
                                         rol = ua.TC_Rol
                                     }).FirstOrDefaultAsync();
            }

            if (buscarLogin == null)
            {
                login.ID = null;
                login.Usuario = null;
                login.rol = null;
            }
            else
            {
                login = buscarLogin;
            }
            return login;
        }

        public async Task<Rol> buscarUsuarioRol(string nombreOficina, int usuarioId)
        {
            Rol rol = new Rol();
            var buscarRol = new Rol();

            using (var _context = new BDContext())
            {
                var oficinaId = (from o in _context.TReporteDeAverias_Oficina
                                 where o.TC_Nombre == nombreOficina
                                 select o.TN_ID).FirstOrDefault();

                buscarRol = await (from uro in _context.TReporteDeAverias_UsuarioRolOficina
                                   join ua in _context.TRA_Usuario on uro.TN_UsuarioId equals ua.TN_IdUsuario
                                   join r in _context.TReporteDeAverias_Rol on uro.TN_RolId equals r.TN_ID
                                   join o in _context.TReporteDeAverias_Oficina on uro.TN_OficinaId equals o.TN_ID
                                   where uro.TN_UsuarioId == usuarioId && uro.TN_OficinaId == oficinaId
                                   select new Rol
                                   {
                                       TN_ID = r.TN_ID,
                                       TC_Nombre = r.TC_Nombre
                                   }).FirstOrDefaultAsync();
            }

            if (buscarRol == null)
            {
                rol.TN_ID = null;
                rol.TC_Nombre = null;
            }
            else
            {
                rol = buscarRol;
            }
            return rol;
        }
    }
}
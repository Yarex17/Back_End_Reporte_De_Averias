using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Data.Context;

namespace Data.Data
{
    public class DataUsuario
    {
        public async Task<List<Usuario>> listarUsuario()
        {
            using (var _context = new DBContext())
            {
                var usuarioBuscar = await (from ua in _context.TraUsuario
                                           join uro in _context.TReporteDeAverias_UsuarioRolOficina on ua.TN_ID equals uro.TN_UsuarioId
                                           join r in _context.TReporteDeAverias_Rol on uro.TN_RolId equals r.TN_ID
                                           join ti in _context.TReporteDeAverias_TipoIdentificacion on ua.TN_TipoIdentificacionId equals ti.TN_ID
                                           where r.TC_Nombre != "Administrador" && ua.TB_Activo != false
                                           select new UsuarioDatos
                                           {
                                               ID = ua.TN_ID,
                                               TipoIdentificacionId = ti.TN_ID,
                                               UsuarioActuailiza = ua.TC_UsuarioActuailiza,
                                               Observaciones = ua.TC_Observaciones,
                                               FechaActualiza = ua.TF_FechaActualiza,
                                               Rol = r.TC_Nombre,
                                               Nombre = ua.TC_Nombre,
                                               PrimerApellido = ua.TC_PrimerApellido,
                                               SegundoApellido = ua.TC_SegundoApellido,
                                               Identificacion = ua.TC_Identificacion,
                                               Usuario = ua.TC_Usuario,
                                               Correo = ua.TC_Correo,
                                               OficinaId = uro.TN_OficinaId,
                                               RolId = ua.
                                           }).ToListAsync();
                return usuarioBuscar;
            }
        }

        public async Task<String> registarUsuario(Usuario usuarioData)
        {
            try { 

            using (var dbContext = new DBContext()) {

                var usuario = new Usuario();
                usuario.TN_Oficina = usuarioData.TN_Oficina;
                usuario.TC_Rol = usuarioData.TC_Rol;
                usuario.TC_Nombre = usuarioData.TC_Nombre;
                usuario.TC_Apellido=usuarioData.TC_Apellido;
                usuario.TC_Cedula = usuarioData.TC_Cedula;
                usuario.TC_Correo=usuarioData.TC_Correo;
                usuario.TC_Contrasennia = usuarioData.TC_Contrasennia;
                usuario.TB_Activo = usuarioData.TB_Activo;
                usuario.TB_Eliminado = usuarioData.TB_Eliminado;
                    dbContext.TraUsuario.Add(usuario);
                await dbContext.SaveChangesAsync();

            }
            }
            catch (DbUpdateException)
            {

                return "No se pueden guardar los cambios. " +
                         "Vuelve a intentarlo y, si el problema persiste, " +
                         "consulte con el administrador del sistema.";
            }
            return "Usuario Registrado";
        }

        public async Task<List<Usuario>> buscarUsuario(string nombre)
        {
            return null;
        }

        public async Task<String> modificarEdificio(Usuario usuario)
        {

            return null;

        }

        public async Task<String> eliminarEdificio(Usuario usuario)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Entities.Context;

namespace Data.Data
{
    public class DataUsuario
    {
        DBContext dbContext = new DBContext();
        public async Task<List<TraUsuario>> listarUsuario()
        {
            var usuario = dbContext.TraUsuario.FromSqlRaw(@"exec AVRS.PA_BuscarUsuario").ToList();
            return usuario;
        }

        public void registarUsuario(TraUsuario usuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@TN_Oficina", usuario.TnOficina),
                new SqlParameter("@TC_Rol", usuario.TcRol),
                new SqlParameter("@TC_Nombre", usuario.TcNombre),
                new SqlParameter("@TC_Apellido", usuario.TcApellido),
                new SqlParameter("@TC_Cedula", usuario.TcCedula),
                new SqlParameter("@TC_Correo", usuario.TcCorreo),
                new SqlParameter("@TC_Contrasennia", usuario.TcContrasennia),
            };
            dbContext.TraUsuario.FromSqlRaw(@"exec AVRS.PA_CrearUsuario @TN_Oficina, @TC_Rol, @TC_Nombre, @TC_Apellido, @TC_Cedula, @TC_Correo, @TC_Contrasennia", parameters).ToList().FirstOrDefault();
        }

        public TraUsuario buscarUsuario(string nombre)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", nombre));
            TraUsuario usuario = dbContext.TraUsuario.FromSqlRaw(@"exec AVRS.PA_BuscarUsuario @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return usuario;
        }

        public async Task<TraUsuario> modificarUsuario(TraUsuario usuario)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdUsuario", usuario.TnIdUsuario));
            parameter.Add(new SqlParameter("@TC_Oficina", usuario.TnOficina));
            parameter.Add(new SqlParameter("@TC_Rol", usuario.TcRol));
            parameter.Add(new SqlParameter("@TC_Nombre", usuario.TcNombre));
            parameter.Add(new SqlParameter("@TC_Apellido", usuario.TcApellido));
            parameter.Add(new SqlParameter("@TC_Cedula", usuario.TcCedula));
            parameter.Add(new SqlParameter("@TC_Correo", usuario.TcCorreo));
            parameter.Add(new SqlParameter("@TC_Contrasennia", usuario.TcCorreo));
            parameter.Add(new SqlParameter("@TB_Activo", usuario.TcContrasennia));
            TraUsuario usuario1 = dbContext.TraUsuario.FromSqlRaw(@"exec AVRS.PA_ActualizarUsuario @TN_Oficina, @TC_Rol, @TC_Nombre, @TC_Apellido, @TC_Cedula, @TC_Correo, @TC_Contrasennia, @TC_Activo", parameter.ToArray()).ToList().FirstOrDefault();
            return usuario1;

        }

        public async Task<TraUsuario> eliminarUsuario(TraUsuario usuario)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdUsuario", usuario.TnIdUsuario));
            TraUsuario usuario1 = dbContext.TraUsuario.FromSqlRaw(@"exec AVRS.PA_EliminarUsuario @TN_IdUsuario", parameter.ToArray()).ToList().FirstOrDefault();
            return usuario1;
        }
    }
}
using Data.Context;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class PrioridadData
    {

        DBContext dbContext = new DBContext();
        public async Task<List<TraPrioridad>> listarPrioridad()
        {
            var prioridad = dbContext.TraPrioridad.FromSqlRaw(@"exec EDFS.PA_BuscarPrioridad").ToList();
            return prioridad;
        }

        public void registarPrioridad(TraPrioridad prioridad)
        {
            var parameters = new[]
        {
                new SqlParameter("@TC_Nombre", prioridad.TcNombre),
                new SqlParameter("@TB_Activa", prioridad.TbActiva),
                new SqlParameter("@TB_Eliminada", prioridad.TbEliminada)
            };
            dbContext.TraPrioridad.FromSqlRaw(@"exec EDFS.PA_CrearPrioridad @TC_Propietario,@TC_Nombre, @TB_Activa, @TB_Eliminada", parameters).ToList().FirstOrDefault();
        }

        public TraPrioridad buscarPrioridad(string nombre)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", nombre));
            TraPrioridad prioridad = dbContext.TraPrioridad.FromSqlRaw(@"exec EDFS.PA_BuscarPrioridad @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return prioridad;
        }

        public async Task<TraPrioridad> modificarPrioridad(TraPrioridad prioridad)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", prioridad.TcNombre));
            TraPrioridad prioridad1 = dbContext.TraPrioridad.FromSqlRaw(@"exec EDFS.PA_ActualizarPrioridad @TC_Propietario, @TC_Nombre, @TC_Activo", parameter.ToArray()).ToList().FirstOrDefault();
            return prioridad1;

        }

        public async Task<TraPrioridad> eliminarPrioridad(TraPrioridad prioridad)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdPrioridad", prioridad.TnIdPrioridad));
            TraPrioridad prioridad1 = dbContext.TraPrioridad.FromSqlRaw(@"exec AVRS.PA_EliminarEstado @TN_IdPrioridad", parameter.ToArray()).ToList().FirstOrDefault();
            return prioridad1;
        }
    }
}
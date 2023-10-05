using Data.Context;
using Entities;
using Entities.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class EstadoReporteData
    {
        DBContext dbContext = new DBContext();
        public async Task<List<TraEstado>> listarEstado()
        {
            var estado = dbContext.TraEstado.FromSqlRaw(@"exec AVRS.PA_BuscarEstado").ToList();
            return estado;
        }

        public void registarEstado(TraEstado estado)
        {
            var parameters = new[]
            {
                new SqlParameter("@TC_Nombre", estado.TcNombre),
            };
            dbContext.TraEstado.FromSqlRaw(@"exec AVRS.PA_CrearEstado @TC_Nombre", parameters).ToList().FirstOrDefault();
        }

        public TraEstado buscarEstado(string nombre)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", nombre));
            TraEstado Estado = dbContext.TraEstado.FromSqlRaw(@"exec AVRS.PA_BuscarEstado @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return Estado;
        }

        public async Task<TraEstado> modificarEstado(TraEstado estado)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdEstado", estado.TnIdEstado));
            parameter.Add(new SqlParameter("@TC_Propietario", estado.TcNombre));
            parameter.Add(new SqlParameter("@TB_Activo", estado.TbActivo));
            TraEstado estado1 = dbContext.TraEstado.FromSqlRaw(@"exec AVRS.PA_ActualizarEstado @TC_Nombre, @TC_Activo", parameter.ToArray()).ToList().FirstOrDefault();
            return estado1;

        }

        public async Task<TraEstado> eliminarEstado(TraEstado Estado)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdEstado", Estado.TnIdEstado));
            TraEstado estado1 = dbContext.TraEstado.FromSqlRaw(@"exec AVRS.PA_EliminarEstado @TN_IdEstado", parameter.ToArray()).ToList().FirstOrDefault();
            return estado1;
        }
    }
}
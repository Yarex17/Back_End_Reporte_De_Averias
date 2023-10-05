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
    internal class OficinaData
    {
        DBContext dbContext = new DBContext();

        public async Task<List<TraOficina>> listarOficina()
        {
            var oficina = dbContext.TraOficina.FromSqlRaw(@"exec EDFS.PA_BuscarOficina").ToList();
            return oficina;
        }

        public void registarOficina(TraOficina oficina)
        {
            var parameters = new[]
           {
                new SqlParameter("@TC_Numero_De_Piso", oficina.TnNumeroPiso),
                new SqlParameter("@TC_Oficina", oficina.TnEdificio),
            };
            dbContext.TraOficina.FromSqlRaw(@"exec EDFS.PA_CrearOficina @TC_Numero_De_Piso,@TC_Oficina", parameters).ToList().FirstOrDefault();
        }

        public TraOficina buscarOficina(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", id));
            TraOficina oficina = dbContext.TraOficina.FromSqlRaw(@"exec EDFS.PA_BuscarOficina @id", parameter.ToArray()).ToList().FirstOrDefault();
            return oficina;
        }


        public async Task<TraOficina> eliminarOficina(TraOficina oficina)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdOficina", oficina.TnIdOficina));
            TraOficina Oficina1 = dbContext.TraOficina.FromSqlRaw(@"exec AVRS.PA_EliminarOficina @TN_IdOficina", parameter.ToArray()).ToList().FirstOrDefault();
            return Oficina1;
        }
    }
}

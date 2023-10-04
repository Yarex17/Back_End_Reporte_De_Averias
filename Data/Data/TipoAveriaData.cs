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
    public class TipoAveriaData
    {
        DBContext dbContext = new DBContext();
        public async Task<List<TraTipoAveria>> listarTipoAveria()
        {
            var tipoAveria = dbContext.TraTipoAveria.FromSqlRaw(@"exec AVRS.PA_BuscarTipoAveria").ToList();
            return tipoAveria;
        }

        public void registarTipoAveria(TraTipoAveria tipoAveria)
        {
            var parameters = new[]
            {
                new SqlParameter("@TC_Descripcion", tipoAveria.TcDescripcion),
            };
            dbContext.TraTipoAveria.FromSqlRaw(@"exec AVRS.PA_CrearTipoAveria @TC_Nombre", parameters).ToList().FirstOrDefault();
        }

        public TraTipoAveria buscarTipoAveria(string nombre)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", nombre));
            TraTipoAveria tipoAveria = dbContext.TraTipoAveria.FromSqlRaw(@"exec AVRS.PA_BuscarTipoAveria @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return tipoAveria;
        }

        public async Task<TraTipoAveria> modificarTipoAveria(TraTipoAveria tipoAveria)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdTipoAveria", tipoAveria.TnIdTipoAveria));
            parameter.Add(new SqlParameter("@TC_Descripcion", tipoAveria.TcDescripcion));
            parameter.Add(new SqlParameter("@TB_Activo", tipoAveria.TbActivo));
            TraTipoAveria tipoAveria1 = dbContext.TraTipoAveria.FromSqlRaw(@"exec AVRS.PA_ActualizarTipoAveria @TN_IdTipoAveria, @TC_Descripcion, @TB_Activo", parameter.ToArray()).ToList().FirstOrDefault();
            return tipoAveria1;

        }

        public async Task<TraTipoAveria> eliminarTipoAveria(TraTipoAveria TipoAveria)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdTipoAveria", TipoAveria.TnIdTipoAveria));
            TraTipoAveria TipoAveria1 = dbContext.TraTipoAveria.FromSqlRaw(@"exec AVRS.PA_EliminarTipoAveria @TN_IdTipoAveria", parameter.ToArray()).ToList().FirstOrDefault();
            return TipoAveria1;
        }
    }
}
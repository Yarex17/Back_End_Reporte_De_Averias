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
    public class ReporteData
    {
        DBContext dbContext = new DBContext();

        public async Task<List<TraReporte>> listarReporte()
        {
            var Reporte = dbContext.TraReporte.FromSqlRaw(@"exec EDFS.PA_BuscarReporte").ToList();
            return Reporte;
        }

        public void registarReporte(TraReporte Reporte)
        {
            var parameters = new[]
           {
                new SqlParameter("@TN_Id_Reporte", Reporte.TnIdReporte),
                new SqlParameter("@TN_Tipo_De_Averia", Reporte.TnTipoAveria),
                new SqlParameter("@TN_Estado", Reporte.TnEstado),
                new SqlParameter("@TN_Oficina", Reporte.TnOficina),
                new SqlParameter("@TC_Descripcion", Reporte.TcDescripcion),
                new SqlParameter("@TB_Activado", Reporte.TbActivo),
                new SqlParameter("@TB_Eliminado", Reporte.TbEliminado),
            };
            dbContext.TraReporte.FromSqlRaw(@"exec EDFS.PA_CrearReporte @TN_Id_Reporte,@TN_Tipo_De_Averia,@TN_Estado,@TN_Oficina,@TB_Activado,@TB_Eliminado", parameters).ToList().FirstOrDefault();
        }

        public TraReporte buscarReporte(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", id));
            TraReporte Reporte = dbContext.TraReporte.FromSqlRaw(@"exec EDFS.PA_BuscarReporte @id", parameter.ToArray()).ToList().FirstOrDefault();
            return Reporte;
        }

        public async Task<TraReporte> modificarReporte(TraReporte Reporte)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdReporte", Reporte.TnIdReporte));
            parameter.Add(new SqlParameter("@TN_Estado", Reporte.TnEstado));
            parameter.Add(new SqlParameter("@TN_Tipo_De_Avería", Reporte.TnTipoAveria));
            parameter.Add(new SqlParameter("@TN_Tipo_De_Avería", Reporte.TnPrioridad));
            parameter.Add(new SqlParameter("@TN_Tipo_De_Avería", Reporte.TnOficina));
            parameter.Add(new SqlParameter("@TB_Activo", Reporte.TbActivo));
            TraReporte Reporte1 = dbContext.TraReporte.FromSqlRaw(@"exec EDFS.PA_ActualizarReporte @TN_Estado, @TN_Tipo_De_Avería,TnOficina,@TC_Activo", parameter.ToArray()).ToList().FirstOrDefault();
            return Reporte1;

        }

        public async Task<TraReporte> eliminarReporte(TraReporte Reporte)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdReporte", Reporte.TnIdReporte));
            TraReporte Reporte1 = dbContext.TraReporte.FromSqlRaw(@"exec AVRS.PA_EliminarReporte @TN_IdReporte", parameter.ToArray()).ToList().FirstOrDefault();
            return Reporte1;
        }
    }
}

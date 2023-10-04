using Data.Context;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;


namespace Data.Data
{
    public class EdificioData
    {
        DBContext dbContext = new DBContext(); 
        public async Task<List<TraEdificio>> listarEdificio()
        {

            var edificio = dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_BuscarEdificio @TC_Nombre").ToList();
            return edificio;
        }

        public void registarEdificio(TraEdificio edificio)
        {
            var parameters = new[]
            {
                new SqlParameter("@TC_Propietario", edificio.TcPropietario),
                new SqlParameter("@TC_Nombre", edificio.TcNombre),
            };
            dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_BuscarEdificio @TC_Propietario,@TC_Nombre", parameters).ToList().FirstOrDefault();
        }

        public TraEdificio buscarEdificio(string nombre)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", nombre)); 
            TraEdificio edificio = dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_BuscarEdificio @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return edificio;
        }

        public async Task<TraEdificio> modificarEdificio(TraEdificio edificio)
        {

            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", edificio.TcNombre));
            TraEdificio edificio1 = dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_BuscarEdificio @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return edificio;

        }

        public async Task<TraEdificio> eliminarEdificio(TraEdificio edificio)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", edificio.TcNombre));
            TraEdificio edificio1 = dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_BuscarEdificio @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return edificio1;
        }
    }
}
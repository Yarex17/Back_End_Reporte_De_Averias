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
    public class AccesoDatosSql
    {
        DBContext dbContext = new DBContext();

        #region CRUDUsuario


        public async Task<List<TraUsuario>> listarUsuario()
        {
            var usuario = dbContext.TraUsuario.FromSqlRaw(@"exec AVRS.PA_BuscarUsuario").ToList();
            return usuario;
        }

        public void registarUsuario(TraUsuario usuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@TC_Rol", usuario.TcRol),
                new SqlParameter("@TC_Nombre", usuario.TcNombre),
                new SqlParameter("@TC_Apellido", usuario.TcApellido),
                new SqlParameter("@TC_Cedula", usuario.TcCedula),
                new SqlParameter("@TC_Correo", usuario.TcCorreo),
                new SqlParameter("@TC_Contrasennia", usuario.TcContrasennia),
            };
            dbContext.TraUsuario.FromSqlRaw(@"exec AVRS.PA_CrearUsuario @TC_Rol, @TC_Nombre, @TC_Apellido, @TC_Cedula, @TC_Correo, @TC_Contrasennia", parameters).ToList().FirstOrDefault();
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
            parameter.Add(new SqlParameter("@TC_Rol", usuario.TcRol));
            parameter.Add(new SqlParameter("@TC_Nombre", usuario.TcNombre));
            parameter.Add(new SqlParameter("@TC_Apellido", usuario.TcApellido));
            parameter.Add(new SqlParameter("@TC_Cedula", usuario.TcCedula));
            parameter.Add(new SqlParameter("@TC_Correo", usuario.TcCorreo));
            parameter.Add(new SqlParameter("@TC_Contrasennia", usuario.TcCorreo));
            parameter.Add(new SqlParameter("@TB_Activo", usuario.TcContrasennia));
            TraUsuario usuario1 = dbContext.TraUsuario.FromSqlRaw(@"exec AVRS.PA_ActualizarUsuario @TC_Rol, @TC_Nombre, @TC_Apellido, @TC_Cedula, @TC_Correo, @TC_Contrasennia, @TC_Activo", parameter.ToArray()).ToList().FirstOrDefault();
            return usuario1;

        }

        public async Task<TraUsuario> eliminarUsuario(TraUsuario usuario)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdUsuario", usuario.TnIdUsuario));
            TraUsuario usuario1 = dbContext.TraUsuario.FromSqlRaw(@"exec AVRS.PA_EliminarUsuario @TN_IdUsuario", parameter.ToArray()).ToList().FirstOrDefault();
            return usuario1;
        }



        #endregion

        #region CRUDEDIFICIO
        public async Task<List<TraEdificio>> listarEdificio()
        {
            var edificio = dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_ListarEdificios").ToList();
            return edificio;
        }

        public bool registarEdificio(TraEdificio edificio)
        {
            var parameters = new[]
                {
                new SqlParameter("@TC_Propietario", edificio.TcPropietario),
                new SqlParameter("@TC_Nombre", edificio.TcNombre),
                };
            try
            { 
                dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_CrearEdificio @TC_Propietario,@TC_Nombre", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex) { 
            
            };
            return true;
        }

        public TraEdificio buscarEdificio(string nombre)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", nombre));
            TraEdificio edificio = dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_BuscarEdificio @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return edificio;
        }

        public bool modificarEdificio(TraEdificio edificio)
        {
            int activo = edificio.TbActivo ? 1 : 0;
            var parameters = new[]
            { 
                new SqlParameter("@TN_IdEdificio", edificio.TnIdEdificio),
                new SqlParameter("@TC_Propietario",edificio.TcPropietario),
                new SqlParameter("@TC_Nombre", edificio.TcNombre),
                new SqlParameter("@TB_Activo", activo)
            };

            try 
            {
                dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_ActualizarEdificio @TN_IdEdificio, @TC_Propietario, @TC_Nombre, @TB_Activo", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex) { 
            
            };

            return true;
        }

        public async Task<TraEdificio> eliminarEdificio(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdEdificio", id));
            TraEdificio edificio1 = dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.SP_EliminarEdificio @TN_IdEdificio", parameter.ToArray()).ToList().FirstOrDefault();
            return edificio1;
        }
        #endregion

        #region CRUDESTADO
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

        #endregion

        #region CRUDOFICINA
        public async Task<List<TraOficina>> listarOficina(int id)
        {
            var parameters = new[]
                {
                new SqlParameter("@TN_IdEdificio", id)
            };
            var oficina = dbContext.TraOficina.FromSqlRaw(@"exec EDFS.PA_ListarOficinasPorEdificio @TN_IdEdificio", parameters).ToList();
            return oficina;
        }

        public void registarOficina(TraOficina oficina)
        {
            var parameters = new[]
           {
                new SqlParameter("@TC_Numero_De_Piso", oficina.TnNumeroPiso)
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

        #endregion

        #region CRUDPRIORIDAD

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


        #endregion

        #region CRUDREPARACIÓN
        public async Task<List<Reparacion>> listarReparacion()
        {
            return null;
        }

        public async Task<String> registarReparacion(Reparacion reparacion)
        {
            return null;
        }

        public async Task<List<EstadoReporte>> buscarReparacion(string nombre)
        {
            return null;
        }

        public async Task<String> modificarReparacion(Reparacion reparacion)
        {

            return null;

        }

        public async Task<String> eliminarReparacion(Reparacion reparacion)
        {
            return null;
        }
        #endregion

        #region CRUDREPORTE
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
                new SqlParameter("@TC_Descripcion", Reporte.TcDescripcion),
                new SqlParameter("@TB_Activado", Reporte.TbActivo),
                new SqlParameter("@TB_Eliminado", Reporte.TbEliminado),
            };
            dbContext.TraReporte.FromSqlRaw(@"exec EDFS.PA_CrearReporte @TN_Id_Reporte,@TB_Activado,@TB_Eliminado", parameters).ToList().FirstOrDefault();
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
            parameter.Add(new SqlParameter("@TB_Activo", Reporte.TbActivo));
            TraReporte Reporte1 = dbContext.TraReporte.FromSqlRaw(@"exec EDFS.PA_ActualizarReporte @TC_Activo", parameter.ToArray()).ToList().FirstOrDefault();
            return Reporte1;

        }

        public async Task<TraReporte> eliminarReporte(TraReporte Reporte)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdReporte", Reporte.TnIdReporte));
            TraReporte Reporte1 = dbContext.TraReporte.FromSqlRaw(@"exec AVRS.PA_EliminarReporte @TN_IdReporte", parameter.ToArray()).ToList().FirstOrDefault();
            return Reporte1;
        }

        #endregion

        #region CRUDTIPODEAVERIA

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

        #endregion

    }
}

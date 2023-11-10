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
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Data.Data
{
    public class AccesoDatosSql
    {
        DBContext dbContext = new DBContext();

        #region CRUDUsuario


        public async Task<List<TraUsuario>> listarUsuario()
        {
            var usuario = dbContext.TraUsuario.FromSqlRaw(@"exec USRS.PA_ListarUsuarios").ToList();
            return usuario;
        }

        public bool registarUsuario(TraUsuario usuario, int idOficina)
        {
            var parameters = new[]
            {
                new SqlParameter("@TC_Rol", usuario.TcRol),
                new SqlParameter("@TC_Nombre", usuario.TcNombre),
                new SqlParameter("@TC_Apellido", usuario.TcApellido),
                new SqlParameter("@TC_Cedula", usuario.TcCedula),
                new SqlParameter("@TC_Correo", usuario.TcCorreo),
                new SqlParameter("@TC_Contrasennia", usuario.TcContrasennia),
                new SqlParameter("@TN_IdOficina", idOficina),
            };
            try
            {
                dbContext.TraUsuario.FromSqlRaw(@"exec USRS.PA_CrearUsuario @TC_Rol, @TC_Nombre, @TC_Apellido, @TC_Cedula, @TC_Correo, @TC_Contrasennia, @TN_IdOficina", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            }
            return true;

        }

        public TraUsuario buscarUsuario(string nombre)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", nombre));
            TraUsuario usuario = dbContext.TraUsuario.FromSqlRaw(@"exec AVRS.PA_BuscarUsuario @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return usuario;
        }

        public TraUsuario buscarTraUsuarioPorEdificioYRol(int idEdificio, string rol)
        {
            var parameters = new[]
            {
                 new SqlParameter("@TN_IdEdificio", idEdificio),
                 new SqlParameter("@TC_Rol", rol)
            };
            TraUsuario usuario = dbContext.TraUsuario.FromSqlRaw(@"exec USRS.PA_BuscarUsuarioPorEdificioYRol @TN_IdEdificio, @TC_Rol", parameters).ToList().FirstOrDefault();
            return usuario;
        }

        public TraUsuario buscarJefeTecnico()
        {
            TraUsuario usuario = dbContext.TraUsuario.FromSqlRaw(@"exec USRS.PA_BuscarJefeTecnico").ToList().FirstOrDefault();
            return usuario;
        }

        public bool modificarUsuario(TraUsuario usuario, int idOficinaNueva)
        {
            int activo = usuario.TbActivo ? 1 : 0;
            var parameters = new[]
            {
                new SqlParameter("@TN_IdUsuario", usuario.TnIdUsuario),
                new SqlParameter("@TC_Rol", usuario.TcRol),
                new SqlParameter("@TC_Nombre", usuario.TcNombre),
                new SqlParameter("@TC_Apellido", usuario.TcApellido),
                new SqlParameter("@TC_Cedula", usuario.TcCedula),
                new SqlParameter("@TC_Correo", usuario.TcCorreo),
                new SqlParameter("@TC_Contrasennia", usuario.TcContrasennia),
                new SqlParameter("@TB_Activo", activo),
                new SqlParameter("@TN_IdOficinaNueva", idOficinaNueva),
            };
            try
            {
                dbContext.TraUsuario.FromSqlRaw(@"exec USRS.PA_ActualizarUsuario @TN_IdUsuario, @TC_Rol, @TC_Nombre, @TC_Apellido, @TC_Cedula, @TC_Correo, @TC_Contrasennia, @TB_Activo, @TN_IdOficinaNueva", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            }
            return true;
        }

        public async Task<TraUsuario> eliminarUsuario(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdUsuario", id));
            TraUsuario usuario1 = dbContext.TraUsuario.FromSqlRaw(@"exec USRS.PA_EliminarUsuario @TN_IdUsuario", parameter.ToArray()).ToList().FirstOrDefault();
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
            catch (Exception ex)
            {

            };
            return true;
        }

        public TraEdificio buscarEdificio(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdEdificio", id));
            TraEdificio edificio = dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_BuscarEdificio @TN_IdEdificio", parameter.ToArray()).ToList().FirstOrDefault();
            return edificio;
        }

        public TraEdificio buscarEdificioPorUsuario(int idUsuario) 
        {
            var parameters = new[]
            {
                 new SqlParameter("@TN_IdUsuario", idUsuario),
            };
            TraEdificio edificio = dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_BuscarEdificioPorUsuario @TN_IdUsuario", parameters).ToList().FirstOrDefault();
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
            catch (Exception ex)
            {

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
            var estado = dbContext.TraEstado.FromSqlRaw(@"exec AVRS.PA_ListarEstados").ToList();
            return estado;
        }

        public bool registarEstado(String nombre)
        {
            var parameters = new[]
            {
                new SqlParameter("@TC_Nombre", nombre)
            };

            try
            {
                dbContext.TraEstado.FromSqlRaw(@"exec AVRS.PA_CrearEstado @TC_Nombre", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };
            return true;
        }

        public TraEstado buscarEstado(string nombre)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", nombre));
            TraEstado Estado = dbContext.TraEstado.FromSqlRaw(@"exec AVRS.PA_BuscarEstado @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return Estado;
        }

        public bool modificarEstado(TraEstado estado)
        {

            int activo = estado.TbActivo ? 1 : 0;
            var parameters = new[]
            {
               new SqlParameter("@TN_IdEstado", estado.TnIdEstado),
               new SqlParameter("@TC_Propietario", estado.TcNombre),
               new SqlParameter("@TB_Activo", estado.TbActivo)
            };

            try
            {
                dbContext.TraEstado.FromSqlRaw(@"exec AVRS.PA_ActualizarEstado @TN_IdEstado, @TC_Propietario, @TB_Activo", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };

            return true;

        }

        public async Task<TraEstado> eliminarEstado(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdEstado",id));
            TraEstado estado1 = dbContext.TraEstado.FromSqlRaw(@"exec AVRS.PA_EliminarEstado @TN_IdEstado", parameter.ToArray()).ToList().FirstOrDefault();
            return estado1;
        }

        #endregion

        #region CRUDOFICINA
        public async Task<List<TraOficina>> listarOficina()
        {
            
            var oficina = dbContext.TraOficina.FromSqlRaw(@"exec EDFS.PA_ListarOficinas").ToList();
            return oficina;
        }

        public bool registarOficina(int numeroPiso, int idEdificio)
        {
            var parameters = new[]
            {
                new SqlParameter("@TN_NumeroPiso", numeroPiso),
                new SqlParameter("@TN_IdEdificio", idEdificio)
            };
            try
            {
                dbContext.TraOficina.FromSqlRaw(@"exec EDFS.PA_CrearOficina @TN_NumeroPiso, @TN_IdEdificio", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            }
            return true;
        }

        public TraOficina buscarOficina(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", id));
            TraOficina oficina = dbContext.TraOficina.FromSqlRaw(@"exec EDFS.PA_BuscarOficina @id", parameter.ToArray()).ToList().FirstOrDefault();
            return oficina;
        }

        public bool modificarOficina(TraOficina traOficina)
        {
            int activo = (bool)traOficina.TbActivo ? 1 : 0;
            var parameters = new[]
            {
                new SqlParameter("@TN_IdOficina", traOficina.TnIdOficina),
                new SqlParameter("@TN_NumeroPiso",traOficina.TnNumeroPiso),
                new SqlParameter("@TB_Activa", activo)
            };

            try
            {
                dbContext.TraEdificio.FromSqlRaw(@"exec EDFS.PA_ActualizarOficina @TN_IdOficina, @TN_NumeroPiso, @TB_Activa", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };

            return true;
        }

        public async Task<TraOficina> eliminarOficina(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdOficina", id));
            TraOficina oficina1 = dbContext.TraOficina.FromSqlRaw(@"exec EDFS.PA_EliminarOficina @TN_IdOficina", parameter.ToArray()).ToList().FirstOrDefault();
            return oficina1;
        }

        #endregion

        #region CRUDPRIORIDAD

        public async Task<List<TraPrioridad>> listarPrioridad()
        {
            var prioridad = dbContext.TraPrioridad.FromSqlRaw(@"exec AVRS.PA_ListarPrioridades").ToList();
            return prioridad;
        }

        public bool registarPrioridad(String nombre)
        {
            var parameters = new[]
        {
                new SqlParameter("@TC_Nombre", nombre)
            };


            try
            {
                dbContext.TraPrioridad.FromSqlRaw(@"exec AVRS.PA_CrearPrioridad @TC_Nombre", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };
            return true;
        }

        public TraPrioridad buscarPrioridad(string nombre)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", nombre));
            TraPrioridad prioridad = dbContext.TraPrioridad.FromSqlRaw(@"exec AVRS.PA_BuscarPrioridad @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return prioridad;
        }

        public bool modificarPrioridad(TraPrioridad prioridad)
        {

            int activo = prioridad.TbActiva ? 1 : 0;
            var parameters = new[]
            {
                new SqlParameter("@TN_IdPrioridad", prioridad.TnIdPrioridad),
                new SqlParameter("@TC_Nombre", prioridad.TcNombre),
                new SqlParameter("@TB_Activa", prioridad.TbActiva)
            };

            try
            {
                dbContext.TraPrioridad.FromSqlRaw(@"exec AVRS.PA_ActualizarPrioridad @TN_IdPrioridad, @TC_Nombre, @TB_Activa", parameters.ToArray()).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };

            return true;

        }

        public async Task<TraPrioridad> eliminarPrioridad(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdPrioridad", id));
            TraPrioridad prioridad1 = dbContext.TraPrioridad.FromSqlRaw(@"exec AVRS.PA_EliminarPrioridad @TN_IdPrioridad", parameter.ToArray()).ToList().FirstOrDefault();
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
            var Reporte = dbContext.TraReporte.FromSqlRaw(@"exec AVRS.PA_ListarReportes").ToList();
            return Reporte;
        }

        public async Task<List<TraReporte>> listarReportesPorUsuario(int idUsuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@TN_IdUsuario", idUsuario)
            };
            var Reporte = dbContext.TraReporte.FromSqlRaw(@"exec AVRS.PA_ListarReportesPorUsusario @TN_idUsuario", parameters).ToList();
            return Reporte;
        }

        public bool registarReporte(string descripcion, int idUsuario, int idAdminEdificio)
        {
            var parameters = new[]
            {
                new SqlParameter("@TC_Descripcion", descripcion),
                new SqlParameter("@TN_IdUsuario", idUsuario),
                new SqlParameter("@TN_IdAdminEdificio", idAdminEdificio)
            };

            try
            {
                dbContext.TraReporte.FromSqlRaw(@"exec AVRS.PA_CrearReporte @TC_Descripcion, @TN_IdUsuario, @TN_IdAdminEdificio", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };
            return true;
            
        }

        public bool enviarTraReporte(int idReporte, int idUsuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@TN_IdReporte", idReporte),
                new SqlParameter("@TN_IdUsuario", idUsuario)
            };

            try
            {
                dbContext.TraReporte.FromSqlRaw(@"exec AVRS.PA_EnviarReporte @TN_IdReporte, @TN_IdUsuario", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };
            return true;
        }

            public TraReporte buscarReporte(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@id", id));
            TraReporte Reporte = dbContext.TraReporte.FromSqlRaw(@"exec EDFS.PA_BuscarReporte @id", parameter.ToArray()).ToList().FirstOrDefault();
            return Reporte;
        }

        public bool agregarDatosReporte(int idReporte, int tipoAveria, int prioridad, int estado, int oficina)
        {
            var parameters = new[]
            {
               new SqlParameter("@TN_IdReporte", idReporte),
               new SqlParameter("@TN_TipoAveria", tipoAveria),
               new SqlParameter("@TN_Prioridad", prioridad),
               new SqlParameter("@TN_Estado", estado),
               new SqlParameter("@TN_IdOficina", oficina)
            };

            try
            {
                dbContext.TraReporte.FromSqlRaw(@"exec AVRS.PA_AgregarDatosReporte @TN_IdReporte, @TN_TipoAveria, @TN_Prioridad, @TN_Estado, @TN_IdOficina", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };
            return true;

        }

        public bool modificarReporte(TraReporte traReporte, int tipoAveria, int prioridad, int estado, int oficina)
        {
            var parameters = new[]
             {
               new SqlParameter("@TN_IdReporte", traReporte.TnIdReporte),
               new SqlParameter("@TC_Descripcion", traReporte.TcDescripcion),
               new SqlParameter("@TB_Activo", traReporte.TbActivo),
               new SqlParameter("@TN_TipoAveria", tipoAveria),
               new SqlParameter("@TN_Prioridad", prioridad),
               new SqlParameter("@TN_Estado", estado),
               new SqlParameter("@TN_IdOficina", oficina)
            };

            try
            {
                dbContext.TraReporte.FromSqlRaw(@"exec AVRS.PA_ActualizarReporte @TN_IdReporte, @TC_Descripcion, @TB_Activo, @TN_TipoAveria, @TN_Prioridad, @TN_Estado, @TN_IdOficina", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };
            return true;

        }

        public async Task<TraReporte> eliminarReporte(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdReporte", id));
            TraReporte Reporte1 = dbContext.TraReporte.FromSqlRaw(@"exec AVRS.PA_EliminarReporte @TN_IdReporte", parameter.ToArray()).ToList().FirstOrDefault();
            return Reporte1;
        }

        #endregion

        #region CRUDTIPODEAVERIA

        public async Task<List<TraTipoAveria>> listarTipoAveria()
        {
            var tipoAveria = dbContext.TraTipoAveria.FromSqlRaw(@"exec AVRS.PA_ListarTiposAveria").ToList();
            return tipoAveria;
        }

        public bool registarTipoAveria(string descripcion)
        {
            var parameters = new[]
            {
                new SqlParameter("@TC_Descripcion", descripcion),
            };

            try
            {
                dbContext.TraTipoAveria.FromSqlRaw(@"exec AVRS.PA_CrearTipoAveria @TC_Descripcion", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };
            return true;

        }

        public TraTipoAveria buscarTipoAveria(string nombre)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TC_Nombre", nombre));
            TraTipoAveria tipoAveria = dbContext.TraTipoAveria.FromSqlRaw(@"exec AVRS.PA_BuscarTipoAveria @TC_Nombre", parameter.ToArray()).ToList().FirstOrDefault();
            return tipoAveria;
        }

        public bool modificarTipoAveria(TraTipoAveria tipoAveria)
        {
            var parameters = new[]
             {
                 new SqlParameter("@TN_IdTipoAveria", tipoAveria.TnIdTipoAveria),
                 new SqlParameter("@TC_Descripcion", tipoAveria.TcDescripcion),
                 new SqlParameter("@TB_Activo", tipoAveria.TbActivo)
            };

            try
            {
                dbContext.TraTipoAveria.FromSqlRaw(@"exec AVRS.PA_ActualizarTipoAveria @TN_IdTipoAveria, @TC_Descripcion, @TB_Activo", parameters).ToList().FirstOrDefault();
                return false;
            }
            catch (Exception ex)
            {

            };
            return true;


        }

        public async Task<TraTipoAveria> eliminarTipoAveria(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TN_IdTipoAveria", id));
            TraTipoAveria TipoAveria1 = dbContext.TraTipoAveria.FromSqlRaw(@"exec AVRS.PA_EliminarTipoAveria @TN_IdTipoAveria", parameter.ToArray()).ToList().FirstOrDefault();
            return TipoAveria1;
        }

        #endregion

    }
}

using Data.Data;
using Entities;
using Entities.Context;
using System.Xml.Linq;
namespace Negocio

{
    public class NegocioSQL
    {
        public AccesoDatosSql _accesoDatosSQL; 
        public NegocioSQL()
        {
            _accesoDatosSQL = new AccesoDatosSql();
        }

        #region CRUDUSUARIO

        public Task<List<TraUsuario>> listarUsuario()
        {
            return _accesoDatosSQL.listarUsuario();
        }
        public bool registarUsuario(TraUsuario usuario, int idOficina)
        {
            return _accesoDatosSQL.registarUsuario(usuario, idOficina);
        }
        public TraUsuario buscarUsuario(string nombre)
        {
            return _accesoDatosSQL.buscarUsuario(nombre);
        }

        public TraUsuario buscarTraUsuarioPorEdificioYRol(int idEdificio, string rol)
        {
            return _accesoDatosSQL.buscarTraUsuarioPorEdificioYRol(idEdificio, rol);
        }

        public TraUsuario buscarJefeTecnico()
        {
            return _accesoDatosSQL.buscarJefeTecnico();
        }

        public List<TraUsuario> buscarTecnicos() {
            
            return _accesoDatosSQL.buscarTecnicos();
        }

        public bool modificarUsuario(TraUsuario usuario, int idOficinaNueva)
        {
            return _accesoDatosSQL.modificarUsuario(usuario, idOficinaNueva);
        }
        public void eliminarUsuario(int id)
        {
            _accesoDatosSQL.eliminarUsuario(id);
        }
        #endregion

        #region CRUDEDIFICIO

        public Task<List<TraEdificio>> listarEdificio()
        {
            return _accesoDatosSQL.listarEdificio();
        }
        public bool registarEdificio(TraEdificio edificio)
        {
            return _accesoDatosSQL.registarEdificio(edificio);
        }
        public TraEdificio buscarEdificio(int id)
        {
            return _accesoDatosSQL.buscarEdificio(id);
        }

        public TraEdificio buscarEdificioPorUsario(int idUsuario)
        {
            return _accesoDatosSQL.buscarEdificioPorUsuario(idUsuario);
        }

        public bool modificarEdificio(TraEdificio edificio)
        {
            return _accesoDatosSQL.modificarEdificio(edificio);
        }
        public void eliminarEdificio(int id)
        {
            _accesoDatosSQL.eliminarEdificio(id);
        }
        #endregion

        #region CRUDESTADO

        public Task<List<TraEstado>> listarEstado()
        {
            return _accesoDatosSQL.listarEstado();
        }
        public bool registarEstado(String nombre)
        {
            return _accesoDatosSQL.registarEstado(nombre);
        }
        public TraEstado buscarEstado(string nombre)
        {
            return _accesoDatosSQL.buscarEstado(nombre);
        }
        public bool modificarEstado(TraEstado estado)
        {
            return _accesoDatosSQL.modificarEstado(estado);
        }
        public void eliminarEstado(int id)
        {
            _accesoDatosSQL.eliminarEstado(id);
        }
        #endregion

        #region CRUDOFICINA

        public Task<List<TraOficina>> listarOficina()
        {
            return _accesoDatosSQL.listarOficina();
        }
        public bool registarOficina(int numeroPiso, int idEdificio)
        {
            return _accesoDatosSQL.registarOficina(numeroPiso, idEdificio);
        }
        public TraOficina buscarOficina(int id)
        {
            return _accesoDatosSQL.buscarOficina(id);
        }

        public bool modificarOficina(TraOficina traOficina)
        {
            return _accesoDatosSQL.modificarOficina(traOficina);
        }

        public void eliminarOficina(int id)
        {
            _accesoDatosSQL.eliminarOficina(id);
        }
        #endregion

        #region CRUDPRIORIDAD

        public Task<List<TraPrioridad>> listarPrioridad()
        {
            return _accesoDatosSQL.listarPrioridad();
        }
        public bool registarPrioridad(String nombre)
        {
            return _accesoDatosSQL.registarPrioridad(nombre);
        }
        public TraPrioridad buscarPrioridad(string nombre)
        {
            return _accesoDatosSQL.buscarPrioridad(nombre);
        }
        public bool modificarPrioridad(TraPrioridad prioridad)
        {
            return _accesoDatosSQL.modificarPrioridad(prioridad);
        }
        public void eliminarPrioridad(int id)
        {
            _accesoDatosSQL.eliminarPrioridad(id);
        }
        #endregion

        #region CRUDREPORTE

        public Task<List<TraReporte>> listarReporte()
        {
            return _accesoDatosSQL.listarReporte();
        }
        public Task<List<TraReporte>> listarReportesPorUsuario(int idUsuario)
        {
            return _accesoDatosSQL.listarReportesPorUsuario(idUsuario);
        }
        public Task<List<TraReporte>> listarTraReportesPorUsuarioYEstado(int idUsuario, string nombreEstado)
        {
            return _accesoDatosSQL.listarReportesPorUsuarioYEstado(idUsuario, nombreEstado);
        }
        public bool registarReporte(string descripcion, int idUsuario, int idAdminEdificio)
        {
            return _accesoDatosSQL.registarReporte(descripcion, idUsuario, idAdminEdificio);
        }

        public bool enviarTraReporte(int idReporte, int idUsuario)
        {
            return _accesoDatosSQL.enviarTraReporte(idReporte, idUsuario);
        }

        public TraReporte buscarReporte(int id)
        {
            return _accesoDatosSQL.buscarReporte(id);
        }
        public bool agregarDatosReporte(int idReporte, int tipoAveria, int prioridad, int estado)
        {
            return _accesoDatosSQL.agregarDatosReporte(idReporte, tipoAveria, prioridad, estado);
        }

        public bool modificarReporteTecnico(int idReporte, string descripcion, int idEstado)
        {
            return _accesoDatosSQL.modificarReporteTecnico(idReporte, descripcion, idEstado);
        }

            public bool modificarReporte(TraReporte reporte, int tipoAveria, int prioridad, int estado)
        {
            return _accesoDatosSQL.modificarReporte(reporte, tipoAveria, prioridad, estado);
        }
        public void eliminarReporte(int id)
        {
            _accesoDatosSQL.eliminarReporte(id);
        }
        #endregion

        #region CRUDTIPODEAVERIA

        public Task<List<TraTipoAveria>> listarTipoAveria()
        {
            return _accesoDatosSQL.listarTipoAveria();
        }
        public bool registarTipoAveria(string descripcion)
        {
            return _accesoDatosSQL.registarTipoAveria(descripcion);
        }
        public TraTipoAveria buscarTipoAveria(string nombre)
        {
            return _accesoDatosSQL.buscarTipoAveria(nombre);
        }
        public bool modificarTipoAveria(TraTipoAveria tipoAveria)
        {
           return _accesoDatosSQL.modificarTipoAveria(tipoAveria);
        }
        public void eliminarTipoAveria(int id)
        {
            _accesoDatosSQL.eliminarTipoAveria(id);
        }
        #endregion
    }


}
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
        public void registarUsuario(TraUsuario usuario)
        {
            _accesoDatosSQL.registarUsuario(usuario);
        }
        public TraUsuario buscarUsuario(string nombre)
        {
            return _accesoDatosSQL.buscarUsuario(nombre);
        }
        public void modificarUsuario(TraUsuario usuario)
        {
            _accesoDatosSQL.modificarUsuario(usuario);
        }
        public void eliminarUsuario(TraUsuario usuario)
        {
            _accesoDatosSQL.eliminarUsuario(usuario);
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
        public TraEdificio buscarEdificio(string nombre)
        {
            return _accesoDatosSQL.buscarEdificio(nombre);
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
        public void registarEstado(TraEstado estado)
        {
            _accesoDatosSQL.registarEstado(estado);
        }
        public TraEstado buscarEstado(string nombre)
        {
            return _accesoDatosSQL.buscarEstado(nombre);
        }
        public void modificarEstado(TraEstado estado)
        {
            _accesoDatosSQL.modificarEstado(estado);
        }
        public void eliminarEstado(TraEstado estado)
        {
            _accesoDatosSQL.eliminarEstado(estado);
        }
        #endregion

        #region CRUDOFICINA

        public Task<List<TraOficina>> listarOficina()
        {
            return _accesoDatosSQL.listarOficina();
        }
        public void registarOficina(TraOficina oficina)
        {
            _accesoDatosSQL.registarOficina(oficina);
        }
        public TraOficina buscarOficina(int id)
        {
            return _accesoDatosSQL.buscarOficina(id);
        }
        public void eliminarOficina(TraOficina oficina)
        {
            _accesoDatosSQL.eliminarOficina(oficina);
        }
        #endregion

        #region CRUDPRIORIDAD

        public Task<List<TraPrioridad>> listarPrioridad()
        {
            return _accesoDatosSQL.listarPrioridad();
        }
        public void registarPrioridad(TraPrioridad prioridad)
        {
            _accesoDatosSQL.registarPrioridad(prioridad);
        }
        public TraPrioridad buscarPrioridad(string nombre)
        {
            return _accesoDatosSQL.buscarPrioridad(nombre);
        }
        public void modificarPrioridad(TraPrioridad prioridad)
        {
            _accesoDatosSQL.modificarPrioridad(prioridad);
        }
        public void eliminarPrioridad(TraPrioridad prioridad)
        {
            _accesoDatosSQL.eliminarPrioridad(prioridad);
        }
        #endregion

        #region CRUDREPORTE

        public Task<List<TraReporte>> listarReporte()
        {
            return _accesoDatosSQL.listarReporte();
        }
        public void registarReporte(TraReporte reporte)
        {
            _accesoDatosSQL.registarReporte(reporte);
        }
        public TraReporte buscarReporte(int id)
        {
            return _accesoDatosSQL.buscarReporte(id);
        }
        public void modificarReporte(TraReporte reporte)
        {
            _accesoDatosSQL.modificarReporte(reporte);
        }
        public void eliminarReporte(TraReporte reporte)
        {
            _accesoDatosSQL.eliminarReporte(reporte);
        }
        #endregion

        #region CRUDTIPODEAVERIA

        public Task<List<TraTipoAveria>> listarTipoAveria()
        {
            return _accesoDatosSQL.listarTipoAveria();
        }
        public void registarTipoAveria(TraTipoAveria tipoAveria)
        {
            _accesoDatosSQL.registarTipoAveria(tipoAveria);
        }
        public TraTipoAveria buscarTipoAveria(string nombre)
        {
            return _accesoDatosSQL.buscarTipoAveria(nombre);
        }
        public void modificarTipoAveria(TraTipoAveria tipoAveria)
        {
            _accesoDatosSQL.modificarTipoAveria(tipoAveria);
        }
        public void eliminarTipoAveria(TraTipoAveria tipoAveria)
        {
            _accesoDatosSQL.eliminarTipoAveria(tipoAveria);
        }
        #endregion
    }


}
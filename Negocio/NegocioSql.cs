using Data.Data;
using System.Xml.Linq;
namespace Negocio

{
    public class NegocioSQL
    {
        public AccesoDatosSql _accesoDatosSQL = new AccesoDatosSql();
        public NegocioSQL(AccesoDatosSql accesoDatosSQL)
        {
            _accesoDatosSQL = accesoDatosSQL;
        }

        #region Actors
        //public bool AgregarActors(Actors P_Entidad)
        //{
        //    return _accesoDatosSQL.AgregarActors(P_Entidad);
        //}
        //public List<Actors> ConsultarActors(Actors P_Entidad)
        //{
        //    return _accesoDatosSQL.ConsultarActors(P_Entidad);
        //}
        //public bool ModificarActors(Actors P_Entidad)
        //{
        //    return _accesoDatosSQL.ModificarActors(P_Entidad);
        //}
        //public bool EliminarActors(Actors P_Entidad)
        //{
        //    return _accesoDatosSQL.EliminarActors(P_Entidad);
        //}
        #endregion

    }


}
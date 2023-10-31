using RAData.Data;
using RAEntities.Entities;

namespace RABusiness.Business
{
    public class UsuarioBusiness
    {
        private DataUsuario dataUsuario;

        public UsuarioBusiness()
        {
            dataUsuario = new DataUsuario();
        }

        public async Task<Login> buscarUsuario(string usuario, string contrasenna)
        {
            return await dataUsuario.buscarUsuario(usuario, contrasenna);
        }

        public async Task<Rol> buscarUsuarioRol(string nombreOficina, int usuarioId)
        {
            return await dataUsuario.buscarUsuarioRol(nombreOficina, usuarioId);
        }
    }
}
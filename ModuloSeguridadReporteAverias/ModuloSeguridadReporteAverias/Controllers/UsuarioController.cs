using Microsoft.AspNetCore.Mvc;
using RABusiness.Business;
using RAEntities.Entities;

namespace ModuloSeguridadReporteAverias.Controllers
{
    public class UsuarioController : Controller
    {
        public IConfiguration Configuration { get; }
        public UsuarioController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        [Route("buscarUsuario")]
        public async Task<Login> buscarUsuario(string usuario, string contrasenna)
        {
            return await (new UsuarioBusiness().buscarUsuario(usuario, contrasenna));
        }

        [HttpPost]
        [Route("buscarUsuarioRol")]
        public async Task<Rol> buscarUsuarioRol(string nombreOficina, int usuarioId)
        {
            return await (new UsuarioBusiness().buscarUsuarioRol(nombreOficina, usuarioId));
        }
    }
}

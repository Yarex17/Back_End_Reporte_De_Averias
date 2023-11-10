using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Context;
using Negocio;

namespace Reporte_De_Averias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraUsuariosController : ControllerBase
    {
        private readonly DBContext _context = new DBContext();
        private readonly NegocioSQL _negocioSql = new NegocioSQL();

        // GET: api/TraUsuarios
        [HttpGet]
        [Route(nameof(ListarTraUsario))]
        public async Task<ActionResult<IEnumerable<TraUsuario>>> ListarTraUsario()
        {
          if (_context.TraUsuario == null)
          {
              return NotFound();
          }
            return await _context.TraUsuario.ToListAsync();
        }

        // GET: api/TraUsuarios/5
        [HttpGet]
        [Route(nameof(BuscarTraUsario))]
        public async Task<ActionResult<TraUsuario>> BuscarTraUsario(int id)
        {
          if (_context.TraUsuario == null)
          {
              return NotFound();
          }
            var traUsuario = await _context.TraUsuario.FindAsync(id);

            if (traUsuario == null)
            {
                return NotFound();
            }

            return traUsuario;
        }

        [HttpPost]
        [Route(nameof(BuscarTraUsarioPorEdificioYRol))]
        public async Task<TraUsuario> BuscarTraUsarioPorEdificioYRol(int idEdificio, string rol)
        {
            return _negocioSql.buscarTraUsuarioPorEdificioYRol(idEdificio, rol);
        }

        [HttpGet]
        [Route(nameof(BuscarJefeTecnico))]
        public async Task<TraUsuario> BuscarJefeTecnico()
        {
            return _negocioSql.buscarJefeTecnico();
        }

        // PUT: api/TraUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route(nameof(CrearTraUsario))]
        public bool CrearTraUsario(string rol, string nombre, string apellido, string cedula, string correo, string contrasennia,int idOficina)
        {
            TraUsuario traUsuario = new TraUsuario();
            traUsuario.TcRol = rol;
            traUsuario.TcNombre = nombre;
            traUsuario.TcApellido = apellido;
            traUsuario.TcCedula = cedula;
            traUsuario.TcCorreo = correo;
            traUsuario.TcContrasennia = contrasennia;
            return _negocioSql.registarUsuario(traUsuario, idOficina);
        }

        // POST: api/TraUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route(nameof(ModificarTraUsario))]
        public bool ModificarTraUsario(int id, string rol, string nombre, string apellido, string cedula, string correo, string contrasennia, bool activo, int idOficinaNueva)
        {
            TraUsuario traUsuario = new TraUsuario();
            traUsuario.TnIdUsuario = id;
            traUsuario.TcRol = rol;
            traUsuario.TcNombre = nombre;
            traUsuario.TcApellido = apellido;
            traUsuario.TcCedula = cedula;
            traUsuario.TcCorreo = correo;
            traUsuario.TcContrasennia = contrasennia;
            traUsuario.TbActivo = activo;
            return _negocioSql.modificarUsuario(traUsuario, idOficinaNueva);
        }

        // DELETE: api/TraUsuarios/5
        [HttpPost]
        [Route(nameof(EliminarTraUsario))]
        public async Task<IActionResult> EliminarTraUsario(int id)
        {
            _negocioSql.eliminarUsuario(id);
            return NoContent();
        }

        private bool TraUsuarioExists(int id)
        {
            return (_context.TraUsuario?.Any(e => e.TnIdUsuario == id)).GetValueOrDefault();
        }
    }
}

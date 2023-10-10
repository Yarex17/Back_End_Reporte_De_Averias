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
    public class TraPrioridadsController : ControllerBase
    {
        private readonly DBContext _context = new DBContext();
        private readonly NegocioSQL _negocioSql = new NegocioSQL();

        // GET: api/TraPrioridads
        [HttpGet]
        [Route(nameof(ListarTraPrioridades))]
        public Task<List<TraPrioridad>> ListarTraPrioridades()
        {
            return _negocioSql.listarPrioridad();
        }

        // GET: api/TraPrioridads/5
        [HttpGet]
        [Route(nameof(BuscarTraPrioridad))]
        public async Task<ActionResult<TraPrioridad>> BuscarTraPrioridad(int id)
        {
            if (_context.TraPrioridad == null)
            {
                return NotFound();
            }
            var traPrioridad = await _context.TraPrioridad.FindAsync(id);

            if (traPrioridad == null)
            {
                return NotFound();
            }

            return traPrioridad;
        }

        // PUT: api/TraPrioridads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route(nameof(CrearTraPrioridad))]
        public bool CrearTraPrioridad(String nombre)
        {

            return _negocioSql.registarPrioridad(nombre);
        }

        // POST: api/TraPrioridads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route(nameof(ModificarPrioridad))]
        public bool ModificarPrioridad(int idPrioridad, String nombre, bool activa)
        {

            TraPrioridad traPrioridad = new TraPrioridad();
            traPrioridad.TnIdPrioridad = idPrioridad;
            traPrioridad.TcNombre = nombre;
            traPrioridad.TbActiva = activa;
            _negocioSql.modificarPrioridad(traPrioridad);
            return true;
        }

        // DELETE: api/TraPrioridads/5
        [HttpPost]
        [Route(nameof(EliminarTraPrioridad))]
        public async Task<IActionResult> EliminarTraPrioridad(int id)
        {
            _negocioSql.eliminarPrioridad(id);
            return NoContent();
        }

        private bool TraPrioridadExists(int id)
        {
            return (_context.TraPrioridad?.Any(e => e.TnIdPrioridad == id)).GetValueOrDefault();
        }
    }
}

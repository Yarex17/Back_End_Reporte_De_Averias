using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Context;
using Data.Data;
using Negocio;

namespace Reporte_De_Averias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraEdificiosController : ControllerBase
    {
        private readonly DBContext _context = new DBContext();
        private readonly NegocioSQL _negocioSql = new NegocioSQL();

        // GET: api/TraEdificios
        [HttpGet]
        [Route(nameof(ListarTraEdificio))]
        public Task<List<TraEdificio>> ListarTraEdificio()
        {
            return _negocioSql.listarEdificio();
        }

        // GET: api/TraEdificios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraEdificio>> GetTraEdificio(int id)
        {
            if (_context.TraEdificio == null)
            {
                return NotFound();
            }
            var traEdificio = await _context.TraEdificio.FindAsync(id);

            if (traEdificio == null)
            {
                return NotFound();
            }

            return traEdificio;
        }

        // PUT: api/TraEdificios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraEdificio(int id, TraEdificio traEdificio)
        {
            if (id != traEdificio.TnIdEdificio)
            {
                return BadRequest();
            }

            _context.Entry(traEdificio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraEdificioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TraEdificios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route(nameof(ModificarTraEdificio))]
        public bool ModificarTraEdificio(TraEdificio traEdificio)
        {

            _negocioSql.eliminarEdificio(traEdificio.TnIdEdificio);
            return true;
        }

        // DELETE: api/TraEdificios/5
        [HttpPost]
        [Route(nameof(EliminarTraEdificio))]
        public async Task<IActionResult> EliminarTraEdificio(int id)
        {
            _negocioSql.eliminarEdificio(id);
            return NoContent();
        }

        private bool TraEdificioExists(int id)
        {
            return (_context.TraEdificio?.Any(e => e.TnIdEdificio == id)).GetValueOrDefault();
        }
    }
}

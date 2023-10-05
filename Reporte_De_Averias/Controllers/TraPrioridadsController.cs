using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Context;

namespace Reporte_De_Averias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraPrioridadsController : ControllerBase
    {
        private readonly DBContext _context;

        public TraPrioridadsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TraPrioridads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraPrioridad>>> GetTraPrioridad()
        {
          if (_context.TraPrioridad == null)
          {
              return NotFound();
          }
            return await _context.TraPrioridad.ToListAsync();
        }

        // GET: api/TraPrioridads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraPrioridad>> GetTraPrioridad(int id)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraPrioridad(int id, TraPrioridad traPrioridad)
        {
            if (id != traPrioridad.TnIdPrioridad)
            {
                return BadRequest();
            }

            _context.Entry(traPrioridad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraPrioridadExists(id))
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

        // POST: api/TraPrioridads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraPrioridad>> PostTraPrioridad(TraPrioridad traPrioridad)
        {
          if (_context.TraPrioridad == null)
          {
              return Problem("Entity set 'DBContext.TraPrioridad'  is null.");
          }
            _context.TraPrioridad.Add(traPrioridad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraPrioridad", new { id = traPrioridad.TnIdPrioridad }, traPrioridad);
        }

        // DELETE: api/TraPrioridads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraPrioridad(int id)
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

            _context.TraPrioridad.Remove(traPrioridad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraPrioridadExists(int id)
        {
            return (_context.TraPrioridad?.Any(e => e.TnIdPrioridad == id)).GetValueOrDefault();
        }
    }
}

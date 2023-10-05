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
    public class TraEdificiosController : ControllerBase
    {
        private readonly DBContext _context;

        public TraEdificiosController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TraEdificios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraEdificio>>> GetTraEdificio()
        {
          if (_context.TraEdificio == null)
          {
              return NotFound();
          }
            return await _context.TraEdificio.ToListAsync();
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
        public async Task<ActionResult<TraEdificio>> PostTraEdificio(TraEdificio traEdificio)
        {
          if (_context.TraEdificio == null)
          {
              return Problem("Entity set 'DBContext.TraEdificio'  is null.");
          }
            _context.TraEdificio.Add(traEdificio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraEdificio", new { id = traEdificio.TnIdEdificio }, traEdificio);
        }

        // DELETE: api/TraEdificios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraEdificio(int id)
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

            _context.TraEdificio.Remove(traEdificio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraEdificioExists(int id)
        {
            return (_context.TraEdificio?.Any(e => e.TnIdEdificio == id)).GetValueOrDefault();
        }
    }
}

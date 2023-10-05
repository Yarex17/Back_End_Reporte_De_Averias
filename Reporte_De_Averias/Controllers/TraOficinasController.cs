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
    public class TraOficinasController : ControllerBase
    {
        private readonly DBContext _context;

        public TraOficinasController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TraOficinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraOficina>>> GetTraOficina()
        {
          if (_context.TraOficina == null)
          {
              return NotFound();
          }
            return await _context.TraOficina.ToListAsync();
        }

        // GET: api/TraOficinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraOficina>> GetTraOficina(int id)
        {
          if (_context.TraOficina == null)
          {
              return NotFound();
          }
            var traOficina = await _context.TraOficina.FindAsync(id);

            if (traOficina == null)
            {
                return NotFound();
            }

            return traOficina;
        }

        // PUT: api/TraOficinas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraOficina(int id, TraOficina traOficina)
        {
            if (id != traOficina.TnIdOficina)
            {
                return BadRequest();
            }

            _context.Entry(traOficina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraOficinaExists(id))
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

        // POST: api/TraOficinas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraOficina>> PostTraOficina(TraOficina traOficina)
        {
          if (_context.TraOficina == null)
          {
              return Problem("Entity set 'DBContext.TraOficina'  is null.");
          }
            _context.TraOficina.Add(traOficina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraOficina", new { id = traOficina.TnIdOficina }, traOficina);
        }

        // DELETE: api/TraOficinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraOficina(int id)
        {
            if (_context.TraOficina == null)
            {
                return NotFound();
            }
            var traOficina = await _context.TraOficina.FindAsync(id);
            if (traOficina == null)
            {
                return NotFound();
            }

            _context.TraOficina.Remove(traOficina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraOficinaExists(int id)
        {
            return (_context.TraOficina?.Any(e => e.TnIdOficina == id)).GetValueOrDefault();
        }
    }
}

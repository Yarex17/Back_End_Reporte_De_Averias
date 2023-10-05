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
    public class TraTipoAveriasController : ControllerBase
    {
        private readonly DBContext _context;

        public TraTipoAveriasController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TraTipoAverias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraTipoAveria>>> GetTraTipoAveria()
        {
          if (_context.TraTipoAveria == null)
          {
              return NotFound();
          }
            return await _context.TraTipoAveria.ToListAsync();
        }

        // GET: api/TraTipoAverias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraTipoAveria>> GetTraTipoAveria(int id)
        {
          if (_context.TraTipoAveria == null)
          {
              return NotFound();
          }
            var traTipoAveria = await _context.TraTipoAveria.FindAsync(id);

            if (traTipoAveria == null)
            {
                return NotFound();
            }

            return traTipoAveria;
        }

        // PUT: api/TraTipoAverias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraTipoAveria(int id, TraTipoAveria traTipoAveria)
        {
            if (id != traTipoAveria.TnIdTipoAveria)
            {
                return BadRequest();
            }

            _context.Entry(traTipoAveria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraTipoAveriaExists(id))
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

        // POST: api/TraTipoAverias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraTipoAveria>> PostTraTipoAveria(TraTipoAveria traTipoAveria)
        {
          if (_context.TraTipoAveria == null)
          {
              return Problem("Entity set 'DBContext.TraTipoAveria'  is null.");
          }
            _context.TraTipoAveria.Add(traTipoAveria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraTipoAveria", new { id = traTipoAveria.TnIdTipoAveria }, traTipoAveria);
        }

        // DELETE: api/TraTipoAverias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraTipoAveria(int id)
        {
            if (_context.TraTipoAveria == null)
            {
                return NotFound();
            }
            var traTipoAveria = await _context.TraTipoAveria.FindAsync(id);
            if (traTipoAveria == null)
            {
                return NotFound();
            }

            _context.TraTipoAveria.Remove(traTipoAveria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraTipoAveriaExists(int id)
        {
            return (_context.TraTipoAveria?.Any(e => e.TnIdTipoAveria == id)).GetValueOrDefault();
        }
    }
}

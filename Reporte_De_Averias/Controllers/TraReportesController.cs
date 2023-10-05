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
    public class TraReportesController : ControllerBase
    {
        private readonly DBContext _context;

        public TraReportesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TraReportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraReporte>>> GetTraReporte()
        {
          if (_context.TraReporte == null)
          {
              return NotFound();
          }
            return await _context.TraReporte.ToListAsync();
        }

        // GET: api/TraReportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraReporte>> GetTraReporte(int id)
        {
          if (_context.TraReporte == null)
          {
              return NotFound();
          }
            var traReporte = await _context.TraReporte.FindAsync(id);

            if (traReporte == null)
            {
                return NotFound();
            }

            return traReporte;
        }

        // PUT: api/TraReportes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraReporte(int id, TraReporte traReporte)
        {
            if (id != traReporte.TnIdReporte)
            {
                return BadRequest();
            }

            _context.Entry(traReporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraReporteExists(id))
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

        // POST: api/TraReportes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraReporte>> PostTraReporte(TraReporte traReporte)
        {
          if (_context.TraReporte == null)
          {
              return Problem("Entity set 'DBContext.TraReporte'  is null.");
          }
            _context.TraReporte.Add(traReporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraReporte", new { id = traReporte.TnIdReporte }, traReporte);
        }

        // DELETE: api/TraReportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraReporte(int id)
        {
            if (_context.TraReporte == null)
            {
                return NotFound();
            }
            var traReporte = await _context.TraReporte.FindAsync(id);
            if (traReporte == null)
            {
                return NotFound();
            }

            _context.TraReporte.Remove(traReporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraReporteExists(int id)
        {
            return (_context.TraReporte?.Any(e => e.TnIdReporte == id)).GetValueOrDefault();
        }
    }
}

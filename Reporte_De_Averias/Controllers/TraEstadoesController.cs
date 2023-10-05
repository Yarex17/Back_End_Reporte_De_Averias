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
    public class TraEstadoesController : ControllerBase
    {
        private readonly DBContext _context;

        public TraEstadoesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TraEstadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraEstado>>> GetTraEstado()
        {
          if (_context.TraEstado == null)
          {
              return NotFound();
          }
            return await _context.TraEstado.ToListAsync();
        }

        // GET: api/TraEstadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraEstado>> GetTraEstado(int id)
        {
          if (_context.TraEstado == null)
          {
              return NotFound();
          }
            var traEstado = await _context.TraEstado.FindAsync(id);

            if (traEstado == null)
            {
                return NotFound();
            }

            return traEstado;
        }

        // PUT: api/TraEstadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraEstado(int id, TraEstado traEstado)
        {
            if (id != traEstado.TnIdEstado)
            {
                return BadRequest();
            }

            _context.Entry(traEstado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraEstadoExists(id))
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

        // POST: api/TraEstadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraEstado>> PostTraEstado(TraEstado traEstado)
        {
          if (_context.TraEstado == null)
          {
              return Problem("Entity set 'DBContext.TraEstado'  is null.");
          }
            _context.TraEstado.Add(traEstado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraEstado", new { id = traEstado.TnIdEstado }, traEstado);
        }

        // DELETE: api/TraEstadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraEstado(int id)
        {
            if (_context.TraEstado == null)
            {
                return NotFound();
            }
            var traEstado = await _context.TraEstado.FindAsync(id);
            if (traEstado == null)
            {
                return NotFound();
            }

            _context.TraEstado.Remove(traEstado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraEstadoExists(int id)
        {
            return (_context.TraEstado?.Any(e => e.TnIdEstado == id)).GetValueOrDefault();
        }
    }
}

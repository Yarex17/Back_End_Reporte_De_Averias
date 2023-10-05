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
    public class TraReporteUsuariosController : ControllerBase
    {
        private readonly DBContext _context;

        public TraReporteUsuariosController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TraReporteUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraReporteUsuario>>> GetTraReporteUsuario()
        {
          if (_context.TraReporteUsuario == null)
          {
              return NotFound();
          }
            return await _context.TraReporteUsuario.ToListAsync();
        }

        // GET: api/TraReporteUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraReporteUsuario>> GetTraReporteUsuario(int id)
        {
          if (_context.TraReporteUsuario == null)
          {
              return NotFound();
          }
            var traReporteUsuario = await _context.TraReporteUsuario.FindAsync(id);

            if (traReporteUsuario == null)
            {
                return NotFound();
            }

            return traReporteUsuario;
        }

        // PUT: api/TraReporteUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraReporteUsuario(int id, TraReporteUsuario traReporteUsuario)
        {
            if (id != traReporteUsuario.TnIdReporte)
            {
                return BadRequest();
            }

            _context.Entry(traReporteUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraReporteUsuarioExists(id))
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

        // POST: api/TraReporteUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraReporteUsuario>> PostTraReporteUsuario(TraReporteUsuario traReporteUsuario)
        {
          if (_context.TraReporteUsuario == null)
          {
              return Problem("Entity set 'DBContext.TraReporteUsuario'  is null.");
          }
            _context.TraReporteUsuario.Add(traReporteUsuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TraReporteUsuarioExists(traReporteUsuario.TnIdReporte))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTraReporteUsuario", new { id = traReporteUsuario.TnIdReporte }, traReporteUsuario);
        }

        // DELETE: api/TraReporteUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraReporteUsuario(int id)
        {
            if (_context.TraReporteUsuario == null)
            {
                return NotFound();
            }
            var traReporteUsuario = await _context.TraReporteUsuario.FindAsync(id);
            if (traReporteUsuario == null)
            {
                return NotFound();
            }

            _context.TraReporteUsuario.Remove(traReporteUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraReporteUsuarioExists(int id)
        {
            return (_context.TraReporteUsuario?.Any(e => e.TnIdReporte == id)).GetValueOrDefault();
        }
    }
}

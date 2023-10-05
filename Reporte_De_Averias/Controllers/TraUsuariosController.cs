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
    public class TraUsuariosController : ControllerBase
    {
        private readonly DBContext _context;

        public TraUsuariosController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TraUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraUsuario>>> GetTraUsuario()
        {
          if (_context.TraUsuario == null)
          {
              return NotFound();
          }
            return await _context.TraUsuario.ToListAsync();
        }

        // GET: api/TraUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraUsuario>> GetTraUsuario(int id)
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

        // PUT: api/TraUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraUsuario(int id, TraUsuario traUsuario)
        {
            if (id != traUsuario.TnIdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(traUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraUsuarioExists(id))
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

        // POST: api/TraUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraUsuario>> PostTraUsuario(TraUsuario traUsuario)
        {
          if (_context.TraUsuario == null)
          {
              return Problem("Entity set 'DBContext.TraUsuario'  is null.");
          }
            _context.TraUsuario.Add(traUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraUsuario", new { id = traUsuario.TnIdUsuario }, traUsuario);
        }

        // DELETE: api/TraUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraUsuario(int id)
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

            _context.TraUsuario.Remove(traUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraUsuarioExists(int id)
        {
            return (_context.TraUsuario?.Any(e => e.TnIdUsuario == id)).GetValueOrDefault();
        }
    }
}

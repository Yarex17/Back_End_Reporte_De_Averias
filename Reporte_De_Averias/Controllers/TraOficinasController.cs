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
    public class TraOficinasController : ControllerBase
    {
        private readonly DBContext _context = new DBContext();
        private readonly NegocioSQL _negocioSql = new NegocioSQL();

        // GET: api/TraOficinas
        [HttpGet]
        [Route(nameof(ListarTraOficinasPorTraEdificio))]
        public Task<List<TraOficina>> ListarTraOficinasPorTraEdificio()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _negocioSql.listarOficina();
        }

        // GET: api/TraOficinas/5
        [HttpPost]
        [Route(nameof(BuscarTraOficina))]
        public async Task<ActionResult<TraOficina>> BuscarTraOficina(int id)
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
        [HttpPost]
        [Route(nameof(CrearTraOficina))]
        public bool CrearTraOficina(int numeroPiso, int idEdificio)
        {

            return _negocioSql.registarOficina(numeroPiso, idEdificio);
        }

        // POST: api/TraOficinas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route(nameof(ModificarOficina))]
        public bool ModificarOficina(int idOficina, int numeroPiso, bool activa)
        {
          
            TraOficina traOficina = new TraOficina();
            traOficina.TnIdOficina = idOficina;
            traOficina.TnNumeroPiso = numeroPiso;
            traOficina.TbActivo = activa;
            _negocioSql.modificarOficina(traOficina);
            return true;
        }

        // DELETE: api/TraOficinas/5
        [HttpPost]
        [Route(nameof(EliminarTraOficina))]
        public async Task<IActionResult> EliminarTraOficina(int id)
        {
            _negocioSql.eliminarOficina(id);
            return NoContent();
        }

        private bool TraOficinaExists(int id)
        {
            return (_context.TraOficina?.Any(e => e.TnIdOficina == id)).GetValueOrDefault();
        }
    }
}

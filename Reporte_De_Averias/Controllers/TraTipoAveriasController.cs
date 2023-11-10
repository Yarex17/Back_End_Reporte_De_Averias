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
    public class TraTipoAveriasController : ControllerBase
    {
        private readonly DBContext _context = new DBContext();
        private readonly NegocioSQL _negocioSql = new NegocioSQL();

        // GET: api/TraTipoAverias
        [HttpGet]
        [Route(nameof(ListarTraTipoAveria))]
        public Task<List<TraTipoAveria>> ListarTraTipoAveria()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _negocioSql.listarTipoAveria();
        }

        // GET: api/TraTipoAverias/5
        [HttpPost]
        [Route(nameof(BuscarTraTipoAveria))]
        public async Task<ActionResult<TraTipoAveria>> BuscarTraTipoAveria(int id)
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
        [HttpPost]
        [Route(nameof(CrearTraTipoAveria))]
        public bool CrearTraTipoAveria(string descripcion)
        {
            return _negocioSql.registarTipoAveria(descripcion);
        }

        // POST: api/TraTipoAverias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route(nameof(ModificarTraTipoAveria))]
        public bool ModificarTraTipoAveria(int idTipoAveria, string descripcion, bool activo)
        {
            TraTipoAveria traTipoAveria = new TraTipoAveria();
            traTipoAveria.TnIdTipoAveria = idTipoAveria;
            traTipoAveria.TcDescripcion = descripcion;
            traTipoAveria.TbActivo = activo;

            return _negocioSql.modificarTipoAveria(traTipoAveria);
        }

        // DELETE: api/TraTipoAverias/5
        [HttpPost]
        [Route(nameof(ElminarTraTipoAveria))]
        public async Task<IActionResult> ElminarTraTipoAveria(int id)
        {
            _negocioSql.eliminarTipoAveria(id);
            return NoContent();
        }

        private bool TraTipoAveriaExists(int id)
        {
            return (_context.TraTipoAveria?.Any(e => e.TnIdTipoAveria == id)).GetValueOrDefault();
        }
    }
}

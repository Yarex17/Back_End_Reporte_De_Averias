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
    public class TraReportesController : ControllerBase
    {
        private readonly DBContext _context = new DBContext();
        private readonly NegocioSQL _negocioSql = new NegocioSQL();

        // GET: api/TraReportes
        [HttpGet]
        [Route(nameof(ListarTraReportesPorTraEdificio))]
        public Task<List<TraReporte>> ListarTraReportesPorTraEdificio(int id)
        {
            return _negocioSql.listarReporte();
        }

        // GET: api/TraReportes/5
        [HttpGet]
        [Route(nameof(BuscarTraReporte))]
        public async Task<ActionResult<TraReporte>> BuscarTraReporte(int id)
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
        [HttpPut]
        [Route(nameof(CrearTraReporte))]
        public bool CrearTraReporte(int id, String descripcion, bool activo, bool eliminado)
        {

            return _negocioSql.registarReporte(id, descripcion, activo, eliminado);
        }

        // POST: api/TraReportes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route(nameof(ModificarReporte))]
        public bool ModificarReporte(int id,String descripcion, bool activo, bool eliminado)
        {

            TraReporte traReporte = new TraReporte();
            traReporte.TnIdReporte = id;
            traReporte.TcDescripcion = descripcion;
            traReporte.TbActivo = activo;
            traReporte.TbEliminado = eliminado;
            _negocioSql.modificarReporte(traReporte);
            return true;
        }

        // DELETE: api/TraReportes/5
        [HttpPost]
        [Route(nameof(EliminarTraReporte))]
        public async Task<IActionResult> EliminarTraReporte(int id)
        {
            _negocioSql.eliminarReporte(id);
            return NoContent();
        }

        private bool TraReporteExists(int id)
        {
            return (_context.TraReporte?.Any(e => e.TnIdReporte == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Context;
using Data.Data;
using Negocio;

namespace Reporte_De_Averias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraEdificiosController : ControllerBase
    {
        private readonly DBContext _context = new DBContext();
        private readonly NegocioSQL _negocioSql = new NegocioSQL();

        // GET: api/TraEdificios
        [HttpGet]
        [Route(nameof(ListarTraEdificio))]
        public Task<List<TraEdificio>> ListarTraEdificio()
        {
            return _negocioSql.listarEdificio();
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
        [HttpPut]

        [Route(nameof(RegistrarTraEdificio))]
        public bool RegistrarTraEdificio(string propietario, string nombre)
        {
            TraEdificio traEdificio = new TraEdificio();
            traEdificio.TcPropietario = propietario;
            traEdificio.TcNombre = nombre;
            return _negocioSql.registarEdificio(traEdificio);
        }

        // POST: api/TraEdificios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route(nameof(ModificarTraEdificio))]
        public bool ModificarTraEdificio(int id, string propietario, string nombre, bool activo)
        {
            TraEdificio traEdificio = new TraEdificio();
            traEdificio.TnIdEdificio = id;
            traEdificio.TcPropietario = propietario;
            traEdificio.TcNombre = nombre;
            traEdificio.TbActivo = activo;
            return _negocioSql.modificarEdificio(traEdificio);
        }

        // DELETE: api/TraEdificios/5
        [HttpPost]
        [Route(nameof(EliminarTraEdificio))]
        public async Task<IActionResult> EliminarTraEdificio(int id)
        {
            _negocioSql.eliminarEdificio(id);
            return NoContent();
        }

        private bool TraEdificioExists(int id)
        {
            return (_context.TraEdificio?.Any(e => e.TnIdEdificio == id)).GetValueOrDefault();
        }
    }
}

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
    public class TraEstadoesController : ControllerBase
    {
        private readonly DBContext _context= new DBContext();
        private readonly NegocioSQL _negocioSql = new NegocioSQL();


        // GET: api/TraEstadoes
        // GET: api/TraEstados
        [HttpGet]
        [Route(nameof(ListarTraEstados))]
        public Task<List<TraEstado>> ListarTraEstados()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _negocioSql.listarEstado();
        }

        // GET: api/TraEstados/5
        [HttpPost]
        [Route(nameof(BuscarTraEstado))]
        public async Task<ActionResult<TraEstado>> BuscarTraEstado(int id)
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

        [HttpPost]
        [Route(nameof(BuscarTraEstadoPorNombre))]
        public async Task<ActionResult<TraEstado>> BuscarTraEstadoPorNombre(string nombre)
        {
            return _negocioSql.buscarEstado(nombre);
        }

            // PUT: api/TraEstados/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
        [Route(nameof(CrearTraEstado))]
        public bool CrearTraEstado(String nombre)
        {

            return _negocioSql.registarEstado(nombre);
        }

        // POST: api/TraEstados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route(nameof(ModificarEstado))]
        public bool ModificarEstado(int idEstado, String nombre, bool activa)
        {

            TraEstado traEstado = new TraEstado();
            traEstado.TnIdEstado = idEstado;
            traEstado.TcNombre = nombre;
            traEstado.TbActivo = activa;
            _negocioSql.modificarEstado(traEstado);
            return true;
        }

        // DELETE: api/TraEstados/5
        [HttpPost]
        [Route(nameof(EliminarTraEstado))]
        public async Task<IActionResult> EliminarTraEstado(int id)
        {
            _negocioSql.eliminarEstado(id);
            return NoContent();
        }

        private bool TraEstadoExists(int id)
        {
            return (_context.TraEstado?.Any(e => e.TnIdEstado == id)).GetValueOrDefault();
        }
    }
}

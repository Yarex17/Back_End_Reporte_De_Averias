﻿using System;
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
        [Route(nameof(ListarTraReportes))]
        public Task<List<TraReporte>> ListarTraReportes()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _negocioSql.listarReporte();
        }

        [HttpGet]
        [Route(nameof(ListarTraReportesPorUsuario))]
        public Task<List<TraReporte>> ListarTraReportesPorUsuario(int idUsuario)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _negocioSql.listarReportesPorUsuario(idUsuario);
        }

        [HttpPost]
        [Route(nameof(ListarTraReportesPorUsuarioYEstado))]
        public Task<List<TraReporte>> ListarTraReportesPorUsuarioYEstado(int idUsuario, string nombreEstado)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _negocioSql.listarTraReportesPorUsuarioYEstado(idUsuario, nombreEstado);
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
        [HttpPost]
        [Route(nameof(CrearTraReporte))]
        public bool CrearTraReporte(string descripcion, int idUsuario, int idAdminEdificio)
        {
            return _negocioSql.registarReporte(descripcion, idUsuario, idAdminEdificio);
        }

        [HttpPost]
        [Route(nameof(EnviarTraReporte))]
        public bool EnviarTraReporte(int idReporte, int idUsuario)
        {
            return _negocioSql.enviarTraReporte(idReporte, idUsuario);
        }

        [HttpPost]
        [Route(nameof(AgregarDatosReporte))]
        public bool AgregarDatosReporte(int idReporte, int tipoAveria, int prioridad, int estado)
        {
            _negocioSql.agregarDatosReporte(idReporte, tipoAveria, prioridad, estado);
            return true;
        }

        [HttpPost]
        [Route(nameof(ModificarReporteTecnico))]
        public bool ModificarReporteTecnico(int idReporte, string descripcion, int idEstado)
        {
            return _negocioSql.modificarReporteTecnico(idReporte, descripcion, idEstado);
        }

        // POST: api/TraReportes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route(nameof(ModificarReporte))]
        public bool ModificarReporte(int idReporte, string descripcion, int tipoAveria, int prioridad, int estado, bool activo)
        {
            TraReporte traReporte = new TraReporte();
            traReporte.TnIdReporte = idReporte;
            traReporte.TcDescripcion = descripcion;
            traReporte.TbActivo = activo;
            
            return _negocioSql.modificarReporte(traReporte, tipoAveria, prioridad, estado);
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

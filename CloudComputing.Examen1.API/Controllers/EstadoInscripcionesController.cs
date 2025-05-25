using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudComputing.Examen1.API.Data;
using CloudComputing.Examen1.Models;

namespace CloudComputing.Examen1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoInscripcionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstadoInscripcionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoInscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoInscripcion>>> GetEstadoInscripcion()
        {
            return await _context.EstadoInscripcion.ToListAsync();
        }

        // GET: api/EstadoInscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoInscripcion>> GetEstadoInscripcion(int id)
        {
            var estadoInscripcion = await _context.EstadoInscripcion.FindAsync(id);

            if (estadoInscripcion == null)
            {
                return NotFound();
            }

            return estadoInscripcion;
        }

        // PUT: api/EstadoInscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoInscripcion(int id, EstadoInscripcion estadoInscripcion)
        {
            if (id != estadoInscripcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoInscripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoInscripcionExists(id))
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

        // POST: api/EstadoInscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoInscripcion>> PostEstadoInscripcion(EstadoInscripcion estadoInscripcion)
        {
            _context.EstadoInscripcion.Add(estadoInscripcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoInscripcion", new { id = estadoInscripcion.Id }, estadoInscripcion);
        }

        // DELETE: api/EstadoInscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoInscripcion(int id)
        {
            var estadoInscripcion = await _context.EstadoInscripcion.FindAsync(id);
            if (estadoInscripcion == null)
            {
                return NotFound();
            }

            _context.EstadoInscripcion.Remove(estadoInscripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoInscripcionExists(int id)
        {
            return _context.EstadoInscripcion.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudComputing.Examen1.API.Data;
using CloudComputingExamen1.Models;

namespace CloudComputing.Examen1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InscripcionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Inscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscripcion>>> GetInscripciones()
        {
            return await _context.Inscripciones.ToListAsync();
        }

        // GET: api/Inscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscripcion>> GetInscripciones(int id)
        {
            var inscripciones = await _context.Inscripciones.FindAsync(id);

            if (inscripciones == null)
            {
                return NotFound();
            }

            return inscripciones;
        }

        // PUT: api/Inscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripciones(int id, Inscripcion inscripciones)
        {
            if (id != inscripciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(inscripciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscripcionesExists(id))
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

        // POST: api/Inscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inscripcion>> PostInscripciones(Inscripcion inscripciones)
        {
            _context.Inscripciones.Add(inscripciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscripciones", new { id = inscripciones.Id }, inscripciones);
        }

        // DELETE: api/Inscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripciones(int id)
        {
            var inscripciones = await _context.Inscripciones.FindAsync(id);
            if (inscripciones == null)
            {
                return NotFound();
            }

            _context.Inscripciones.Remove(inscripciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscripcionesExists(int id)
        {
            return _context.Inscripciones.Any(e => e.Id == id);
        }
    }
}

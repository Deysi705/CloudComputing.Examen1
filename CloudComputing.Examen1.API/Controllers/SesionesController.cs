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
    public class SesionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SesionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sesiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sesion>>> GetSesiones()
        {
            return await _context.Sesiones.ToListAsync();
        }

        // GET: api/Sesiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sesion>> GetSesiones(int id)
        {
            var sesiones = await _context.Sesiones.FindAsync(id);

            if (sesiones == null)
            {
                return NotFound();
            }

            return sesiones;
        }

        // PUT: api/Sesiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSesiones(int id, Sesion sesiones)
        {
            if (id != sesiones.Id)
            {
                return BadRequest();
            }

            _context.Entry(sesiones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SesionesExists(id))
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

        // POST: api/Sesiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sesion>> PostSesiones(Sesion sesiones)
        {
            _context.Sesiones.Add(sesiones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSesiones", new { id = sesiones.Id }, sesiones);
        }

        // DELETE: api/Sesiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesiones(int id)
        {
            var sesiones = await _context.Sesiones.FindAsync(id);
            if (sesiones == null)
            {
                return NotFound();
            }

            _context.Sesiones.Remove(sesiones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SesionesExists(int id)
        {
            return _context.Sesiones.Any(e => e.Id == id);
        }
    }
}

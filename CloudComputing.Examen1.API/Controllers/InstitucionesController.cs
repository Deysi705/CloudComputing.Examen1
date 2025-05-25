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
    public class InstitucionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InstitucionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Instituciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institucion>>> GetInstitucion()
        {
            return await _context.Institucion.ToListAsync();
        }

        // GET: api/Instituciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Institucion>> GetInstitucion(int id)
        {
            var institucion = await _context.Institucion.FindAsync(id);

            if (institucion == null)
            {
                return NotFound();
            }

            return institucion;
        }

        // PUT: api/Instituciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitucion(int id, Institucion institucion)
        {
            if (id != institucion.Id)
            {
                return BadRequest();
            }

            _context.Entry(institucion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitucionExists(id))
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

        // POST: api/Instituciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Institucion>> PostInstitucion(Institucion institucion)
        {
            _context.Institucion.Add(institucion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstitucion", new { id = institucion.Id }, institucion);
        }

        // DELETE: api/Instituciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitucion(int id)
        {
            var institucion = await _context.Institucion.FindAsync(id);
            if (institucion == null)
            {
                return NotFound();
            }

            _context.Institucion.Remove(institucion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitucionExists(int id)
        {
            return _context.Institucion.Any(e => e.Id == id);
        }
    }
}

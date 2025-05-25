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
    public class EspaciosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EspaciosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Espacios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Espacio>>> GetEspacios()
        {
            return await _context.Espacios.ToListAsync();
        }

        // GET: api/Espacios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Espacio>> GetEspacios(int id)
        {
            var espacios = await _context.Espacios.FindAsync(id);

            if (espacios == null)
            {
                return NotFound();
            }

            return espacios;
        }

        // PUT: api/Espacios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspacios(int id, Espacio espacios)
        {
            if (id != espacios.Id)
            {
                return BadRequest();
            }

            _context.Entry(espacios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspaciosExists(id))
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

        // POST: api/Espacios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Espacio>> PostEspacios(Espacio espacios)
        {
            _context.Espacios.Add(espacios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspacios", new { id = espacios.Id }, espacios);
        }

        // DELETE: api/Espacios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspacios(int id)
        {
            var espacios = await _context.Espacios.FindAsync(id);
            if (espacios == null)
            {
                return NotFound();
            }

            _context.Espacios.Remove(espacios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspaciosExists(int id)
        {
            return _context.Espacios.Any(e => e.Id == id);
        }
    }
}

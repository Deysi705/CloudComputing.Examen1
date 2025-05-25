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
    public class PonentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PonentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ponentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ponente>>> GetPonentes()
        {
            return await _context.Ponentes.ToListAsync();
        }

        // GET: api/Ponentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ponente>> GetPonentes(int id)
        {
            var ponentes = await _context.Ponentes.FindAsync(id);

            if (ponentes == null)
            {
                return NotFound();
            }

            return ponentes;
        }

        // PUT: api/Ponentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPonentes(int id, Ponente ponentes)
        {
            if (id != ponentes.Id)
            {
                return BadRequest();
            }

            _context.Entry(ponentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PonentesExists(id))
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

        // POST: api/Ponentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ponente>> PostPonentes(Ponente ponentes)
        {
            _context.Ponentes.Add(ponentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPonentes", new { id = ponentes.Id }, ponentes);
        }

        // DELETE: api/Ponentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePonentes(int id)
        {
            var ponentes = await _context.Ponentes.FindAsync(id);
            if (ponentes == null)
            {
                return NotFound();
            }

            _context.Ponentes.Remove(ponentes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PonentesExists(int id)
        {
            return _context.Ponentes.Any(e => e.Id == id);
        }
    }
}

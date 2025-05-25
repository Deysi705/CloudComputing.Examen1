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
    public class TipoEventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoEventosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEvento>>> GetTipoEventos()
        {
            return await _context.TipoEventos.ToListAsync();
        }

        // GET: api/TipoEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEvento>> GetTipoEventos(int id)
        {
            var tipoEventos = await _context.TipoEventos.FindAsync(id);

            if (tipoEventos == null)
            {
                return NotFound();
            }

            return tipoEventos;
        }

        // PUT: api/TipoEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEventos(int id, TipoEvento tipoEventos)
        {
            if (id != tipoEventos.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoEventos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEventosExists(id))
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

        // POST: api/TipoEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoEvento>> PostTipoEventos(TipoEvento tipoEventos)
        {
            _context.TipoEventos.Add(tipoEventos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoEventos", new { id = tipoEventos.Id }, tipoEventos);
        }

        // DELETE: api/TipoEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoEventos(int id)
        {
            var tipoEventos = await _context.TipoEventos.FindAsync(id);
            if (tipoEventos == null)
            {
                return NotFound();
            }

            _context.TipoEventos.Remove(tipoEventos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoEventosExists(int id)
        {
            return _context.TipoEventos.Any(e => e.Id == id);
        }
    }
}

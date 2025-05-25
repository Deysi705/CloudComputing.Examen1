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
    public class TipoEventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoEventosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEvento>>> GetTipoEvento()
        {
            return await _context.TipoEvento.ToListAsync();
        }

        // GET: api/TipoEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEvento>> GetTipoEvento(int id)
        {
            var tipoEvento = await _context.TipoEvento.FindAsync(id);

            if (tipoEvento == null)
            {
                return NotFound();
            }

            return tipoEvento;
        }

        // PUT: api/TipoEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEvento(int id, TipoEvento tipoEvento)
        {
            if (id != tipoEvento.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEventoExists(id))
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
        public async Task<ActionResult<TipoEvento>> PostTipoEvento(TipoEvento tipoEvento)
        {
            _context.TipoEvento.Add(tipoEvento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoEvento", new { id = tipoEvento.Id }, tipoEvento);
        }

        // DELETE: api/TipoEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoEvento(int id)
        {
            var tipoEvento = await _context.TipoEvento.FindAsync(id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            _context.TipoEvento.Remove(tipoEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoEventoExists(int id)
        {
            return _context.TipoEvento.Any(e => e.Id == id);
        }
    }
}

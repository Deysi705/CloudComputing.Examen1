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
    public class EstadoCertificadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstadoCertificadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoCertificados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoCertificado>>> GetEstadoCertificado()
        {
            return await _context.EstadoCertificado.ToListAsync();
        }

        // GET: api/EstadoCertificados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoCertificado>> GetEstadoCertificado(int id)
        {
            var estadoCertificado = await _context.EstadoCertificado.FindAsync(id);

            if (estadoCertificado == null)
            {
                return NotFound();
            }

            return estadoCertificado;
        }

        // PUT: api/EstadoCertificados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoCertificado(int id, EstadoCertificado estadoCertificado)
        {
            if (id != estadoCertificado.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoCertificado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoCertificadoExists(id))
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

        // POST: api/EstadoCertificados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoCertificado>> PostEstadoCertificado(EstadoCertificado estadoCertificado)
        {
            _context.EstadoCertificado.Add(estadoCertificado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoCertificado", new { id = estadoCertificado.Id }, estadoCertificado);
        }

        // DELETE: api/EstadoCertificados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoCertificado(int id)
        {
            var estadoCertificado = await _context.EstadoCertificado.FindAsync(id);
            if (estadoCertificado == null)
            {
                return NotFound();
            }

            _context.EstadoCertificado.Remove(estadoCertificado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoCertificadoExists(int id)
        {
            return _context.EstadoCertificado.Any(e => e.Id == id);
        }
    }
}

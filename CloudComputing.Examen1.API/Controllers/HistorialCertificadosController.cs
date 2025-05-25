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
    public class HistorialCertificadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialCertificadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HistorialCertificados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialCertificado>>> GetHistorialCertificado()
        {
            return await _context.HistorialCertificado.ToListAsync();
        }

        // GET: api/HistorialCertificados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialCertificado>> GetHistorialCertificado(int id)
        {
            var historialCertificado = await _context.HistorialCertificado.FindAsync(id);

            if (historialCertificado == null)
            {
                return NotFound();
            }

            return historialCertificado;
        }

        // PUT: api/HistorialCertificados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialCertificado(int id, HistorialCertificado historialCertificado)
        {
            if (id != historialCertificado.Id)
            {
                return BadRequest();
            }

            _context.Entry(historialCertificado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialCertificadoExists(id))
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

        // POST: api/HistorialCertificados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialCertificado>> PostHistorialCertificado(HistorialCertificado historialCertificado)
        {
            _context.HistorialCertificado.Add(historialCertificado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialCertificado", new { id = historialCertificado.Id }, historialCertificado);
        }

        // DELETE: api/HistorialCertificados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialCertificado(int id)
        {
            var historialCertificado = await _context.HistorialCertificado.FindAsync(id);
            if (historialCertificado == null)
            {
                return NotFound();
            }

            _context.HistorialCertificado.Remove(historialCertificado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialCertificadoExists(int id)
        {
            return _context.HistorialCertificado.Any(e => e.Id == id);
        }
    }
}

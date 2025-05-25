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
    public class HistoricoCertificadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistoricoCertificadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HistoricoCertificados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoCertificado>>> GetHistoricoCertificados()
        {
            return await _context.HistoricoCertificados.ToListAsync();
        }

        // GET: api/HistoricoCertificados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoCertificado>> GetHistoricoCertificados(int id)
        {
            var historicoCertificados = await _context.HistoricoCertificados.FindAsync(id);

            if (historicoCertificados == null)
            {
                return NotFound();
            }

            return historicoCertificados;
        }

        // PUT: api/HistoricoCertificados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricoCertificados(int id, HistoricoCertificado historicoCertificados)
        {
            if (id != historicoCertificados.Id)
            {
                return BadRequest();
            }

            _context.Entry(historicoCertificados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoCertificadosExists(id))
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

        // POST: api/HistoricoCertificados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoricoCertificado>> PostHistoricoCertificados(HistoricoCertificado historicoCertificados)
        {
            _context.HistoricoCertificados.Add(historicoCertificados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoricoCertificados", new { id = historicoCertificados.Id }, historicoCertificados);
        }

        // DELETE: api/HistoricoCertificados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoricoCertificados(int id)
        {
            var historicoCertificados = await _context.HistoricoCertificados.FindAsync(id);
            if (historicoCertificados == null)
            {
                return NotFound();
            }

            _context.HistoricoCertificados.Remove(historicoCertificados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoricoCertificadosExists(int id)
        {
            return _context.HistoricoCertificados.Any(e => e.Id == id);
        }
    }
}

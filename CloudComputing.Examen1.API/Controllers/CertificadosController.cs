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
    public class CertificadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CertificadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Certificados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificado>>> GetCertificados()
        {
            return await _context.Certificados.ToListAsync();
        }

        // GET: api/Certificados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Certificado>> GetCertificados(int id)
        {
            var certificados = await _context.Certificados.FindAsync(id);

            if (certificados == null)
            {
                return NotFound();
            }

            return certificados;
        }

        // PUT: api/Certificados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificados(int id, Certificado certificados)
        {
            if (id != certificados.Id)
            {
                return BadRequest();
            }

            _context.Entry(certificados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificadosExists(id))
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

        // POST: api/Certificados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Certificado>> PostCertificados(Certificado certificados)
        {
            _context.Certificados.Add(certificados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCertificados", new { id = certificados.Id }, certificados);
        }

        // DELETE: api/Certificados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificados(int id)
        {
            var certificados = await _context.Certificados.FindAsync(id);
            if (certificados == null)
            {
                return NotFound();
            }

            _context.Certificados.Remove(certificados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificadosExists(int id)
        {
            return _context.Certificados.Any(e => e.Id == id);
        }
    }
}

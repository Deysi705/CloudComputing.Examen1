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
    public class MedioPagosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedioPagosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MediosPagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedioPago>>> GetMediosPagos()
        {
            return await _context.MediosPagos.ToListAsync();
        }

        // GET: api/MediosPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedioPago>> GetMediosPagos(int id)
        {
            var mediosPagos = await _context.MediosPagos.FindAsync(id);

            if (mediosPagos == null)
            {
                return NotFound();
            }

            return mediosPagos;
        }

        // PUT: api/MediosPagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediosPagos(int id, MedioPago mediosPagos)
        {
            if (id != mediosPagos.Id)
            {
                return BadRequest();
            }

            _context.Entry(mediosPagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediosPagosExists(id))
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

        // POST: api/MediosPagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedioPago>> PostMediosPagos(MedioPago mediosPagos)
        {
            _context.MediosPagos.Add(mediosPagos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediosPagos", new { id = mediosPagos.Id }, mediosPagos);
        }

        // DELETE: api/MediosPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediosPagos(int id)
        {
            var mediosPagos = await _context.MediosPagos.FindAsync(id);
            if (mediosPagos == null)
            {
                return NotFound();
            }

            _context.MediosPagos.Remove(mediosPagos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediosPagosExists(int id)
        {
            return _context.MediosPagos.Any(e => e.Id == id);
        }
    }
}

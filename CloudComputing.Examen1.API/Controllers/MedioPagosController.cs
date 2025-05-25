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
    public class MedioPagosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedioPagosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MedioPagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedioPago>>> GetMedioPago()
        {
            return await _context.MedioPago.ToListAsync();
        }

        // GET: api/MedioPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedioPago>> GetMedioPago(int id)
        {
            var medioPago = await _context.MedioPago.FindAsync(id);

            if (medioPago == null)
            {
                return NotFound();
            }

            return medioPago;
        }

        // PUT: api/MedioPagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedioPago(int id, MedioPago medioPago)
        {
            if (id != medioPago.Id)
            {
                return BadRequest();
            }

            _context.Entry(medioPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedioPagoExists(id))
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

        // POST: api/MedioPagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedioPago>> PostMedioPago(MedioPago medioPago)
        {
            _context.MedioPago.Add(medioPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedioPago", new { id = medioPago.Id }, medioPago);
        }

        // DELETE: api/MedioPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedioPago(int id)
        {
            var medioPago = await _context.MedioPago.FindAsync(id);
            if (medioPago == null)
            {
                return NotFound();
            }

            _context.MedioPago.Remove(medioPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedioPagoExists(int id)
        {
            return _context.MedioPago.Any(e => e.Id == id);
        }
    }
}

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
    public class EstadoPagosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstadoPagosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoPagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoPago>>> GetEstadoPago()
        {
            return await _context.EstadoPago.ToListAsync();
        }

        // GET: api/EstadoPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPago>> GetEstadoPago(int id)
        {
            var estadoPago = await _context.EstadoPago.FindAsync(id);

            if (estadoPago == null)
            {
                return NotFound();
            }

            return estadoPago;
        }

        // PUT: api/EstadoPagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPago(int id, EstadoPago estadoPago)
        {
            if (id != estadoPago.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPagoExists(id))
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

        // POST: api/EstadoPagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoPago>> PostEstadoPago(EstadoPago estadoPago)
        {
            _context.EstadoPago.Add(estadoPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoPago", new { id = estadoPago.Id }, estadoPago);
        }

        // DELETE: api/EstadoPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoPago(int id)
        {
            var estadoPago = await _context.EstadoPago.FindAsync(id);
            if (estadoPago == null)
            {
                return NotFound();
            }

            _context.EstadoPago.Remove(estadoPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoPagoExists(int id)
        {
            return _context.EstadoPago.Any(e => e.Id == id);
        }
    }
}

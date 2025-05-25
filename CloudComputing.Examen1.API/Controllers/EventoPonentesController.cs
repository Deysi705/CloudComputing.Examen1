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
    public class EventoPonentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventoPonentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EventosPonentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoPonente>>> GetEventosPonentes()
        {
            return await _context.EventosPonentes.ToListAsync();
        }

        // GET: api/EventosPonentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoPonente>> GetEventosPonentes(int id)
        {
            var eventosPonentes = await _context.EventosPonentes.FindAsync(id);

            if (eventosPonentes == null)
            {
                return NotFound();
            }

            return eventosPonentes;
        }

        // PUT: api/EventosPonentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventosPonentes(int id, EventoPonente eventosPonentes)
        {
            if (id != eventosPonentes.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventosPonentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventosPonentesExists(id))
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

        // POST: api/EventosPonentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventoPonente>> PostEventosPonentes(EventoPonente eventosPonentes)
        {
            _context.EventosPonentes.Add(eventosPonentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventosPonentes", new { id = eventosPonentes.Id }, eventosPonentes);
        }

        // DELETE: api/EventosPonentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventosPonentes(int id)
        {
            var eventosPonentes = await _context.EventosPonentes.FindAsync(id);
            if (eventosPonentes == null)
            {
                return NotFound();
            }

            _context.EventosPonentes.Remove(eventosPonentes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventosPonentesExists(int id)
        {
            return _context.EventosPonentes.Any(e => e.Id == id);
        }
    }
}

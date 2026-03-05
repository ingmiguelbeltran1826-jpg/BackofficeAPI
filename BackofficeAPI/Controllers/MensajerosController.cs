using BackofficeAPI.Data;
using BackofficeAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackofficeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajerosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MensajerosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Mensajeros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mensajero>>> GetMensajeros()
        {
            return await _context.Mensajero.ToListAsync();
        }

        // GET: api/Mensajeros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mensajero>> GetMensajero(int id)
        {
            var mensajero = await _context.Mensajero.FindAsync(id);

            if (mensajero == null)
            {
                return NotFound();
            }

            return mensajero;
        }

        // POST: api/Mensajeros
        [HttpPost]
        public async Task<ActionResult<Mensajero>> PostMensajero(Mensajero mensajero)
        {
            mensajero.FechaCreacion = DateTime.UtcNow;
            _context.Mensajero.Add(mensajero);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMensajero), new { id = mensajero.Id }, mensajero);
        }

        // PUT: api/Mensajeros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMensajero(int id, Mensajero mensajero)
        {
            if (id != mensajero.Id)
            {
                return BadRequest();
            }

            _context.Entry(mensajero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensajeroExists(id))
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

        // DELETE: api/Mensajeros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensajero(int id)
        {
            var mensajero = await _context.Mensajero.FindAsync(id);
            if (mensajero == null)
            {
                return NotFound();
            }

            _context.Mensajero.Remove(mensajero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MensajeroExists(int id)
        {
            return _context.Mensajero.Any(e => e.Id == id);
        }
    }
}


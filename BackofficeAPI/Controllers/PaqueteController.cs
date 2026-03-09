using BackofficeAPI.Data;
using BackofficeAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackofficeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaqueteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paquete>>> GetPaquetes()
        {
            return await _context.Paquete
                .Include(p => p.Cliente)
                .Include(p => p.Mensajero)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paquete>> GetPaquete(int id)
        {
            var paquete = await _context.Paquete.FindAsync(id);

            if (paquete == null)
            {
                return NotFound();
            }

            return paquete;
        }

        [HttpPost]
        public async Task<ActionResult<Paquete>> PostPaquete(Paquete paquete)
        {
            paquete.FechaCreacion = DateTime.UtcNow;

            _context.Paquete.Add(paquete);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaquete), new { id = paquete.Id }, paquete);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaquete(int id, Paquete paquete)
        {
            if (id != paquete.Id)
            {
                return BadRequest();
            }

            _context.Entry(paquete).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaquete(int id)
        {
            var paquete = await _context.Paquete.FindAsync(id);

            if (paquete == null)
            {
                return NotFound();
            }

            _context.Paquete.Remove(paquete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

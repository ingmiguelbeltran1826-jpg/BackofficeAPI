using BackofficeAPI.Data;
using BackofficeAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackofficeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecaudoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecaudoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recaudo>>> GetRecaudos()
        {
            return await _context.Recaudo.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recaudo>> GetRecaudo(int id)
        {
            var recaudo = await _context.Recaudo.FindAsync(id);

            if (recaudo == null)
            {
                return NotFound();
            }

            return recaudo;
        }

        [HttpPost]
        public async Task<ActionResult<Recaudo>> PostRecaudo(Recaudo recaudo)
        {
            recaudo.FechaCreacion = DateTime.UtcNow;

            _context.Recaudo.Add(recaudo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecaudo), new { id = recaudo.Id }, recaudo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecaudo(int id, Recaudo recaudo)
        {
            if (id != recaudo.Id)
            {
                return BadRequest();
            }

            _context.Entry(recaudo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecaudo(int id)
        {
            var recaudo = await _context.Recaudo.FindAsync(id);

            if (recaudo == null)
            {
                return NotFound();
            }

            _context.Recaudo.Remove(recaudo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

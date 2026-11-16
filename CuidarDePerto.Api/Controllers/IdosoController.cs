using CuidarDePerto.Api.Data;
using CuidarDePerto.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuidarDePerto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdosoController : ControllerBase
    {
        private readonly CuidarDePertoContext _context;

        public IdosoController(CuidarDePertoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idoso>>> GetIdosos()
        {
            return await _context.Idosos.Include(i => i.Alertas).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Idoso>> GetIdoso(int id)
        {
            var idoso = await _context.Idosos.Include(i => i.Alertas)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (idoso == null) return NotFound();

            return idoso;
        }

        [HttpPost]
        public async Task<ActionResult<Idoso>> PostIdoso(Idoso idoso)
        {
            _context.Idosos.Add(idoso);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIdoso), new { id = idoso.Id }, idoso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdoso(int id, Idoso idoso)
        {
            if (id != idoso.Id) return BadRequest();

            _context.Entry(idoso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdoso(int id)
        {
            var idoso = await _context.Idosos.FindAsync(id);
            if (idoso == null) return NotFound();

            _context.Idosos.Remove(idoso);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
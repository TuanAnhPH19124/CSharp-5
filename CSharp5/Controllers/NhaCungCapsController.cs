using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapsController : ControllerBase
    {
        private readonly DbContexts _context;

        public NhaCungCapsController(DbContexts context)
        {
            _context = context;
        }

        // GET: api/NhaCungCaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhaCungCap>>> GetnhaCungCaps()
        {
            return await _context.nhaCungCaps.ToListAsync();
        }

        // GET: api/NhaCungCaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhaCungCap>> GetNhaCungCap(int id)
        {
            var nhaCungCap = await _context.nhaCungCaps.FindAsync(id);

            if (nhaCungCap == null)
            {
                return NotFound();
            }

            return nhaCungCap;
        }

        // PUT: api/NhaCungCaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhaCungCap(int id, NhaCungCap nhaCungCap)
        {
            if (id != nhaCungCap.Id)
            {
                return BadRequest();
            }

            _context.Entry(nhaCungCap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaCungCapExists(id))
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

        // POST: api/NhaCungCaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhaCungCap>> PostNhaCungCap(NhaCungCap nhaCungCap)
        {
            _context.nhaCungCaps.Add(nhaCungCap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNhaCungCap", new { id = nhaCungCap.Id }, nhaCungCap);
        }

        // DELETE: api/NhaCungCaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhaCungCap(int id)
        {
            var nhaCungCap = await _context.nhaCungCaps.FindAsync(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            _context.nhaCungCaps.Remove(nhaCungCap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhaCungCapExists(int id)
        {
            return _context.nhaCungCaps.Any(e => e.Id == id);
        }
    }
}

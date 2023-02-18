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
    public class MausController : ControllerBase
    {
        private readonly DbContexts _context;

        public MausController(DbContexts context)
        {
            _context = context;
        }

        // GET: api/Maus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mau>>> Getmaus()
        {
            return await _context.maus.ToListAsync();
        }

        // GET: api/Maus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mau>> GetMau(int id)
        {
            var mau = await _context.maus.FindAsync(id);

            if (mau == null)
            {
                return NotFound();
            }

            return mau;
        }

        // PUT: api/Maus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMau(int id, Mau mau)
        {
            if (id != mau.Id)
            {
                return BadRequest();
            }

            _context.Entry(mau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MauExists(id))
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

        // POST: api/Maus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mau>> PostMau(Mau mau)
        {
            _context.maus.Add(mau);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMau", new { id = mau.Id }, mau);
        }

        // DELETE: api/Maus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMau(int id)
        {
            var mau = await _context.maus.FindAsync(id);
            if (mau == null)
            {
                return NotFound();
            }

            _context.maus.Remove(mau);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MauExists(int id)
        {
            return _context.maus.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;

namespace CSharp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly DbContexts _context;

        public SizesController(DbContexts context)
        {
            _context = context;
        }

        // GET: api/Sizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Size>>> Getsizes()
        {
            return await _context.sizes.ToListAsync();
        }

        // GET: api/Sizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Size>> GetSize(int id)
        {
            var size = await _context.sizes.FindAsync(id);

            if (size == null)
            {
                return NotFound();
            }

            return size;
        }

        // PUT: api/Sizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSize(int id, Size size)
        {
            if (id != size.Id)
            {
                return BadRequest();
            }

            _context.Entry(size).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeExists(id))
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

        // POST: api/Sizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Size>> PostSize(Size size)
        {
            _context.sizes.Add(size);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSize", new { id = size.Id }, size);
        }

        // DELETE: api/Sizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            var size = await _context.sizes.FindAsync(id);
            if (size == null)
            {
                return NotFound();
            }

            _context.sizes.Remove(size);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SizeExists(int id)
        {
            return _context.sizes.Any(e => e.Id == id);
        }
    }
}

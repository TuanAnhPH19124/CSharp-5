using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSharp5.Data;
using CSharp5.Models;

namespace CSharp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanQuyensController : ControllerBase
    {
        private readonly DataContext _context;

        public PhanQuyensController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PhanQuyens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhanQuyen>>> GetphanQuyens()
        {
            return await _context.phanQuyens.ToListAsync();
        }

        // GET: api/PhanQuyens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhanQuyen>> GetPhanQuyen(int id)
        {
            var phanQuyen = await _context.phanQuyens.FindAsync(id);

            if (phanQuyen == null)
            {
                return NotFound();
            }

            return phanQuyen;
        }

        // PUT: api/PhanQuyens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhanQuyen(int id, PhanQuyen phanQuyen)
        {
            if (id != phanQuyen.Id)
            {
                return BadRequest();
            }

            _context.Entry(phanQuyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhanQuyenExists(id))
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

        // POST: api/PhanQuyens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhanQuyen>> PostPhanQuyen(PhanQuyen phanQuyen)
        {
            _context.phanQuyens.Add(phanQuyen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhanQuyen", new { id = phanQuyen.Id }, phanQuyen);
        }

        // DELETE: api/PhanQuyens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhanQuyen(int id)
        {
            var phanQuyen = await _context.phanQuyens.FindAsync(id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            _context.phanQuyens.Remove(phanQuyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhanQuyenExists(int id)
        {
            return _context.phanQuyens.Any(e => e.Id == id);
        }
    }
}

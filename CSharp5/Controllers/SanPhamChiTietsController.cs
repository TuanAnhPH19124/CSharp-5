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
    public class SanPhamChiTietsController : ControllerBase
    {
        private readonly DataContext _context;

        public SanPhamChiTietsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SanPhamChiTiets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamChiTiet>>> GetsanPhamChiTiets()
        {
            return await _context.sanPhamChiTiets.ToListAsync();
        }

        // GET: api/SanPhamChiTiets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPhamChiTiet>> GetSanPhamChiTiet(int id)
        {
            var sanPhamChiTiet = await _context.sanPhamChiTiets.FindAsync(id);

            if (sanPhamChiTiet == null)
            {
                return NotFound();
            }

            return sanPhamChiTiet;
        }

        // PUT: api/SanPhamChiTiets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPhamChiTiet(int id, SanPhamChiTiet sanPhamChiTiet)
        {
            if (id != sanPhamChiTiet.Id)
            {
                return BadRequest();
            }

            _context.Entry(sanPhamChiTiet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamChiTietExists(id))
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

        // POST: api/SanPhamChiTiets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SanPhamChiTiet>> PostSanPhamChiTiet(SanPhamChiTiet sanPhamChiTiet)
        {
            _context.sanPhamChiTiets.Add(sanPhamChiTiet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSanPhamChiTiet", new { id = sanPhamChiTiet.Id }, sanPhamChiTiet);
        }

        // DELETE: api/SanPhamChiTiets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPhamChiTiet(int id)
        {
            var sanPhamChiTiet = await _context.sanPhamChiTiets.FindAsync(id);
            if (sanPhamChiTiet == null)
            {
                return NotFound();
            }

            _context.sanPhamChiTiets.Remove(sanPhamChiTiet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SanPhamChiTietExists(int id)
        {
            return _context.sanPhamChiTiets.Any(e => e.Id == id);
        }
    }
}

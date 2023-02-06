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
    public class GioHangsController : ControllerBase
    {
        private readonly DbContexts _context;

        public GioHangsController(DbContexts context)
        {
            _context = context;
        }

        // GET: api/GioHangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GioHang>>> GetgioHangs()
        {
            return await _context.gioHangs.ToListAsync();
        }

        // GET: api/GioHangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GioHang>> GetGioHang(int id)
        {
            var gioHang = await _context.gioHangs.FindAsync(id);

            if (gioHang == null)
            {
                return NotFound();
            }

            return gioHang;
        }

        // PUT: api/GioHangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGioHang(int id, GioHang gioHang)
        {
            if (id != gioHang.Id)
            {
                return BadRequest();
            }

            _context.Entry(gioHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GioHangExists(id))
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

        // POST: api/GioHangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GioHang>> PostGioHang(GioHang gioHang)
        {
            _context.gioHangs.Add(gioHang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGioHang", new { id = gioHang.Id }, gioHang);
        }

        // DELETE: api/GioHangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGioHang(int id)
        {
            var gioHang = await _context.gioHangs.FindAsync(id);
            if (gioHang == null)
            {
                return NotFound();
            }

            _context.gioHangs.Remove(gioHang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GioHangExists(int id)
        {
            return _context.gioHangs.Any(e => e.Id == id);
        }
    }
}

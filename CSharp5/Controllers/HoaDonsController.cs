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
    public class HoaDonsController : ControllerBase
    {
        private readonly DbContexts _context;

        public HoaDonsController(DbContexts context)
        {
            _context = context;
        }

        // GET: api/HoaDons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDon>>> GethoaDons()
        {
            return await _context.hoaDons.ToListAsync();
        }

        // GET: api/HoaDons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDon>> GetHoaDon(int id)
        {
            var hoaDon = await _context.hoaDons.FindAsync(id);

            if (hoaDon == null)
            {
                return NotFound();
            }

            return hoaDon;
        }

        // PUT: api/HoaDons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoaDon(int id, HoaDon hoaDon)
        {
            if (id != hoaDon.Id)
            {
                return BadRequest();
            }

            _context.Entry(hoaDon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonExists(id))
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

        // POST: api/HoaDons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HoaDon>> PostHoaDon(HoaDon hoaDon)
        {
            _context.hoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoaDon", new { id = hoaDon.Id }, hoaDon);
        }

        // DELETE: api/HoaDons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoaDon(int id)
        {
            var hoaDon = await _context.hoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            _context.hoaDons.Remove(hoaDon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoaDonExists(int id)
        {
            return _context.hoaDons.Any(e => e.Id == id);
        }
    }
}

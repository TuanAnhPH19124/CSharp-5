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
    public class GiamGiaHDsController : ControllerBase
    {
        private readonly DbContexts _context;

        public GiamGiaHDsController(DbContexts context)
        {
            _context = context;
        }

        // GET: api/GiamGiaHDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiamGiaHD>>> GetgiamGiaHDs()
        {
            return await _context.giamGiaHDs.ToListAsync();
        }

        // GET: api/GiamGiaHDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiamGiaHD>> GetGiamGiaHD(int id)
        {
            var giamGiaHD = await _context.giamGiaHDs.FindAsync(id);

            if (giamGiaHD == null)
            {
                return NotFound();
            }

            return giamGiaHD;
        }

        // PUT: api/GiamGiaHDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiamGiaHD(int id, GiamGiaHD giamGiaHD)
        {
            if (id != giamGiaHD.Id)
            {
                return BadRequest();
            }

            _context.Entry(giamGiaHD).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiamGiaHDExists(id))
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

        // POST: api/GiamGiaHDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GiamGiaHD>> PostGiamGiaHD(GiamGiaHD giamGiaHD)
        {
            _context.giamGiaHDs.Add(giamGiaHD);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiamGiaHD", new { id = giamGiaHD.Id }, giamGiaHD);
        }

        // DELETE: api/GiamGiaHDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiamGiaHD(int id)
        {
            var giamGiaHD = await _context.giamGiaHDs.FindAsync(id);
            if (giamGiaHD == null)
            {
                return NotFound();
            }

            _context.giamGiaHDs.Remove(giamGiaHD);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiamGiaHDExists(int id)
        {
            return _context.giamGiaHDs.Any(e => e.Id == id);
        }
    }
}

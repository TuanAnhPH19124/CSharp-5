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
    public class GiamGiaSPsController : ControllerBase
    {
        private readonly DataContext _context;

        public GiamGiaSPsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GiamGiaSPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiamGiaSP>>> GetgiamGiaSPs()
        {
            return await _context.giamGiaSPs.ToListAsync();
        }

        // GET: api/GiamGiaSPs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiamGiaSP>> GetGiamGiaSP(int id)
        {
            var giamGiaSP = await _context.giamGiaSPs.FindAsync(id);

            if (giamGiaSP == null)
            {
                return NotFound();
            }

            return giamGiaSP;
        }

        // PUT: api/GiamGiaSPs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiamGiaSP(int id, GiamGiaSP giamGiaSP)
        {
            if (id != giamGiaSP.Id)
            {
                return BadRequest();
            }

            _context.Entry(giamGiaSP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiamGiaSPExists(id))
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

        // POST: api/GiamGiaSPs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GiamGiaSP>> PostGiamGiaSP(GiamGiaSP giamGiaSP)
        {
            _context.giamGiaSPs.Add(giamGiaSP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiamGiaSP", new { id = giamGiaSP.Id }, giamGiaSP);
        }

        // DELETE: api/GiamGiaSPs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiamGiaSP(int id)
        {
            var giamGiaSP = await _context.giamGiaSPs.FindAsync(id);
            if (giamGiaSP == null)
            {
                return NotFound();
            }

            _context.giamGiaSPs.Remove(giamGiaSP);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiamGiaSPExists(int id)
        {
            return _context.giamGiaSPs.Any(e => e.Id == id);
        }
    }
}

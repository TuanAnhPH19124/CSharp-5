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
    public class HinhAnhSPsController : ControllerBase
    {
        private readonly DataContext _context;

        public HinhAnhSPsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/HinhAnhSPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HinhAnhSP>>> GethinhAnhSPs()
        {
            return await _context.hinhAnhSPs.ToListAsync();
        }

        // GET: api/HinhAnhSPs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HinhAnhSP>> GetHinhAnhSP(int id)
        {
            var hinhAnhSP = await _context.hinhAnhSPs.FindAsync(id);

            if (hinhAnhSP == null)
            {
                return NotFound();
            }

            return hinhAnhSP;
        }

        // PUT: api/HinhAnhSPs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHinhAnhSP(int id, HinhAnhSP hinhAnhSP)
        {
            if (id != hinhAnhSP.Id)
            {
                return BadRequest();
            }

            _context.Entry(hinhAnhSP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HinhAnhSPExists(id))
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

        // POST: api/HinhAnhSPs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HinhAnhSP>> PostHinhAnhSP(HinhAnhSP hinhAnhSP)
        {
            _context.hinhAnhSPs.Add(hinhAnhSP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHinhAnhSP", new { id = hinhAnhSP.Id }, hinhAnhSP);
        }

        // DELETE: api/HinhAnhSPs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHinhAnhSP(int id)
        {
            var hinhAnhSP = await _context.hinhAnhSPs.FindAsync(id);
            if (hinhAnhSP == null)
            {
                return NotFound();
            }

            _context.hinhAnhSPs.Remove(hinhAnhSP);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HinhAnhSPExists(int id)
        {
            return _context.hinhAnhSPs.Any(e => e.Id == id);
        }
    }
}

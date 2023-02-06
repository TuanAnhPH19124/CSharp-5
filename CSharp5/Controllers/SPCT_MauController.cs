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
    public class SPCT_MauController : ControllerBase
    {
        private readonly DbContexts _context;

        public SPCT_MauController(DbContexts context)
        {
            _context = context;
        }

        // GET: api/SPCT_Mau
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SPCT_Mau>>> GetsPCT_Maus()
        {
            return await _context.sPCT_Maus.ToListAsync();
        }

        // GET: api/SPCT_Mau/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SPCT_Mau>> GetSPCT_Mau(int id)
        {
            var sPCT_Mau = await _context.sPCT_Maus.FindAsync(id);

            if (sPCT_Mau == null)
            {
                return NotFound();
            }

            return sPCT_Mau;
        }

        // PUT: api/SPCT_Mau/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSPCT_Mau(int id, SPCT_Mau sPCT_Mau)
        {
            if (id != sPCT_Mau.Id_mau)
            {
                return BadRequest();
            }

            _context.Entry(sPCT_Mau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SPCT_MauExists(id))
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

        // POST: api/SPCT_Mau
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SPCT_Mau>> PostSPCT_Mau(SPCT_Mau sPCT_Mau)
        {
            _context.sPCT_Maus.Add(sPCT_Mau);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SPCT_MauExists(sPCT_Mau.Id_mau))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSPCT_Mau", new { id = sPCT_Mau.Id_mau }, sPCT_Mau);
        }

        // DELETE: api/SPCT_Mau/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSPCT_Mau(int id)
        {
            var sPCT_Mau = await _context.sPCT_Maus.FindAsync(id);
            if (sPCT_Mau == null)
            {
                return NotFound();
            }

            _context.sPCT_Maus.Remove(sPCT_Mau);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SPCT_MauExists(int id)
        {
            return _context.sPCT_Maus.Any(e => e.Id_mau == id);
        }
    }
}

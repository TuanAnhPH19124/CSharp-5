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
    public class DiaChisController : ControllerBase
    {
        private readonly DbContexts _context;

        public DiaChisController(DbContexts context)
        {
            _context = context;
        }

        // GET: api/DiaChis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaChi>>> GetdiaChis()
        {
            return await _context.diaChis.ToListAsync();
        }

        // GET: api/DiaChis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaChi>> GetDiaChi(int id)
        {
            var diaChi = await _context.diaChis.FindAsync(id);

            if (diaChi == null)
            {
                return NotFound();
            }

            return diaChi;
        }

        // PUT: api/DiaChis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaChi(int id, DiaChi diaChi)
        {
            if (id != diaChi.Id)
            {
                return BadRequest();
            }

            _context.Entry(diaChi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaChiExists(id))
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

        // POST: api/DiaChis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiaChi>> PostDiaChi(DiaChi diaChi)
        {
            _context.diaChis.Add(diaChi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiaChi", new { id = diaChi.Id }, diaChi);
        }

        // DELETE: api/DiaChis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaChi(int id)
        {
            var diaChi = await _context.diaChis.FindAsync(id);
            if (diaChi == null)
            {
                return NotFound();
            }

            _context.diaChis.Remove(diaChi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiaChiExists(int id)
        {
            return _context.diaChis.Any(e => e.Id == id);
        }
    }
}

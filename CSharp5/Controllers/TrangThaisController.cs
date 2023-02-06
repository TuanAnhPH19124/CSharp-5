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
    public class TrangThaisController : ControllerBase
    {
        private readonly DbContexts _context;

        public TrangThaisController(DbContexts context)
        {
            _context = context;
        }

        // GET: api/TrangThais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrangThai>>> GettrangThais()
        {
            return await _context.trangThais.ToListAsync();
        }

        // GET: api/TrangThais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrangThai>> GetTrangThai(int id)
        {
            var trangThai = await _context.trangThais.FindAsync(id);

            if (trangThai == null)
            {
                return NotFound();
            }

            return trangThai;
        }

        // PUT: api/TrangThais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrangThai(int id, TrangThai trangThai)
        {
            if (id != trangThai.Id)
            {
                return BadRequest();
            }

            _context.Entry(trangThai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrangThaiExists(id))
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

        // POST: api/TrangThais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrangThai>> PostTrangThai(TrangThai trangThai)
        {
            _context.trangThais.Add(trangThai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrangThai", new { id = trangThai.Id }, trangThai);
        }

        // DELETE: api/TrangThais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrangThai(int id)
        {
            var trangThai = await _context.trangThais.FindAsync(id);
            if (trangThai == null)
            {
                return NotFound();
            }

            _context.trangThais.Remove(trangThai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrangThaiExists(int id)
        {
            return _context.trangThais.Any(e => e.Id == id);
        }
    }
}

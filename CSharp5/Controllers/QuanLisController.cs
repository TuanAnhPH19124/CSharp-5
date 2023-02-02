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
    public class QuanLisController : ControllerBase
    {
        private readonly DataContext _context;

        public QuanLisController(DataContext context)
        {
            _context = context;
        }

        // GET: api/QuanLis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuanLi>>> GetquanLis()
        {
            return await _context.quanLis.ToListAsync();
        }

        // GET: api/QuanLis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuanLi>> GetQuanLi(int id)
        {
            var quanLi = await _context.quanLis.FindAsync(id);

            if (quanLi == null)
            {
                return NotFound();
            }

            return quanLi;
        }

        // PUT: api/QuanLis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuanLi(int id, QuanLi quanLi)
        {
            if (id != quanLi.Id)
            {
                return BadRequest();
            }

            _context.Entry(quanLi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuanLiExists(id))
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

        // POST: api/QuanLis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuanLi>> PostQuanLi(QuanLi quanLi)
        {
            _context.quanLis.Add(quanLi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuanLi", new { id = quanLi.Id }, quanLi);
        }

        // DELETE: api/QuanLis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuanLi(int id)
        {
            var quanLi = await _context.quanLis.FindAsync(id);
            if (quanLi == null)
            {
                return NotFound();
            }

            _context.quanLis.Remove(quanLi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuanLiExists(int id)
        {
            return _context.quanLis.Any(e => e.Id == id);
        }
    }
}

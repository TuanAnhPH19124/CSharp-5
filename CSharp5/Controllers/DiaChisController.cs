using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSharp5.Data;
using CSharp5.Models;
using CSharp5.IRepositories;

namespace CSharp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaChisController : ControllerBase
    {
        private readonly IAllRepositories<DiaChi> AllRepositories;


        public DiaChisController(IAllRepositories<DiaChi> context)
        {
            AllRepositories = context;
        }

        // GET: api/DiaChis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaChi>>> GetdiaChis()
        {
            return await AllRepositories.AddManyAsync(List<DiaChi>);
        }

        // GET: api/DiaChis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaChi>> GetDiaChi(int id)
        {
            var diaChi = await AllRepositories.diaChis.FindAsync(id);

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

            AllRepositories.Entry(diaChi).State = EntityState.Modified;

            try
            {
                await AllRepositories.SaveChangesAsync();
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
            AllRepositories.diaChis.Add(diaChi);
            await AllRepositories.SaveChangesAsync();

            return CreatedAtAction("GetDiaChi", new { id = diaChi.Id }, diaChi);
        }

        // DELETE: api/DiaChis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaChi(int id)
        {
            var diaChi = await AllRepositories.diaChis.FindAsync(id);
            if (diaChi == null)
            {
                return NotFound();
            }

            AllRepositories.diaChis.Remove(diaChi);
            await AllRepositories.SaveChangesAsync();

            return NoContent();
        }

        private bool DiaChiExists(int id)
        {
            return AllRepositories.diaChis.Any(e => e.Id == id);
        }

    }
}

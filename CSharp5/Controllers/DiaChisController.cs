using DAL.IServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaChisController : ControllerBase
    {
        private readonly IDiaChiService _service;

        public DiaChisController(IDiaChiService service)
        {
            _service = service;
        }

        // GET: api/DiaChis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaChi>>> GetdiaChis()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/DiaChis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaChi>> GetDiaChi(int id)
        {
            var diaChi = await _service.GetOneAsync(id);

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

            try
            {
                await _service.UpdateAsync(diaChi);
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

            await _service.AddAsync(diaChi);
            return CreatedAtAction("GetDiaChi", new { id = diaChi.Id }, diaChi);
        }

        // DELETE: api/DiaChis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaChi(int id)
        {
            var diaChi = await _service.GetOneAsync(id);
            if (diaChi == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);
            return NoContent();
        }

        private bool DiaChiExists(int id)
        {
            return _service.EntityExists(id);
        }

    }
}

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
    public class TrangThaisController : ControllerBase
    {
        private readonly ITrangThaiService _service;

        public TrangThaisController(ITrangThaiService service)
        {
            _service = service;
        }

        // GET: api/TrangThais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrangThai>>> GettrangThais()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/TrangThais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrangThai>> GetTrangThai(int id)
        {
            var trangThai = await _service.GetOneAsync(id);

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

            try
            {
                await _service.UpdateAsync(trangThai);
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
            await _service.AddAsync(trangThai);
            return CreatedAtAction("GetTrangThai", new { id = trangThai.Id }, trangThai);
        }

        // DELETE: api/TrangThais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrangThai(int id)
        {
            var trangThai = await _service.GetOneAsync(id);
            if (trangThai == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);

            return NoContent();
        }

        private bool TrangThaiExists(int id)
        {
            return _service.EntityExists(id);
        }
    }
}

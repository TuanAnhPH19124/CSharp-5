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
    public class PhanQuyensController : ControllerBase
    {
        private readonly IPhanQuyenService _service;

        public PhanQuyensController(IPhanQuyenService service)
        {
            _service = service;
        }

        // GET: api/PhanQuyens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhanQuyen>>> GetphanQuyens()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/PhanQuyens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhanQuyen>> GetPhanQuyen(int id)
        {
            var phanQuyen = await _service.GetOneAsync(id);

            if (phanQuyen == null)
            {
                return NotFound();
            }

            return phanQuyen;
        }

        // PUT: api/PhanQuyens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhanQuyen(int id, PhanQuyen phanQuyen)
        {
            if (id != phanQuyen.Id)
            {
                return BadRequest();
            }


            try
            {
                await _service.UpdateAsync(phanQuyen);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhanQuyenExists(id))
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

        // POST: api/PhanQuyens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhanQuyen>> PostPhanQuyen(PhanQuyen phanQuyen)
        {
            await _service.AddAsync(phanQuyen);

            return CreatedAtAction("GetPhanQuyen", new { id = phanQuyen.Id }, phanQuyen);
        }

        // DELETE: api/PhanQuyens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhanQuyen(int id)
        {
            var phanQuyen = await _service.GetOneAsync(id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);

            return NoContent();
        }

        private bool PhanQuyenExists(int id)
        {
            return _service.EntityExists(id);
        }
    }
}

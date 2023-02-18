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
    public class QuanLisController : ControllerBase
    {
        private readonly IQuanLiService _service;

        public QuanLisController(IQuanLiService service)
        {
            _service = service;
        }

        // GET: api/QuanLis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuanLi>>> GetquanLis()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/QuanLis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuanLi>> GetQuanLi(int id)
        {
            var quanLi = await _service.GetOneAsync(id);

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

            try
            {
                await _service.UpdateAsync(quanLi);
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
            await _service.AddAsync(quanLi);

            return CreatedAtAction("GetQuanLi", new { id = quanLi.Id }, quanLi);
        }

        // DELETE: api/QuanLis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuanLi(int id)
        {
            var quanLi = await _service.GetOneAsync(id);
            if (quanLi == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);

            return NoContent();
        }

        private bool QuanLiExists(int id)
        {
            return _service.EntityExists(id);
        }
    }
}

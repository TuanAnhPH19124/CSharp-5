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
    public class GiamGiaSPsController : ControllerBase
    {
        private readonly IGiamGiaSPService _service;

        public GiamGiaSPsController(IGiamGiaSPService service)
        {
            _service = service;
        }

        // GET: api/GiamGiaSPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiamGiaSP>>> GetgiamGiaSPs()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/GiamGiaSPs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiamGiaSP>> GetGiamGiaSP(int id)
        {
            var giamGiaSP = await _service.GetOneAsync(id);

            if (giamGiaSP == null)
            {
                return NotFound();
            }

            return giamGiaSP;
        }

        // PUT: api/GiamGiaSPs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiamGiaSP(int id, GiamGiaSP giamGiaSP)
        {
            if (id != giamGiaSP.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(giamGiaSP);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiamGiaSPExists(id))
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

        // POST: api/GiamGiaSPs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GiamGiaSP>> PostGiamGiaSP(GiamGiaSP giamGiaSP)
        {
            await _service.AddAsync(giamGiaSP);

            return CreatedAtAction("GetGiamGiaSP", new { id = giamGiaSP.Id }, giamGiaSP);
        }

        // DELETE: api/GiamGiaSPs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiamGiaSP(int id)
        {
            var giamGiaSP = await _service.GetOneAsync(id);
            if (giamGiaSP == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);

            return NoContent();
        }

        private bool GiamGiaSPExists(int id)
        {
            return _service.EntityExists(id);
        }
    }
}

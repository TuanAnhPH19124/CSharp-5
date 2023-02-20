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
    public class GiamGiaHDsController : ControllerBase
    {
        private readonly IGiamGiaHDService _service;

        public GiamGiaHDsController(IGiamGiaHDService service)
        {
            _service = service;
        }

        // GET: api/GiamGiaHDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiamGiaHD>>> GetgiamGiaHDs()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/GiamGiaHDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiamGiaHD>> GetGiamGiaHD(int id)
        {
            var giamGiaHD = await _service.GetOneAsync(id);

            if (giamGiaHD == null)
            {
                return NotFound();
            }

            return giamGiaHD;
        }

        // PUT: api/GiamGiaHDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiamGiaHD(int id, GiamGiaHD giamGiaHD)
        {
            if (id != giamGiaHD.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(giamGiaHD);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiamGiaHDExists(id))
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

        // POST: api/GiamGiaHDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GiamGiaHD>> PostGiamGiaHD(GiamGiaHD giamGiaHD)
        {
            await _service.AddAsync(giamGiaHD);
            return CreatedAtAction("GetGiamGiaHD", new { id = giamGiaHD.Id }, giamGiaHD);
        }

        // DELETE: api/GiamGiaHDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiamGiaHD(int id)
        {
            var giamGiaHD = await _service.GetOneAsync(id);
            if (giamGiaHD == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);
            return NoContent();
        }

        private bool GiamGiaHDExists(int id)
        {
            return _service.EntityExists(id);
        }
    }
}

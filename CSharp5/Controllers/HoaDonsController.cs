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
    public class HoaDonsController : ControllerBase
    {
        private readonly IHoaDonService _service;

        public HoaDonsController(IHoaDonService service)
        {
            _service = service;
        }

        // GET: api/HoaDons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDon>>> GethoaDons()
        {
            var query = _service.GetFirstOrDefault(include: x => x.Include(a => a.hoaDonChiTiets).ThenInclude(a=>a.sanPhamChiTiet).Include(a=>a.diaChi).ThenInclude(a=>a.nguoiDung));
            return await _service.GetAll2Async(query);
        }

        // GET: api/HoaDons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDon>> GetHoaDon(int id)
        {
            var hoaDon = await _service.GetOneAsync(id);

            if (hoaDon == null)
            {
                return NotFound();
            }

            return hoaDon;
        }

        // PUT: api/HoaDons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoaDon(int id, HoaDon hoaDon)
        {
            if (id != hoaDon.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(hoaDon);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonExists(id))
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

        // POST: api/HoaDons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HoaDon>> PostHoaDon(HoaDon hoaDon)
        {
            await _service.AddAsync(hoaDon);
            return CreatedAtAction("GetHoaDon", new { id = hoaDon.Id }, hoaDon);
        }

        // DELETE: api/HoaDons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoaDon(int id)
        {
            var hoaDon = await _service.GetOneAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);
            return NoContent();
        }

        private bool HoaDonExists(int id)
        {
            return _service.EntityExists(id);
        }
    }
}

using DAL.IServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangsController : ControllerBase
    {
        private readonly IGioHangService _service;

        public GioHangsController(IGioHangService service)
        {
            _service = service;
        }

        // GET: api/GioHangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GioHang>>> GetgioHangs()
        {
            var query = _service.GetFirstOrDefault(include: x => x.Include(a => a.sanPhamChiTiet));
            return await _service.GetAll2Async(query);
        }

        // GET: api/GioHangs/5
        [HttpGet("getDelete")]
        public async Task<ActionResult<IEnumerable<GioHang>>> GetGioHang()
        {
            return await _service.GetAllAsync();
        }

        // PUT: api/GioHangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGioHang(int id, GioHang gioHang)
        {
            if (id != gioHang.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(gioHang);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GioHangExists(id))
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

        // POST: api/GioHangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GioHang>> PostGioHang(GioHang gioHang)
        {
            await _service.AddAsync(gioHang);

            return CreatedAtAction("GetGioHang", new { id = gioHang.Id }, gioHang);
        }

        // DELETE: api/GioHangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGioHang(int id)
        {
            var gioHang = await _service.GetOneAsync(id);
            if (gioHang == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);

            return NoContent();
        }
        [HttpPost("clear")]
        public async Task<IActionResult> DeleteGioHangs(List<GioHang> gioHangs)
        {
            await _service.RemoveRangeAsync(gioHangs);
            return NoContent();
        }
        private bool GioHangExists(int id)
        {
            return _service.EntityExists(id);
        }
    }
}

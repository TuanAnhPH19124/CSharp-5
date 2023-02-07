using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;
using DAL.IServices;

namespace CSharp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamChiTietsController : ControllerBase
    {
        private readonly ISanPhamChiTietService _service;

        public SanPhamChiTietsController(ISanPhamChiTietService service)
        {
            _service = service;
        }

        // GET: api/SanPhamChiTiets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamChiTiet>>> GetsanPhamChiTiets()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/SanPhamChiTiets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPhamChiTiet>> GetSanPhamChiTiet(int id)
        {
            var sanPhamChiTiet = await _service.GetOneAsync(id);

            if (sanPhamChiTiet == null)
            {
                return NotFound();
            }

            return sanPhamChiTiet;
        }

        // PUT: api/SanPhamChiTiets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPhamChiTiet(int id, SanPhamChiTiet sanPhamChiTiet)
        {
            if (id != sanPhamChiTiet.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(sanPhamChiTiet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamChiTietExists(id))
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

        // POST: api/SanPhamChiTiets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SanPhamChiTiet>> PostSanPhamChiTiet(SanPhamChiTiet sanPhamChiTiet)
        {
            await _service.AddAsync(sanPhamChiTiet);
            return CreatedAtAction("GetSanPhamChiTiet", new { id = sanPhamChiTiet.Id }, sanPhamChiTiet);
        }

        // DELETE: api/SanPhamChiTiets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPhamChiTiet(int id)
        {
            var sanPhamChiTiet = await _service.GetOneAsync(id);
            if (sanPhamChiTiet == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);
            return NoContent();
        }

        private bool SanPhamChiTietExists(int id)
        {
            return _service.EntityExists(id);
        }
    }
}

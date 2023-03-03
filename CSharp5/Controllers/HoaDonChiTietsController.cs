using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;
using DAL.Base;
using DAL.IServices;

namespace CSharp5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonChiTietsController : ControllerBase
    {
        private readonly IHoaDonChiTietService _service;

        public HoaDonChiTietsController(IHoaDonChiTietService service)
        {
            _service = service;
        }

        // GET: api/HoaDonChiTiets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDonChiTiet>>> GethoaDonChiTiets()
        {
            return NoContent();
        }

        // GET: api/HoaDonChiTiets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDonChiTiet>> GetHoaDonChiTiet(int id)
        {
            //var hoaDonChiTiet = await _service.hoaDonChiTiets.FindAsync(id);

            //if (hoaDonChiTiet == null)
            //{
            //    return NotFound();
            //}

            return NoContent();
        }

        // PUT: api/HoaDonChiTiets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoaDonChiTiet(int id, HoaDonChiTiet hoaDonChiTiet)
        {
            //if (id != hoaDonChiTiet.Id)
            //{
            //    return BadRequest();
            //}

            //_service.Entry(hoaDonChiTiet).State = EntityState.Modified;

            //try
            //{
            //    await _service.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!HoaDonChiTietExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/HoaDonChiTiets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostHoaDonChiTiet(List<HoaDonChiTiet> hoaDonChiTiets)
        {
            //_service.hoaDonChiTiets.Add(hoaDonChiTiet);
            //await _service.SaveChangesAsync();

            //return CreatedAtAction("GetHoaDonChiTiet", new { id = hoaDonChiTiet.Id }, hoaDonChiTiet);

            await _service.AddRangeAsync(hoaDonChiTiets);
            return CreatedAtAction("AddHoaDonChitiet", hoaDonChiTiets);
        }

        // DELETE: api/HoaDonChiTiets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoaDonChiTiet(int id)
        {
            //var hoaDonChiTiet = await _service.hoaDonChiTiets.FindAsync(id);
            //if (hoaDonChiTiet == null)
            //{
            //    return NotFound();
            //}

            //_service.hoaDonChiTiets.Remove(hoaDonChiTiet);
            //await _service.SaveChangesAsync();

            return NoContent();
        }

        //private bool HoaDonChiTietExists(int id)
        //{
        //    return _service.hoaDonChiTiets.Any(e => e.Id == id);
        //}
    }
}

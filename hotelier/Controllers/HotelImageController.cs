using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotelier.Data;
using hotelier.Models;

namespace hotelier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelImageController : ControllerBase
    {
        private readonly HotelierContext _context;

        public HotelImageController(HotelierContext context)
        {
            _context = context;
        }

        // GET: api/HotelImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelImage>>> GetHotelImages()
        {
            return await _context.HotelImages.ToListAsync();
        }

        // GET: api/HotelImage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelImage>> GetHotelImage(int id)
        {
            var hotelImage = await _context.HotelImages.FindAsync(id);

            if (hotelImage == null)
            {
                return NotFound();
            }

            return hotelImage;
        }

        // PUT: api/HotelImage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelImage(int id, HotelImage hotelImage)
        {
            if (id != hotelImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelImageExists(id))
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

        // POST: api/HotelImage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelImage>> PostHotelImage(HotelImage hotelImage)
        {
            _context.HotelImages.Add(hotelImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelImage", new { id = hotelImage.Id }, hotelImage);
        }

        // DELETE: api/HotelImage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelImage(int id)
        {
            var hotelImage = await _context.HotelImages.FindAsync(id);
            if (hotelImage == null)
            {
                return NotFound();
            }

            _context.HotelImages.Remove(hotelImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelImageExists(int id)
        {
            return _context.HotelImages.Any(e => e.Id == id);
        }
    }
}

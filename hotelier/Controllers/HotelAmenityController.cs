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
    public class HotelAmenityController : ControllerBase
    {
        private readonly HotelierContext _context;

        public HotelAmenityController(HotelierContext context)
        {
            _context = context;
        }

        // GET: api/HotelAmenity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelAmenity>>> GetHotelAmenities()
        {
            return await _context.HotelAmenities.ToListAsync();
        }

        // GET: api/HotelAmenity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelAmenity>> GetHotelAmenity(int id)
        {
            var hotelAmenity = await _context.HotelAmenities.FindAsync(id);

            if (hotelAmenity == null)
            {
                return NotFound();
            }

            return hotelAmenity;
        }

        // PUT: api/HotelAmenity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelAmenity(int id, HotelAmenity hotelAmenity)
        {
            if (id != hotelAmenity.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelAmenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelAmenityExists(id))
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

        // POST: api/HotelAmenity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelAmenity>> PostHotelAmenity(HotelAmenity hotelAmenity)
        {
            _context.HotelAmenities.Add(hotelAmenity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelAmenity", new { id = hotelAmenity.Id }, hotelAmenity);
        }

        // DELETE: api/HotelAmenity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelAmenity(int id)
        {
            var hotelAmenity = await _context.HotelAmenities.FindAsync(id);
            if (hotelAmenity == null)
            {
                return NotFound();
            }

            _context.HotelAmenities.Remove(hotelAmenity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelAmenityExists(int id)
        {
            return _context.HotelAmenities.Any(e => e.Id == id);
        }
    }
}

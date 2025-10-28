using Mavzuho.Data;
using Mavzuho.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mavzuho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MavzuControler : ControllerBase
    {
        private readonly MavzuDbContext _context;

        public MavzuControler(MavzuDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mavods = await _context.Mavzuho.ToListAsync();
            return Ok(mavods);
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var mavzu = await _context.Mavzuho.FindAsync(id);
            if (mavzu == null)
            {
                return NotFound(new { message = "Мавзу ёфт нашуд" });
            }
            return Ok(mavzu);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Mavzu mavzu)
        {
            if (mavzu == null || !ModelState.IsValid)
            {
                return BadRequest(new { message = "Маълумоти нодуруст ворид шудааст" });
            }

            _context.Mavzuho.Add(mavzu);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = mavzu.Id }, mavzu);
        }

       
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Mavzu mavzu)
        {
            if (id != mavzu.Id || !ModelState.IsValid)
            {
                return BadRequest(new { message = "Маълумоти нодуруст ворид шудааст" });
            }

            var exists = await _context.Mavzuho.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound(new { message = "Мавзу ёфт нашуд" });
            }

            _context.Entry(mavzu).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

       
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mavzu = await _context.Mavzuho.FindAsync(id);
            if (mavzu == null)
            {
                return NotFound(new { message = "Мавзу ёфт нашуд" });
            }

            _context.Mavzuho.Remove(mavzu);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
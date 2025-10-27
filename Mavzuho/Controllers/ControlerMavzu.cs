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
    public class BooksController : ControllerBase
    {
        private readonly DataB _context;

        public BooksController(DataB context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _context.Mavods.ToListAsync();
            return Ok(books);
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _context.Mavods.FindAsync(id);
            if (book == null)
            {
                return NotFound(new { message = "Китоб ёфт нашуд" });
            }
            return Ok(book);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Mavod book)
        {
            if (book == null || !ModelState.IsValid)
            {
                return BadRequest(new { message = "Маълумоти нодуруст ворид шудааст" });
            }

            _context.Mavods.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

       
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Mavod book)
        {
            if (id != book.Id || !ModelState.IsValid)
            {
                return BadRequest(new { message = "Маълумоти нодуруст ворид шудааст" });
            }

            var exists = await _context.Mavods.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound(new { message = "Китоб ёфт нашуд" });
            }

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

       
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Mavods.FindAsync(id);
            if (book == null)
            {
                return NotFound(new { message = "Китоб ёфт нашуд" });
            }

            _context.Mavods.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
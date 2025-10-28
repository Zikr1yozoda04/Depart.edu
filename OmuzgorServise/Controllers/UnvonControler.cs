using Microsoft.AspNetCore.Mvc;
using OmuzgorServise.Model;
using OmuzgorServise.Service;

namespace OmuzgorServise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnvonControler: ControllerBase
    {
        private readonly IUnvon unvonService;

        public UnvonControler(IUnvon service)
        {
            unvonService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await unvonService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var unvon = await unvonService.GetByIdAsync(id);
            if (unvon == null) return NotFound("Хатоги! Маълумот дарёфт нашуд!");
            return Ok(unvon);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Unvon unvon)
        {
            var result = await unvonService.CreateAsync(unvon);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Unvon unvon)
        {
            if (id != unvon.Id) return BadRequest("ID mismatch");
            var updated = await unvonService.UpdateAsync(unvon);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await unvonService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

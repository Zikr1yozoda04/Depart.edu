using Microsoft.AspNetCore.Mvc;
using OmuzgorServise.Model;
using OmuzgorServise.Service;

namespace OmuzgorServise.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DarajaControler: ControllerBase
    {
        private readonly IDaraja _service;

        public DarajaControler(IDaraja service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var daraja = await _service.GetByIdAsync(id);
            if (daraja == null) return NotFound("Хатоги! Маълумот дарёфт нашуд!");
            return Ok(daraja);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Daraja daraja)
        {
            var result = await _service.CreateAsync(daraja);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Daraja daraja)
        {
            if (id != daraja.Id) return BadRequest("ID mismatch");
            var updated = await _service.UpdateAsync(daraja);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

    }
}

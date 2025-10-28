using Microsoft.AspNetCore.Mvc;
using OmuzgorServise.Model;
using OmuzgorServise.Service;

namespace OmuzgorServise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OmuzgorControler:ControllerBase
    {
        private readonly IOmuzgor omuzgorservice;

        public OmuzgorControler(IOmuzgor service)
        {
            omuzgorservice = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await omuzgorservice.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var omuzgor = await omuzgorservice.GetByIdAsync(id);
            if (omuzgor == null) return NotFound("Хатоги! Маълумот дарёфт нашуд!");
            return Ok(omuzgor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Omuzgor omuzgor)
        {
            var result = await omuzgorservice.CreateAsync(omuzgor);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Omuzgor omuzgor)
        {
            if (id != omuzgor.Id) return BadRequest("ID mismatch");
            var updated = await omuzgorservice.UpdateAsync(omuzgor);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await omuzgorservice.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

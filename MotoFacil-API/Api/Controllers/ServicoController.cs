using Microsoft.AspNetCore.Mvc;
using MotoFacil_API.Application.Dtos;
using MotoFacilAPI.Application.Dtos;
using MotoFacilAPI.Application.Interfaces;

namespace MotoFacilAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicosController : ControllerBase
    {
        private readonly IServicoService _service;
        public ServicosController(IServicoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoDto>>> Get() => Ok(await _service.ListAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServicoDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServicoDto>> Post([FromBody] ServicoDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] ServicoDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
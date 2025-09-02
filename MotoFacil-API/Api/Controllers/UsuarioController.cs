using Microsoft.AspNetCore.Mvc;
using MotoFacil_API.Application.Dtos;
using MotoFacilAPI.Application.Dtos;
using MotoFacilAPI.Application.Interfaces;

namespace MotoFacilAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuariosController(IUsuarioService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get() => Ok(await _service.ListAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDto dto)
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
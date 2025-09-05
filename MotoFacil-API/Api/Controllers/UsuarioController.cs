using Microsoft.AspNetCore.Mvc;
using MotoFacilAPI.Application.Dtos;
using MotoFacilAPI.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MotoFacilAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuariosController(IUsuarioService service) => _service = service;

        /// <summary>Lista todos os usuários</summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os usuários")]
        [ProducesResponseType(typeof(IEnumerable<UsuarioDto>), 200)]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get() => Ok(await _service.ListAsync());

        /// <summary>Busca usuário por ID</summary>
        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Busca usuário por ID")]
        [ProducesResponseType(typeof(UsuarioDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        /// <summary>Cria novo usuário</summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Cria novo usuário")]
        [ProducesResponseType(typeof(UsuarioDto), 201)]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>Atualiza usuário</summary>
        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Atualiza usuário")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>Remove usuário</summary>
        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Remove usuário")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
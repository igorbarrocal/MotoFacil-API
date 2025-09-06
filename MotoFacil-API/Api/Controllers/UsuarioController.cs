using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Lista todos os usuários (com paginação)
        /// </summary>
        /// <param name="page">Página</param>
        /// <param name="pageSize">Itens por página</param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioDto>), 200)]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var all = await _service.ListAsync();
            var paged = all.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(paged);
        }

        /// <summary>
        /// Busca usuário por ID
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UsuarioDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        /// <summary>
        /// Cria novo usuário
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioDto), 201)]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza usuário
        /// </summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>
        /// Remove usuário
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
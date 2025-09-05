using Microsoft.AspNetCore.Mvc;
using MotoFacil_API.Application.Dtos;
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

        /// <summary>
        /// Lista usuários paginados com links HATEOAS.
        /// </summary>
        /// <param name="page">Página</param>
        /// <param name="pageSize">Itens por página</param>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista usuários", Description = "Retorna usuários paginados com links HATEOAS")]
        [ProducesResponseType(typeof(IEnumerable<UsuarioDto>), 200)]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var list = await _service.ListPagedAsync(page, pageSize);
            foreach (UsuarioDto usuario in list) // Explicitly cast to UsuarioDto
            {
                usuario.Links = new List<LinkDto>
                {
                    new LinkDto(Url.Action(nameof(GetById), new { id = usuario.Id })!, "self", "GET"),
                    new LinkDto(Url.Action(nameof(Put), new { id = usuario.Id })!, "update_usuario", "PUT"),
                    new LinkDto(Url.Action(nameof(Delete), new { id = usuario.Id })!, "delete_usuario", "DELETE")
                };
            }
            return Ok(list);
        }

        /// <summary>
        /// Busca usuário por ID.
        /// </summary>
        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Busca usuário por ID")]
        [ProducesResponseType(typeof(UsuarioDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            usuario.Links = new List<LinkDto>
            {
                new LinkDto(Url.Action(nameof(GetById), new { id = usuario.Id })!, "self", "GET"),
                new LinkDto(Url.Action(nameof(Put), new { id = usuario.Id })!, "update_usuario", "PUT"),
                new LinkDto(Url.Action(nameof(Delete), new { id = usuario.Id })!, "delete_usuario", "DELETE")
            };
            return Ok(usuario);
        }

        /// <summary>
        /// Cria novo usuário.
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Cria novo usuário")]
        [ProducesResponseType(typeof(UsuarioDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _service.CreateAsync(dto);
            created.Links = new List<LinkDto>
            {
                new LinkDto(Url.Action(nameof(GetById), new { id = created.Id })!, "self", "GET"),
                new LinkDto(Url.Action(nameof(Put), new { id = created.Id })!, "update_usuario", "PUT"),
                new LinkDto(Url.Action(nameof(Delete), new { id = created.Id })!, "delete_usuario", "DELETE")
            };
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza usuário.
        /// </summary>
        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Atualiza usuário")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>
        /// Remove usuário.
        /// </summary>
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
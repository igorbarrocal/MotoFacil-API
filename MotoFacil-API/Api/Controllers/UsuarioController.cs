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
            foreach (var usuario in list)
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
        // ... restantes endpoints com SwaggerOperation, ProducesResponseType, HATEOAS nos DTOs
    }
}
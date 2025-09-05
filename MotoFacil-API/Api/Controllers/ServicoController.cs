using Microsoft.AspNetCore.Mvc;
using MotoFacil_API.Application.Dtos;
using MotoFacilAPI.Application.Dtos;
using MotoFacilAPI.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MotoFacilAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicosController : ControllerBase
    {
        private readonly IServicoService _service;
        public ServicosController(IServicoService service) => _service = service;

        /// <summary>Lista todos os serviços</summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os serviços")]
        [ProducesResponseType(typeof(IEnumerable<ServicoDto>), 200)]
        public async Task<ActionResult<IEnumerable<ServicoDto>>> Get() => Ok(await _service.ListAsync());

        /// <summary>Busca serviço por ID</summary>
        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Busca serviço por ID")]
        [ProducesResponseType(typeof(ServicoDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ServicoDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        /// <summary>Cria novo serviço</summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Cria novo serviço")]
        [ProducesResponseType(typeof(ServicoDto), 201)]
        public async Task<ActionResult<ServicoDto>> Post([FromBody] ServicoDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>Atualiza serviço</summary>
        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Atualiza serviço")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] ServicoDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>Remove serviço</summary>
        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Remove serviço")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
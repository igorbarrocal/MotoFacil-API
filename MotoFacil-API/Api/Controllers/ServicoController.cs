using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Lista todos os serviços (com paginação)
        /// </summary>
        /// <param name="page">Página</param>
        /// <param name="pageSize">Itens por página</param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ServicoDto>), 200)]
        public async Task<ActionResult<IEnumerable<ServicoDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var all = await _service.ListAsync();
            var paged = all.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(paged);
        }

        /// <summary>
        /// Busca serviço por ID
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ServicoDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ServicoDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Cria novo serviço
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ServicoDto), 201)]
        public async Task<ActionResult<ServicoDto>> Post([FromBody] ServicoDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza serviço
        /// </summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] ServicoDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>
        /// Remove serviço
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
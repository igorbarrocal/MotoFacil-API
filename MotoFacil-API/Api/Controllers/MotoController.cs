using Microsoft.AspNetCore.Mvc;
using MotoFacilAPI.Application.Dtos;
using MotoFacilAPI.Application.Interfaces;

namespace MotoFacilAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly IMotoService _service;
        public MotosController(IMotoService service) => _service = service;

        /// <summary>
        /// Lista todas as motos (com paginação)
        /// </summary>
        /// <param name="page">Página</param>
        /// <param name="pageSize">Itens por página</param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MotoDto>), 200)]
        public async Task<ActionResult<IEnumerable<MotoDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var all = await _service.ListAsync();
            var paged = all.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(paged);
        }

        /// <summary>
        /// Busca moto por ID
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(MotoDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MotoDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Cria nova moto
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(MotoDto), 201)]
        public async Task<ActionResult<MotoDto>> Post([FromBody] MotoDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza uma moto
        /// </summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] MotoDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>
        /// Remove uma moto
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
using Microsoft.AspNetCore.Mvc;
using MotoFacilAPI.Application.Dtos;
using MotoFacilAPI.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MotoFacilAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly IMotoService _service;
        public MotosController(IMotoService service) => _service = service;

        /// <summary>
        /// Lista todas as motos
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as motos")]
        [ProducesResponseType(typeof(IEnumerable<MotoDto>), 200)]
        public async Task<ActionResult<IEnumerable<MotoDto>>> Get()
            => Ok(await _service.ListAsync());

        /// <summary>
        /// Busca moto por ID
        /// </summary>
        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Busca moto por ID")]
        [ProducesResponseType(typeof(MotoDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MotoDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        /// <summary>
        /// Cria nova moto
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Cria nova moto")]
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
        [SwaggerOperation(Summary = "Atualiza uma moto")]
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
        [SwaggerOperation(Summary = "Remove uma moto")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
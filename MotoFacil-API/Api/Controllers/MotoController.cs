using Microsoft.AspNetCore.Mvc;
using MotoFacilAPI.Application.Dtos;
using MotoFacilAPI.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MotoFacilAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly IMotoService _service;
        public MotosController(IMotoService service) => _service = service;

        /// <summary>
        /// Lista todas as motos (com paginação e HATEOAS)
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResultDto<MotoDto>), 200)]
        public async Task<ActionResult<PagedResultDto<MotoDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var all = await _service.ListAsync();
            var total = all.Count;
            var paged = all.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            foreach (var moto in paged)
            {
                moto.Links.Add(new LinkDto { Rel = "self", Href = Url.Action(nameof(GetById), new { id = moto.Id }), Method = "GET" });
                moto.Links.Add(new LinkDto { Rel = "update", Href = Url.Action(nameof(Put), new { id = moto.Id }), Method = "PUT" });
                moto.Links.Add(new LinkDto { Rel = "delete", Href = Url.Action(nameof(Delete), new { id = moto.Id }), Method = "DELETE" });
            }

            return Ok(new PagedResultDto<MotoDto>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = total,
                Items = paged
            });
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

            result.Links.Add(new LinkDto { Rel = "self", Href = Url.Action(nameof(GetById), new { id = result.Id }), Method = "GET" });
            result.Links.Add(new LinkDto { Rel = "update", Href = Url.Action(nameof(Put), new { id = result.Id }), Method = "PUT" });
            result.Links.Add(new LinkDto { Rel = "delete", Href = Url.Action(nameof(Delete), new { id = result.Id }), Method = "DELETE" });

            return Ok(result);
        }

        /// <summary>
        /// Cria nova moto
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(MotoDto), 201)]
        public async Task<ActionResult<MotoDto>> Post([FromBody] MotoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);

            created.Links.Add(new LinkDto { Rel = "self", Href = Url.Action(nameof(GetById), new { id = created.Id }), Method = "GET" });
            created.Links.Add(new LinkDto { Rel = "update", Href = Url.Action(nameof(Put), new { id = created.Id }), Method = "PUT" });
            created.Links.Add(new LinkDto { Rel = "delete", Href = Url.Action(nameof(Delete), new { id = created.Id }), Method = "DELETE" });

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
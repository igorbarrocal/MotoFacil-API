using Microsoft.AspNetCore.Mvc;
using MotoFacil_API.Data;
using MotoFacilAPI.Data;
using MotoFacilAPI.Dtos;
using MotoFacilAPI.Models;
using System;
using System.Linq;

namespace MotoFacilAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        a
        public ServicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var servicos = _context.Servicos
                .Select(s => new ServicoDto
                {
                    Id = s.Id,
                    Descricao = s.Descricao,
                    Data = s.Data,
                    UsuarioId = s.UsuarioId,
                    MotoId = s.MotoId
                }).ToList();

            return Ok(servicos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var servico = _context.Servicos
                .Where(s => s.Id == id)
                .Select(s => new ServicoDto
                {
                    Id = s.Id,
                    Descricao = s.Descricao,
                    Data = s.Data,
                    UsuarioId = s.UsuarioId,
                    MotoId = s.MotoId
                }).FirstOrDefault();

            if (servico == null) return NotFound();
            return Ok(servico);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ServicoDto dto)
        {
            var servico = new Servico { Descricao = dto.Descricao, Data = dto.Data, UsuarioId = dto.UsuarioId, MotoId = dto.MotoId };
            _context.Servicos.Add(servico);
            _context.SaveChanges();

            dto.Id = servico.Id;
            return CreatedAtAction(nameof(GetById), new { id = servico.Id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ServicoDto dto)
        {
            var servico = _context.Servicos.Find(id);
            if (servico == null) return NotFound();

            servico.Descricao = dto.Descricao;
            servico.Data = dto.Data;
            servico.UsuarioId = dto.UsuarioId;
            servico.MotoId = dto.MotoId;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var servico = _context.Servicos.Find(id);
            if (servico == null) return NotFound();

            _context.Servicos.Remove(servico);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

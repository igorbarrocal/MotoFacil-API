using Microsoft.AspNetCore.Mvc;
using MotoFacil_API.Data;
using MotoFacilAPI.Data;
using MotoFacilAPI.Dtos;
using MotoFacilAPI.Models;
using System.Linq;

namespace MotoFacilAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var motos = _context.Motos
                .Select(m => new MotoDto
                {
                    Id = m.Id,
                    Modelo = m.Modelo,
                    Marca = m.Marca,
                    UsuarioId = m.UsuarioId
                }).ToList();

            return Ok(motos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var moto = _context.Motos
                .Where(m => m.Id == id)
                .Select(m => new MotoDto
                {
                    Id = m.Id,
                    Modelo = m.Modelo,
                    Marca = m.Marca,
                    UsuarioId = m.UsuarioId
                }).FirstOrDefault();

            if (moto == null) return NotFound();
            return Ok(moto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MotoDto dto)
        {
            var moto = new Moto
            {
                Modelo = dto.Modelo,  // enum garante valor válido
                Marca = dto.Marca,
                UsuarioId = dto.UsuarioId
            };

            _context.Motos.Add(moto);
            _context.SaveChanges();

            dto.Id = moto.Id;
            return CreatedAtAction(nameof(GetById), new { id = moto.Id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MotoDto dto)
        {
            var moto = _context.Motos.Find(id);
            if (moto == null) return NotFound();

            moto.Modelo = dto.Modelo;  // enum garante valor válido
            moto.Marca = dto.Marca;
            moto.UsuarioId = dto.UsuarioId;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var moto = _context.Motos.Find(id);
            if (moto == null) return NotFound();

            _context.Motos.Remove(moto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

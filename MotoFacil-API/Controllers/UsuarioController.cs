using Microsoft.AspNetCore.Mvc;
using MotoFacilAPI.Data;
using MotoFacilAPI.Dtos;
using MotoFacilAPI.Models;
using System;
using System.Linq;

namespace MotoFacilAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _context.Usuarios
                .Select(u => new UsuarioDto
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email
                }).ToList();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _context.Usuarios
                .Where(u => u.Id == id)
                .Select(u => new UsuarioDto
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email
                }).FirstOrDefault();

            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UsuarioDto dto)
        {
            var usuario = new Usuario { Nome = dto.Nome, Email = dto.Email };
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            dto.Id = usuario.Id;
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UsuarioDto dto)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return NotFound();

            usuario.Nome = dto.Nome;
            usuario.Email = dto.Email;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

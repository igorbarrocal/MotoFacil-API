using MotoFacil_API.Application.Dtos;
using MotoFacilAPI.Application.Dtos;
using MotoFacilAPI.Application.Interfaces;
using MotoFacilAPI.Domain.Entities;
using MotoFacilAPI.Domain.Repositories;
using MotoFacilAPI.Domain.ValueObjects;

namespace MotoFacilAPI.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<UsuarioDto>> ListAsync()
        {
            var usuarios = await _repo.ListAsync();
            return usuarios.Select(ToDto).ToList();
        }

        public async Task<List<UsuarioDto>> ListPagedAsync(int page, int pageSize)
        {
            var usuarios = await _repo.ListAsync();
            return usuarios
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(ToDto)
                .ToList();
        }

        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            var usuario = await _repo.GetByIdAsync(id);
            return usuario is null ? null : ToDto(usuario);
        }

        public async Task<UsuarioDto> CreateAsync(UsuarioDto dto)
        {
            var entity = new Usuario(dto.Nome, new Email(dto.Email));
            await _repo.AddAsync(entity);
            return ToDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, UsuarioDto dto)
        {
            var usuario = await _repo.GetByIdAsync(id);
            if (usuario is null) return false;
            usuario.AlterarNome(dto.Nome);
            usuario.AlterarEmail(new Email(dto.Email));
            await _repo.UpdateAsync(usuario);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            return true;
        }

        // Clean Code: método privado para conversão e HATEOAS
        private UsuarioDto ToDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email.Value,
                Links = GetLinks(usuario.Id)
            };
        }

        private List<LinkDto> GetLinks(int id) =>
            new List<LinkDto>
            {
                new LinkDto($"/api/usuarios/{id}", "self", "GET"),
                new LinkDto($"/api/usuarios/{id}", "update_usuario", "PUT"),
                new LinkDto($"/api/usuarios/{id}", "delete_usuario", "DELETE")
            };
    }
}
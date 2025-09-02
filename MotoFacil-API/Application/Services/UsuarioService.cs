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
        public UsuarioService(IUsuarioRepository repo) => _repo = repo;

        public async Task<List<UsuarioDto>> ListAsync()
        {
            var list = await _repo.ListAsync();
            return list.Select(u => new UsuarioDto { Id = u.Id, Nome = u.Nome, Email = u.Email.Value }).ToList();
        }

        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u is null) return null;
            return new UsuarioDto { Id = u.Id, Nome = u.Nome, Email = u.Email.Value };
        }

        public async Task<UsuarioDto> CreateAsync(UsuarioDto dto)
        {
            var entity = new Usuario(dto.Nome, new Email(dto.Email));
            await _repo.AddAsync(entity);
            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, UsuarioDto dto)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u is null) return false;
            u.AlterarNome(dto.Nome);
            u.AlterarEmail(new Email(dto.Email));
            await _repo.UpdateAsync(u);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            return true;
        }
    }
}
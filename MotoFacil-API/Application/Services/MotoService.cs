using MotoFacil_API.Application.Dtos;
using MotoFacilAPI.Application.Dtos;
using MotoFacilAPI.Application.Interfaces;
using MotoFacilAPI.Domain.Entities;
using MotoFacilAPI.Domain.Enums;
using MotoFacilAPI.Domain.Repositories;

namespace MotoFacilAPI.Application.Services
{
    public class MotoService : IMotoService
    {
        private readonly IMotoRepository _repo;
        public MotoService(IMotoRepository repo) => _repo = repo;

        public async Task<List<MotoDto>> ListAsync()
        {
            var list = await _repo.ListAsync();
            return list.Select(m => new MotoDto { Id = m.Id, Marca = m.Marca, Modelo = m.Modelo, UsuarioId = m.UsuarioId }).ToList();
        }

        public async Task<MotoDto?> GetByIdAsync(int id)
        {
            var m = await _repo.GetByIdAsync(id);
            if (m is null) return null;
            return new MotoDto { Id = m.Id, Marca = m.Marca, Modelo = m.Modelo, UsuarioId = m.UsuarioId };
        }

        public async Task<MotoDto> CreateAsync(MotoDto dto)
        {
            var entity = new Moto(dto.Modelo, dto.Marca, dto.UsuarioId);
            await _repo.AddAsync(entity);
            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, MotoDto dto)
        {
            var m = await _repo.GetByIdAsync(id);
            if (m is null) return false;
            m.AtualizarMarca(dto.Marca);
            // Modelo/UsuarioId update if needed
            await _repo.UpdateAsync(m);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            return true;
        }
    }
}